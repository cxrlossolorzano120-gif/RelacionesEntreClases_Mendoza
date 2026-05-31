using SistemaNominas_ClasesAbstractas.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//autor: Mendoza Jennifer 4toA
namespace RelacionesEntreClases_Mendoza.Controladores
{
    public class TListaPersona
    {
        public static List<Persona> Lista_Persona = new List<Persona>();
        public static void Insert(Persona pe)
        {
            Lista_Persona.Add(pe);
        }
        public static void Edit(int pos, Persona pe)
        {
            Lista_Persona[pos] = pe;
        }
        public static void Delete(int pos)
        {
            Lista_Persona.RemoveAt(pos);
        }
        public static int Buscar(string cod)
        {
            int pos = -1;
            for (int i = 0; i < Lista_Persona.Count; i++)
            {
                if (Lista_Persona[i].Codigo.Equals(cod))
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }
        public static Persona GetPersona(int id)
        {
            return Lista_Persona[id];
        }
        public static List<Persona> GetPersonas(string cedula)
        {
            List<Persona> lista = new List<Persona>();
            for (int i = 0; TListaPersona.Lista_Persona.Count > i; i++)
            {
                if (TListaPersona.Lista_Persona[i].Cedula.Equals(cedula))
                {
                    lista.Add(TListaPersona.Lista_Persona[i]);
                }
            }
            return lista;
        }
    }
}

