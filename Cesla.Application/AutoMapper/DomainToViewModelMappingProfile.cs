using AutoMapper;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cesla.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            //Colaborador
            CreateMap<Colaborador, ColaboradorInsertViewModel>();
            CreateMap<Colaborador, ColaboradorUpdateViewModel>();
            CreateMap<Colaborador, ColaboradorQueryResultViewModel>()
                .ForMember(c => c.Cargo, opt => opt.MapFrom(x => x.Cargo.Nome))
                .ForMember(c => c.Departamento, opt => opt.MapFrom(x => x.Cargo.Departamento.Nome));

            //Empresa
            //Colaborador
            CreateMap<Empresa, EmpresaInsertViewModel>();
            CreateMap<Empresa, EmpresaUpdateViewModel>();
            CreateMap<Empresa, EmpresaViewModel>();

            //Endereco
            CreateMap<Endereco, EnderecoViewModel>();

            //Departamento
            CreateMap<Departamento, DepartamentoViewModel>();

            //Cargo
            CreateMap<Cargo, CargoViewModel>();
        }
    }
}
