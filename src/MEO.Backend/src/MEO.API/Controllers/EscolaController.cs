using MediatR;
using MEO.Application.Commands;
using MEO.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MEO.API.Controllers
{
    public class EscolaController : BaseController
    {
        private readonly IMediator _mediator;

        public EscolaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("criarescola")]
        public async Task<IActionResult> CriarEscola([FromBody] CriarEscolaCommand command)
        {
            return CustomResponse(await _mediator.Send(command));
        }

        [HttpPost("obtertodasescolas")]
        public async Task<IActionResult> ObterTodasEscolas()
        {
            return CustomResponse(await _mediator.Send(new ObterTodasEscolasQuery()));
        }
    }
}
