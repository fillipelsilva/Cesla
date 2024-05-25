using Cesla.API.Localizer;
using Core.Communication.MediatrHandler;
using Core.Messages.CommomMessages.Notifications;
using Core.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using Serilog;

namespace Cesla.API.Controllers
{
    public abstract class MainController<TChildController> : ControllerBase where TChildController : MainController<TChildController>
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IStringLocalizer<Resource> _localizer;
        private readonly IMediatorHandler _mediatorHandler;
        protected MainController(INotificationHandler<DomainNotification> notifications,
                                 IStringLocalizer<Resource> localizer,
                                 IMediatorHandler mediatorHandler)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _localizer = localizer;
            _mediatorHandler = mediatorHandler;
        }

        protected bool OperacaoValida()
        {
            return !_notifications.TemNotificacao();
        }

        protected void NotificarErro(string codigo, string mensagem, bool success)
        {
            _mediatorHandler.PublicarNotificacao(new DomainNotification(codigo, mensagem, success));
        }

        protected new IActionResult Response(object result = null)
        {
            var messages = new List<string>();
            Log.Information($"----------------- BackEnd Domain Message -----------------");
            _notifications.ObterNotificacoes().ForEach(x =>
            {
                messages.Add(_localizer[x.Value].Value);
                Serilog.Log.Information($"Contexto: {this.GetType().Name} - Mensagem: {_localizer[x.Value]}");
            });
            Log.Information($"----------------- Fim BackEnd Domain Message -----------------");


            if (OperacaoValida())
            {
                Log.Information($"----------------- Success with Response {result} -----------------");
                return Ok(new OperationResult(true, messages.ToArray(), result));
            }

            Log.Error($"----------------- Error with Response {JsonConvert.SerializeObject(messages)} -----------------");
            return BadRequest(new OperationResult(false, messages));
        }
    }
}
