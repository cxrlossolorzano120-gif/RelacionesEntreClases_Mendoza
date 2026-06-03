using RelacionesEntreClases_Mendoza.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelacionesEntreClases_Mendoza.Controladores
{
    public class TListaExportadorPDF
    {
        public static List<ExportadorPDF> Lista_ExportadorPDF =
            new List<ExportadorPDF>();

        public static void Insert(ExportadorPDF ep)
        {
            Lista_ExportadorPDF.Add(ep);
        }

        public static void Edit(int pos,
            ExportadorPDF ep)
        {
            Lista_ExportadorPDF[pos] = ep;
        }

        public static void Delete(int pos)
        {
            Lista_ExportadorPDF.RemoveAt(pos);
        }

        public static int Buscar(string cod)
        {
            int pos = -1;

            for (int i = 0;
                i < Lista_ExportadorPDF.Count;
                i++)
            {
                if (Lista_ExportadorPDF[i]
                    .CodigoExportacion.Equals(cod))
                {
                    pos = i;
                    break;
                }
            }

            return pos;
        }

        public static ExportadorPDF
            GetExportador(int id)
        {
            return Lista_ExportadorPDF[id];
        }

        public static List<ExportadorPDF>
            GetFormato(string formato)
        {
            List<ExportadorPDF> lista =
                new List<ExportadorPDF>();

            for (int i = 0;
                i < Lista_ExportadorPDF.Count;
                i++)
            {
                if (Lista_ExportadorPDF[i]
                    .Formato.Equals(formato))
                {
                    lista.Add(
                        Lista_ExportadorPDF[i]);
                }
            }
            return lista;
        }
    }
}
