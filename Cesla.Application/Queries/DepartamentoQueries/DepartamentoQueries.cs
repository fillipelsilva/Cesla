using AutoMapper;
using Cesla.Application.Queries.EmpresaQueries;
using Cesla.Application.Queries.Interfaces;
using Cesla.Application.ViewModels.CargoViewModels;
using Cesla.Application.ViewModels.DepartamentoViewModels;
using Cesla.Application.ViewModels.EmpresaVIewModels;
using Cesla.Data.Repositorios.Interfaces;
using Cesla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.Queries.DepartamentoQueries
{
    public class DepartamentoQueries : IDepartamentoQueries
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly IMapper _mapper;

        public DepartamentoQueries(IDepartamentoRepository departamentoRepository, IMapper mapper)
        {
            _departamentoRepository = departamentoRepository;
            _mapper = mapper;
        }

        public async Task<List<DepartamentoQueryResultViewModel>> ListarDepartamentos()
        {
            var lstDepartamentos = await _departamentoRepository.ObterTodos();

            var result = _mapper.Map<List<DepartamentoQueryResultViewModel>>(lstDepartamentos.OrderBy(e => e.Nome));

            return result;
        }
    }

}
