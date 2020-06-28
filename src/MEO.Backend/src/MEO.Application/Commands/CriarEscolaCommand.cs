using FluentValidation;
using MEO.Application.ApplicationObjects;

namespace MEO.Application.Commands
{
    public class CriarEscolaCommand : Command
    {
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public int TipoLocalizacaoId { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CriarEscolaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class CriarEscolaCommandValidation : AbstractValidator<CriarEscolaCommand>
        {
            public CriarEscolaCommandValidation()
            {
                RuleFor(c => c.Nome)
                    .NotEmpty()
                    .WithMessage("O nome deve ser informado");

                RuleFor(c => c.Codigo)
                    .NotEmpty()
                    .WithMessage("O código deve ser informado");

                RuleFor(c => c.Logradouro)
                    .NotEmpty()
                    .WithMessage("O logradouro deve ser informado");

                RuleFor(c => c.Bairro)
                    .NotEmpty()
                    .WithMessage("O bairro deve ser informado");

                RuleFor(c => c.Cep)
                    .NotEmpty()
                    .WithMessage("O cep deve ser informado");

                RuleFor(c => c.TipoLocalizacaoId)
                    .NotEqual(0)
                    .WithMessage("O tipo de localização deve ser informado");

                RuleFor(c => c.Telefone)
                    .NotEmpty()
                    .WithMessage("O telefone deve ser informado");

                RuleFor(c => c.Email)
                    .NotEmpty()
                    .WithMessage("O email deve ser informado");
            }

        }

    }
}
