using Cesla.Application.ViewModels.ColaboradorViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.Queries.Interfaces
{
    public interface IColaboradoresQueries
    {
        Task<List<ColaboradorQueryResultViewModel>> ListarColaboradores();
    }
}
