using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public interface ICommandRepository<T> : IRepository<T> where T : Entity
    {
        Task Adicionar(T entity);
        Task Remover(T entity);
        Task Atualizar(T entity);
    }
}
