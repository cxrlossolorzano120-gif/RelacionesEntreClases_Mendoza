using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelacionesEntreClases_Mendoza.Entidades
{
    public class Factura
    {
        private string numeroFactura;
        private DateTime fecha;
        private double iva;

        private Cliente cliente;
        private Proyecto proyecto;

        public Factura()
        {
        }

        public Factura(string numeroFactura, DateTime fecha,
            double iva, Cliente cliente, Proyecto proyecto)
        {
            this.numeroFactura = numeroFactura;
            this.fecha = fecha;
            this.iva = iva;
            this.cliente = cliente;
            this.proyecto = proyecto;
        }

        public string NumeroFactura { get => numeroFactura; set => numeroFactura = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public double Iva { get => iva; set => iva = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Proyecto Proyecto { get => proyecto; set => proyecto = value; }

        public double Subtotal()
        {
            double subtotal = proyecto.TotalProyecto();
            return subtotal;
        }

        public double ValorIVA()
        {
            double valor = Subtotal() * (iva / 100);
            return valor;
        }

        public double TotalPagar()
        {
            double total = Subtotal() + ValorIVA();
            return total;
        }

        public string ImprimirFactura()
        {
            string men = "Numero Factura: " + numeroFactura + "\n" +
                         "Fecha: " + fecha.ToShortDateString() + "\n\n" +


                         cliente.ImprimirPersona() + "\n\n" +

                         proyecto.ImprimirProyecto() + "\n\n" +

                         "Subtotal: $" + Subtotal() + "\n" +
                         "IVA: " + iva + "%\n" +
                         "Valor IVA: $" + ValorIVA() + "\n" +
                         "TOTAL PAGAR: $" + TotalPagar();

            return men;
        }
    

    public string NombreCliente
        {
            get { return cliente.Nombre; }
        }

        public string NombreProyecto
        {
            get { return proyecto.NombreProyecto; }
        }

        public string EstadoProyecto
        {
            get { return proyecto.Estado; }
        }

        public double TotalFactura
        {
            get
            {
                return proyecto.TotalProyecto();
            }
        }
    }
}    
