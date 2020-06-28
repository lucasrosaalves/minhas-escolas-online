using FluentValidation;
using MEO.Application.ApplicationObjects;
using MEO.Application.DTOs;
using System;

namespace MEO.Application.Queries
{
    public class ObterEscolaPorIdQuery : Query<EscolaDTO>
    {
        public Guid Id { get; set; }

        public override bool IsValid()
        {
            var validation = new ObterEscolaPorIdQueryValidation().Validate(this);
            return validation.IsValid;
        }

        public class ObterEscolaPorIdQueryValidation : AbstractValidator<ObterEscolaPorIdQuery>
        {
            public ObterEscolaPorIdQueryValidation()
            {
                RuleFor(c => c.Id)
                    .NotEmpty()
                    .WithMessage("Id inválido");
            }

        }
    }
}
