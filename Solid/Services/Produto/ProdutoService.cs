using Solid.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Solid.Services.Produto
{
    public class ProdutoService : Service, IProdutoService
    {
        public double CalcularValorProdutos(long nrPedido)
        {
            IList<ProdutoEntity> produtos = ObterProdutos(nrPedido);
            return produtos.Sum(p => p.Valor);
        }

        public IList<ProdutoEntity> ObterProdutos(long nrPedido)
        {
            //retornar produtos
            return new List<ProdutoEntity> {
                new ProdutoEntity { Valor = 150 },
                new ProdutoEntity { Valor = 265 }
            };
        }
    }
}
