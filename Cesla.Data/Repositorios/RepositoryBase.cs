using Cesla.Data.Connection;
using Cesla.Data.Context;
using Cesla.Domain.Entities;
using Core.Data;
using Core.DomainObjects;
using Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Data.Repositorios
{
    public class RepositoryBase<T> : ICommandRepository<T>, IQueryRepository<T> where T : Entity
    {
        private readonly DbSet<T> _DbSet;
        private readonly CeslaContext _context;
        private readonly CeslaConnection _connection;

        public RepositoryBase(CeslaContext context, CeslaConnection connection)
        {
            _DbSet = context.Set<T>();
            _context = context;
            _connection = connection;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<T>> ObterPorEntidadeRelacionada(string entidade, string entidadeRelacionada, int entidadeRelacionadaId)
        {
            return await _connection.QueryAsync<T>(QueryExtensions.ConditionalQuery(entidade, entidadeRelacionada, entidadeRelacionadaId));
        }

        public async Task<T> ObterPorId(int id)
        {
            return (T)await _DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> ObterPorPredicado(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            var query = _DbSet.AsQueryable();

            if (includes != null)
            {
                foreach (var includeExpression in includes)
                {
                    query = query.Include(includeExpression);
                }
            }

            if (filter != null)
                query = query
                    .Where(filter)
                    .AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> ObterTodos()
        {
            return _context.Set<T>().ToList();
        }

        public async Task Adicionar(T entity)
        {

            await _DbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(T entity)
        {
            _DbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(T entity)
        {
            _DbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public Task<bool> Commit()
        {
            return this.UnitOfWork.Commit();
        }
    }
}
