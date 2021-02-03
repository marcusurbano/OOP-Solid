using Solid.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solid.Repository.Fornecedor
{
    public class FornecedorRepository : Repository, IFornecedorRepository
    {
        public FornecedorRepository(IContext context) : base(context)
        {

        }

        public FornecedorEntity BuscarPorCodigo(long codigo)
        {
            return DbContext.Fornecedores.Find(codigo);
        }

        public void Incluir(FornecedorEntity fornecedor)
        {
            fornecedor.Codigo = DbContext.Fornecedores.NextKey();
            DbContext.Fornecedores.Insert(fornecedor);
        }

        public void Incluir(IList<FornecedorEntity> fornecedores)
        {
            DbContext.Fornecedores.Insert(fornecedores);
        }

        public void Alterar(FornecedorEntity fornecedor)
        {
            DbContext.Fornecedores.Update(fornecedor);
        }

        public IList<FornecedorEntity> Listar()
        {
            return DbContext.Fornecedores;
        }
    }
}
