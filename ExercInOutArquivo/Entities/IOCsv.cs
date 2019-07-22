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
        public string SourcePath { get; private set; }
        public List<string> Produtos { get; private set; } = new List<string>();
        public string TargetPath { get; private set; }

        //Construtores
        public IOCsv() { }

        public IOCsv(string caminho)
        {
            SourcePath = caminho;
            ExibirArquivoEntrada(SourcePath);
            EscreverArquivo(Produtos);

        }

        //Metodos da Classe IOCsv
        public void ExibirArquivoEntrada(string entrada)
        {
            using (FileStream fs = new FileStream(entrada, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    Console.WriteLine("--------------------------------INPUT ARQUIVOS--------------------------------");
                    while (!sr.EndOfStream)
                    {
                        string linhas = sr.ReadLine();
                        Console.WriteLine(linhas);
                    }
                    Console.WriteLine("\nCaminho de origem: " + Path.GetFullPath(SourcePath));
                    Console.WriteLine("------------------------------------------------------------------------------\n");
                }
            }
            LerArquivo(entrada);
            NovoCaminho(SourcePath);
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
                        RecuperarDados(linhasSeparadas[0], linhasSeparadas[1], linhasSeparadas[2]);
                    }
                }
            }
        }

        public void RecuperarDados(string s1, string s2, string s3)
        {
            string produtos = s1;
            double valorTotal = double.Parse(s2) * int.Parse(s3);
            string dados = produtos + " - R$" + valorTotal.ToString("f2", CultureInfo.InvariantCulture);
            Produtos.Add(dados);
        }

        //new
        public void NovoCaminho(string caminhoOrigem)
        {
            string origem = Path.GetDirectoryName(SourcePath);
            string destino = @"Out\";
            TargetPath = Path.Combine(origem,destino);
            Directory.CreateDirectory(TargetPath);
        }

        //new
        public void EscreverArquivo(List<string> produtos)
        {
            string[] celulas = File.ReadAllLines(SourcePath);
            string nomeArquivoSaida = "OUTPUT.csv";
            TargetPath = TargetPath + nomeArquivoSaida;

            using (StreamWriter sw = File.AppendText(TargetPath))
            {
                foreach (string produto in produtos)
                {
                    sw.WriteLine(produto);
                }
            }
            ExibirArquivoSaida(TargetPath);
        }

        public void ExibirArquivoSaida(string saida)
        {

            Console.WriteLine("--------------------------------OUTPUT ARQUIVOS-------------------------------");
            foreach (string produto in Produtos)
            {
                Console.WriteLine(produto);
            }

            Console.WriteLine("\nDados salvos em: " + saida);
            Console.WriteLine("------------------------------------------------------------------------------");
        }
    }
}
