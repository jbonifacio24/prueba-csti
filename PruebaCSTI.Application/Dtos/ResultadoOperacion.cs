using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCSTI.Application.Dtos
{
    public class ResultadoOperacion
    {
        public bool EsValido { get; set; }
        public string Mensaje { get; set; }

        public static ResultadoOperacion Ok()
        {
            return new ResultadoOperacion { EsValido = true };
        }

        public static ResultadoOperacion Error(string mensaje)
        {
            return new ResultadoOperacion
            {
                EsValido = false,
                Mensaje = mensaje
            };
        }
    }
}
