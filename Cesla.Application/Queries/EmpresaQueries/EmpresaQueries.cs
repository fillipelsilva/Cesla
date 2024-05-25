using AutoMapper;
using Cesla.Application.Queries.Interfaces;
using Cesla.Application.ViewModels.EmpresaVIewModels;
using Cesla.Data.Repositorios.Interfaces;
using Cesla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.Queries.EmpresaQueries
{
    public class EmpresaQueries : IEmpresaQueries
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;

        public EmpresaQueries(IEmpresaRepository empresaRepository, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }

        public async Task<List<EmpresaViewModel>> ListarEmpresas()
        {
            var lstEmpresas = await _empresaRepository.ObterTodos();

            var result = _mapper.Map<List<EmpresaViewModel>>(lstEmpresas.OrderBy(e => e.Nome));

            return result;
        }
    }

}
