using MEO.Domain.DomainObjects;
using MEO.Domain.Entities;
using MEO.Domain.Repositories;
using MEO.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IUnitOfWork UnitOfWork => _context;

        #region Leitura

        public Task<List<Escola>> ObterEscolasPaginadas(int pagina, int tamanhoPagina, bool incluirTurmas = false)
        {
            return ObterQueryableEscola(incluirTurmas)
                .OrderBy(e => e.Nome)
                .Skip((pagina - 1) * tamanhoPagina).Take(tamanhoPagina)
                .ToListAsync();
        }

        public Task<Escola> ObterEscolaPorIdAsync(Guid escolaId, bool incluirTurmas = false)
            => ObterQueryableEscola(incluirTurmas).FirstOrDefaultAsync(e => e.Id == escolaId);

        public Task<Escola> ObterEscolaPorCodigoAsync(string codigo, bool incluirTurmas = false)
            => ObterQueryableEscola(incluirTurmas).FirstOrDefaultAsync(e => e.Codigo == codigo);

        private IQueryable<Escola> ObterQueryableEscola(bool incluirTurmas)
        {

            if (incluirTurmas)
            {
               return _context.Escolas
                    .AsQueryable()
                    .Include(p => p.Endereco)
                    .Include(p => p.Contato)
                    .Include(p => p.Turmas);
            }

            return _context.Escolas
                .AsQueryable()
                .Include(p => p.Endereco)
                .Include(p => p.Contato);
        }

        #endregion

        #region Escrita

        public Task AdicionarAsync(Escola escola)
        {
            _context.Escolas.Add(escola);

            return Task.CompletedTask;
        }

        public Task AtualizarAsync(Escola escola)
        {
            _context.Entry(escola).State = EntityState.Modified;
            _context.Escolas.Update(escola);

            return Task.CompletedTask;
        }

        public Task AdicionarAsync(Turma turma)
        {
            _context.Turmas.Add(turma);

            return Task.CompletedTask;
        }

        public Task AtualizarAsync(Turma turma)
        {
            _context.Entry(turma).State = EntityState.Modified;
            _context.Turmas.Update(turma);

            return Task.CompletedTask;
        }

        #endregion

    }
}
