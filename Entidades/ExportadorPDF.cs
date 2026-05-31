using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelacionesEntreClases_Mendoza.Entidades
{
    public class ExportadorPDF
    {
        private string codigoExportacion;
        private DateTime fechaExportacion;
        private string formato;

        public ExportadorPDF()
        {
        }

        public ExportadorPDF(string codigoExportacion,
            DateTime fechaExportacion,
            string formato)
        {
            this.codigoExportacion = codigoExportacion;
            this.fechaExportacion = fechaExportacion;
            this.formato = formato;
        }

        public string CodigoExportacion
        {
            get => codigoExportacion;
            set => codigoExportacion = value;
        }

        public DateTime FechaExportacion
        {
            get => fechaExportacion;
            set => fechaExportacion = value;
        }

        public string Formato
        {
            get => formato;
            set => formato = value;
        }

        public string ExportarProyecto(Proyecto p)
        {
            string men =
                "===== REPORTE PDF =====\n\n" +
                "Codigo Proyecto: " + p.IdProyecto + "\n" +
                "Nombre Proyecto: " + p.NombreProyecto + "\n" +
                "Tipo Proyecto: " + p.TipoDiseno + "\n" +
                "Estado: " + p.Estado + "\n" +
                "Costo: $" + p.Presupuesto + "\n" +
                "Material: " + p.Material.Nombre + "\n" +
                "Total: $" + p.TotalProyecto() + "\n\n" +

                "Codigo Exportacion: " + codigoExportacion + "\n" +
                "Fecha Exportacion: " + fechaExportacion.ToShortDateString() + "\n" +
                "Formato: " + formato;

            return men;
        }
    }
}
