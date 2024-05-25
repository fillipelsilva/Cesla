using Cesla.Application.ViewModels.ColaboradorViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.AppServices.Interfaces
{
    public interface IColaboradoresAppService
    {
        Task<List<ColaboradorQueryResultViewModel>> ListarColaboradores();
        Task<bool> CadastrarColaborador(ColaboradorInsertViewModel colaboradorViewModel);
        Task<bool> AtualizarColaborador(ColaboradorUpdateViewModel colaboradorViewModel);
        Task<bool> DeletarColaborador(int id);
    }
}
