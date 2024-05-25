using AutoMapper;
using Cesla.Application.AppServices.Interfaces;
using Cesla.Application.Commands.ColaboradorCommand;
using Cesla.Application.Queries.Interfaces;
using Cesla.Application.ViewModels.ColaboradorViewModels;
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
    public class ColaboradoresAppService : IColaboradoresAppService
    {

        private readonly IColaboradoresQueries _colaboradoresQueries;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;

        public ColaboradoresAppService(IColaboradoresQueries colaboradoresQueries, IMediatorHandler mediatorHandler, IMapper mapper)
        {
            _colaboradoresQueries = colaboradoresQueries;
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
        }

        public async Task<bool> CadastrarColaborador(ColaboradorInsertViewModel colaboradorViewModel)
        {
            if (colaboradorViewModel.IsNull()) await this.LancarDomainNotification(_mediatorHandler, "ColaboradorVazio", false);

            var colaborador = _mapper.Map<Colaborador>(colaboradorViewModel);

            var command = new AdicionarColaboradorCommand(colaborador.Nome, colaborador.CargoId);
            if (!await _mediatorHandler.EnviarComando(command))
                return false;

            return true;
        }

        public async Task<bool> AtualizarColaborador(ColaboradorUpdateViewModel colaboradorViewModel)
        {
            if (colaboradorViewModel.IsNull()) await this.LancarDomainNotification(_mediatorHandler, "ColaboradorVazio", false);

            var colaborador = _mapper.Map<Colaborador>(colaboradorViewModel);

            var command = new AtualizarColaboradorCommand(colaborador.Id, colaborador.Nome, colaborador.CargoId);
            if (!await _mediatorHandler.EnviarComando(command))
                return false;
            
            return true;
        }

        public async Task<bool> DeletarColaborador(int id)
        {
            if (id <= 0) await this.LancarDomainNotification(_mediatorHandler, "ColaboradorIdVazio", false);

            var command = new DeletarColaboaradorCommand(id);
            if (!await _mediatorHandler.EnviarComando(command))
                return false;

            return true;
        }

        public async Task<List<ColaboradorQueryResultViewModel>> ListarColaboradores()
        {
            var lstColaboradores = await _colaboradoresQueries.ListarColaboradores();

            if (lstColaboradores.IsNull()) await _mediatorHandler.PublicarNotificacao(new DomainNotification("Colaboradores", "ListaColaboradoresVazia", false));

            return lstColaboradores;
        }
    }
}
