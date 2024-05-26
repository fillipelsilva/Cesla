using Cesla.Application.ViewModels.CargoViewModels;
using Cesla.Application.ViewModels.DepartamentoViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.AppServices.Interfaces
{
    public interface IDepartamentoAppService
    {
        Task<List<DepartamentoQueryResultViewModel>> ListarDepartamentos();
        Task<bool> CadastrarDepartamento(DepartamentoInsertViewModel departamentoViewModel);
        Task<bool> AtualizarDepartamento(DepartamentoUpdateViewModel departamentoViewModel);
        Task<bool> DeletarDepartamento(int id);
    }

}
