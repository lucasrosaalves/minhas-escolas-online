using MediatR;
using MEO.Application.DTOs;
using MEO.Application.Mappers;
using MEO.Domain.Exceptions;
using MEO.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace MEO.Application.Queries.Handlers
{
    public class ObterEscolaPorCodigoQueryHandler : IRequestHandler<ObterEscolaPorCodigoQuery, EscolaDTO>
    {
        private readonly IEscolaRepository _escolaRepository;

        public ObterEscolaPorCodigoQueryHandler(IEscolaRepository escolaRepository)
        {
            _escolaRepository = escolaRepository;
        }

        public async Task<EscolaDTO> Handle(ObterEscolaPorCodigoQuery request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                throw new DomainException("Request inválido");
            }

            var escola = await _escolaRepository.ObterEscolaPorCodigoAsync(request.Codigo, true);

            return EscolaDTOMapper.Map(escola);
        }
    }
}
