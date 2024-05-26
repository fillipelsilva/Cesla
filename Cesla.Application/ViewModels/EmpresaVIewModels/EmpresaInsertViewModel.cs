﻿using Cesla.Application.ViewModels.EnderecoViewModels;
using Cesla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.ViewModels.EmpresaVIewModels
{
    public class EmpresaInsertViewModel
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public EnderecoInsertViewModel Endereco { get; set; }
    }
}
