using Microsoft.Extensions.DependencyInjection;
using Solid.Repository;
using Solid.Repository.Fornecedor;
using Solid.Repository.Mock;
using Solid.Services.Fornecedor;
using System;
using System.Collections.Generic;


namespace Solid.Services
{
    public class DependendyInjection : ServiceCollection, IDependendyInjection
    {
        public IServiceProvider ConfigureServices()
        {
            this
                .AddScoped<IProdutoService, ProdutoService>()
                .AddScoped<IFornecedorRepository, FornecedorRepository>()
                .AddScoped<IContext, ContextMock>();

            return this.BuildServiceProvider();
        }
    }

    public interface IDependendyInjection : IServiceCollection
    {
        IServiceProvider ConfigureServices();
    }
}
