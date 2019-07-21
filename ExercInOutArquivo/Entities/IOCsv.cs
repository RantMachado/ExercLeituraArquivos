using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
            LerArquivo(SourcePath);
        }

        //Metodos da Classe IOCsv
        public void LerArquivo(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    Console.WriteLine("------------------------------INPUT------------------------------");
                    while (!sr.EndOfStream)
                    {
                        string[] linhasSeparadas = sr.ReadLine().Split(';');
                        foreach (string linhas in linhasSeparadas)
                        {
                            Console.WriteLine(linhas);
                        }
                    }
                    Console.WriteLine("-----------------------------------------------------------------");
                }
            }
        }


        
    }
}
