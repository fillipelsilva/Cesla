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

namespace Cesla.Application.Commands.EmpresaCommand
{
    public class EmpresaCommandHandler : IRequestHandler<AdicionarEmpresaCommand, bool>,
                              IRequestHandler<AtualizarEmpresaCommand, bool>,
                              IRequestHandler<DeletarEmpresaCommand, bool>
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly ICargoRepository _cargoRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public EmpresaCommandHandler(IEmpresaRepository empresaRepository, IMediatorHandler mediatorHandler, ICargoRepository cargoRepository)
        {
            _empresaRepository = empresaRepository;
            _mediatorHandler = mediatorHandler;
            _cargoRepository = cargoRepository;
        }

        public async Task<bool> Handle(AdicionarEmpresaCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarComando(request)) return false;

            var empresa = new Empresa(0, request.Nome, request.Telefone);
            empresa.AdicionarEndereco(request.Endereco);

            await _empresaRepository.Adicionar(empresa);

            await _mediatorHandler.PublicarNotificacao(new DomainNotification("Empresas", "EmpresaAdicionadaSucesso", true));

            return await _empresaRepository.Commit();
        }

        public async Task<bool> Handle(AtualizarEmpresaCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarComando(request)) return false;

            var empresa = await _empresaRepository.ObterPorId(request.Id);
            if (empresa.IsNull()) return await _mediatorHandler.LancarDomainNotification(_mediatorHandler, "EmpresaNaoExiste", false);

            empresa.AtualizarEmpresa(request.Nome, request.Telefone);

            await _empresaRepository.Atualizar(empresa);

            await _mediatorHandler.PublicarNotificacao(new DomainNotification("Empresas", "EmpresaAtualizadaSucesso", true));

            return await _empresaRepository.Commit();
        }

        public async Task<bool> Handle(DeletarEmpresaCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarComando(request)) return false;

            var empresa = await _empresaRepository.ObterPorId(request.Id);
            if (empresa.IsNull()) return await _mediatorHandler.LancarDomainNotification(_mediatorHandler, "EmpresaNaoExiste", false);

            await _empresaRepository.Remover(empresa);

            await _mediatorHandler.PublicarNotificacao(new DomainNotification("Empresas", "EmpresaExcluidaSucesso", true));

            return await _empresaRepository.Commit();
        }

        private bool ValidarComando(Command message)
        {
            if (message.EhValido()) return true;

            foreach (var error in message.ValidationResult.Errors)
            {
                _mediatorHandler.PublicarNotificacao(new DomainNotification("Empresa", error.ErrorMessage, false));
            }

            return false;
        }
    }

}
