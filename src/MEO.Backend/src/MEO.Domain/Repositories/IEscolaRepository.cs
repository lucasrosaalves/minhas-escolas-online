using MEO.Domain.DomainObjects;
using MEO.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MEO.Domain.Repositories
{
    public interface IEscolaRepository : IRepository<Escola>
    {
        Task<List<Escola>> ObterTodasAsync();
        void AdicionarAsync(Escola escola);
    }
}
