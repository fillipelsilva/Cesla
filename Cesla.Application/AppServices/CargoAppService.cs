using AutoMapper;
using Cesla.Application.AppServices.Interfaces;
using Cesla.Application.Commands.CargoCommand;
using Cesla.Application.Commands.EmpresaCommand;
using Cesla.Application.Queries.Interfaces;
using Cesla.Application.ViewModels.CargoViewModels;
using Cesla.Application.ViewModels.EmpresaVIewModels;
using Cesla.Domain.Entities;
using Core.Communication.MediatrHandler;
using Core.Extensions;
using Core.Messages.CommomMessages.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.AppServices
{
    public class CargoAppService : ICargoAppService
    {
        private readonly ICargoQueries _cargoQueries;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;

        public CargoAppService(ICargoQueries cargoQueries, IMediatorHandler mediatorHandler, IMapper mapper)
        {
            _cargoQueries = cargoQueries;
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
        }

        public async Task<bool> CadastrarCargo(CargoInsertViewModel cargoViewModel)
        {
            if (cargoViewModel.IsNull())
            {
                await this.LancarDomainNotification(_mediatorHandler, "CargoVazio", false);
                return false;
            }

            var cargo = _mapper.Map<Cargo>(cargoViewModel);

            var command = new AdicionarCargoCommand(cargo.Nome, cargo.Salario, cargo.DepartamentoId);
            if (!await _mediatorHandler.EnviarComando(command))
                return false;

            return true;
        }

        public async Task<bool> AtualizarCargo(CargoUpdateViewModel cargoViewModel)
        {
            if (cargoViewModel.IsNull())
            {
                await this.LancarDomainNotification(_mediatorHandler, "CargoVazio", false);
                return false;
            }

            var cargo = _mapper.Map<Cargo>(cargoViewModel);

            var command = new AtualizarCargoCommand(cargo.Id, cargo.Nome, cargo.Salario, cargo.DepartamentoId);
            if (!await _mediatorHandler.EnviarComando(command))
                return false;

            return true;
        }

        public async Task<bool> DeletarCargo(int id)
        {
            if (id <= 0)
            {
                await this.LancarDomainNotification(_mediatorHandler, "CargoIdVazio", false);
                return false; 
            }

            var command = new DeletarCargoCommand(id);
            if (!await _mediatorHandler.EnviarComando(command))
                return false;

            return true;
        }

        public async Task<List<CargoQueryResultViewModel>> ListarCargos()
        {
            var lstCargos = await _cargoQueries.ListarCargos();

            if (lstCargos.IsNull()) await _mediatorHandler.PublicarNotificacao(new DomainNotification("Cargos", "ListaCargosVazia", false));

            return lstCargos;
        }
    }

}
