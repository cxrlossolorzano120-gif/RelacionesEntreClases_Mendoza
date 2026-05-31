using RelacionesEntreClases_Mendoza.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelacionesEntreClases_Mendoza.Controladores
{
    public class TListaSoftwareDiseno
    {
        public static List<SoftwareDiseno> Lista_SoftwareDiseno = new List<SoftwareDiseno>();

        public static void Insert(SoftwareDiseno sd)
        {
            Lista_SoftwareDiseno.Add(sd);
        }

        public static void Edit(int pos, SoftwareDiseno sd)
        {
            Lista_SoftwareDiseno[pos] = sd;
        }

        public static void Delete(int pos)
        {
            Lista_SoftwareDiseno.RemoveAt(pos);
        }

        public static int Buscar(string cod)
        {
            int pos = -1;

            for (int i = 0; i < Lista_SoftwareDiseno.Count; i++)
            {
                if (Lista_SoftwareDiseno[i].CodigoSoftware.Equals(cod))
                {
                    pos = i;
                    break;
                }
            }

            return pos;
        }

        public static SoftwareDiseno GetSoftware(int id)
        {
            return Lista_SoftwareDiseno[id];
        }

        public static List<SoftwareDiseno> GetSoftwareDiseno(string licencia)
        {
            List<SoftwareDiseno> lista = new List<SoftwareDiseno>();

            for (int i = 0; i < TListaSoftwareDiseno.Lista_SoftwareDiseno.Count; i++)
            {
                if (TListaSoftwareDiseno.Lista_SoftwareDiseno[i].Licencia.Equals(licencia))
                {
                    lista.Add(TListaSoftwareDiseno.Lista_SoftwareDiseno[i]);
                }
            }

            return lista;
        }
    }
}
