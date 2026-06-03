using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNominas_ClasesAbstractas.Entidades
{
    public class Persona
    {
        private string codigo;
        private string cedula;
        private string apellido;
        private string nombre;
        private char sexo;
        private DateTime fechanaci;
        private string estado;
        private string direccion;
        private string telefono;

        public string Codigo { get => codigo; set => codigo = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public char Sexo { get => sexo; set => sexo = value; }
        public DateTime Fechanaci { get => fechanaci; set => fechanaci = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
 
        public Persona()
        {
        }

        public Persona(string codigo, string cedula, string apellido, string nombre, char sexo, DateTime fechanaci,
            string estado, string direccion, string telefono)
        {
            this.codigo = codigo;
            this.cedula = cedula;
            this.apellido = apellido;
            this.nombre = nombre;
            this.sexo = sexo;
            this.fechanaci = fechanaci;
            this.estado = estado;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        protected Persona(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public int Edad()
        {
            int age = DateTime.Now.Year - fechanaci.Year;
            if (DateTime.Now.Month < fechanaci.Month || (DateTime.Now.Month == fechanaci.Month && DateTime.Now.Day < fechanaci.Day))
                age--;
            return age;
        }
        
        public Boolean Cumpleaños()
        {
            Boolean var = false;
            if (DateTime.Now.Month == fechanaci.Month && DateTime.Now.Day == fechanaci.Day)
            {
                var = true;
            }
            return var;
        }
        public double BonoCumple()
        {
            double val = 0;
            if (Cumpleaños())
            {
                val = 100;
            }
            return val;
        }
      
        public string ImprimirPersona()
        {
            string men = "Codigo: " + codigo + "\n" +
                         "Cedula: " + cedula + "\n" +
                         "Nombres y Apellidos: " + nombre + " " + apellido + "\n" +
                         "Sexo: " + sexo + "\n" +
                         "Edad: " + Edad() + "\n" +
                         "Estado: " + estado + "\n" +
                         "Direccion: " + direccion + "\n" +
                         "Telefono: " + telefono + "\n";
            return men;
        }
   
    }
}
