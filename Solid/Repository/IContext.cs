using Solid.Domain;
using Solid.Extensions;
using System;
using System.Collections.Generic;

namespace Solid.Repository
{
    public interface IContext : IDisposable
    {
        IDbList<FornecedorEntity> Fornecedores { get; }
        IDbList<ClienteEntity> Clientes { get; }
        IDbList<ProdutoEntity> Produtos { get; }
    }
}
