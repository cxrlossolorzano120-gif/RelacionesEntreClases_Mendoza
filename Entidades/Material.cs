using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelacionesEntreClases_Mendoza.Entidades
{
    public class Material
    {
        private string codigoMaterial;
        private string nombre;
        private int cantidad;
        private double costoUnitario;

        public Material()
        {
        }

        public Material(string codigoMaterial, string nombre, int cantidad, double costoUnitario)
        {
            this.codigoMaterial = codigoMaterial;
            this.nombre = nombre;
            this.cantidad = cantidad;
            this.costoUnitario = costoUnitario;
        }

        public string CodigoMaterial { get => codigoMaterial; set => codigoMaterial = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double CostoUnitario { get => costoUnitario; set => costoUnitario = value; }

        public double CalcularCosto()
        {
            double total = cantidad * costoUnitario;
            return total;
        }
        public string ImprimirMaterial()
        {
            string men = "Codigo Material: " + codigoMaterial + "\n" +
                         "Nombre: " + nombre + "\n" +
                         "Cantidad: " + cantidad + "\n" +
                         "Costo Unitario: $" + costoUnitario + "\n" +
                         "Costo Total: $" + CalcularCosto();

            return men;
        }
    }
}
