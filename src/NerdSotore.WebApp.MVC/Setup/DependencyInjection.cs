
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
using NerdStore.Vendas.Application.Commands;
using NerdStore.Vendas.infraestrutura.Repository;

namespace NerdSotore.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(ref WebApplicationBuilder builber)
        {
            builber.Services.AddScoped<IMediatrHandler, MediatorHandler>();
            builber.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            builber.Services.AddScoped<IProdutoAppService, ProdutoAppService>();
            builber.Services.AddScoped<IEstoqueService, EstoqueService>();
            builber.Services.AddScoped<CatalogoContext>();
            builber.Services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();
            builber.Services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();
            builber.Services.AddScoped<IPedidoRepository, PedidoRepository>();
            
        }
    }
}
