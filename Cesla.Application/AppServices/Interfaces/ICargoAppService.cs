using Cesla.Application.ViewModels.CargoViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.AppServices.Interfaces
{
    public interface ICargoAppService
    {
        Task<List<CargoQueryResultViewModel>> ListarCargos();
        Task<bool> CadastrarCargo(CargoInsertViewModel cargoViewModel);
        Task<bool> AtualizarCargo(CargoUpdateViewModel cargoViewModel);
        Task<bool> DeletarCargo(int id);
    }
}
