using MEO.Domain.DomainObjects;
using MEO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MEO.Domain.Repositories
{
    public interface IEscolaRepository : IRepository<Escola>
    {
        Task<List<Escola>> ObterTodasAsync();
        Task<Escola> ObterEscolaPorIdAsync(Guid escolaId, bool obterTurmas = false);
        Task<Escola> ObterEscolaPorCodigoAsync(string codigo, bool obterTurmas = false);
        Task AdicionarAsync(Escola escola);
        Task AtualizarAsync(Escola escola);
        Task AdicionarAsync(Turma turma);
        Task AtualizarAsync(Turma turma);
    }
}
