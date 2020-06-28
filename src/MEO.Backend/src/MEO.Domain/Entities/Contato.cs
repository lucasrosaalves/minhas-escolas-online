using MEO.Domain.DomainObjects;
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
            Telefone = telefone;
            Email = email;
            Site = site;
        }
    }
}
