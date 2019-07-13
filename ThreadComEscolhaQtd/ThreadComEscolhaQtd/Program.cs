using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadComEscolhaQtd
{
    class Program
    {
        static List<ListaThreads> listaThreadload = new List<ListaThreads>();
        static long indice1 = 0;
        static long indice2 = 0;

        static void Main(string[] args)
        {
            Thread thread0 = new Thread(IncrementIndex1);
            thread0.Start();
            
            Thread thread1 = new Thread(IncrementIndex2);
            thread1.Start();
            
            //Thread thread2 = new Thread(IncrementIndex);
            //thread2.Start();
            
            var iniciDeOperacao = DateTime.Now;
           // IncrementIndex();
            
            while ((indice1 +indice2) < 1000000000)
            {
          
            }
            var tempoTotal = DateTime.Now - iniciDeOperacao;

            Console.WriteLine($"Tempo total de execução: {tempoTotal}");
            Console.ReadKey();
        }

        public static void IncrementIndex1()
        {
            while (indice1 < 500000000)
                indice1++;
        }

        public static void IncrementIndex2()
        {
            while (indice2 < 500000000)
                indice2++;
        }

        public static void CarregaLista()
        {
            for (long i = 0; i < 10000000; i++)
            {
                try
                {
                    listaThreadload.Add(new ListaThreads()
                    {
                        Numero = indice1++
                    });
                }
                catch
                {
                    //estoruou o idx
                    Console.WriteLine("ALAH AKBARRRR!!!!!!!");
                }
            }
        }
    }

    public class ListaThreads
    {
        /// <summary>
        /// Número q define a ordem de criação
        /// </summary>
        public long Numero { get; set; } = 0;

        /// <summary>
        /// Identificador booleano
        /// </summary>
        public bool Atualizado { get; set; } = false;
    }
}
