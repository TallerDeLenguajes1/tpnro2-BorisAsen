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
    /// Lógica de interacción para modificarAlumno.xaml
    /// </summary>
    public partial class ABMAlumno : Window
    {
        public ABMAlumno(List<Curso> Cursos, Alumno aluEnviado)
        {
            InitializeComponent();

            //Recibir los parametros
            listaCursos = Cursos;
            alu = aluEnviado;

            //Utilizar los datos para rellenar el contenido del formulario
            txbDNIMod.Text = Convert.ToString(alu.dni);
            txbApellidoMod.Text = Convert.ToString(alu.apellido);
            txbNombreMod.Text = Convert.ToString(alu.nombre);
            dtpNacimientoMod.Text = Convert.ToString(alu.fechaDeNacimiento);


            //Cargar el combobox de inscribir alumno con la lista de cursos
            foreach (var item in listaCursos) cboCurso.Items.Add(item);

        }

        //Variables auxiliares
        List<Curso> listaCursos;
        Alumno alu;


        private void btnModificarAlumno_Click(object sender, RoutedEventArgs e)
        {
            //Si hay algun item del cboCursos seleccionado, inscribir al alumno cuando se presione modificar
            InscribirAlumno(alu);

            //Asigno los valores de los campos del formulario al objeto
            alu.dni = Convert.ToInt32(txbDNIMod.Text);
            alu.apellido = txbApellidoMod.Text;
            alu.nombre = txbNombreMod.Text;
            alu.fechaDeNacimiento = Convert.ToDateTime(dtpNacimientoMod.Text);

            

            this.Close();
        }

        public void InscribirAlumno(Alumno alu)
        {
            if (cboCurso.SelectedIndex >= 0)
            {
                ((Curso)cboCurso.SelectedItem).cargarAlumno(alu);
            }
        }
    }
}
