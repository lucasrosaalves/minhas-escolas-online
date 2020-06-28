using MediatR;
using System;

namespace MEO.Application.ApplicationObjects
{
    public abstract class Query<T> : IRequest<T>
    {
        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
