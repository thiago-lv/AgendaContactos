using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDeContactos
{
    internal class Usuario
    {
        private string nombre, apellido;
        private int numero;
        private ArrayList listaContactos; 
        // Constructor
        public Usuario(string nombre, string apellido, int numero)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.numero = numero;
            this.listaContactos = new ArrayList();
        } 
        // Propiedades
        public string NOMBRE { 
            get { return this.nombre; }
            set { this.nombre = value; }
            }
        public string APELLIDO { 
            get { return this.apellido; }
            set { this.apellido = value; }
        }
        public int NUMERO { 
            get { return this.numero; } 
            set { this.numero = value; }
        }
        public ArrayList LISTACONTACTOS {
            get { return this.listaContactos; }
            set { this.listaContactos = value; }
        }
        // Metodos
        public void AgregarContacto(Contacto x) { 
            listaContactos.Add(x);
        }
        public bool EliminarContacto(string x)
        {
            foreach (Contacto b in this.listaContactos)
            {
                if (b.NOMBRE == x)
                {
                    listaContactos.Remove(b);
                    return true;
                }
            }
            return false;
        }
    }
}
