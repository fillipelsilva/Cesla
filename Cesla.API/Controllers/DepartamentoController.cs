using Cesla.API.Localizer;
using Cesla.Application.AppServices.Interfaces;
using Cesla.Application.ViewModels.CargoViewModels;
using Cesla.Application.ViewModels.DepartamentoViewModels;
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
    public class DepartamentoController : MainController<DepartamentoController>
    {
        private readonly IDepartamentoAppService _departamentoAppService;
        public DepartamentoController(IStringLocalizer<Resource> localizer,
                                 INotificationHandler<DomainNotification> notifications,
                                 IDepartamentoAppService departamentoAppService,
                                 IMediatorHandler mediator)
            : base(notifications, localizer, mediator)
        {
            _departamentoAppService = departamentoAppService;
        }

        [HttpGet("ListarDepartamentos")]
        public async Task<IActionResult> ListarDepartamentos()
        {
            var lstDepartamentos = await _departamentoAppService.ListarDepartamentos();

            return Response(lstDepartamentos);
        }

        [HttpPost("CadastrarDepartamento")]
        public async Task<IActionResult> CadastrarDepartamento([FromBody] DepartamentoInsertViewModel departamentoViewModel)
        {
            await _departamentoAppService.CadastrarDepartamento(departamentoViewModel);
            return Response(departamentoViewModel);
        }

        [HttpPut("AtualizarDepartamento")]
        public async Task<IActionResult> AtualizarDepartamento([FromBody] DepartamentoUpdateViewModel departamentoViewModel)
        {
            await _departamentoAppService.AtualizarDepartamento(departamentoViewModel);
            return Response(departamentoViewModel);
        }

        [HttpDelete("DeletarDepartamento/{id}")]
        public async Task<IActionResult> DeletarDepartamento(int id)
        {
            await _departamentoAppService.DeletarDepartamento(id);
            return Response(id);
        }
    }

}
