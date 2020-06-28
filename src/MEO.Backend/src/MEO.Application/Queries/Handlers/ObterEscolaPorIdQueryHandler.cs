using MediatR;
using MEO.Application.DTOs;
using MEO.Domain.DomainObjects;
using MEO.Domain.Enums;
using MEO.Domain.Exceptions;
using MEO.Domain.Repositories;
using System.Linq;
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

            if (escola is null)
            {
                return null;
            }

            var contato = new ContatoDTO(escola.Contato.Telefone, escola.Contato.Email, escola.Contato.Site);

            var tipoLocalizacao = new TipoLocalizacaoDTO(escola.Endereco.TipoLocalizacaoId,
                Enumeration.FromValue<TipoLocalizacao>(escola.Endereco.TipoLocalizacaoId).Descricao);

            var endereco = new EnderecoDTO(escola.Endereco.Logradouro,
                escola.Endereco.Numero,
                escola.Endereco.Complemento,
                escola.Endereco.Bairro,
                escola.Endereco.Cep,
                tipoLocalizacao);

            var turmas = escola.Turmas?.Select(t =>
            {

                var tipoTurno = new TipoTurnoDTO(t.TipoTurnoId,
                    Enumeration.FromValue<TipoTurno>(t.TipoTurnoId).Descricao);

                return new TurmaDTO(t.Id, t.Codigo, tipoTurno, t.QuantidadeAlunos);
            });

            return new EscolaDTO(escola.Id,
                escola.Nome,
                escola.Codigo,
                contato,
                endereco,
                turmas);
        }
    }
}
