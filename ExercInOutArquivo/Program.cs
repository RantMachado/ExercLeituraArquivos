using System;
using ExercInOutArquivo.Entities;

namespace ExercInOutArquivo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IOCsv arquivo = new IOCsv(@"C:\temp\MyFolder\Arquivo\INPUT.csv");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
  