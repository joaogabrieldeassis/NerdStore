
using MediatR;
using NerdSotre.Vendas.Domain.Interfaces.Repository;
using NerdStore.Catalogo.Application.interfaces;
using NerdStore.Catalogo.Application.Services;
using NerdStore.Catalogo.Data.Context;
using NerdStore.Catalogo.Data.Repository;
using NerdStore.Catalogo.Domain.Events;
using NerdStore.Catalogo.Domain.Interfaces.Repository;
using NerdStore.Catalogo.Domain.Interfaces.Service;
using NerdStore.Catalogo.Domain.ServiceDomain;
using NerdStore.Core.Events;
using NerdStore.Core.Interfaces;
using NerdStore.Core.Messages.ComunMessages.Notifications;
using NerdStore.Pagamentos.AntiCorruption;
using NerdStore.Pagamentos.Business;
using NerdStore.Pagamentos.Data;
using NerdStore.Pagamentos.Data.Repository;
using NerdStore.Vendas.Application.Commands;
using NerdStore.Vendas.Application.Events;
using NerdStore.Vendas.Application.Queries;
using NerdStore.Vendas.Application.Queries.Interfaces;
using NerdStore.Vendas.infraestrutura.Repository;

namespace NerdSotore.WebApp.MVC.Configurations
{
    public static class DependencyInjection
    {
        public static void RegisterServices(ref WebApplicationBuilder builber)
        {
            builber.Services.AddScoped<IMediatrHandler, MediatorHandler>();

            builber.Services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            builber.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            builber.Services.AddScoped<IProdutoAppService, ProdutoAppService>();
            builber.Services.AddScoped<IEstoqueService, EstoqueService>();
            builber.Services.AddScoped<CatalogoContext>();
            
            builber.Services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();
            builber.Services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();
            builber.Services.AddScoped<IRequestHandler<AtualizarItemPedidoCommand, bool>, PedidoCommandHandler>();
            builber.Services.AddScoped<IRequestHandler<RemoveItemPedidoCommand, bool>, PedidoCommandHandler>();
            builber.Services.AddScoped<IRequestHandler<ApplicarVoucherPedidoCommand, bool>, PedidoCommandHandler>();
            
            builber.Services.AddScoped<IPedidoRepository, PedidoRepository>();
            builber.Services.AddScoped<IPedidoQueries, PedidoQueries>();

            builber.Services.AddScoped<INotificationHandler<PedidoRascunhoIniciadoEvent>, PedidoEventHandler>();
            builber.Services.AddScoped<INotificationHandler<PedidoAtualizadoEvent>, PedidoEventHandler>();
            builber.Services.AddScoped<INotificationHandler<PedidoItemAdicionadoEvent>, PedidoEventHandler>();

            builber.Services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            builber.Services.AddScoped<IPagamentoService, PagamentoService>();
            builber.Services.AddScoped<IPagamentoCartaoCreditoFacade, PagamentoCartaoCreditoFacade>();
            builber.Services.AddScoped<IPayPalGateway, PayPalGateway>();
            builber.Services.AddScoped<IConfigurationManager2, ConfigurationManager2>();
            builber.Services.AddScoped<PagamentoContext>();

        }
    }
}
