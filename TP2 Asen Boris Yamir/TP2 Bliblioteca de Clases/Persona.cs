using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Bliblioteca_de_Clases
{
    public abstract class Persona
    {
        //  ATRIBUTOS  //
        public int dni{ get; set; } //test set and get
        string Nombre;
        string Apellido;
        DateTime FechaDeNacimiento;

        //  SETTERS AND GETTERS  //


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

        //  SETTERS AND GETTERS  //

        public Persona(int dni, string nombre, string apellido, DateTime fechaDeNacimiento) {
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaDeNacimiento = fechaDeNacimiento;
        }

        //  OTROS METODOS  //

        public int Edad()
        {
            return DateTime.Today.AddTicks(-FechaDeNacimiento.Ticks).Year - 1;
        }

        public Persona()
        {
        }
    }

    public class Alumno : Persona
    {
        //  ATRIBUTOS  //
        private List<Cuota> Cuotas;

        //  SETTERS AND GETTERS  //
        public List<Cuota> cuotas
        {
            get
            {
                return Cuotas;
            }

            set
            {
                Cuotas = value;
            }
        }

        //  CONSTRUCTOR  //
        public Alumno(int dni, string nombre, string apellido, DateTime fechaDeNacimiento): base(dni,nombre,apellido, fechaDeNacimiento)
        {
            //this.cuotas = cuotas;
        }

        public Alumno() : base()
        {
        }

        //  OTROS METODOS  //
        public override string ToString()
        {
            return dni + " - " + apellido + ", " + nombre;
        }

        public string ConcatenarDatos()
        {
            return dni + ";" + apellido + ";" + nombre + ";" + fechaDeNacimiento;
        }

    }

    public class Cuota
    {
        double Valor;
        bool Pagada;

        public double valor
        {
            get
            {
                return Valor;
            }

            set
            {
                Valor = value;
            }
        }

        public bool pagada
        {
            get
            {
                return Pagada;
            }

            set
            {
                Pagada = value;
            }
        }
    }

    public enum Cargos{Administrativo,Docente,Limpieza}
    
    public class Empleado : Persona
    {
        //  ATRIBUTOS  //
        DateTime FechaDeAlta;
        string Cargo;
        double Sueldo;

        //  SETTERS AND GETTERS  //
        public DateTime fechaDeAlta
        {
            get
            {
                return FechaDeAlta;
            }

            set
            {
                FechaDeAlta = value;
            }
        }

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

        //  CONSTRUCTOR  //
        public Empleado(int dni, string nombre, string apellido, DateTime fechaDeNacimiento, DateTime fechaDeAlta, double sueldo, string cargo): base(dni,nombre,apellido, fechaDeNacimiento)
        {
            this.fechaDeAlta = fechaDeAlta;
            this.sueldo = sueldo;
            this.cargo = cargo;
        }

        public Empleado() : base()
        {

        }

        //  OTROS METODOS  //
        public override string ToString()
        {
            return dni + " - " + apellido + ", " + nombre + " (" + cargo + ")";
        }

        public int Antiguedad()
        {
            return DateTime.Today.AddTicks(-FechaDeAlta.Ticks).Year - 1;
        }
    }
}
