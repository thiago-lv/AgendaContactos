using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDeContactos
{
    internal class OpcionIncorrecta : Exception
    {
        private string mensaje;
        public OpcionIncorrecta(string mensaje) : base (mensaje) {
        }
    }
}
