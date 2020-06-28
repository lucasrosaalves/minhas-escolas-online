using MEO.Domain.DomainObjects;
using MEO.Domain.Exceptions;
using System;

namespace MEO.Domain.Entities
{
    public class Contato : Entity
    {
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public string Site { get; private set; }

        public Guid EscolaId { get; private set; }

        // EF Relation
        public Escola Escola { get; protected set; }

        public Contato(string telefone, string email, string site)
        {
            if (string.IsNullOrWhiteSpace(telefone))
            {
                throw new DomainException("O telefone de contato deve ser informado");
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new DomainException("O email de contato deve ser informado");
            }

            Telefone = telefone;
            Email = email;
            Site = site;
        }
    }
}
