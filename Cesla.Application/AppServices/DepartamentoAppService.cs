using AutoMapper;
using Cesla.Application.AppServices.Interfaces;
using Cesla.Application.Commands.CargoCommand;
using Cesla.Application.Commands.DepartamentoCommand;
using Cesla.Application.Commands.EmpresaCommand;
using Cesla.Application.Queries.Interfaces;
using Cesla.Application.ViewModels.CargoViewModels;
using Cesla.Application.ViewModels.DepartamentoViewModels;
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
    public class DepartamentoAppService : IDepartamentoAppService
    {
        private readonly IDepartamentoQueries _departamentoQueries;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;

        public DepartamentoAppService(IDepartamentoQueries departamentoQueries, IMediatorHandler mediatorHandler, IMapper mapper)
        {
            _departamentoQueries = departamentoQueries;
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
        }

        public async Task<bool> CadastrarDepartamento(DepartamentoInsertViewModel departamentoViewModel)
        {
            if (departamentoViewModel.IsNull()) await this.LancarDomainNotification(_mediatorHandler, "DepartamentoVazio", false);

            var departamento = _mapper.Map<Departamento>(departamentoViewModel);

            var command = new AdicionarDepartamentoCommand(departamento.Nome, departamento.EmpresaId);
            if (!await _mediatorHandler.EnviarComando(command))
                return false;

            return true;
        }

        public async Task<bool> AtualizarDepartamento(DepartamentoUpdateViewModel departamentoViewModel)
        {
            if (departamentoViewModel.IsNull()) await this.LancarDomainNotification(_mediatorHandler, "DepartamentoVazio", false);

            var departamento = _mapper.Map<Departamento>(departamentoViewModel);

            var command = new AtualizarDepartamentoCommand(departamento.Id, departamento.Nome, departamento.EmpresaId);
            if (!await _mediatorHandler.EnviarComando(command))
                return false;

            return true;
        }

        public async Task<bool> DeletarDepartamento(int id)
        {
            if (id <= 0) await this.LancarDomainNotification(_mediatorHandler, "DepartamentoIdVazio", false);

            var command = new DeletarDepartamentoCommand(id);
            if (!await _mediatorHandler.EnviarComando(command))
                return false;

            return true;
        }

        public async Task<List<DepartamentoQueryResultViewModel>> ListarDepartamentos()
        {
            var lstDepartamentos = await _departamentoQueries.ListarDepartamentos();

            if (lstDepartamentos.IsNull()) await _mediatorHandler.PublicarNotificacao(new DomainNotification("Departamentos", "ListaDepartamentosVazia", false));

            return lstDepartamentos;
        }
    }


}
