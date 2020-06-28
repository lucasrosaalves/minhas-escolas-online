using FluentValidation;
using MEO.Application.ApplicationObjects;
using MEO.Domain.DomainObjects;
using MEO.Domain.Enums;
using System;
using System.Linq;

namespace MEO.Application.Commands
{
    public class CriarTurmaCommand : Command
    {
        public string Codigo { get; set; }
        public int TipoTurnoId { get; set; }
        public int QuantidadeAlunos { get; set; }
        public Guid EscolaId { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CriarTurmaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class CriarTurmaCommandValidation : AbstractValidator<CriarTurmaCommand>
        {
            public CriarTurmaCommandValidation()
            {
                RuleFor(c => c.Codigo)
                    .NotEmpty()
                    .WithMessage("O código deve ser informado");

                var tiposTurnos = Enumeration.ObterTodos<TipoTurno>().Select(p => p.Id);

                RuleFor(c => c.TipoTurnoId)
                    .InclusiveBetween(tiposTurnos.Min(), tiposTurnos.Max())
                    .WithMessage("Tipo de turno inválido");


                RuleFor(c => c.QuantidadeAlunos)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("A quantidade de alunos não pode ser negativa");

                RuleFor(c => c.EscolaId)
                    .NotEmpty()
                    .WithMessage("A escola deve ser informada");
            }

        }
    }
}
