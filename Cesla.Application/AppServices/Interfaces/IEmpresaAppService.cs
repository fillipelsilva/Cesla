using Cesla.Application.ViewModels.EmpresaVIewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.AppServices.Interfaces
{
    public interface IEmpresaAppService
    {
        Task<List<EmpresaViewModel>> ListarEmpresas();
        Task<bool> CadastrarEmpresa(EmpresaInsertViewModel empresaViewModel);
        Task<bool> AtualizarEmpresa(EmpresaUpdateViewModel empresaViewModel);
        Task<bool> DeletarEmpresa(int id);
    }
}
