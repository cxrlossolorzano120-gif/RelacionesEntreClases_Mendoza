using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelacionesEntreClases_Mendoza.Entidades
{
    public class Proyecto
    {
        private string idProyecto;
        private string nombreProyecto;
        private string tipoDiseno;
        private double presupuesto;
        private DateTime fechaInicio;
        private DateTime fechaEntrega;
        private string estado;

        private Material material;

        public Proyecto()
        {
        }
        public Proyecto(string idProyecto, string nombreProyecto,
            string tipoDiseno, double presupuesto,
            DateTime fechaInicio, DateTime fechaEntrega,
            string estado, Material material)
        {
            this.idProyecto = idProyecto;
            this.nombreProyecto = nombreProyecto;
            this.tipoDiseno = tipoDiseno;
            this.presupuesto = presupuesto;
            this.fechaInicio = fechaInicio;
            this.fechaEntrega = fechaEntrega;
            this.estado = estado;
            this.material = material;
        }

        public string IdProyecto { get => idProyecto; set => idProyecto = value; }
        public string NombreProyecto { get => nombreProyecto; set => nombreProyecto = value; }
        public string TipoDiseno { get => tipoDiseno; set => tipoDiseno = value; }
        public double Presupuesto { get => presupuesto; set => presupuesto = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaEntrega { get => fechaEntrega; set => fechaEntrega = value; }
        public string Estado { get => estado; set => estado = value; }
        public Material Material { get => material; set => material = value; }

        public double TotalProyecto()
        {
            double total = presupuesto + material.CalcularCosto();
            return total;
        }

        public string ImprimirProyecto()
        {
            string men = "ID Proyecto: " + idProyecto + "\n" +
                         "Nombre Proyecto: " + nombreProyecto + "\n" +
                         "Tipo Diseño: " + tipoDiseno + "\n" +
                         "Presupuesto: $" + presupuesto + "\n" +
                         "Fecha Inicio: " + fechaInicio.ToShortDateString() + "\n" +
                         "Fecha Entrega: " + fechaEntrega.ToShortDateString() + "\n" +
                         "Estado: " + estado + "\n\n" +

                         "DATOS DEL MATERIAL\n\n" +
                         material.ImprimirMaterial() + "\n\n" +

                         "TOTAL PROYECTO: $" + TotalProyecto();

            return men;
        }
    }
}
