using Solid.Domain;
using Solid.Services.Produto;

namespace Solid.Services.NotaFiscal
{
    public class NotaFiscalService : Service, INotaFiscalService
    {
        public NotaFiscalEntity EmitirNotaFiscal(IProdutoService produtoService, long nrPedido)
        {
            double valorTotal = produtoService.CalcularValorProdutos(nrPedido);
            return new NotaFiscalEntity
            {
                NrPedido = nrPedido,
                TotalProdutos = valorTotal
            };
        }

        public void EncaminharNotaFiscal(FornecedorEntity fornecedor, long nrNotaFiscal)
        {
            //Obter Nota Fiscal
            _ = nrNotaFiscal;
            //Imprimindo nota Fiscal
            EnviarEmail(fornecedor);
        }

        private void EnviarEmail(FornecedorEntity fornecedor)
        {
            //Enviar Email para fornecedor.Email
            _ = fornecedor.Email;
        }
    }
}
