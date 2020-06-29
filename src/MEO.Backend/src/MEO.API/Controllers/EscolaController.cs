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
        {
            return QueryAsync<ObterEscolasPaginadasQuery, List<EscolaDTO>>(query);
        }

        [HttpGet("obterescolaporid")]
        public Task<IActionResult> ObterEscolaPorId([FromQuery] ObterEscolaPorIdQuery query)
        { 
            return QueryAsync<ObterEscolaPorIdQuery, EscolaDTO>(query); 
        }

        [HttpGet("obterescolaporcodigo")]
        public Task<IActionResult> ObterEscolaPorId([FromQuery] ObterEscolaPorCodigoQuery query)
        {           
            return QueryAsync<ObterEscolaPorCodigoQuery, EscolaDTO>(query);

        }
        #endregion

        #region Escrita

        [HttpPost("criarescola")]
        public Task<IActionResult> CriarEscola([FromBody] CriarEscolaCommand command)
        {
            return SendAsync(command);
        }
            
        [HttpPost("criarturma")]
        public Task<IActionResult> CriarTurma([FromBody] CriarTurmaCommand command)
        {
            return SendAsync(command);
        }


        #endregion


    }
}
