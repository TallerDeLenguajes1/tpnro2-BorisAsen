using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TP2_Bliblioteca_de_Clases;

namespace TP2_WPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //cargar listas de Alumnos, Cursos y Empleados con archivos csv
            //const string FileName = "Alumnos.csv";
            HelperDeArchivos.CargarListaAlumnos(Alumnos,"Listas Precargadas/Alumnos.csv");
            HelperDeArchivos.CargarListaEmpleados(Empleados, "Listas Precargadas/Empleados.csv");
            HelperDeArchivos.CargarListaCursos(Cursos, "Listas Precargadas/Cursos.csv");

            lbxAlumnos.ItemsSource = Alumnos;
            lbxEmpelados.ItemsSource = Empleados;
            lbxCursos.ItemsSource = Cursos;
        }

        //Crear lista de cursos
        List<Curso> Cursos = new List<Curso>();
        //Crear lista de alumnos
        List<Alumno> Alumnos = new List<Alumno>();
        //Crear loista de empleados
        List<Empleado> Empleados = new List<Empleado>();

        //Colores predefinidos utiles
        SolidColorBrush correcto = new SolidColorBrush(Colors.Gainsboro);
        SolidColorBrush incorrecto = new SolidColorBrush(Colors.Red);

        //---------------------------CARGAR DATOS---------------------------//


        //---------------------------AGREGAR CURSO---------------------------//
        private void btnCurso_Click(object sender, RoutedEventArgs e)
        {
            //Control de campos vacios

            //Cambio de colores (Opcional)
            if (txbTema.Text == "") txbTema.BorderBrush = incorrecto;
            if (dtpTurno.Text == "") txbTema.BorderBrush = incorrecto;
            if (txbCuota.Text == "") txbCuota.BorderBrush = incorrecto;
            if (txbInscripcion.Text == "") txbInscripcion.BorderBrush = incorrecto;
            if (cboTipo.Text == "") cboTipo.BorderBrush = incorrecto;

            if (txbTema.Text == "" || dtpTurno.Text == "" || txbCuota.Text == "" || txbInscripcion.Text == "" || cboTipo.Text == "")
            {
                lblErrorCursos.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                //Cambio de colores (Opcional)
                lblErrorCursos.Visibility = Visibility.Collapsed;
                txbTema.BorderBrush = correcto;
                txbTema.BorderBrush = correcto;
                txbCuota.BorderBrush = correcto;
                txbInscripcion.BorderBrush = correcto;
                cboTipo.BorderBrush = correcto;
            }

            //Declaracion de variables para tomar el contenido del formulario
            string tema = txbTema.Text;
            DateTime turno = dtpTurno.SelectedDate.Value;
            double cuota = Convert.ToDouble(txbCuota.Text);
            double inscripcion = Convert.ToDouble(txbInscripcion.Text);
            string tipo = cboTipo.Text;


            //Creo nuevo curso segun el tipo y cargo los valores tomados
            Curso nuevoCurso;
            switch (tipo)
            {
                case "Presencial":
                    nuevoCurso = new Presencial(turno,tema,cuota,inscripcion);
                    break;
                case "Semipresencial":
                    nuevoCurso = new SemiPresencial(turno, tema, cuota, inscripcion);
                    break;
                case "No presencial":
                    nuevoCurso = new NoPresencial(turno, tema, cuota, inscripcion);
                    break;
                default:
                    nuevoCurso = new Presencial(turno, tema, cuota, inscripcion);
                    break;
            }
            Cursos.Add(nuevoCurso);
            lbxCursos.Items.Refresh();
        }

        //---------------------------MODIFICAR CURSO---------------------------//
        private void lbxCursos_DoubleCLick(object sender, RoutedEventArgs e)
        {
            //Controla que al hacer click en otra parte del lbx que nos ea un item no se abra la ventana de modificar con una referencia nula
            if (lbxCursos.SelectedItem != null)
            {
                ABMCurso modificarCurso = new ABMCurso((Curso)lbxCursos.SelectedItem);
                modificarCurso.Owner = this;
                modificarCurso.ShowDialog();
                lbxCursos.Items.Refresh();
            }
        }



        //---------------------------AGREGAR ALUMNO---------------------------//
        private void btnAlumno_Click(object sender, RoutedEventArgs e)
        {
            //Control de campos vacios

            //Cambio de colores (Opcional)
            if (txbDNI.Text == "") txbDNI.BorderBrush = incorrecto;
            if (txbNombre.Text == "") txbNombre.BorderBrush = incorrecto;
            if (txbApellido.Text == "") txbApellido.BorderBrush = incorrecto;
            if (dtpNacimiento.Text == "") dtpNacimiento.BorderBrush = incorrecto;
            
            if (txbDNI.Text == "" || txbNombre.Text == "" || txbApellido.Text == "" || dtpNacimiento.Text == "")
            {
                lblErrorAlumnos.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                //Cambio de colores (Opcional)
                lblErrorAlumnos.Visibility = Visibility.Collapsed;
                txbDNI.BorderBrush = correcto;
                txbNombre.BorderBrush = correcto;
                txbApellido.BorderBrush = correcto;
                dtpNacimiento.BorderBrush = correcto;
            }

            //Declaracion de variables para tomar el contenido del formulario
            int dni = Convert.ToInt32(txbDNI.Text);
            string nombre = txbNombre.Text;
            string apellido = txbApellido.Text;
            DateTime fechaDeNacimiento = dtpNacimiento.SelectedDate.Value;

            //Creo nuevo alumno y lo agrego a la lista y listbox
            Alumno nuevoAlumno = new Alumno(dni, nombre, apellido, fechaDeNacimiento);
            Alumnos.Add(nuevoAlumno);
            lbxAlumnos.Items.Refresh();
        }

        //---------------------------MODIFICAR ALUMNO---------------------------//
        private void lbxAlumnos_DoubleCLick(object sender, RoutedEventArgs e)
        {
            //Controla que al hacer click en otra parte del lbx que nos ea un item no se abra la ventana de modificar con una referencia nula
            if (lbxAlumnos.SelectedItem != null)
            {
                ABMAlumno modificarAlumno = new ABMAlumno(Cursos, (Alumno)lbxAlumnos.SelectedItem);
                modificarAlumno.Owner = this;
                modificarAlumno.ShowDialog();
                lbxAlumnos.Items.Refresh();
            }
        }


        //---------------------------AGREGAR EMPLEADO---------------------------//
        private void btnEmpleado_Click(object sender, RoutedEventArgs e)
        {
            //Declaracion de variables para tomar el contenido del formulario
            int dni = Convert.ToInt32(txbEmpleadoDNI.Text);
            string nombre = txbEmpleadoNombre.Text;
            string apellido = txbEmpleadoApellido.Text;
            DateTime fechaDeNacimiento = dtpEmpleadoNacimiento.SelectedDate.Value;
            DateTime fechaDeAlta = dtpEmpleadoAlta.SelectedDate.Value;
            double sueldo = Convert.ToDouble(txbEmpleadoSueldo.Text);
            string cargo = cbxEmpleadoCargo.Text;


            //Creo nuevo empleado segun el cargo que ocupe y lo agrego a la lista y al lbx
            Empleado nuevoEmpleado;
            switch (cargo)
            {
                case "Administrativo":
                    nuevoEmpleado = new Empleado(dni, nombre, apellido, fechaDeNacimiento, fechaDeAlta, sueldo, Enum.GetName(typeof(Cargos), 0));
                    break;
                case "Docente":
                    nuevoEmpleado = new Empleado(dni, nombre, apellido, fechaDeNacimiento, fechaDeAlta, sueldo, Enum.GetName(typeof(Cargos),1));
                    break;
                case "Limpieza":
                    nuevoEmpleado = new Empleado(dni, nombre, apellido, fechaDeNacimiento, fechaDeAlta, sueldo, Enum.GetName(typeof(Cargos), 2));
                    break;
                default:
                    nuevoEmpleado = new Empleado(dni, nombre, apellido, fechaDeNacimiento, fechaDeAlta, sueldo, Enum.GetName(typeof(Cargos), 0));
                    break;
            }
            Empleados.Add(nuevoEmpleado);
            lbxEmpelados.Items.Refresh();
        }

        //---------------------------MODIFICAR EMPLEADO---------------------------//
        private void lbxEmpleados_DoubleCLick(object sender, RoutedEventArgs e)
        {
            //Controla que al hacer click en otra parte del lbx que nos ea un item no se abra la ventana de modificar con una referencia nula
            if (lbxEmpelados.SelectedItem != null)
            {
                ABMEmpleado ABMEmleado = new ABMEmpleado(Empleados, Cursos, (Empleado)lbxEmpelados.SelectedItem);
                ABMEmleado.Owner = this;
                ABMEmleado.ShowDialog();
                lbxEmpelados.Items.Refresh();
            }
        }

    }
}
