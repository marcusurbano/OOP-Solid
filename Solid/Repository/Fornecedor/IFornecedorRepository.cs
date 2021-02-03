using Solid.Domain;
using System.Collections.Generic;

namespace Solid.Repository.Fornecedor
{
    public interface IFornecedorRepository : IRepository
    {
        FornecedorEntity BuscarPorCodigo(long codigo);
        void Incluir(FornecedorEntity fornecedor);
        void Incluir(IList<FornecedorEntity> fornecedores);
        void Alterar(FornecedorEntity fornecedor);
        IList<FornecedorEntity> Listar();
    }
}
