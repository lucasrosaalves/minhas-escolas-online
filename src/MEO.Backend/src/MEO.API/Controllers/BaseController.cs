using FluentValidation.Results;
using MediatR;
using MEO.Application.ApplicationObjects;
using MEO.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEO.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected ICollection<string> Erros = new List<string>();

        private readonly IMediator _mediator;

        protected BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected Task<IActionResult> SendAsync<T>(T command) where T : Command
            => ExecuteAsync(command);

        protected Task<IActionResult> QueryAsync<T,TOut>(T query) where T : Query<TOut>
            => ExecuteAsync(query);

        private async Task<IActionResult> ExecuteAsync<T>(T @object)
        {
            try
            {
                var result = await _mediator.Send(@object);

                return CustomResponse(result);
            }
            catch
            {
                AdicionarErroProcessamento("Ocorreu um erro inesperado no sistema");

                return CustomResponse();
            }
        }

        private ActionResult CustomResponse(object result = null)
        {
            if(result is ValidationResult)
            {
                return CustomResponse(result as ValidationResult);
            }

            if (OperacaoValida())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Mensagens", Erros.ToArray() }
            }));
        }

        private ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                AdicionarErroProcessamento(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        private bool OperacaoValida()
        {
            return !Erros.Any();
        }

        private void AdicionarErroProcessamento(string erro)
        {
            Erros.Add(erro);
        }

        private void LimparErrosProcessamento()
        {
            Erros.Clear();
        }
    }
}
