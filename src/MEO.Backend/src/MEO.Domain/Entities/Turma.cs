using MEO.Domain.DomainObjects;
using MEO.Domain.Enums;
using MEO.Domain.Exceptions;
using System;
using System.Linq;

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

        protected Turma() { }

        public Turma(string codigo, int tipoTurnoId, int quantidadeAlunos, Guid escolaId)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                throw new DomainException("Código inválido");
            }

            if (escolaId == Guid.Empty)
            {
                throw new DomainException("Escola inválida");
            }

            var tiposTurnos = Enumeration.ObterTodos<TipoTurno>().Select(p => p.Id);

            if (!tiposTurnos.Contains(tipoTurnoId))
            {
                throw new DomainException("Tipo de turno inválido");
            }

            Codigo = codigo;
            TipoTurnoId = tipoTurnoId;
            QuantidadeAlunos = quantidadeAlunos;
            EscolaId = escolaId;
        }
    }
}
