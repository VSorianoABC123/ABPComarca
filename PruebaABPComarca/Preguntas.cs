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
    public partial class Preguntas : Form
    {
        List<Pregunta> preguntas = new List<Pregunta>();
        public Preguntas(string idioma)
        {
            InitializeComponent();
        }

        private void Preguntas_Load(object sender, EventArgs e)
        {
            BloqueoBotones();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {

        }

        private void buttonCrear_Click(object sender, EventArgs e)
        {

        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {

        }

        //Para que no se pueda elegir nada sin haber objetos en el json
        private void BloqueoBotones()
        {
            if (preguntas.Count() == 0)
            {
                buttonEditar.Enabled = false;
                buttonBorrar.Enabled = false;
            }
            else
            {
                buttonEditar.Enabled = true;
                buttonBorrar.Enabled = true;
            }
        }
        private void refrescar()
        {
            dataGridViewPreguntas.DataSource = null;
            dataGridViewPreguntas.DataSource = preguntas;
            BloqueoBotones();


        }

        private void guardarFichero()
        {
            string ruta = rutaIdioma();
            JArray jArrayPreguntas = (JArray)JToken.FromObject(preguntas);

            StreamWriter fichero = File.CreateText(ruta);
            JsonTextWriter jsonwriter = new JsonTextWriter(fichero);

            jArrayPreguntas.WriteTo(jsonwriter);

            jsonwriter.Close();

            MessageBox.Show("Guardado correctamente", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }



        private string rutaIdioma()
        {
            string ruta = "";
            String Idioma = comboBoxIdiomes.Text;
            switch (Idioma)
            {
                case "Català":
                    ruta = @"..\..\Resources\JSON\preguntesCAT.json";
                    break;

                case "Castellano":
                    ruta = @"..\..\Resources\JSON\preguntesES.json";
                    break;

                case "English":
                    ruta = @"..\..\Resources\JSON\preguntesEN.json";
                    break;
            }
            return ruta;
        }

        private void comprobarFichero(String ruta)
        {
            //VACIAMOS LA LISTA
            preguntas.Clear();

            if (System.IO.File.Exists(ruta))
            {
                //MessageBox.Show("El fichero existe");
                JArray jArrayPreguntas = JArray.Parse(File.ReadAllText(ruta));
                preguntas = jArrayPreguntas.ToObject<List<Pregunta>>();
            }
            else
            {
                MessageBox.Show("No existe fichero con preguntas del idioma seleccionado", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


    }
}
