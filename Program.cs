using System;
using System.IO;
using System.Collections.Generic;

namespace TP08
{
    class Program
    {
        static int Main(string[] args){


            Console.WriteLine("Por favor ingrese un path para listar contenidos: ");
            string? buffUno, pathDirectory;
            do{
            Console.WriteLine("Ingrese el path de una carpeta: ");
            buffUno = Console.ReadLine();
            } while (string.IsNullOrEmpty(buffUno));

            string path = @"C:\Users\Usuario\Desktop\index.csv";
            pathDirectory = buffUno;

            if (Directory.Exists(pathDirectory))
            {

                if(!File.Exists(path)){
                File.Create(path);
                }

                FileStream Fstream = new FileStream(path, FileMode.Open);
                StreamWriter Streamw= new StreamWriter(Fstream);

                List<string> archivos = Directory.GetFiles(pathDirectory).ToList();
                List<string> subcarpetas = Directory.GetDirectories(pathDirectory).ToList();

                int i = 0;
                string[] acortado;
                string[] acortadoFormato;

                foreach (string item in archivos)
                {
                    acortado = item.Split("\\");
                    Console.WriteLine(acortado[acortado.Length-1]);
                    acortadoFormato = acortado[acortado.Length-1].Split(".");
                    Streamw.WriteLine(i +";"+ acortadoFormato[0] +";"+ acortadoFormato[1]);
                    i++;
                }

                foreach (var item in subcarpetas)
                {
                    acortado = item.Split("\\");
                    Console.WriteLine(acortado[acortado.Length-1]);
                    acortadoFormato = acortado[acortado.Length-1].Split(".");
                    Streamw.WriteLine(i +";"+ acortadoFormato[0] +";"+ "Carpeta");
                    i++;
                }

                Streamw.Close();

            }else{
                Console.WriteLine("\nLa direccion de la carpeta no existe.");
            }

            return 0;
        }

    }
}