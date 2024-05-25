﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.ViewModels.EnderecoViewModels
{
    public class EnderecoViewModel
    {
        public string Rua { get; set; }
        public int Numero { get; set; }
        public int Id { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Pais { get; set; }
    }
}
