using SistemaNominas_ClasesAbstractas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelacionesEntreClases_Mendoza.Entidades
{
    public class Disenador : Persona
    {
        private string especialidad;
        private string nivelProfesional;
        private DateTime fechaContrato;
        private double horastrabajadas;

        public Disenador()
            :base() {
        }

        public Disenador(string codigo, string cedula, string apellido, string nombre, char sexo, DateTime fechanaci,
            string estado, string direccion, string telefono, string especialidad, string nivelProfesional, DateTime fechaContrato, double horastrabajadas)
            : base(codigo, cedula, apellido, nombre, sexo, fechanaci, estado, direccion, telefono)
        {
            this.especialidad = especialidad;
            this.nivelProfesional = nivelProfesional;
            this.fechaContrato = fechaContrato;
            this.horastrabajadas = horastrabajadas;
        }

        public string Especialidad { get => especialidad; set => especialidad = value; }
        public string NivelProfesional { get => nivelProfesional; set => nivelProfesional = value; }
        public DateTime FechaContrato { get => fechaContrato; set => fechaContrato = value; }
        public double Horastrabajadas { get => horastrabajadas; set => horastrabajadas = value; }

        public double CalcularSueldo()
        {
            double sueldo = 0;
                if (nivelProfesional.Equals("Junior"))
                {
                    sueldo = 3000;
                }
                else if (nivelProfesional.Equals("SemiSenior"))
                {
                    sueldo = 5000;
                }
                else if (nivelProfesional.Equals("Senior"))
                {
                    sueldo = 8000;
                }
                return sueldo;
        }

        public double Incentivo()
        {
            double incentivo = 0;
            if (horastrabajadas > 160)
            {
                incentivo = (horastrabajadas - 160) * 20;
            }
            return incentivo;
        }
        public void Imprimir()
        {
            MessageBox.Show("Especialidad: " + especialidad + "\n" +
                        "Nivel Profesional: " + nivelProfesional + "\n" +
                        "Fecha de Contrato: " + fechaContrato.ToShortDateString() + "\n" +
                        "Horas Trabajadas: " + horastrabajadas + "\n" +
                        "Sueldo: $" + CalcularSueldo());
        }
    }
}