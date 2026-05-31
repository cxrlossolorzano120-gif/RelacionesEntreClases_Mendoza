using RelacionesEntreClases_Mendoza.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelacionesEntreClases_Mendoza.Controladores
{
    public class TListaFactura
    {
        public static List<Factura> Lista_Factura = new List<Factura>();

        public static void Insert(Factura fc)
        {
            Lista_Factura.Add(fc);
        }

        public static void Edit(int pos, Factura fc)
        {
            Lista_Factura[pos] = fc;
        }

        public static void Delete(int pos)
        {
            Lista_Factura.RemoveAt(pos);
        }

        public static int Buscar(string cod)
        {
            int pos = -1;

            for (int i = 0; i < Lista_Factura.Count; i++)
            {
                if (Lista_Factura[i].NumeroFactura.Equals(cod))
                {
                    pos = i;
                    break;
                }
            }

            return pos;
        }

        public static Factura GetFactura(int id)
        {
            return Lista_Factura[id];
        }

        public static List<Factura> GetFacturas(string cliente)
        {
            List<Factura> lista = new List<Factura>();

            for (int i = 0; i < TListaFactura.Lista_Factura.Count; i++)
            {
                if (TListaFactura.Lista_Factura[i].Cliente.Nombre.Equals(cliente))
                {
                    lista.Add(TListaFactura.Lista_Factura[i]);
                }
            }

            return lista;
        }
    }
}
