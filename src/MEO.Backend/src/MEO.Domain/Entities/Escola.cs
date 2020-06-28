using MEO.Domain.DomainObjects;
using MEO.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MEO.Domain.Entities
{
    public class Escola : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Codigo { get; private set; }
        public Endereco Endereco { get; private set; }
        public Contato Contato { get; private set; }

        private List<Turma> _turmas;
        public IReadOnlyCollection<Turma> Turmas => _turmas ?? new List<Turma>();

        // EF Constructor
        protected Escola() { }

        public Escola(string nome,
            string codigo,
            Endereco endereco,
            Contato contato)
        {
            Nome = nome;
            Codigo = codigo;
            Endereco = endereco;
            Contato = contato;
        }

        public void AdicionarTurma(Turma turma)
        {
            if (turma is null)
            {
                throw new DomainException("A turma informada é inválida");
            }

            if (_turmas is null)
            {
                _turmas = new List<Turma>();
            }

            _turmas.Add(turma);
        }

    }
}
