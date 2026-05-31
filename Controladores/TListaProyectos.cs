using RelacionesEntreClases_Mendoza.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelacionesEntreClases_Mendoza.Controladores
{
    public class TListaProyecto
    {
        public static List<Proyecto> Lista_Proyecto = new List<Proyecto>();

        public static void Insert(Proyecto pr)
        {
            Lista_Proyecto.Add(pr);
        }

        public static void Edit(int pos, Proyecto pr)
        {
            Lista_Proyecto[pos] = pr;
        }

        public static void Delete(int pos)
        {
            Lista_Proyecto.RemoveAt(pos);
        }

        public static int Buscar(string cod)
        {
            int pos = -1;

            for (int i = 0; i < Lista_Proyecto.Count; i++)
            {
                if (Lista_Proyecto[i].IdProyecto.Equals(cod))
                {
                    pos = i;
                    break;
                }
            }

            return pos;
        }

        public static Proyecto GetProyecto(int id)
        {
            return Lista_Proyecto[id];
        }

        public static List<Proyecto> GetProyectos(string estado)
        {
            List<Proyecto> lista = new List<Proyecto>();

            for (int i = 0; i < TListaProyecto.Lista_Proyecto.Count; i++)
            {
                if (TListaProyecto.Lista_Proyecto[i].NombreProyecto.Equals(estado))
                {
                    lista.Add(TListaProyecto.Lista_Proyecto[i]);
                }
            }

            return lista;
        }
    }
}
