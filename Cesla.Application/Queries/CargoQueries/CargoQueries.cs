using AutoMapper;
using Cesla.Application.Queries.EmpresaQueries;
using Cesla.Application.Queries.Interfaces;
using Cesla.Application.ViewModels.CargoViewModels;
using Cesla.Application.ViewModels.EmpresaVIewModels;
using Cesla.Data.Repositorios.Interfaces;
using Cesla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.Queries.CargoQueries
{
    public class CargoQueries : ICargoQueries
    {
        private readonly ICargoRepository _cargoRepository;
        private readonly IMapper _mapper;

        public CargoQueries(ICargoRepository cargoRepository, IMapper mapper)
        {
            _cargoRepository = cargoRepository;
            _mapper = mapper;
        }

        public async Task<List<CargoQueryResultViewModel>> ListarCargos()
        {
            var lstCargos = await _cargoRepository.ObterPorPredicado(null, c => c.Departamento);

            var result = _mapper.Map<List<CargoQueryResultViewModel>>(lstCargos.OrderBy(e => e.Nome));

            return result;
        }
    }

}
