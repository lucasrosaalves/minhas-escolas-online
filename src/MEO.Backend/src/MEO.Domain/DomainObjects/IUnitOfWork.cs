using System;
using System.Threading.Tasks;

namespace MEO.Domain.DomainObjects
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
    }
}
