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
        bool defecto;
        Boolean modificar;
        Pregunta pregunta;

        public NuevaPregunta(List<Pregunta> preguntas, Pregunta preguntaNueva,Boolean modificarPregunta)
        {
            modificar = modificarPregunta;
            pregunta = preguntaNueva;

            InitializeComponent();
        }

        //Carga los elementos en el formulario, si recibe el booleano de modificar tambien introduce todos los datos.
        private void NuevaPregunta_Load(object sender, EventArgs e)
        {

            comboBoxEdad.Items.AddRange(Constantes.Edad);
            comboBoxDificultad.Items.AddRange(Constantes.Dificultad);
            if (modificar == true)
            {
                textBoxTitulo.Text = pregunta.titulo;
                pictureBoxPregunta.ImageLocation = pregunta.imagen;
                comboBoxEdad.SelectedItem = pregunta.edad;
                comboBoxDificultad.SelectedItem = pregunta.dificultad;
                textBoxRespuesta1.Text = pregunta.respuestas[0].respuesta.ToString();
                if (pregunta.respuestas[0].correcte == true)
                {
                    radioButtonRespuesta1.Checked = true;
                }
                textBoxRespuesta2.Text = pregunta.respuestas[1].respuesta.ToString();
                if (pregunta.respuestas[1].correcte == true)
                {
                    radioButtonRespuesta2.Checked = true;
                }
                textBoxRespuesta3.Text = pregunta.respuestas[2].respuesta.ToString();
                if (pregunta.respuestas[2].correcte == true)
                {
                    radioButtonRespuesta3.Checked = true;
                }
                textBoxRespuesta4.Text = pregunta.respuestas[3].respuesta.ToString();
                if (pregunta.respuestas[3].correcte == true)
                {
                    radioButtonRespuesta4.Checked = true;
                }
            }

        }

        //Dependiendo de el idioma que reciba por parametro cargara un JSON u otro.
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

        //Guarda los datos en el JSON
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


        //Se comprueba que el fichero JSON existe.
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


        //Comprueba que todos los campos esten completados, y luego los guarda.
        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (textBoxTitulo.Text == "" || comboBoxEdad.Text == "IDIOMA" || comboBoxDificultad.Text == "DIFICULTAD" || textBoxRespuesta1.Text == "" || textBoxRespuesta2.Text == "" || textBoxRespuesta3.Text == "" || textBoxRespuesta4.Text == "")
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
                guardarFichero();
                this.Close();
                
            }
        }

        //Depende de donde se de se abre desde una carpeta inicial o no. SOLUCIONADO!!!

        private void pictureBoxPregunta_Click(object sender, EventArgs e)
        {
            defecto = false;
            subirImagen(defecto);
        }

        private void buttonImatgeDefecte_Click(object sender, EventArgs e)
        {
            defecto = true;
            subirImagen(defecto);
        }

        private void subirImagen(bool defecto)
        {
            string rutaImagenes = @"..\..\Resources\JSON\imagenes\\";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string path = System.IO.Directory.GetCurrentDirectory();
            path += "\\ImagenesDefecto";


            //NO FUNCIONA

            if (defecto == true){
                openFileDialog.InitialDirectory = path;
            }
            

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
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

        private void comboBoxEdad_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CAMBIO A LAS COMBOBOX!
            comboBoxEdad.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void comboBoxDificultad_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CAMBIO A LAS COMBOBOX!
            comboBoxDificultad.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
    }
