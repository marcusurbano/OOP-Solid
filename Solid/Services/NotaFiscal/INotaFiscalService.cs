using Solid.Domain;
using Solid.Services.Produto;

namespace Solid.Services.NotaFiscal
{
    public interface INotaFiscalService
    {
        NotaFiscalEntity EmitirNotaFiscal(IProdutoService produtoService, long nrPedido);
        void EncaminharNotaFiscal(FornecedorEntity fornecedor, long nrNotaFiscal);
    }
}
