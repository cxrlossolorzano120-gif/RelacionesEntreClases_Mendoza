using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelacionesEntreClases_Mendoza.Entidades
{
    public class DetalleFactura
    {
        private string codigoDetalle;
        private Proyecto proyecto;

        public DetalleFactura()
        {
        }

        public DetalleFactura(string codigoDetalle, Proyecto proyecto)
        {
            this.codigoDetalle = codigoDetalle;
            this.proyecto = proyecto;
        }

        public string CodigoDetalle { get => codigoDetalle; set => codigoDetalle = value; }
        public Proyecto Proyecto { get => proyecto; set => proyecto = value; }

        public double SubtotalDetalle()
        {
            double subtotal = proyecto.TotalProyecto();
            return subtotal;
        }

        public string ImprimirDetalle()
        {
            string men = "Codigo Detalle: " + codigoDetalle + "\n\n" +
                         proyecto.ImprimirProyecto() + "\n\n" +

                         "Subtotal Detalle: $" + SubtotalDetalle();
            return men;
        }
    }
}
