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
    /// Lógica de interacción para modificarCurso.xaml
    /// </summary>
    public partial class ABMCurso : Window
    {
        public ABMCurso(Curso cursoEnviado)
        {
            InitializeComponent();

            //Recibo datos de entrada y completo los campos del formulario
            curso = cursoEnviado;
            lbxAlumnosDeCurso.ItemsSource = cursoEnviado.alumnos;

            //Utilizar los datos para rellenar el contenido del formulario
            txbTema.Text = curso.tema;
            dtpTurno.Text = Convert.ToString(curso.turno);
            txbCuota.Text = Convert.ToString(curso.cuota);
            txbInscripcion.Text = Convert.ToString(curso.inscripcion);
            cboTipo.Text = curso.tipo;


            //Si el curso tiene un docente asignado se muestra su nombre en el label de nombre docente
            if (cursoEnviado.docente != null)
            {
                lblDocente.Content = cursoEnviado.docente;
            }

            //Si la lista de alumnos del curso no esta vacia y tiene un docente asignado se muestra el btn de exportar
            if (cursoEnviado.docente != null && cursoEnviado.alumnos.Count() >0)
            {
                btnExportar.Visibility = Visibility.Visible;
            }
        }

        //Variables auxiliares
        Curso curso;

        private void btnExportar_Click(object sender, RoutedEventArgs e)
        {
            //Genero un archivo csv cuyo nombre sera el del profesor mas el curso que dicta
            HelperDeArchivos.CargarArchivo(curso.alumnos, curso.docente.apellido +" - "+ curso.docente.nombre + " (" + curso.tema + ").csv");
            //Hacer que el btn desaparezca una vez que ya se haya exportado el archivo
            btnExportar.Visibility = Visibility.Collapsed;
            lblListo.Visibility = Visibility.Visible;
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            //Asigno los valores de los campos del formulario al objeto
            curso.tema = txbTema.Text;
            curso.turno = Convert.ToDateTime(dtpTurno.Text);
            curso.cuota = Convert.ToDouble(txbCuota.Text);
            curso.inscripcion = Convert.ToDouble(txbInscripcion.Text);
            curso.tipo = cboTipo.Text;

            this.Close();
        }
    }
}
