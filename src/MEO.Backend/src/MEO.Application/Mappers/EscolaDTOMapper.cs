using MEO.Application.DTOs;
using MEO.Domain.DomainObjects;
using MEO.Domain.Entities;
using MEO.Domain.Enums;
using System.Linq;

namespace MEO.Application.Mappers
{
    public class EscolaDTOMapper
    {
        public static EscolaDTO Map(Escola escola)
        {
            if(escola is null)
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
