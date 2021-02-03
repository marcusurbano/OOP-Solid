using Microsoft.Extensions.DependencyInjection;
using Solid.Repository;
using Solid.Repository.Fornecedor;
using Solid.Repository.Mock;
using Solid.Services.Fornecedor;
using System;


namespace Solid.Services
{
    public class DependencyInjection : ServiceCollection, IDependendyInjection
    {
        public IServiceProvider ConfigureServices()
        {
            this
                .AddScoped<IFornecedorService, FornecedorService>()
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
