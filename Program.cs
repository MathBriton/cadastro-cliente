using System;
using System.Collections.Generic;

namespace CadastroDeClientesConsole
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} | Nome: {Nome} | Email: {Email} | Telefone: {Telefone}";
        }
    }

    public class SistemaClientes
    {
        private List<Cliente> clientes = new List<Cliente>();
        private int proximoId = 1;

        public void AdicionarCliente(string nome, string email, string telefone)
        {
            var cliente = new Cliente
            {
                Id = proximoId++,
                Nome = nome,
                Email = email,
                Telefone = telefone
            };

            clientes.Add(cliente);
            Console.WriteLine("Cliente cadastrado com sucesso!");
        }

        public void ListarClientes()
        {
            if (clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
                return;
            }

            foreach (var cliente in clientes)
            {
                Console.WriteLine(cliente);
            }
        }

        public void EditarCliente(int id, string novoNome, string novoEmail, string novoTelefone)
        {
            var cliente = clientes.Find(c => c.Id == id);
            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }

            cliente.Nome = novoNome;
            cliente.Email = novoEmail;
            cliente.Telefone = novoTelefone;

            Console.WriteLine("Cliente atualizado com sucesso!");
        }

        public void ExcluirCliente(int id)
        {
            var cliente = clientes.Find(c => c.Id == id);
            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }

            clientes.Remove(cliente);
            Console.WriteLine("Cliente excluído com sucesso!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sistema = new SistemaClientes();
            string opcao;

            do
            {
                Console.WriteLine("\n=== Sistema de Cadastro de Clientes ===");
                Console.WriteLine("1. Adicionar Cliente");
                Console.WriteLine("2. Listar Clientes");
                Console.WriteLine("3. Editar Cliente");
                Console.WriteLine("4. Excluir Cliente");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("Digite o nome do cliente: ");
                        string nome = Console.ReadLine();
                        Console.Write("Digite o email do cliente: ");
                        string email = Console.ReadLine();
                        Console.Write("Digite o telefone do cliente: ");
                        string telefone = Console.ReadLine();

                        sistema.AdicionarCliente(nome, email, telefone);
                        break;

                    case "2":
                        sistema.ListarClientes();
                        break;

                    case "3":
                        Console.Write("Digite o ID do cliente a ser editado: ");
                        int idEditar = int.Parse(Console.ReadLine());
                        Console.Write("Digite o novo nome do cliente: ");
                        string novoNome = Console.ReadLine();
                        Console.Write("Digite o novo email do cliente: ");
                        string novoEmail = Console.ReadLine();
                        Console.Write("Digite o novo telefone do cliente: ");
                        string novoTelefone = Console.ReadLine();

                        sistema.EditarCliente(idEditar, novoNome, novoEmail, novoTelefone);
                        break;

                    case "4":
                        Console.Write("Digite o ID do cliente a ser excluído: ");
                        int idExcluir = int.Parse(Console.ReadLine());
                        sistema.ExcluirCliente(idExcluir);
                        break;

                    case "5":
                        Console.WriteLine("Saindo do sistema...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            } while (opcao != "5");
        }
    }
}
