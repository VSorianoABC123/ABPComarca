﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaABPComarca
{
    class Pregunta
    {
        public string pregunta { get; set; }
        public string imagen { get; set; }
        public string dificultad { get; set; }
        public string edad { get; set; }
        public List<Respuesta> respuestas { get; set; }

        public Pregunta(){

            }


    }
}