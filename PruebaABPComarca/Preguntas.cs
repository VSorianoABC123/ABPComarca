using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaABPComarca
{
    public partial class Preguntas : Form
    {
        List<Pregunta> preguntas = new List<Pregunta>();
        Boolean modificarPregunta;
        public Preguntas()
        {
            
            InitializeComponent();
            
        }

        private void Preguntas_Load(object sender, EventArgs e)
        {
            BloqueoBotones();
            String ruta = rutaIdioma();

            String idioma = this.Text;

            switch (idioma)
            {
                case "Català":
                    comprobarFichero(ruta);
                    refrescar();
                    break;

                case "Castellano":
                    comprobarFichero(ruta);
                    refrescar();
                    break;

                case "English":
                    comprobarFichero(ruta);
                    refrescar();
                    break;
            }

        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {

            if (dataGridViewPreguntas.SelectedRows.Count > 0)
            {
                String ruta = rutaIdioma();
                modificarPregunta = true;


                //Elimino la pregunta
                Pregunta pregunta = (Pregunta)dataGridViewPreguntas.SelectedRows[0].DataBoundItem;

                foreach (DataGridViewRow eliminarPregunta in dataGridViewPreguntas.SelectedRows)
                {
                    preguntas.Remove((Pregunta)eliminarPregunta.DataBoundItem);
                }

                guardarFichero();


                NuevaPregunta editarPregunta = new NuevaPregunta(preguntas, pregunta, modificarPregunta);
                editarPregunta.Text = this.Text;
                editarPregunta.ShowDialog();

                //Actualiza el gridView con los datos introducidos
                comprobarFichero(ruta);
                refrescar();

            }
            else
            {
                MessageBox.Show("Error, ninguna pregunta seleccionada", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCrear_Click(object sender, EventArgs e)
        {
            modificarPregunta = false;
            String ruta = rutaIdioma();

            Pregunta pregunta = new Pregunta();
            NuevaPregunta nuevaPregunta = new NuevaPregunta(preguntas, pregunta, modificarPregunta);
            nuevaPregunta.Text = this.Text;            
            nuevaPregunta.ShowDialog();
            preguntas.Add(pregunta);
            
            comprobarFichero(ruta);
            refrescar();


        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            var respuesta = MessageBox.Show("¿Estás seguro que quieres eliminar la pregunta?", "ELIMINAR", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            if (respuesta == DialogResult.Yes)
            {

                if (dataGridViewPreguntas.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow eliminarPregunta in dataGridViewPreguntas.SelectedRows)
                    {
                        preguntas.Remove((Pregunta)eliminarPregunta.DataBoundItem);
                    }
                    refrescar();
                    guardarFichero();

                }
                else
                {
                    MessageBox.Show("Error, ninguna pregunta seleccionada", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
        }



        private string rutaIdioma()
        {
            string ruta = "";
            String idioma = Text;
            switch (idioma)
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
                MessageBox.Show("No existe el fichero con preguntas del idioma seleccionado. Creandolo.", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dataGridViewPreguntas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
