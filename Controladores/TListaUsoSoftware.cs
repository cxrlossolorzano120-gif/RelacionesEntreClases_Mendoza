using RelacionesEntreClases_Mendoza.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelacionesEntreClases_Mendoza.Controladores
{
    public class TListaUsoSoftware
    {
        public static List<UsoSoftware> Lista_UsoSoftware = new List<UsoSoftware>();

        public static void Insert(UsoSoftware us)
        {
            Lista_UsoSoftware.Add(us);
        }

        public static void Edit(int pos, UsoSoftware us)
        {
            Lista_UsoSoftware[pos] = us;
        }

        public static void Delete(int pos)
        {
            Lista_UsoSoftware.RemoveAt(pos);
        }

        public static int Buscar(string cod)
        {
            int pos = -1;

            for (int i = 0; i < Lista_UsoSoftware.Count; i++)
            {
                if (Lista_UsoSoftware[i].CodigoUso.Equals(cod))
                {
                    pos = i;
                    break;
                }
            }

            return pos;
        }

        public static UsoSoftware GetUsoSoftware(int id)
        {
            return Lista_UsoSoftware[id];
        }

        public static List<UsoSoftware> GetSoftware(string licencia)
        {
            List<UsoSoftware> lista = new List<UsoSoftware>();

            for (int i = 0; i < TListaUsoSoftware.Lista_UsoSoftware.Count; i++)
            {
                if (TListaUsoSoftware.Lista_UsoSoftware[i].Software.Licencia.Equals(licencia))
                {
                    lista.Add(TListaUsoSoftware.Lista_UsoSoftware[i]);
                }
            }

            return lista;
        }
    }
}
