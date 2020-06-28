using MEO.Domain.DomainObjects;
using MEO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MEO.Domain.Repositories
{
    public interface IEscolaRepository : IRepository<Escola>
    {
        Task<List<Escola>> ObterEscolasPaginadas(int pagina, int tamanhoPagina, bool incluirTurmas = false);
        Task<Escola> ObterEscolaPorIdAsync(Guid escolaId, bool incluirTurmas = false);
        Task<Escola> ObterEscolaPorCodigoAsync(string codigo, bool incluirTurmas = false);
        Task AdicionarAsync(Escola escola);
        Task AtualizarAsync(Escola escola);
        Task AdicionarAsync(Turma turma);
        Task AtualizarAsync(Turma turma);
    }
}
