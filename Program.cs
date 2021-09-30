using System;
using DesafioDio.Classes;

namespace DesafioDio
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
        
            while(opcaoUsuario.ToUpper() != "X"){
                switch(opcaoUsuario){
                    case "1":
                        ListarSeries();
                    break;

                    case "2":
                        InserirSerie();
                    break;

                    case "3": 
                        ExcluirSerie();
                    break;

                    case "C":
                        Console.Clear();
                    break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            
            }

            Console.WriteLine("Obrigodo por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListarSeries(){
            Console.WriteLine("Lista séries");
            
            var lista = repositorio.Lista();

            if(lista.Count == 0){
                Console.WriteLine("Nenhum série cadastrada.");
                return;
            }

            foreach (var serie in lista){
                
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
            }

        }

        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Lista séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Excluir série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");

            Console.WriteLine();
            
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }

        private static void VisualizarSerie(){
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void atualizarSerie(){
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine($"{i}-{Enum.GetNames(typeof(Genero))}");
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entragaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Discrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                            genero: (Genero)entragaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
        }

        private static void InserirSerie(){
            
            foreach(int i in Enum.GetValues(typeof(Genero))){
				Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}"); 
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            
			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

        private static void ExcluirSerie(){
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

    }

}

