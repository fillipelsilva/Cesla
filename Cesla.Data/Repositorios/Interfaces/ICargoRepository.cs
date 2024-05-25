using Cesla.Domain.Entities;
using Core.Data;
using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Data.Repositorios.Interfaces
{
    public interface ICargoRepository : ICommandRepository<Cargo>, IQueryRepository<Cargo>
    {
    }
}
