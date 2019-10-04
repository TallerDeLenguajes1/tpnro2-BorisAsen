using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Bliblioteca_de_Clases
{
    public class HelperDeArchivos
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

                Console.WriteLine("\n\nListado " + CsvFileName + " guardado con exito");
            }
            catch (Exception error)
            {
                Console.WriteLine("\n\n¡Hubo un error!");
                Console.WriteLine(error.Message);
            }

        }


        //Funcion para rellenar la lista de alumnos con un archivo csv
        public static void CargarListaAlumnos(List<Alumno> Lista, string FileName)
        {
            string[] content = File.ReadAllLines(FileName);
            foreach (string line in content)
            {
                string[] delimitedContent = line.Split(';');
                int dni = Convert.ToInt32(delimitedContent[0]);
                string nombre = delimitedContent[1];
                string apellido = delimitedContent[2];
                DateTime fechaDeNacimiento = Convert.ToDateTime(delimitedContent[3]);

                Alumno newObject = new Alumno(dni, nombre, apellido, fechaDeNacimiento);
                Lista.Add(newObject);
            }
        }

        //Funcion para rellenar la lista de empleados con un archivo csv
        public static void CargarListaEmpleados(List<Empleado> Lista, string FileName)
        {
            string[] content = File.ReadAllLines(FileName);
            foreach (string line in content)
            {
                string[] delimitedContent = line.Split(';');
                int dni = Convert.ToInt32(delimitedContent[0]);
                string nombre = delimitedContent[1];
                string apellido = delimitedContent[2];
                DateTime fechaDeNacimiento = Convert.ToDateTime(delimitedContent[3]);
                DateTime fechaDeAlta = Convert.ToDateTime(delimitedContent[4]);
                double sueldo = Convert.ToDouble(delimitedContent[5]);
                string cargo = delimitedContent[6];

                Empleado newObject = new Empleado(dni, nombre, apellido, fechaDeNacimiento, fechaDeAlta, sueldo, cargo);
                Lista.Add(newObject);
            }
        }

        //Funcion para rellenar la lista de empleados con un archivo csv
        public static void CargarListaCursos(List<Curso> Lista, string FileName)
        {
            string[] content = File.ReadAllLines(FileName);
            foreach (string line in content)
            {
                string[] delimitedContent = line.Split(';');
                DateTime turno = Convert.ToDateTime(delimitedContent[0]);
                string tema = delimitedContent[1];
                double cuota = Convert.ToDouble(delimitedContent[2]);
                double inscripcion = Convert.ToDouble(delimitedContent[3]);
                string tipo = delimitedContent[4];


                switch (tipo)
                {
                    case "Presencial":
                        Curso newPresencial = new Presencial(turno, tema, cuota, inscripcion);
                        Lista.Add(newPresencial);
                        break;
                    case "Semipresencial":
                        Curso newSemiPresencial = new SemiPresencial(turno, tema, cuota, inscripcion);
                        Lista.Add(newSemiPresencial);
                        break;
                    case "No presencial":
                        Curso newNoPresencial = new NoPresencial(turno, tema, cuota, inscripcion);
                        Lista.Add(newNoPresencial);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
