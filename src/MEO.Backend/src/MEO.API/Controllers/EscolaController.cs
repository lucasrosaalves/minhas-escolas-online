using MediatR;
using MEO.Application.Commands;
using MEO.Application.DTOs;
using MEO.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MEO.API.Controllers
{
    public class EscolaController : BaseController
    {
        public EscolaController(IMediator mediator)
            : base(mediator)
        {
        }

        #region Leitura

        [HttpGet("obterescolaspaginadas")]
        public Task<IActionResult> ObterEscolasPaginadas([FromQuery] ObterEscolasPaginadasQuery query)
            => QueryAsync<ObterEscolasPaginadasQuery, List<EscolaDTO>>(query);

        [HttpGet("obterescolaporid")]
        public Task<IActionResult> ObterEscolaPorId([FromQuery] ObterEscolaPorIdQuery query)
            => QueryAsync<ObterEscolaPorIdQuery, EscolaDTO>(query);

        #endregion

        #region Escrita

        [HttpPost("criarescola")]
        public Task<IActionResult> CriarEscola([FromBody] CriarEscolaCommand command)
            => SendAsync(command);

        [HttpPost("criarturma")]
        public Task<IActionResult> CriarTurma([FromBody] CriarTurmaCommand command)
            => SendAsync(command);

        #endregion


    }
}
    