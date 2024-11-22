using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDeContactos
{
    internal class Contacto
    {
        private string nombre,apellido;
        private int numero;

        //Constructor
        public Contacto(string nombre, string apellido, int numero)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.numero = numero;

        }
        // Propiedades
        public string NOMBRE { get { return this.nombre; }
            set { this.nombre = value; } 
        }
        public string APELLIDO
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }
        public int NUMERO
        {
            get { return numero; }
            set { this.numero = value; }
        }
        // Metodos
    }
}
