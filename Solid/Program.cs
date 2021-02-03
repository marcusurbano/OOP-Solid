using Microsoft.Extensions.DependencyInjection;
using Solid.Domain;
using Solid.Services;
using Solid.Services.Fornecedor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solid
{
    public static class Program
    {
        static void Main(string[] args)
        {
            IDependendyInjection services = new DependendyInjection();
            IServiceProvider provider = services.ConfigureServices();
            IFornecedorService fornecedorService = provider.GetService<IFornecedorService>();
            GerarMenu(fornecedorService, string.Empty);
        }

        static void GerarMenu(IFornecedorService fornecedorService, string msg)
        {
            Console.Clear();
            if (!string.IsNullOrEmpty(msg))
                Console.WriteLine(msg);

            Console.WriteLine("\nSOLID - Menu Fornecedor");
            Console.WriteLine("1- Inserir");
            Console.WriteLine("2- Alterar");
            Console.WriteLine("3- Exibir");
            Console.WriteLine("4- Exibir Todos");
            Console.WriteLine("5- Sair");
            Console.WriteLine("...");
            Console.WriteLine("Escolha uma opção: ");
            string retorno = Console.ReadLine();
            if (int.TryParse(retorno, out int acao) && acao > 0 && acao < 6)
            {
                FornecedorEntity fornecedor = null;
                switch (acao)
                {
                    case 1:
                        {
                            Console.Clear();
                            CapturarAcaoGravar(fornecedorService, fornecedor, true);
                        }
                        break;
                    case 2:
                        {
                            CapturarAcaoGravar(fornecedorService, fornecedor, false);
                        }
                        break;
                    case 3:
                        {
                            ImprimirIndividual(fornecedorService.Listar(), fornecedorService);
                        }
                        break;
                    case 4:
                        {
                            ImprimirLista(fornecedorService.Listar(), fornecedorService);
                        }
                        break;
                    case 5:
                        Environment.Exit(1);
                        break;
                }
            }
            else
                GerarMenu(fornecedorService, string.Empty);
        }

        static void CapturarAcaoGravar(IFornecedorService fornecedorService, FornecedorEntity fornecedor, bool incluir)
        {
            string titulo = string.Format("SOLID - {0} Fornecedor", incluir ? "Cadastrando" : "Alterando");
            Console.WriteLine(titulo);

            if (fornecedor == null || (fornecedor is FornecedorPjEntity fornPj && string.IsNullOrEmpty(fornPj.Cnpj))
                                  || (fornecedor is FornecedorPfEntity fornPf && string.IsNullOrEmpty(fornPf.Cpf)))
            {
                Console.WriteLine("Informe o CPF/CNPJ (ou X para cancelar): ");
                string cpfCnpj = ValidarCancelamento(fornecedorService, Console.ReadLine());
                if (!string.IsNullOrEmpty(cpfCnpj))
                {
                    if (cpfCnpj.Length == 11)
                    {
                        if (fornecedor == null)
                            fornecedor = new FornecedorPfEntity();
                        ((FornecedorPfEntity)fornecedor).Cpf = cpfCnpj;
                    }
                    else if (cpfCnpj.Length == 14)
                    {
                        if (fornecedor == null)
                            fornecedor = new FornecedorPjEntity();
                        ((FornecedorPjEntity)fornecedor).Cnpj = cpfCnpj;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"CPF/CNPJ inválido!\n");
                        CapturarAcaoGravar(fornecedorService, fornecedor, incluir);
                    }
                }
                else
                {
                    Console.Clear();
                    CapturarAcaoGravar(fornecedorService, fornecedor, incluir);
                }
            }

            if (fornecedor != null)
            {
                Console.Clear();
                Console.WriteLine(titulo);
                string msgNome = string.Format("Informe {0} (ou X para cancelar): ", fornecedor is FornecedorPfEntity ? "o Nome" : "a Razão Social");
                Console.WriteLine(msgNome);
                string nome = ValidarCancelamento(fornecedorService, Console.ReadLine());
                if (!string.IsNullOrEmpty(nome))
                {
                    if (fornecedor is FornecedorPfEntity forn)
                        forn.Nome = nome;
                    else if (fornecedor is FornecedorPjEntity fornPjota)
                        fornPjota.RazaoSocial = nome;

                    Console.Clear();
                    ImprimirAcaoGravar(fornecedor, fornecedorService);
                }
                else
                {
                    Console.Clear();
                    CapturarAcaoGravar(fornecedorService, fornecedor, incluir);
                }
            }
        }

        static void ImprimirAcaoGravar(FornecedorEntity fornecedor, IFornecedorService fornecedorService)
        {
            Console.WriteLine("Confirma a gravação do fornecedor abaixo?");
            ImprimirFornecedor(fornecedor);
            Console.WriteLine("1- Sim");
            Console.WriteLine("2- Não");
            string acao = Console.ReadLine();
            if (!string.IsNullOrEmpty(acao) && int.TryParse(acao, out int opcao))
            {
                switch (opcao)
                {
                    case 1:
                        {
                            try
                            {
                                if (fornecedor.Codigo > 0)
                                    fornecedorService.Alterar(fornecedor);
                                else
                                    fornecedorService.Incluir(fornecedor);

                                Console.WriteLine("Fornecedor gravado com sucesso!");
                                Console.WriteLine("...\n\n\n Pressione qualquer tecla para continuar...");
                                Console.ReadLine();

                                GerarMenu(fornecedorService, string.Empty);
                            }
                            catch (Exception er)
                            {
                                GerarMenu(fornecedorService, er.Message);
                            }
                        }
                        break;
                    case 2:
                        GerarMenu(fornecedorService, string.Empty);
                        break;
                    default:
                        Console.Clear();
                        ImprimirAcaoGravar(fornecedor, fornecedorService);
                        break;
                }
            }
            else
            {
                Console.Clear();
                ImprimirAcaoGravar(fornecedor, fornecedorService);
            }
        }

        static string ValidarCancelamento(IFornecedorService fornecedorService, string linha)
        {
            if (!string.IsNullOrEmpty(linha) && linha.ToUpper() == "X")
                GerarMenu(fornecedorService, string.Empty);

            return linha;
        }

        static void ImprimirFornecedor(FornecedorEntity fornecedor)
        {
            if (fornecedor.Codigo > 0)
                Console.WriteLine($"Código: {fornecedor.Codigo}");
            if (fornecedor is FornecedorPfEntity forn)
            {
                Console.WriteLine($"CPF: {forn.Cpf}");
                Console.WriteLine($"Nome: {forn.Nome}");
            }
            else if (fornecedor is FornecedorPjEntity fornPjota)
            {
                Console.WriteLine($"CNPJ: {fornPjota.Cnpj}");
                Console.WriteLine($"Razão Social: {fornPjota.RazaoSocial}");
            }
        }

        static void ImprimirLista(IList<FornecedorEntity> fornecedores, IFornecedorService fornecedorService)
        {
            Console.Clear();
            if (fornecedores != null && fornecedores.Any())
            {
                foreach (var forn in fornecedores)
                {
                    ImprimirFornecedor(forn);
                    Console.WriteLine("...");
                }
            }
            else
                Console.WriteLine("Não existem fornecedores cadastrados!");

            Console.WriteLine("...\n\n\n Pressione qualquer tecla para continuar...");
            Console.ReadLine();
            GerarMenu(fornecedorService, string.Empty);
        }

        static void ImprimirIndividual(IList<FornecedorEntity> fornecedores, IFornecedorService fornecedorService)
        {
            string msg = string.Empty;
            Console.Clear();
            if (fornecedores != null && fornecedores.Any())
            {
                for (var i = 0; i < fornecedores.Count; i++)
                {
                    FornecedorEntity forn = fornecedores[i];
                    string nome = forn is FornecedorPfEntity ? ((FornecedorPfEntity)forn).Nome : ((FornecedorPjEntity)forn).RazaoSocial;
                    Console.WriteLine($"{i + 1}- {nome}");

                }

                Console.WriteLine("...\n\n\n Escolha um fornecedor:");

                string acao = Console.ReadLine();
                if (!string.IsNullOrEmpty(acao) && long.TryParse(acao, out long opcao))
                {
                    try
                    {
                        FornecedorEntity fornc = fornecedorService.BuscarPorCodigo(opcao);
                        Console.Clear();
                        ImprimirFornecedor(fornc);
                    }
                    catch (Exception er)
                    {
                        Console.Clear();
                        msg = er.Message;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Informe um código válido!");
                }
            }
            else
                Console.WriteLine("Não existem fornecedores cadastrados!");

            if(!string.IsNullOrEmpty(msg))
                Console.WriteLine(msg);

            Console.WriteLine("...\n\n\n Pressione qualquer tecla para continuar...");
            Console.ReadLine();
            GerarMenu(fornecedorService, msg);
        }
    }
}
