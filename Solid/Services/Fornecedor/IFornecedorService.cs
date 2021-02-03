using Solid.Domain;
using System.Collections.Generic;

namespace Solid.Services.Fornecedor
{
    interface IFornecedorService
    {
        FornecedorEntity BuscarPorCodigo(long codigo);
        void Incluir(FornecedorEntity fornecedor);
        void Alterar(FornecedorEntity fornecedor);
        IList<FornecedorEntity> Listar();
    }
}
