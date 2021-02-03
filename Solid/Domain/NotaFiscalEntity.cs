using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Domain
{
    public class NotaFiscalEntity
    {
        public long NrPedido { get; set; }
        public ProdutoEntity Produto { get; set; }
        public FornecedorEntity Fornecedor { get; set; }
        public double TotalProdutos { get; set; }
    }
}
