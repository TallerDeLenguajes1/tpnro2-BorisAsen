using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Bliblioteca_de_Clases
{
    class Persona
    {
        int DNI;
        string Nombre;
        string Apellido;
        DateTime FechaDeNacimiento;

        public int dni
        {
            get
            {
                return DNI;
            }

            set
            {
                DNI = value;
            }
        }

        public string nombre
        {
            get
            {
                return Nombre;
            }

            set
            {
                Nombre = value;
            }
        }

        public string apellido
        {
            get
            {
                return Apellido;
            }

            set
            {
                Apellido = value;
            }
        }

        public DateTime fechaDeNacimiento
        {
            get
            {
                return FechaDeNacimiento;
            }

            set
            {
                FechaDeNacimiento = value;
            }
        }

        public int Edad()
        {
            return 18;
        }
    }

    class Alumno : Persona
    {
        public override string ToString()
        {
            return dni + " - " + apellido + " " + nombre ;
        }

        public string ConcatenarDatos()
        {
            return dni + ";" + apellido + ";" + nombre;
        }
    }

    enum Cargos
    {
        Administrativo,
        Docente,
        Limpieza,
    }

    class Empleado : Persona
    {
        DateTime FechaDeAlta;
        string Cargo;
        double Sueldo;

        public double sueldo
        {
            get
            {
                return Sueldo;
            }

            set
            {
                Sueldo = value;
            }
        }

        public string cargo
        {
            get
            {
                return Cargo;
            }

            set
            {
                Cargo = value;
            }
        }

        public override string ToString()
        {
            return apellido + "," + nombre;
        }

        public int Antiguedad()
        {
            //Calcular antiguedad
            return 30;
        }
    }
}
