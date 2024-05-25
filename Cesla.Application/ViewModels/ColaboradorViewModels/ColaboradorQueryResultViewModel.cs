using Cesla.Application.ViewModels.CargoViewModels;
using Cesla.Application.ViewModels.DepartamentoViewModels;
using Cesla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.ViewModels.ColaboradorViewModels
{
    public class ColaboradorQueryResultViewModel
    {
        public int Id { get; set; } 
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }
    }
}
