using MEO.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MEO.Domain.Entities
{
    public class Turma : Entity
    {
        public string Codigo { get; private set; }
        public int TipoTurnoId { get; private set; }
        public int QuantidadeAlunos { get; private set; }

        public Guid EscolaId { get; private set; }

        // EF Relation
        public Escola Escola { get; protected set; }
    }
}
