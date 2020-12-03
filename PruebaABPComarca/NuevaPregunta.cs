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
    public partial class NuevaPregunta : Form
    {
        List<Pregunta> preguntas = new List<Pregunta>();
        String enlace;
        bool defecto;

        public NuevaPregunta()
        {
            InitializeComponent();
        }
        private void NuevaPregunta_Load(object sender, EventArgs e)
        {

            comboBoxEdad.Items.AddRange(Constantes.Edad);
            comboBoxDificultad.Items.AddRange(Constantes.Dificultad);

        }

        private string rutaIdioma()
        {
            string ruta = "";
            String Idioma = this.Text;
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

        internal void FormClosed()
        {
            throw new NotImplementedException();
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
                //MessageBox.Show("Fichero creado");
                StreamWriter fichero = File.CreateText(ruta);
                fichero.Close();
            }

        }



        private void checkBoxRespuesta4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (textBoxTitulo.Text == "" || comboBoxEdad.Text == "" || comboBoxDificultad.Text == "" || textBoxRespuesta1.Text == "" || textBoxRespuesta2.Text == "" || textBoxRespuesta3.Text == "" || textBoxRespuesta4.Text == "")
            {
                MessageBox.Show("Faltan campos por completar", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                String ruta = rutaIdioma();
                comprobarFichero(ruta);

                Pregunta pregunta = new Pregunta();
                pregunta.titulo = textBoxTitulo.Text;
                pregunta.imagen = pictureBoxPregunta.ImageLocation;
                pregunta.edad = comboBoxEdad.Text;
                pregunta.dificultad = comboBoxDificultad.Text;
                pregunta.respuestas = new List<Respuesta>();

                if (textBoxRespuesta1.Text != "")
                {
                    Respuesta respuesta = new Respuesta();
                    respuesta.respuesta = textBoxRespuesta1.Text;
                    if (radioButtonRespuesta1.Checked == true)
                    {
                        respuesta.correcte = true;
                    }
                    else
                    {
                        respuesta.correcte = false;
                    }

                    pregunta.respuestas.Add(respuesta);
                }

                if (textBoxRespuesta2.Text != "")
                {
                    Respuesta respuesta = new Respuesta();
                    respuesta.respuesta = textBoxRespuesta2.Text;
                    if (radioButtonRespuesta2.Checked == true)
                    {
                        respuesta.correcte = true;
                    }
                    else
                    {
                        respuesta.correcte = false;
                    }

                    pregunta.respuestas.Add(respuesta);
                }

                if (textBoxRespuesta3.Text != "")
                {
                    Respuesta respuesta = new Respuesta();
                    respuesta.respuesta = textBoxRespuesta3.Text;
                    if (radioButtonRespuesta3.Checked == true)
                    {
                        respuesta.correcte = true;
                    }
                    else
                    {
                        respuesta.correcte = false;
                    }

                    pregunta.respuestas.Add(respuesta);

                }

                if (textBoxRespuesta4.Text != "")
                {
                    Respuesta respuesta = new Respuesta();
                    respuesta.respuesta = textBoxRespuesta4.Text;
                    if (radioButtonRespuesta4.Checked == true)
                    {
                        respuesta.correcte = true;
                    }
                    else
                    {
                        respuesta.correcte = false;
                    }

                    pregunta.respuestas.Add(respuesta);

                }

                preguntas.Add(pregunta);

                //LLAMAMOS A LA FUNCION DE GUARDAR
                guardarFichero();
                //CERRAMOS EL FORM
                Preguntas formPregunta = new Preguntas();
                formPregunta.Text = this.Text;
                this.Close();
                formPregunta.ShowDialog();
                
            }
        }

        private void pictureBoxPregunta_Click(object sender, EventArgs e)
        {
            enlace = "";
            defecto = false;
            subirImagen(enlace, defecto);
        }

        private void buttonImatgeDefecte_Click(object sender, EventArgs e)
        {
            enlace = @"..\..\Resources\ImagenesDefecto\";
            defecto = true;
            subirImagen(enlace, defecto);
        }

        private void subirImagen(string enlace, bool defecto)
        {
            string rutaImagenes = @"..\..\Resources\JSON\imagenes\";
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (defecto == true){
                openFileDialog.InitialDirectory = enlace;
            }
            

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //pictureBoxPregunta.ImageLocation = openFileDialog.FileName;
                //pictureBoxPregunta.BackgroundImageLayout = ImageLayout.Stretch;
                if (pictureBoxPregunta.ImageLocation == null)
                {
                    if (openFileDialog.FileName.EndsWith(".png"))
                    {
                        rutaImagenes += "imagen" + DateTime.Now.Ticks.ToString() + ".png";
                    }
                    else if (openFileDialog.FileName.EndsWith(".jpg"))
                    {
                        rutaImagenes += "imagen" + DateTime.Now.Ticks.ToString() + ".jpg";
                    }
                    else if (openFileDialog.FileName.EndsWith(".jpeg"))
                    {
                        rutaImagenes += "imagen" + DateTime.Now.Ticks.ToString() + ".jpeg";
                    }

                    pictureBoxPregunta.BackgroundImageLayout = ImageLayout.Stretch;

                    File.Copy(openFileDialog.FileName, rutaImagenes);
                    pictureBoxPregunta.ImageLocation = rutaImagenes;

                }

                else
                {
                    File.Delete(pictureBoxPregunta.ImageLocation);

                    if (openFileDialog.FileName.EndsWith(".png"))
                    {
                        rutaImagenes += "imagen" + DateTime.Now.Ticks.ToString() + ".png";
                    }
                    else if (openFileDialog.FileName.EndsWith(".jpg"))
                    {
                        rutaImagenes += "imagen" + DateTime.Now.Ticks.ToString() + ".jpg";
                    }
                    else if (openFileDialog.FileName.EndsWith(".jpeg"))
                    {
                        rutaImagenes += "imagen" + DateTime.Now.Ticks.ToString() + ".jpeg";
                    }
                    File.Copy(openFileDialog.FileName, rutaImagenes);
                    pictureBoxPregunta.ImageLocation = rutaImagenes;

                }
                // rutaDefinitiva = rutaImagenes.Substring(16);
            }

        }

       
    }
    }
