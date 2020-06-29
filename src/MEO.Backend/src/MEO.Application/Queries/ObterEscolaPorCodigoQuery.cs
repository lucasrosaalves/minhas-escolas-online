using FluentValidation;
using MEO.Application.ApplicationObjects;
using MEO.Application.DTOs;

namespace MEO.Application.Queries
{
    public class ObterEscolaPorCodigoQuery : Query<EscolaDTO>
    {
        public string Codigo { get; set; }

        public override bool IsValid()
        {
            var validation = new ObterEscolaPorCodigoQueryValidation().Validate(this);
            return validation.IsValid;
        }

        public class ObterEscolaPorCodigoQueryValidation : AbstractValidator<ObterEscolaPorCodigoQuery>
        {
            public ObterEscolaPorCodigoQueryValidation()
            {
                RuleFor(c => c.Codigo)
                    .NotEmpty()
                    .WithMessage("Código inválido");
            }

        }
    }
}
