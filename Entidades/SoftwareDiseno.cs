using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelacionesEntreClases_Mendoza.Entidades
{
    public class SoftwareDiseno
    {
        private string codigoSoftware;
        private string nombreSoftware;
        private string version;
        private string licencia;
        private double precio;

        public SoftwareDiseno()
        {
        }

        public SoftwareDiseno(string codigoSoftware,
            string nombreSoftware,
            string version,
            string licencia,
            double precio)
        {
            this.codigoSoftware = codigoSoftware;
            this.nombreSoftware = nombreSoftware;
            this.version = version;
            this.licencia = licencia;
            this.precio = precio;
        }

        public string CodigoSoftware { get => codigoSoftware; set => codigoSoftware = value; }
        public string NombreSoftware { get => nombreSoftware; set => nombreSoftware = value; }
        public string Version { get => version; set => version = value; }
        public string Licencia { get => licencia; set => licencia = value; }
        public double Precio { get => precio; set => precio = value; }

        public double Descuento()
        {
            double descuento = 0;

            if (precio > 100)
            {
                descuento = precio * 0.10;
            }

            return descuento;
        }

        public double TotalPagar()
        {
            double total = precio - Descuento();

            return total;
        }

        public string ImprimirSoftware()
        {
            string men = "Codigo Software: " + codigoSoftware + "\n" +
                         "Nombre Software: " + nombreSoftware + "\n" +
                         "Version: " + version + "\n" +
                         "Licencia: " + licencia + "\n" +
                         "Precio: $" + precio + "\n" +
                         "Descuento: $" + Descuento() + "\n" +
                         "Total Pagar: $" + TotalPagar();

            return men;
        }
    }
}
