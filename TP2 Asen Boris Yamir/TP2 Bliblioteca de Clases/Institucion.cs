using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Bliblioteca_de_Clases
{
    public class Institucion
    {
        // ************ ATRIBUTOS ************ //
        string Nombre;
        string Matricula_Ministerio;
        List<Curso> ListCursos;

        // ************ GETTERS AND SETTERS ************ //
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

        public string matricula_ministerio
        {
            get
            {
                return Matricula_Ministerio;
            }

            set
            {
                Matricula_Ministerio = value;
            }
        }

        public List<Curso> listCursos
        {
            get
            {
                return ListCursos;
            }

            //set
            //{
            //    ListCursos = value;
            //}
        }

        // ************ OTROS METODOS ************ //
        //private void CrearCurso(DateTime turno, List<Alumno>alumnos, Empleado docente, string tema, double cuota, double inscripcion)
        //{
        //    //Usar constructor
        //    Curso nuevoCurso = new Curso();
        //    nuevoCurso.turno = turno;
        //    nuevoCurso.alumnos = alumnos;
        //    nuevoCurso.docente = docente;
        //    nuevoCurso.tema = tema;
        //    nuevoCurso.cuota = cuota;
        //    nuevoCurso.inscripcion = inscripcion;
        //    ListCursos.Add(nuevoCurso);
        //}
    }

    public abstract class Curso
    {
        // ************ ATRIBUTOS ************ //
        DateTime Turno;
        List<Alumno> Alumnos;
        Empleado Docente;
        string Tema;
        double Cuota;
        double Inscripcion;
        string Tipo;

        // ************ SETTERS AND GETTERS ************ //
        public DateTime turno
        {
            get
            {
                return Turno;
            }

            set
            {
                Turno = value;
            }
        }

        public List<Alumno> alumnos
        {
            get
            {
                return Alumnos;
            }

            set
            {
                Alumnos = value;
            }
        }

        public Empleado docente
        {
            get
            {
                return Docente;
            }

            set
            {
                Docente = value;
            }
        }

        public string tema
        {
            get
            {
                return Tema;
            }

            set
            {
                Tema = value;
            }
        }

        public double cuota
        {
            get
            {
                return Cuota;
            }

            set
            {
                Cuota = value;
            }
        }

        public double inscripcion
        {
            get
            {
                return Inscripcion;
            }

            set
            {
                Inscripcion = value;
            }
        }

        public string tipo
        {
            get
            {
                return Tipo;
            }

            set
            {
                Tipo = value;
            }
        }


        // ************ CONSTRUCTOR ************ //
        public Curso(DateTime turno, string tema, double cuota, double inscripcion)
        {
            this.turno = turno;
            this.tema = tema;
            this.cuota = cuota;
            this.inscripcion = inscripcion;
            this.alumnos = new List<Alumno>();
        }

        // ************ OTROS METODOS ************ //
        public void cargarProfesor(Empleado doc)
        {
            docente = doc;
        }

        public void cargarAlumno(Alumno nuevoInscripto)
        {
            Alumnos.Add(nuevoInscripto);
        }

        public virtual void valorCuota() { }

        public override string ToString()
        {
            return Tema + " (" + Tipo + ")" ;
        }
    }

    public class Presencial : Curso
    {
        // ************ CONSTRUCTOR ************ //
        public Presencial(DateTime _turno, string _tema, double _cuota, double _inscripcion) : base(_turno,_tema,_cuota,_inscripcion){ tipo = "Presencial"; }

        public override void valorCuota()
        {
            List<Cuota> listCuotas = new List<Cuota>();
            double precioMes = cuota + cuota *0.21 + inscripcion/3;

            //Asigno los valores correspondientes a cada miembro de la lista de cuotas

            //Distribuyo el valor de la inscripcion en las primeras 3 cuotas de la lista
            listCuotas[0].valor = precioMes;
            listCuotas[1].valor = precioMes;
            listCuotas[2].valor = precioMes;

            //A las demas cuotas les asigno el valor sin la inscripcion
            precioMes = cuota + cuota * 0.21;
            for (int i = 3; i < 12; i++)
            {
                listCuotas[i].valor = precioMes;
            }
            //Incializo todas las cuotas como no pagadas
            for (int i = 0; i < 12; i++)
            {
                listCuotas[i].pagada = false;
            }

            //Asigno un listado de cuotas a cada alumno
            foreach (var alu in alumnos)
            {
                alu.cuotas = listCuotas;
            }
        }
    }

    public class SemiPresencial : Curso
    {
        public SemiPresencial(DateTime _turno, string _tema, double _cuota, double _inscripcion) : base(_turno,_tema,_cuota,_inscripcion) { tipo = "Semipresencial"; }

        public override void valorCuota()
        {
            List<Cuota> listCuotas = new List<Cuota>();

            //Asigno los valores correspondientes a cada miembro de la lista de cuotas

            //Solo la primera cuota lleva agregado el valor de la inscripcion
            listCuotas[0].valor = cuota + inscripcion;

            //A las demas cuotas les asigno el valor sin la inscripcion
            for (int i = 1; i < 12; i++)
            {
                listCuotas[i].valor = cuota;
            }
            //Incializo todas las cuotas como no pagadas
            for (int i = 0; i < 12; i++)
            {
                listCuotas[i].pagada = false;
            }

            //Asigno un listado de cuotas a cada alumno
            foreach (var alu in alumnos)
            {
                alu.cuotas = listCuotas;
            }
        }
    }

    public class NoPresencial : Curso
    {
        public NoPresencial(DateTime _turno, string _tema, double _cuota, double _inscripcion) : base(_turno,_tema,_cuota,_inscripcion) { tipo = "No presencial"; }

        public override void valorCuota()
        {
            List<Cuota> listCuotas = new List<Cuota>();

            //(inscripcion*0.5)/3 == inscripcion/6
            double precioMes = cuota + inscripcion/6;

            //Asigno los valores correspondientes a cada miembro de la lista de cuotas

            //Distribuyo el valor de la inscripcion en las primeras 3 cuotas de la lista
            listCuotas[0].valor = precioMes;
            listCuotas[1].valor = precioMes;
            listCuotas[2].valor = precioMes;

            //A las demas cuotas les asigno el valor sin la inscripcion
            for (int i = 3; i < 12; i++)
            {
                listCuotas[i].valor = cuota;
            }
            //Incializo todas las cuotas como no pagadas
            for (int i = 0; i < 12; i++)
            {
                listCuotas[i].pagada = false;
            }

            //Asigno un listado de cuotas a cada alumno
            foreach (var alu in alumnos)
            {
                alu.cuotas = listCuotas;
            }
        }
    }
}
