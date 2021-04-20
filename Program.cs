using System;
using OsSistemas.Classes;

namespace OsSistemas
{
    class Program
    {
        static OSrepositorio repositorio = new OSrepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarOrdemServico();
                        break;
                    case "2":
                        InserirOrdemServico();
                        break;
                    case "3":
                        // AtualizarOrdemServico();
                        break;
                    case "4":
                        ExcluirOrdemServico();
                        break;
                    case "5":
                        VisualizarOrdemServico();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
        }

        //Menu do usuario
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("\nDIO Séries a seu dispor!");
            Console.WriteLine("Informe a opção desejada: \n");

            Console.WriteLine("1 - Listar Ordem de Serviço");
            Console.WriteLine("2 - Inserir nova Ordem de Serviço");
            Console.WriteLine("3 - Atualizar Ordem de Serviço");
            Console.WriteLine("4 - Excluir Ordem de Serviço");
            Console.WriteLine("5 - Visualizar Ordem de Serviço");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair\n");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        //Metodo de listagem das ordens de serviço

        private static void ListarOrdemServico()
        {
            Console.WriteLine("Listar OS's\n");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Ordem cadastrada.");
                return;
            }
            foreach(var ordemServico in lista)
            {
                var excluido = ordemServico.retornaExcluidoId();

                Console.WriteLine("#ID {0}: - {1} {2}", ordemServico.retornaId(), ordemServico.retornaTitulo(), (excluido? "- *Excluído": ""));
            }

        }

        //Metodo de inserção da Ordem de serviço
        private static void InserirOrdemServico()
        {
            

            Console.WriteLine("Digite o Título da Ordem de Serviço: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite a descrição do serviço a ser feito: ");
            string entradaDescricao = Console.ReadLine();

            Console.WriteLine("Qual o valor do serviço: ");
            int entradaValor = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o Endereço: ");
            string entradaEndereco = Console.ReadLine();

            Console.WriteLine("Informe o nome do cliente: ");
            string entradaNomeCliente = Console.ReadLine();

            Console.WriteLine("CPF ou CNPJ do cliente: ");
            int entradaCpfCnpj = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o prazo inicial do serviço: ");
            DateTime entradaData = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Técnico Responsável: ");
            string entradaNomeTecnico = Console.ReadLine();

            Console.WriteLine("Forma de Pagamento");
            foreach(int i in Enum.GetValues(typeof(FormaDePagamento)))
            {
                Console.WriteLine("{0} - {1}", i , Enum.GetName(typeof(FormaDePagamento), i));
            }

            Console.WriteLine("\nInforme a Forma de Pagamento: ");
            int entradaFormaPagamento = int.Parse(Console.ReadLine());

                        

            OrdemServico novaOrdemServico = new OrdemServico(id: repositorio.ProximoId(),tituloOS: entradaTitulo, descricaoServico: entradaDescricao,
                                                            valor: entradaValor, endereco: entradaEndereco, nomeCliente: entradaNomeCliente, cpfCnpj: entradaCpfCnpj,
                                                            dataEmissao: entradaData,formaDePagamento: (FormaDePagamento)entradaFormaPagamento, nomeTecnico: entradaNomeTecnico
                                                            );
        
            repositorio.Insere(novaOrdemServico);
        }

        //Metodo de atualização de OS por Id

        private static void AtualizarOrdemServico()
        {

            Console.WriteLine("Digite o id da série: ");
            int indiceOrdemServico = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Ordem de Serviço: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite a descrição do serviço a ser feito: ");
            string entradaDescricao = Console.ReadLine();

            Console.WriteLine("Qual o valor do serviço: ");
            int entradaValor = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o Endereço: ");
            string entradaEndereco = Console.ReadLine();

            Console.WriteLine("Informe o nome do cliente: ");
            string entradaNomeCliente = Console.ReadLine();

            Console.WriteLine("CPF ou CNPJ do cliente: ");
            int entradaCpfCnpj = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o prazo inicial do serviço: ");
            DateTime entradaData = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Técnico Responsável: ");
            string entradaNomeTecnico = Console.ReadLine();

            Console.WriteLine("Forma de Pagamento");
            foreach(int i in Enum.GetValues(typeof(FormaDePagamento)))
            {
                Console.WriteLine("{0} - {1}", i , Enum.GetName(typeof(FormaDePagamento), i));
            }

            Console.WriteLine("\nInforme a Forma de Pagamento: ");
            int entradaFormaPagamento = int.Parse(Console.ReadLine());

                        

            OrdemServico atualizaOrdemServico = new OrdemServico(id: indiceOrdemServico, tituloOS: entradaTitulo, descricaoServico: entradaDescricao,
                                                            valor: entradaValor, endereco: entradaEndereco, nomeCliente: entradaNomeCliente, cpfCnpj: entradaCpfCnpj,
                                                            dataEmissao: entradaData,formaDePagamento: (FormaDePagamento)entradaFormaPagamento, nomeTecnico: entradaNomeTecnico
                                                            );
        
            repositorio.Atualiza(indiceOrdemServico, atualizaOrdemServico);
        }

        //Metodo de exclusão por Id
        private static void ExcluirOrdemServico()
        {
            Console.Write("Digite o número da Ordem de Serviço: ");
            int indiceServico = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceServico);
        } 

        //Metodo de visualização das OS's
        private static void VisualizarOrdemServico()
        {
            Console.WriteLine("Digite o número da Ordem de Serviço: ");
            int indiceServico = int.Parse(Console.ReadLine());

            var servico = repositorio.RetornaPorId(indiceServico);

            Console.WriteLine(servico);
        }

        

    }
}
