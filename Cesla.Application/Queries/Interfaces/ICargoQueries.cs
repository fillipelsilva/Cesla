using Cesla.Application.ViewModels.CargoViewModels;
using Cesla.Application.ViewModels.EmpresaVIewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.Queries.Interfaces
{
    public interface ICargoQueries
    {
        Task<List<CargoQueryResultViewModel>> ListarCargos();
    }
}
