using Solid.Domain;
using Solid.Extensions;
using System;
using System.Collections.Generic;

namespace Solid.Repository.Mock
{
    public class ContextMock : IContext
    {
        private static readonly IDbList<FornecedorEntity> fornecedores = new DbList<FornecedorEntity>();
        private static readonly IDbList<ClienteEntity> clientes = new DbList<ClienteEntity>();
        private static readonly IDbList<ProdutoEntity> produtos = new DbList<ProdutoEntity>();

        public IDbList<FornecedorEntity> Fornecedores => fornecedores;
        public IDbList<ClienteEntity> Clientes => clientes;
        public IDbList<ProdutoEntity> Produtos => produtos;

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                clientes.Clear();
                fornecedores.Clear();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
