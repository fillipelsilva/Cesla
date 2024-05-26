using Cesla.API.Localizer;
using Cesla.Application.AppServices.Interfaces;
using Cesla.Application.ViewModels.CargoViewModels;
using Cesla.Application.ViewModels.EmpresaVIewModels;
using Core.Communication.MediatrHandler;
using Core.Messages.CommomMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Cesla.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : MainController<CargoController>
    {
        private readonly ICargoAppService _cargoAppService;
        public CargoController(IStringLocalizer<Resource> localizer,
                                 INotificationHandler<DomainNotification> notifications,
                                 ICargoAppService cargoAppService,
                                 IMediatorHandler mediator)
            : base(notifications, localizer, mediator)
        {
            _cargoAppService = cargoAppService;
        }

        [HttpGet("ListarCargos")]
        public async Task<IActionResult> ListarCargos()
        {
            var lstCargos = await _cargoAppService.ListarCargos();

            return Response(lstCargos);
        }

        [HttpPost("CadastrarCargo")]
        public async Task<IActionResult> CadastrarCargo([FromBody] CargoInsertViewModel cargoViewModel)
        {
            await _cargoAppService.CadastrarCargo(cargoViewModel);
            return Response(cargoViewModel);
        }

        [HttpPut("AtualizarCargo")]
        public async Task<IActionResult> AtualizarCargo([FromBody] CargoUpdateViewModel cargoViewModel)
        {
            await _cargoAppService.AtualizarCargo(cargoViewModel);
            return Response(cargoViewModel);
        }

        [HttpDelete("DeletarCargo/{id}")]
        public async Task<IActionResult> DeletarCargo(int id)
        {
            await _cargoAppService.DeletarCargo(id);
            return Response(id);
        }
    }
}
