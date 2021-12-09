using System;

namespace DIO.Series
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSeries();
                        break;
                    case "3":
                        AtualizarSeries();
                        break;
                    case "4":
                        ExcluirSeries();
                        break;
                    case "5":
                        VisualizarSeries();
                        break; 
                    case "C":
                        Console.Clear();
                        break;  
                    default:
                       throw new ArgumentOutOfRangeException();                       
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

             Console.WriteLine("Obrgiada por utilizar nossos serviçoes.");
             Console.ReadLine();
        }

        private static void ExcluirSeries()
        {
            System.Console.WriteLine("Digite o id da serie:");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);
        }
         private static void VisualizarSeries()
         {
             System.Console.WriteLine("Digite o id da serie: ");
             int indiceSerie = int.Parse(Console.ReadLine());

             var serie = repositorio.retornaId(indiceSerie);

             Console.WriteLine(serie);
         }


        private static void AtualizarSeries()
        {
            Console.WriteLine("Digite o Id da serie");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genero entre as opçoes acima ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da serie ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de inicio da serie ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descricao da Serie ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizarSerie = new Serie(id: indiceSerie,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                       ano: entradaAno,
                                 descricao: entradaDescricao);
            repositorio.Atualizar(indiceSerie, atualizarSerie);

        }


        private static void ListarSeries()
        {
           Console.WriteLine("Listar series");

           var lista = repositorio.Lista();

           if(lista.Count == 0)
           {
             Console.WriteLine("Nenhuma serie cadastrada.");
             return;
           }
           foreach (var serie in lista)
           {
               var Excluido = serie.retornaExcluido();
               Console.WriteLine("#ID {0}: - {1} {2}", serie,retornaId(), serie,retornaTitulo(), (Excluido ? "*Excluido*" : "" ));
           }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genero entre as opçoes acima ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da serie ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de inicio da serie ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descricao da Serie ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                       ano: entradaAno,
                                 descricao: entradaDescricao);
            repositorio.Inserir(novaSerie);

        }


        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series a seu dispor!!!");
            Console.WriteLine("Informe a opçao desejada");

            Console.WriteLine("1 - Lista series");
            Console.WriteLine("2 - Inserir nova serie");
            Console.WriteLine("3 - Atualizar serie");
            Console.WriteLine("4 - Excluir serie");
            Console.WriteLine("5 - Visualizar serie");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
