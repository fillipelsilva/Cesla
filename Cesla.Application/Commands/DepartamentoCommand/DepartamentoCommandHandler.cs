using Cesla.Data.Repositorios;
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

namespace Cesla.Application.Commands.DepartamentoCommand
{
    public class DepartamentoCommandHandler : IRequestHandler<AdicionarDepartamentoCommand, bool>,
                             IRequestHandler<AtualizarDepartamentoCommand, bool>,
                             IRequestHandler<DeletarDepartamentoCommand, bool>
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public DepartamentoCommandHandler(IDepartamentoRepository departamentoRepository, IMediatorHandler mediatorHandler, IEmpresaRepository empresaRepository)
        {
            _departamentoRepository = departamentoRepository;
            _mediatorHandler = mediatorHandler;
            _empresaRepository = empresaRepository;
        }

        public async Task<bool> Handle(AdicionarDepartamentoCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarComando(request)) return false;

            var empresa = await _empresaRepository.ObterPorId(request.EmpresaId);
            if (empresa.IsNull()) return await _mediatorHandler.LancarDomainNotification(_mediatorHandler, "EmpresaNaoExiste", false);

            var departamento = new Departamento(0, request.Nome);

            departamento.AdicionarEmpresa(empresa);

            await _departamentoRepository.Adicionar(departamento);

            await _mediatorHandler.PublicarNotificacao(new DomainNotification("Departamentos", "DepartamentoAdicionadoSucesso", true));

            return await _departamentoRepository.Commit();
        }

        public async Task<bool> Handle(AtualizarDepartamentoCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarComando(request)) return false;

            var departamento = await _departamentoRepository.ObterPorId(request.Id);
            if (departamento.IsNull()) return await _mediatorHandler.LancarDomainNotification(_mediatorHandler, "DepartamentoNaoExiste", false);

            var empresa = await _empresaRepository.ObterPorId(request.EmpresaId);
            if (empresa.IsNull()) return await _mediatorHandler.LancarDomainNotification(_mediatorHandler, "EmpresaNaoExiste", false);

            departamento.AtualizarEmpresa(request.Nome);
            departamento.EmpresaId = empresa.Id;

            await _departamentoRepository.Atualizar(departamento);

            await _mediatorHandler.PublicarNotificacao(new DomainNotification("Departamentos", "DepartamentoAtualizadoSucesso", true));

            return await _departamentoRepository.Commit();
        }

        public async Task<bool> Handle(DeletarDepartamentoCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarComando(request)) return false;

            var departamento = await _departamentoRepository.ObterPorId(request.Id);
            if (departamento.IsNull()) return await _mediatorHandler.LancarDomainNotification(_mediatorHandler, "DepartamentoNaoExiste", false);

            await _departamentoRepository.Remover(departamento);

            await _mediatorHandler.PublicarNotificacao(new DomainNotification("Departamentos", "DepartamentoExcluidoSucesso", true));

            return await _departamentoRepository.Commit();
        }

        private bool ValidarComando(Command message)
        {
            if (message.EhValido()) return true;

            foreach (var error in message.ValidationResult.Errors)
            {
                _mediatorHandler.PublicarNotificacao(new DomainNotification("Departamento", error.ErrorMessage, false));
            }

            return false;
        }
    }


}
