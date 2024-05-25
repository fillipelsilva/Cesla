using Cesla.Application.ViewModels.DepartamentoViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.ViewModels.CargoViewModels
{
    public class CargoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public DepartamentoViewModel Departamento { get;set;}
    }
}
