﻿using System;
using ExercInOutArquivo.Entities;

namespace ExercInOutArquivo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IOCsv arquivo = new IOCsv(args[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
  