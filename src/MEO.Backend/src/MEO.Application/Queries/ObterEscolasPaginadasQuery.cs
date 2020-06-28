using FluentValidation;
using MEO.Application.ApplicationObjects;
using MEO.Application.DTOs;
using System.Collections.Generic;

namespace MEO.Application.Queries
{
    public class ObterEscolasPaginadasQuery : Query<List<EscolaDTO>>
    {
        public int Pagina { get; set; }
        public int TamanhoPagina { get; set; }


        public override bool IsValid()
        {
            var validation = new ObterEscolasPaginadasQueryValidation().Validate(this);
            return validation.IsValid;
        }

        public class ObterEscolasPaginadasQueryValidation : AbstractValidator<ObterEscolasPaginadasQuery>
        {
            public ObterEscolasPaginadasQueryValidation()
            {
                RuleFor(c => c.Pagina)
                    .GreaterThan(0)
                    .WithMessage("Página inválida");

                RuleFor(c => c.TamanhoPagina)
                    .GreaterThan(0)
                    .WithMessage("Tamanha da página inválido");
            }

        }
    }
}
