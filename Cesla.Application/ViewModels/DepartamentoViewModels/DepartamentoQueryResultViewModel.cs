using Cesla.Application.ViewModels.EmpresaVIewModels;
using Cesla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.ViewModels.DepartamentoViewModels
{
    public class DepartamentoQueryResultViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Empresa { get; set; }
    }
}
