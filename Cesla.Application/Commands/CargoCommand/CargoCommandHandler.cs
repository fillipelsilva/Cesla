using Cesla.Data.Repositorios.Interfaces;
using Cesla.Domain.Entities;
using Core.Communication.MediatrHandler;
using Core.Extensions;
using Core.Messages;
using Core.Messages.CommomMessages.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.Commands.CargoCommand
{
    public class CargoCommandHandler : IRequestHandler<AdicionarCargoCommand, bool>,
                          IRequestHandler<AtualizarCargoCommand, bool>,
                          IRequestHandler<DeletarCargoCommand, bool>
    {
        private readonly ICargoRepository _cargoRepository;
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public CargoCommandHandler(ICargoRepository cargoRepository, IMediatorHandler mediatorHandler, IDepartamentoRepository departamentoRepository)
        {
            _cargoRepository = cargoRepository;
            _mediatorHandler = mediatorHandler;
            _departamentoRepository = departamentoRepository;
        }

        public async Task<bool> Handle(AdicionarCargoCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarComando(request)) return false;

            var departamento = await _departamentoRepository.ObterPorId(request.DepartamentoId);
            if (departamento.IsNull()) return await _mediatorHandler.LancarDomainNotification(_mediatorHandler, "DepartamentoNaoExiste", false);

            var cargo = new Cargo(0, request.Nome, request.Salario);

            cargo.AdicionarDepartamento(departamento);

            await _cargoRepository.Adicionar(cargo);

            await _mediatorHandler.PublicarNotificacao(new DomainNotification("Cargos", "CargoAdicionadoSucesso", true));

            return await _cargoRepository.Commit();
        }

        public async Task<bool> Handle(AtualizarCargoCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarComando(request)) return false;

            var cargo = await _cargoRepository.ObterPorId(request.Id);
            if (cargo.IsNull()) return await _mediatorHandler.LancarDomainNotification(_mediatorHandler, "CargoNaoExiste", false);

            var departamento = await _departamentoRepository.ObterPorId(request.DepartamentoId);
            if (departamento.IsNull()) return await _mediatorHandler.LancarDomainNotification(_mediatorHandler, "DepartamentoNaoExiste", false);

            cargo.AtualizarCargo(request.Nome, request.Salario);
            cargo.DepartamentoId = departamento.Id;

            await _cargoRepository.Atualizar(cargo);

            await _mediatorHandler.PublicarNotificacao(new DomainNotification("Cargos", "CargoAtualizadoSucesso", true));

            return await _cargoRepository.Commit();
        }

        public async Task<bool> Handle(DeletarCargoCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarComando(request)) return false;

            var cargo = await _cargoRepository.ObterPorId(request.Id);
            if (cargo.IsNull()) return await _mediatorHandler.LancarDomainNotification(_mediatorHandler, "CargoNaoExiste", false);

            await _cargoRepository.Remover(cargo);

            await _mediatorHandler.PublicarNotificacao(new DomainNotification("Cargos", "CargoExcluidoSucesso", true));

            return await _cargoRepository.Commit();
        }

        private bool ValidarComando(Command message)
        {
            if (message.EhValido()) return true;

            foreach (var error in message.ValidationResult.Errors)
            {
                _mediatorHandler.PublicarNotificacao(new DomainNotification("Cargo", error.ErrorMessage, false));
            }

            return false;
        }
    }


}
