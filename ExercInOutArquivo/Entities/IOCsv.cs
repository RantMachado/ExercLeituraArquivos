using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace ExercInOutArquivo.Entities
{
    class IOCsv
    {
        //Auto-Properties
        public string SourcePath { get; set; }

        //Construtores
        public IOCsv() { }

        public IOCsv(string caminho)
        {
            SourcePath = caminho;
            ExibirArquivoEntrada(SourcePath);
        }

        //Metodos da Classe IOCsv
        public void ExibirArquivoEntrada(string entrada)
        {
            using (FileStream fs = new FileStream(entrada, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    Console.WriteLine("--------------------------------INPUT--------------------------------");
                    while (!sr.EndOfStream)
                    {
                        string linhas = sr.ReadLine();
                        Console.WriteLine(linhas);
                    }
                    Console.WriteLine("---------------------------------------------------------------------\n");
                }
            }
            LerArquivo(entrada);
        }

        public void LerArquivo(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] linhasSeparadas = sr.ReadLine().Split(',');
                        EscreverArquivo(linhasSeparadas[0], linhasSeparadas[1], linhasSeparadas[2]);
                    }
                }
            }
        }

        public void EscreverArquivo(string s1, string s2, string s3)
        {
            string produto = s1;
            double valorTotal = double.Parse(s2) * int.Parse(s3);
            Console.WriteLine(produto + " - R$" + valorTotal.ToString("f2", CultureInfo.InvariantCulture));
        }
    }
}
