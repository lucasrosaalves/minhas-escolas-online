using MEO.Domain.DomainObjects;
using System;

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
            string cep)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
        }
    }
}
