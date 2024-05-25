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

namespace Cesla.Application.Commands.ColaboradorCommand
{
    public class ColaboradorCommandHandler : IRequestHandler<AdicionarColaboradorCommand, bool>,
                                             IRequestHandler<AtualizarColaboradorCommand, bool>,
                                             IRequestHandler<DeletarColaboaradorCommand, bool>
    {
        private readonly IColaboradoresRepository _colaboradorRepository;
        private readonly ICargoRepository _cargoRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public ColaboradorCommandHandler(IColaboradoresRepository colaboradorRepository, IMediatorHandler mediatorHandler, ICargoRepository cargoRepository)
        {
            _colaboradorRepository = colaboradorRepository;
            _mediatorHandler = mediatorHandler;
            _cargoRepository = cargoRepository;
        }

        public async Task<bool> Handle(AdicionarColaboradorCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarComando(request)) return false;

            var cargo = await _cargoRepository.ObterPorId(request.CargoId);
            if (cargo.IsNull()) return await _mediatorHandler.LancarDomainNotification(_mediatorHandler, "CargoNaoExiste", false);

            var colaborador = new Colaborador(0, request.Nome, request.CargoId, request.Ativo);

            colaborador.AdicionarCargo(cargo);

            await _colaboradorRepository.Adicionar(colaborador);

            await _mediatorHandler.PublicarNotificacao(new DomainNotification("Colaboradores", "ColaboradorAdicionadoSucesso", true));

            return await _colaboradorRepository.Commit();
        }

        public async Task<bool> Handle(AtualizarColaboradorCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarComando(request)) return false;

            var colaborador = await _colaboradorRepository.ObterPorId(request.Id);
            if (colaborador.IsNull()) return await _mediatorHandler.LancarDomainNotification(_mediatorHandler, "ColaboradorNaoExiste", false);

            var cargo = await _cargoRepository.ObterPorId(request.CargoId);
            if (cargo.IsNull()) return await _mediatorHandler.LancarDomainNotification(_mediatorHandler, "CargoNaoExiste", false);

            colaborador.AtualizarColaborador(request.Nome);
            colaborador.CargoId = cargo.Id;

            await _colaboradorRepository.Atualizar(colaborador);

            await _mediatorHandler.PublicarNotificacao(new DomainNotification("Colaboradores", "ColaboradorAtualizadoSucesso", true));

            return await _colaboradorRepository.Commit();
        }

        public async Task<bool> Handle(DeletarColaboaradorCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarComando(request)) return false;

            var colaborador = await _colaboradorRepository.ObterPorId(request.Id);
            if (colaborador.IsNull()) return await _mediatorHandler.LancarDomainNotification(_mediatorHandler, "ColaboradorNaoExiste", false);

            colaborador.DeletarColaborador();

            await _colaboradorRepository.Atualizar(colaborador);

            await _mediatorHandler.PublicarNotificacao(new DomainNotification("Colaboradores", "ColaboradorExcluidoSucesso", true));

            return await _colaboradorRepository.Commit();
        }

        private bool ValidarComando(Command message)
        {
            if (message.EhValido()) return true;

            foreach (var error in message.ValidationResult.Errors)
            {
                _mediatorHandler.PublicarNotificacao(new DomainNotification("Colaborador", error.ErrorMessage, false));
            }

            return false;
        }
    }
}
