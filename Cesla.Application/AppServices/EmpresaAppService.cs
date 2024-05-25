using AutoMapper;
using Cesla.Application.AppServices.Interfaces;
using Cesla.Application.Commands.EmpresaCommand;
using Cesla.Application.Queries.Interfaces;
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
    public class EmpresaAppService : IEmpresaAppService
    {

        private readonly IEmpresaQueries _empresaQueries;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;

        public EmpresaAppService(IEmpresaQueries empresaQueries, IMediatorHandler mediatorHandler, IMapper mapper)
        {
            _empresaQueries = empresaQueries;
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
        }

        public async Task<bool> CadastrarEmpresa(EmpresaInsertViewModel empresaViewModel)
        {
            if (empresaViewModel.IsNull()) await this.LancarDomainNotification(_mediatorHandler, "EmpresaVazia", false);

            var empresa = _mapper.Map<Empresa>(empresaViewModel);

            var command = new AdicionarEmpresaCommand(empresa.Nome, empresa.Telefone, empresa.EnderecoId);
            if (!await _mediatorHandler.EnviarComando(command))
                return false;

            return true;
        }

        public async Task<bool> AtualizarEmpresa(EmpresaUpdateViewModel empresaViewModel)
        {
            if (empresaViewModel.IsNull()) await this.LancarDomainNotification(_mediatorHandler, "EmpresaVazia", false);

            var empresa = _mapper.Map<Empresa>(empresaViewModel);

            var command = new AtualizarEmpresaCommand(empresa.Id, empresa.Nome, empresa.Telefone, empresa.EnderecoId);
            if (!await _mediatorHandler.EnviarComando(command))
                return false;

            return true;
        }

        public async Task<bool> DeletarEmpresa(int id)
        {
            if (id <= 0) await this.LancarDomainNotification(_mediatorHandler, "EmpresaIdVazio", false);

            var command = new DeletarEmpresaCommand(id);
            if (!await _mediatorHandler.EnviarComando(command))
                return false;

            return true;
        }

        public async Task<List<EmpresaViewModel>> ListarEmpresas()
        {
            var lstEmpresas = await _empresaQueries.ListarEmpresas();

            if (lstEmpresas.IsNull()) await _mediatorHandler.PublicarNotificacao(new DomainNotification("Empresas", "ListaEmpresasVazia", false));

            return lstEmpresas;
        }
    }
}
