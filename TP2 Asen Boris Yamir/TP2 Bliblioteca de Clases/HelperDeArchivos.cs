using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Bliblioteca_de_Clases
{
    class HelperDeArchivos
    {
        public static void CargarArchivo(List<Alumno> Listado, string CsvFileName)
        {
            string directorio = "Listados";
            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }

            string csvFile = directorio + @"\" + CsvFileName;
            string line;

            try
            {
                using (StreamWriter file = File.CreateText(csvFile))
                {
                    foreach (Alumno alu in Listado)
                    {
                        line = alu.ConcatenarDatos();
                        file.WriteLine(line);
                    }
                    file.Close();
                }

                //Console.WriteLine("\n\nListado " + CsvFileName + " guardado con exito");
            }
            catch (Exception error)
            {
                Console.WriteLine("\n\n¡Hubo un error!");
                Console.WriteLine(error.Message);
            }

        }
    }
}
