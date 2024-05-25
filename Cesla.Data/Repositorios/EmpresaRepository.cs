using Cesla.Data.Connection;
using Cesla.Data.Context;
using Cesla.Data.Repositorios.Interfaces;
using Cesla.Domain.Entities;
using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Data.Repositorios
{
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(CeslaContext context, CeslaConnection connection) : base(context, connection)
        {            
        }
    }
}
