using System;
using FluentValidation.Results;
using MediatR;

namespace MEO.Application.ApplicationObjects
{
    public abstract class Command : IRequest<ValidationResult>
    {
        public ValidationResult ValidationResult { get; protected set; }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
