using SistemaNominas_ClasesAbstractas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelacionesEntreClases_Mendoza.Entidades
{
    public class Cliente : Persona
    {
        private string tipo;
        private string empresa;
        private DateTime fechaPedido;
        private double monto;

        public Cliente()
            : base()
        {
        }

        public Cliente(string codigo, string cedula, string apellido, string nombre, char sexo, DateTime fechanaci,
            string estado, string direccion, string telefono,string tipo, string empresa, DateTime fechaPedido,  double monto)
            : base(codigo, cedula, apellido, nombre, sexo, fechanaci, estado, direccion, telefono)
        {
            this.tipo = tipo;
            this.empresa = empresa;
            this.fechaPedido = fechaPedido;
            this.monto = monto;
        }

        public string Tipo { get => tipo; set => tipo = value; }
        public string Empresa { get => empresa; set => empresa = value; }
        public DateTime FechaPedido { get => fechaPedido; set => fechaPedido = value; }
        public double Monto { get => monto; set => monto = value; }


        public double Descuento()
        {
            double descuento = 0;
            if (tipo.Equals("Regular"))
            {
                descuento = monto * 0.05;
            }
            else if (tipo.Equals("Premium"))
            {
                descuento = monto * 0.1;
            }
            return descuento;
        }


    }
}
