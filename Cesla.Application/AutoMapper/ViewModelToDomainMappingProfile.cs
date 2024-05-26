﻿using AutoMapper;
using Cesla.Application.ViewModels.CargoViewModels;
using Cesla.Application.ViewModels.ColaboradorViewModels;
using Cesla.Application.ViewModels.DepartamentoViewModels;
using Cesla.Application.ViewModels.EmpresaVIewModels;
using Cesla.Application.ViewModels.EnderecoViewModels;
using Cesla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //Colaborador
            CreateMap<ColaboradorInsertViewModel, Colaborador>();
            CreateMap<ColaboradorUpdateViewModel, Colaborador>();
            CreateMap<ColaboradorQueryResultViewModel, Colaborador>();

            //Empresa
            CreateMap<EmpresaInsertViewModel, Empresa>();
            CreateMap<EmpresaUpdateViewModel, Empresa>();
            CreateMap<EmpresaQueryResultViewModel, Empresa>();

            //Endereco
            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<EnderecoInsertViewModel, Endereco>();
            CreateMap<EnderecoUpdateViewModel, Endereco>();

            //Departamento
            CreateMap<DepartamentoQueryResultViewModel, Departamento>();
            CreateMap<DepartamentoInsertViewModel, Departamento>();
            CreateMap<DepartamentoUpdateViewModel, Departamento>();

            //Cargo
            CreateMap<CargoQueryResultViewModel, Cargo>();
            CreateMap<CargoInsertViewModel, Cargo>();
            CreateMap<CargoUpdateViewModel, Cargo>();
        }
    }
}
