using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_Bliblioteca_de_Clases
{
    class Institucion
    {
        string Nombre;
        string Matricula_Ministerio;
        List<Curso> ListCursos;

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

            set
            {
                ListCursos = value;
            }
        }

        public Curso CrearCurso(DateTime turno, List<Alumno>alumnos, Empleado docente, string tema, double cuota, double inscripcion)
        {
            Curso nuevoCurso = new Curso();
            nuevoCurso.turno = turno;
            nuevoCurso.alumnos = alumnos;
            nuevoCurso.docente = docente;
            nuevoCurso.tema = tema;
            nuevoCurso.cuota = cuota;
            nuevoCurso.inscripcion = inscripcion;
            return nuevoCurso;
        }
    }

    class Curso
    {
        DateTime Turno;
        List<Alumno> Alumnos;
        Empleado Docente;
        string Tema;
        double Cuota;
        double Inscripcion;

        public override string ToString()
        {
            return Tema + " - Prof: " + Docente;
        }

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

        public Alumno cargarAlumno()
        {
            Alumno nuevoAlumno = new Alumno();
            return nuevoAlumno;
        }
    }

    class Presencial : Curso{ }
    class SemiPresencial : Curso{ }
    class NoPresencial : Curso{ }
}
