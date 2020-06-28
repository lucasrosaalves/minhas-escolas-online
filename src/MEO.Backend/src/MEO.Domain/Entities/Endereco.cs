using MEO.Domain.DomainObjects;
using MEO.Domain.Enums;
using MEO.Domain.Exceptions;
using System;
using System.Linq;

namespace MEO.Domain.Entities
{
    public class Endereco : Entity
    {
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cep { get; private set; }
        public int TipoLocalizacaoId { get; private set; }
        public Guid EscolaId { get; private set; }

        // EF Relation
        public Escola Escola { get; protected set; }

        public Endereco(string logradouro,
            string numero,
            string complemento,
            string bairro,
            string cep,
            int tipoLocalizacaoId)
        {
            if (string.IsNullOrWhiteSpace(logradouro))
            {
                throw new DomainException("O logradouro deve ser informado");
            }
            if (string.IsNullOrWhiteSpace(bairro))
            {
                throw new DomainException("O bairro deve ser informado");
            }
            if (string.IsNullOrWhiteSpace(cep))
            {
                throw new DomainException("O cep deve ser informado");
            }

            var tiposLocalizacao = Enumeration.ObterTodos<TipoLocalizacao>().Select(p => p.Id);

            if (!tiposLocalizacao.Contains(tipoLocalizacaoId))
            {
                throw new DomainException("Tipo de localização inválida");
            }

            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            TipoLocalizacaoId = tipoLocalizacaoId;
        }
    }
}
