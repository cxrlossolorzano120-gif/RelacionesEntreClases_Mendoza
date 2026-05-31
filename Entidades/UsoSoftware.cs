using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelacionesEntreClases_Mendoza.Entidades
{
    public class UsoSoftware
    {
        private string codigoUso;
        private Disenador disenador;
        private SoftwareDiseno software;

        public UsoSoftware()
        {
        }

        public UsoSoftware(string codigoUso,
            Disenador disenador,
            SoftwareDiseno software)
        {
            this.codigoUso = codigoUso;
            this.disenador = disenador;
            this.software = software;
        }

        public string CodigoUso { get => codigoUso; set => codigoUso = value; }
        public Disenador Disenador { get => disenador; set => disenador = value; }
        public SoftwareDiseno Software { get => software; set => software = value; }

        public string NombreDisenador
        {
            get { return disenador.Nombre; }
        }

        public string Especialidad
        {
            get { return disenador.Especialidad; }
        }

        public string NombreSoftware
        {
            get { return software.NombreSoftware; }
        }

        public string Licencia
        {
            get { return software.Licencia; }
        }

        public double Precio
        {
            get { return software.Precio; }
        }
    }
}
