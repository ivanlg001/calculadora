using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calculadora.Models
{
    public class Ecuacion
    {
        public int Id { get; set; }
        public string PrimerEcuacion { get; set; }
        public string SegundaEcuacion { get; set; }
        public string ValorX { get; set; }
        public string ValorY { get; set; }
    }
}