using MEO.Domain.DomainObjects;
using MEO.Domain.Entities;
using MEO.Domain.Repositories;
using MEO.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MEO.Infra.Repositories
{
    public class EscolaRepository : IEscolaRepository
    {
        private readonly DataContext _context;

        public EscolaRepository(DataContext context)
        {
            _context = context;
        }

        public Task<List<Escola>> ObterTodasAsync()
        {
            return _context.Escolas.ToListAsync();
        }

        public void AdicionarAsync(Escola escola)
        {
            _context.Escolas.Add(escola);
        }

        public IUnitOfWork UnitOfWork => _context;
    }
}
