using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using TP2_Bliblioteca_de_Clases;

namespace TP2_WPF
{
    /// <summary>
    /// Lógica de interacción para ABMEmpleado.xaml
    /// </summary>
    public partial class ABMEmpleado : Window
    {
        public ABMEmpleado(List<Empleado> Empleados, List<Curso> Cursos, Empleado empEnviado)
        {
            InitializeComponent();

            //Recibir los parametros
            listaEmpleados = Empleados;
            listaCursos = Cursos;
            emp = empEnviado;

            //Utilizar los datos para rellenar el contenido del formulario
            txbModEmpleadoDNI.Text = Convert.ToString(emp.dni);
            txbModEmpleadoApellido.Text = emp.apellido;
            txbModEmpleadoNombre.Text = emp.nombre;
            dtpModEmpleadoNacimiento.Text = Convert.ToString(emp.fechaDeNacimiento);
            dtpModEmpleadoAlta.Text = Convert.ToString(emp.fechaDeAlta);
            txbModEmpleadoSueldo.Text = Convert.ToString(emp.sueldo);
            cbxModEmpleadoCargo.Text = emp.cargo;

            //Mostrar la seccion de Asignar a curso solo si es Docente
            if (emp.cargo == "Docente")
            {
                lblAsignarCurso.Visibility = Visibility.Visible;
                cboCursosDictar.Visibility = Visibility.Visible;
            }
            //Cargar el combobox de dictar curso con todos los cursos que haya en el sistema
            foreach (var item in listaCursos) cboCursosDictar.Items.Add(item);
        }

        //Variables auxiliares para guardar los parametros
        Empleado emp;
        List<Empleado> listaEmpleados;
        List<Curso> listaCursos;

        private void btnModificarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            //Modificar todos los atributos del emp recibido con los campos del formulario
            emp.dni = Convert.ToInt32(txbModEmpleadoDNI.Text) ;
            emp.apellido = txbModEmpleadoApellido.Text;
            emp.nombre = txbModEmpleadoNombre.Text;
            emp.fechaDeNacimiento = Convert.ToDateTime(dtpModEmpleadoNacimiento.Text);
            emp.fechaDeAlta = Convert.ToDateTime(dtpModEmpleadoAlta.Text);
            emp.sueldo = Convert.ToDouble(txbModEmpleadoSueldo.Text);
            emp.cargo = cbxModEmpleadoCargo.Text;

            //Si hay algun item del cboCursosDictar seleccionado asociar ese profesor al curso
            CargarDocenteEnCurso(emp);

            this.Close();
        }

        public void CargarDocenteEnCurso(Empleado emp)
        {
            if (cboCursosDictar.SelectedIndex >= 0 && emp.cargo == "Docente")
            {
                ((Curso)cboCursosDictar.SelectedItem).cargarProfesor(emp);
            }
        }

    }
}
