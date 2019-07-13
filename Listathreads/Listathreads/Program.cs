using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listathreads
{
    class Program
    {
        static List<ParallelListTeste> listaDeItens = new List<ParallelListTeste>();

        static void Main(string[] args)
        {
            var iniciDeOperacao = DateTime.Now;
            CarregaListaParallel();
            var tempoTotal = DateTime.Now - iniciDeOperacao;

            Console.WriteLine($"Tempo total de execução: {tempoTotal}");
            Console.ReadKey();
        }

        public static void CarregaListaParallel()
        {
            Parallel.For(0, 100000, i =>
             {
                 listaDeItens.Add(new ParallelListTeste()
                 {
                     Numero = i
                 });
             });
        }

        public static void CarregaLista()
        {
            for (int i = 0; i < 100000; i++)
            {
                listaDeItens.Add(new ParallelListTeste()
                {
                    Numero=i
                });
            }
        }
    }

    public class ParallelListTeste
    {
        public int Numero { get; set; } = 0;
        /// <summary>
        /// Indicador booleano que mostra se foi atualizado ou não.
        /// </summary>
        public bool Atualizado { get; set; } = false;
    }
}
