﻿using FluentValidation;
using FluentValidation.Results;
using MEO.Application.ApplicationObjects;
using MEO.Domain.DomainObjects;
using MEO.Domain.Enums;
using System.Linq;

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
                    .WithMessage("O nome deve ser informado")
                    .MaximumLength(100)
                    .WithMessage("O nome deve possuir até 100 caracteres");

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


                var tiposLocalizacao = Enumeration.ObterTodos<TipoLocalizacao>().Select(p => p.Id);

                RuleFor(c => c.TipoLocalizacaoId)
                    .InclusiveBetween(tiposLocalizacao.Min(), tiposLocalizacao.Max())
                    .WithMessage("Tipo de localização inválido");


                RuleFor(c => c.Telefone)
                    .NotEmpty()
                    .WithMessage("O telefone deve ser informado");

                RuleFor(c => c.Email)
                    .NotEmpty()
                    .WithMessage("O email deve ser informado")
                    .EmailAddress()
                    .WithMessage("O email está inválido");

            }

        }

    }
}
