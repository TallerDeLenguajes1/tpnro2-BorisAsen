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
    public partial class modificarAlumno : Window
    {
        //public modificarAlumno()
        public modificarAlumno(List<Alumno> Alumnos, int i)
        {
            InitializeComponent();

            //Recibir los parametros
            listaAlumnos = Alumnos;
            indice = i;

            //Utilizar los datos para rellenar el contenido del formulario
            string datosAlumno = ",,,";
            if (indice != -1)
            {
                datosAlumno = listaAlumnos[indice].ToString();
            }

            string[] datos = datosAlumno.Split(',');

            txbDNIMod.Text = datos[0];
            txbApellidoMod.Text = datos[1];
            txbNombreMod.Text = datos[2];
            dtpNacimientoMod.Text = datos[3];


            //Mostrar lista obtenida
            foreach (var item in listaAlumnos) testLista.Items.Add(item);
      
        }

        int indice = 0;
        List<Alumno> listaAlumnos;
        

        private void btnModificarAlumno_Click(object sender, RoutedEventArgs e)
        {
            //Borrar item indicado por el indice
            listaAlumnos.RemoveAt(indice);
            testLista.Items.RemoveAt(indice);

            //Generar un nuevo objeto con los valores de los campos
            Alumno objModificado = new Alumno(Convert.ToInt32(txbDNIMod.Text), txbNombreMod.Text, txbApellidoMod.Text, Convert.ToDateTime(dtpNacimientoMod.Text));

            //Insertar el objeto en la lista en la posicion del indice
            listaAlumnos.Insert(indice, objModificado) ;
            testLista.Items.Insert(indice, objModificado);
            //MainWindow.lbxAlumnos.Items.Clear();
            //MainWindow test = new MainWindow();
            //test.lbxAlumnos.Items.RemoveAt(indice);
            //test.lbxAlumnos.Items.Insert(indice, objModificado);


        }
    }
}
