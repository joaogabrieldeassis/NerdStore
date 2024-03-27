using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Interfaces;
using NerdStore.Core.Messages.ComunMessages.Notifications;

namespace NerdSotore.WebApp.MVC.Controllers
{
    public class ControllerBase : Controller
    {
        protected Guid ClienteId = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatrHandler _mediatorHandler;

        

        protected ControllerBase(INotificationHandler<DomainNotification> notifications,
                                 IMediatrHandler mediatorHandler)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediatorHandler = mediatorHandler;
        }

        protected bool OperacaoValida()
        {
            return !_notifications.TemNotificacao();
        }

        protected IEnumerable<string> ObterMensagensErro()
        {
            return _notifications.ObterNotificacoes().Select(c => c.Value).ToList();
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediatorHandler.PublicarNotificacao(new DomainNotification(codigo, mensagem));
        }
    }
}
