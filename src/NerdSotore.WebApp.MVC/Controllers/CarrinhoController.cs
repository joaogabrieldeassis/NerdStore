using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalogo.Application.interfaces;
using NerdStore.Core.Interfaces;
using NerdStore.Core.Messages.ComunMessages.Notifications;
using NerdStore.Vendas.Application.Commands;

namespace NerdSotore.WebApp.MVC.Controllers
{
    public class CarrinhoController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly IMediatrHandler _mediator;

        public CarrinhoController(INotificationHandler<DomainNotification> notifications, IMediatrHandler mediatrHandler, IProdutoAppService produtoAppService, IMediatrHandler mediator)
            : base(notifications, mediatrHandler)
        {
            _produtoAppService = produtoAppService;
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("meu-carrinho")]
        public async Task<IActionResult> AdicionarItem(Guid id, int quantidade)
        {
            var produto = await _produtoAppService.ObterPorId(id);
            if (produto == null) return NotFound("Produto não encontrado");

            if (produto.QuantidadeEstoque < quantidade)
            {
                TempData["Erro"] = "Produto com estoque insuficiente";
                return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
            }
            var command = new AdicionarItemPedidoCommand(ClienteId, produto.Id, produto.Nome, quantidade, produto.Valor);
            await _mediator.EnviarComando(command);

            if (OperacaoValida())
            {
                return RedirectToAction("Index");
            }
               

            TempData["Erros"] = ObterMensagensErro();
            return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
        }
    }
}
