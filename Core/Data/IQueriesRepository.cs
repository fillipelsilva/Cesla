using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public interface IQueryRepository<T> : IRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> ObterPorEntidadeRelacionada(string entidade, string entidadeRelacionada, int entidadeRelacionadaId);
        Task<IEnumerable<T>> ObterTodos();
        Task<T> ObterPorId(int id);
        Task<IEnumerable<T>> ObterPorPredicado(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includes);
    }
}
