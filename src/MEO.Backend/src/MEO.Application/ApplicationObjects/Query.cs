using MediatR;

namespace MEO.Application.ApplicationObjects
{
    public abstract class Query<T> : IRequest<T>
    {
    }
}
