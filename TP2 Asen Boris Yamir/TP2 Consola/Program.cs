using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Bliblioteca_de_Clases;

namespace TP2_Consola
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public static void AlumnosFromCsvToList(string CsvFile, List<Alumno> Properties)
        {
            string[] content = null;
            try
            {
                content = File.ReadAllLines(CsvFile);
            }
            catch (Exception error)
            {
                Console.WriteLine("\n¡Hubo un error!\n");
                Console.WriteLine(error.Message);
            }

            Alumno nuevoAlumno;

            foreach (string line in content)
            {
                //nuevoAlumno = Alumno(line);
                //Properties.Add(nuevoAlumno);
            }
        }
    }
}
