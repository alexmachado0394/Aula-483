using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //classe do .NET que trabalha com threads paralelas com funções básicas de repetição
            Parallel.For(0, 5, index => 
            {
                ImprimeOCafeEstaPronto(index);
                ImprimeOAlmocoEstaPronto(index);
            });

            Console.ReadKey();
        }

        public static void ImprimeOCafeEstaPronto(int numero)
        {
            Console.WriteLine($"O café está pronto {numero}");
        }

        public static void ImprimeOAlmocoEstaPronto(int numero)
        {
            Console.WriteLine($"O almoço está pronto {numero}");
        }
    }
}
