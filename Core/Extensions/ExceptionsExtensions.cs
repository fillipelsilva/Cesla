using Core.Communication.MediatrHandler;
using Core.Messages.CommomMessages.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ExceptionsExtensions
    {
        public static async Task<bool> LancarDomainNotification<T>(this T @this, IMediatorHandler handler, string Erro, bool success) where T : class
        {
            await handler.PublicarNotificacao(new DomainNotification(nameof(T), Erro, success));
            return success;
        }
    }
}
