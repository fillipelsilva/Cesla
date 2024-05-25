using Cesla.API.Localizer;
using Cesla.Application.AppServices.Interfaces;
using Cesla.Application.ViewModels.ColaboradorViewModels;
using Core.Communication.MediatrHandler;
using Core.Messages.CommomMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Cesla.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradoresController : MainController<ColaboradoresController>
    {
        private readonly IColaboradoresAppService _colaboradoresAppService;
        public ColaboradoresController(IStringLocalizer<Resource> localizer,
                                      INotificationHandler<DomainNotification> notifications,
                                      IColaboradoresAppService colaboradoresAppService,
                                      IMediatorHandler mediator)
            : base(notifications, localizer, mediator)
        {
            _colaboradoresAppService = colaboradoresAppService;
        }

        [HttpGet("ListarColaboradores")]
        public async Task<IActionResult> ListarColaboradores()
        {
            var lstColaboradores = await _colaboradoresAppService.ListarColaboradores();

            return Response(lstColaboradores);
        }

        [HttpPost("CadastrarColaborador")]
        public async Task<IActionResult> CadastrarColaborador([FromBody] ColaboradorInsertViewModel colaboradorViewModel)
        {
            await _colaboradoresAppService.CadastrarColaborador(colaboradorViewModel);
            return Response(colaboradorViewModel);
        }

        [HttpPut("AtualizarColaborador")]
        public async Task<IActionResult> AtualizarColaborador([FromBody] ColaboradorUpdateViewModel colaboradorViewModel)
        {
            await _colaboradoresAppService.AtualizarColaborador(colaboradorViewModel);
            return Response(colaboradorViewModel);
        }

        [HttpDelete("DeletarColaborador/{id}")]
        public async Task<IActionResult> DeletarColaborador(int id)
        {
            await _colaboradoresAppService.DeletarColaborador(id);
            return Response(id);
        }
    }
}
