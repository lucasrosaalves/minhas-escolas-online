using MediatR;
using MEO.Application.DTOs;
using MEO.Application.Mappers;
using MEO.Common.Extensions;
using MEO.Domain.DomainObjects;
using MEO.Domain.Enums;
using MEO.Domain.Exceptions;
using MEO.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MEO.Application.Queries.Handlers
{
    public class ObterEscolasPaginadasQueryHandler : IRequestHandler<ObterEscolasPaginadasQuery, List<EscolaDTO>>
    {
        private readonly IEscolaRepository _escolaRepository;

        public ObterEscolasPaginadasQueryHandler(IEscolaRepository escolaRepository)
        {
            _escolaRepository = escolaRepository;
        }

        public async Task<List<EscolaDTO>> Handle(ObterEscolasPaginadasQuery request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                throw new DomainException("Request inválido");
            }

            var escolas = await _escolaRepository.ObterEscolasPaginadas(request.Pagina,
                request.TamanhoPagina, true);

            if (escolas.IsNullOrEmpty())
            {
                return new List<EscolaDTO>();
            }

            return escolas.Select(e =>
            {
                var contato = new ContatoDTO(e.Contato.Telefone, e.Contato.Email, e.Contato.Site);

                var tipoLocalizacao = new TipoLocalizacaoDTO(e.Endereco.TipoLocalizacaoId,
                    Enumeration.FromValue<TipoLocalizacao>(e.Endereco.TipoLocalizacaoId).Descricao);

                var endereco = new EnderecoDTO(e.Endereco.Logradouro,
                    e.Endereco.Numero,
                    e.Endereco.Complemento,
                    e.Endereco.Bairro,
                    e.Endereco.Cep,
                    tipoLocalizacao);

                return new EscolaDTO(e.Id,
                    e.Nome,
                    e.Codigo,
                    contato,
                    endereco,
                    e.Turmas.Count());

            }).ToList();
        }
    }
}
