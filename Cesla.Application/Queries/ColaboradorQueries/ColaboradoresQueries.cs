using AutoMapper;
using Cesla.Application.Queries.Interfaces;
using Cesla.Application.ViewModels.ColaboradorViewModels;
using Cesla.Data.Repositorios.Interfaces;
using Cesla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.Queries.ColaboradorQueries
{
    public class EmpresaQueries : IColaboradoresQueries
    {
        private readonly IColaboradoresRepository _colaboradoresRepository;
        private readonly IMapper _mapper;

        public EmpresaQueries(IColaboradoresRepository colaboradoresRepository, IMapper mapper)
        {
            _colaboradoresRepository = colaboradoresRepository;
            _mapper = mapper;
        }

        public async Task<List<ColaboradorQueryResultViewModel>> ListarColaboradores()
        {
            var lstColaboradores = await _colaboradoresRepository.ObterPorPredicado(c => c.Ativo, c => c.Cargo, c => c.Cargo.Departamento);

            var result = _mapper.Map<List<ColaboradorQueryResultViewModel>>(lstColaboradores.OrderBy(c => c.Nome));

            return result;
        }
    }
}
