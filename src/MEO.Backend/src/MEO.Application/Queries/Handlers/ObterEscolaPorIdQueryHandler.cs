﻿using MediatR;
using MEO.Application.DTOs;
using MEO.Application.Mappers;
using MEO.Domain.Exceptions;
using MEO.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace MEO.Application.Queries.Handlers
{
    public class ObterEscolaPorIdQueryHandler : IRequestHandler<ObterEscolaPorIdQuery, EscolaDTO>
    {
        private readonly IEscolaRepository _escolaRepository;

        public ObterEscolaPorIdQueryHandler(IEscolaRepository escolaRepository)
        {
            _escolaRepository = escolaRepository;
        }

        public async Task<EscolaDTO> Handle(ObterEscolaPorIdQuery request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                throw new DomainException("Request inválido");
            }

            var escola = await _escolaRepository.ObterEscolaPorIdAsync(request.Id, true);


            return EscolaDTOMapper.Map(escola);
        }
    }
}
