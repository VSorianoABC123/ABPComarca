using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaABPComarca
{
    public partial class PantallaPrincipal : Form
    {
        public PantallaPrincipal()
        {
            InitializeComponent();
        }
        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {
            //EL IDIOMA DEL PROGRAMA NO CAMBIA, ESTO UNICAMENTE ELIGE EL JSON QUE SE CARGARÁ
            comboBoxIdiomas.Items.AddRange(Constantes.Idiomas);
        }

        private void ButtonPreguntas_Click(object sender, EventArgs e)
        {
            if (comboBoxIdiomas.Text == "IDIOMA")
            {
                MessageBox.Show("Por favor, elige un idioma!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                //Le pasamos el idioma por parametro
                Preguntas pregunta = new Preguntas();
                pregunta.Text = comboBoxIdiomas.Text;


                pregunta.Show();
            }

        }

        private void ButtonPersonajes_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CAMBIO A LAS COMBOBOX!
            comboBoxIdiomas.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
