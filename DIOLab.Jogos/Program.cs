using System;

namespace DIOLab.Jogos
{
    class Program
    {
        static JogoRepositorio repositorio = new JogoRepositorio();

        static void Main(string[] args)
        {
            //Opção escolhida pelo usuario.
            string OpUser = ObterOpUser();

            while (OpUser.ToUpper() != "X")
            {
                switch (OpUser)
                {
                    case "1":
                        ListarJogos();
                    break;
                    case "2":
                        InserirJogo();
                    break;
                    case "3":
                        AtualizarJogo();
                    break;
                    case "4":
                        ExcluirJogo();
                    break;
                    case "5":
                        VisualizarJogo();
                    break;
                    case "C":
                        Console.Clear();
                    break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                OpUser = ObterOpUser();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();
        }

        private static string ObterOpUser()
        {
            //interface com o usuario
            Console.WriteLine();
            Console.WriteLine("DIO Games a seu dispor");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");
            
            Console.WriteLine("1- Listar Jogos");
            Console.WriteLine("2- Inserir novo Jogo");
            Console.WriteLine("3- Atualizar Jogo");
            Console.WriteLine("4- Excluir Jogo");
            Console.WriteLine("5- Visualizar Jogo");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            String OpUser = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpUser;
        }

        private static void ListarJogos()
        {
            Console.WriteLine("-Listar jogos-");
            Console.WriteLine();
            var lista = repositorio.Lista();

            Console.Clear();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum jogo cadastrado");
                return;
            }

            foreach(var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), serie.retornaExcluido() ? "Excluído":"Disponível");
            }
        }

        private static void InserirJogo()
        {
            Console.WriteLine("-Inserir novo jogo-");
            Console.WriteLine();
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima");
            int entradaGenero = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o Título do Jogo");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de lançamento do jogo");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição do jogo");
            string entradaDescricao = Console.ReadLine();

            Jogos novaSerie = new Jogos
            (
                id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
            );
            repositorio.Insere(novaSerie);
            Console.Clear();
        }

        public static void AtualizarJogo()
        {
            Console.WriteLine("-Atualizar Jogos-");
            Console.WriteLine();
            Console.WriteLine("Digite o ID do jogo");
            int indiceJogo = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima");
            int entradaGenero = int.Parse(Console.ReadLine());
                
            Console.WriteLine("Digite o Título do Jogo");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de lançamento do jogo");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição do jogo");
            string entradaDescricao = Console.ReadLine();

            Jogos AtualizaJogo = new Jogos
            (
                id: indiceJogo,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
            );

            repositorio.Atualiza(indiceJogo, AtualizaJogo);
            Console.Clear();
        }

        public static void ExcluirJogo()
        {
            Console.WriteLine("-Excluir Jogos-");
            Console.WriteLine("Deseja realemente realizar essa operação? [S/N]");
            string rsp = Console.ReadLine();

            if(rsp.ToUpper() == "S")
            {
                Console.WriteLine("Digite o ID do jogo para exclui-lo");
                int indiceJogo = int.Parse(Console.ReadLine());

                repositorio.Exclui(indiceJogo);
            }
            Console.Clear();
        }

        public static void VisualizarJogo()
        {
            Console.WriteLine("-Visualizar Jogos-");
            Console.WriteLine();
            Console.WriteLine("Digite o Id do Jogo");
            int indiceJogo = int.Parse(Console.ReadLine());

            var jogo = repositorio.RetornaPorId(indiceJogo);
            
            Console.Clear();
            Console.WriteLine(jogo);
        }
    }
}
