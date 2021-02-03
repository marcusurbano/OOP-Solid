using Solid.Domain;
using System.Collections.Generic;

namespace Solid.Services.Produto
{
    public interface IProdutoService
    {
        IList<ProdutoEntity> ObterProdutos(long nrPedido);
        double CalcularValorProdutos(long nrPedido);
    }
}
