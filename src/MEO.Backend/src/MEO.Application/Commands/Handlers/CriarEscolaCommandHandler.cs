using FluentValidation.Results;
using MediatR;
using MEO.Application.ApplicationObjects;
using MEO.Domain.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MEO.Application.Commands.Handlers
{
    public class CriarEscolaCommandHandler : CommandHandler, IRequestHandler<CriarEscolaCommand, ValidationResult>
    {
        public Task<ValidationResult> Handle(CriarEscolaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid())
                {
                    return Task.FromResult(request.ValidationResult);

                }

                return Task.FromResult(new ValidationResult());
            }
            catch (DomainException ex)
            {
                AddErro(ex.Message);
                return Task.FromResult(ValidationResult);
            }
            catch (Exception)
            {
                AddErro("Ocorreu um erro inesperado no sistema");
                return Task.FromResult(ValidationResult);
            }

        }
    }
}
