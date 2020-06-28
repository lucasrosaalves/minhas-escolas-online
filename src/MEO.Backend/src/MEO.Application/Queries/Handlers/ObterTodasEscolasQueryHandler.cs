using MediatR;
using MEO.Domain.Entities;
using MEO.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MEO.Application.Queries.Handlers
{
    public class ObterTodasEscolasQueryHandler : IRequestHandler<ObterTodasEscolasQuery, List<Escola>>
    {
        private readonly IEscolaRepository _escolaRepository;

        public ObterTodasEscolasQueryHandler(IEscolaRepository escolaRepository)
        {
            _escolaRepository = escolaRepository;
        }

        public Task<List<Escola>> Handle(ObterTodasEscolasQuery request, CancellationToken cancellationToken)
        {
            return _escolaRepository.ObterTodasAsync();
        }
    }
}
