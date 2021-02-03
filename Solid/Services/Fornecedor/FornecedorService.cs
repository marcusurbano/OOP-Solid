using Solid.Domain;
using Solid.Extensions;
using Solid.Repository.Fornecedor;
using System;
using System.Collections.Generic;

namespace Solid.Services.Fornecedor
{
    public class FornecedorService : Service, IFornecedorService
    {
        readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public FornecedorEntity BuscarPorCodigo(long codigo)
        {
            var fornecedor = _fornecedorRepository.BuscarPorCodigo(codigo);
            if (fornecedor == null)
                throw new SolidException("Fornecedor não localizado!");
            return fornecedor;
        }

        public void Incluir(FornecedorEntity fornecedor)
        {
            Validar(fornecedor, false);
            _fornecedorRepository.Incluir(fornecedor);
        }

        public void Alterar(FornecedorEntity fornecedor)
        {
            Validar(fornecedor, true);
            _fornecedorRepository.Alterar(fornecedor);
        }

        public IList<FornecedorEntity> Listar()
        {
            return _fornecedorRepository.Listar();
        }

        private void Validar(FornecedorEntity fornecedor, bool alterarFornecedor)
        {
            if (alterarFornecedor && fornecedor.Codigo <= 0)
                throw new SolidException("Código do Fornecedor não informado!");

            if (fornecedor is FornecedorPjEntity pj)
                Validar(pj);
            else if (fornecedor is FornecedorPfEntity pf)
                Validar(pf);
        }

        private void Validar(FornecedorPfEntity fornecedorPf)
        {
            if (string.IsNullOrEmpty(fornecedorPf.Cpf))
                throw new SolidException("CPF não informado!");

            if (string.IsNullOrEmpty(fornecedorPf.Nome))
                throw new SolidException("Nome não informado!");
        }

        private void Validar(FornecedorPjEntity fornecedorPj)
        {
            if (string.IsNullOrEmpty(fornecedorPj.Cnpj))
                throw new SolidException("CNPJ não informado!");

            if (string.IsNullOrEmpty(fornecedorPj.RazaoSocial))
                throw new SolidException("Razão Social não informado!");
        }
    }
}
