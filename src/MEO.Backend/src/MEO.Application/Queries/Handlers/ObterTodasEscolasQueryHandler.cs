using MediatR;
using MEO.Application.DTOs;
using MEO.Common.Extensions;
using MEO.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MEO.Application.Queries.Handlers
{
    public class ObterTodasEscolasQueryHandler : IRequestHandler<ObterTodasEscolasQuery, List<EscolaDTO>>
    {
        private readonly IEscolaRepository _escolaRepository;

        public ObterTodasEscolasQueryHandler(IEscolaRepository escolaRepository)
        {
            _escolaRepository = escolaRepository;
        }

        public async Task<List<EscolaDTO>> Handle(ObterTodasEscolasQuery request, CancellationToken cancellationToken)
        {
            var escolas = await _escolaRepository.ObterTodasAsync();

            if(escolas.IsNullOrEmpty())
            {
                return new List<EscolaDTO>();
            }

            return escolas.Select(e => new EscolaDTO()
            {
                Nome = e.Nome,
                Codigo = e.Codigo
            }).ToList();


        }
    }
}
