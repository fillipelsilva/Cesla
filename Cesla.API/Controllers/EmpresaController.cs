using Cesla.API.Localizer;
using Cesla.Application.AppServices.Interfaces;
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
    public class EmpresaController : MainController<EmpresaController>
    {
        private readonly IEmpresaAppService _empresaAppService;
        public EmpresaController(IStringLocalizer<Resource> localizer,
                                 INotificationHandler<DomainNotification> notifications,
                                 IEmpresaAppService empresaAppService,
                                 IMediatorHandler mediator)
            : base(notifications, localizer, mediator)
        {
            _empresaAppService = empresaAppService;
        }

        [HttpGet("ListarEmpresas")]
        public async Task<IActionResult> ListarEmpresas()
        {
            var lstEmpresas = await _empresaAppService.ListarEmpresas();

            return Response(lstEmpresas);
        }

        [HttpPost("CadastrarEmpresa")]
        public async Task<IActionResult> CadastrarEmpresa([FromBody] EmpresaInsertViewModel empresaViewModel)
        {
            await _empresaAppService.CadastrarEmpresa(empresaViewModel);
            return Response(empresaViewModel);
        }

        [HttpPut("AtualizarEmpresa")]
        public async Task<IActionResult> AtualizarEmpresa([FromBody] EmpresaUpdateViewModel empresaViewModel)
        {
            await _empresaAppService.AtualizarEmpresa(empresaViewModel);
            return Response(empresaViewModel);
        }

        [HttpDelete("DeletarEmpresa/{id}")]
        public async Task<IActionResult> DeletarEmpresa(int id)
        {
            await _empresaAppService.DeletarEmpresa(id);
            return Response(id);
        }
    }
}
