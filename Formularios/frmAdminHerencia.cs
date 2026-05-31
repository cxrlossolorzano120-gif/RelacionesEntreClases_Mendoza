using RelacionesEntreClases_Mendoza.Controladores;
using RelacionesEntreClases_Mendoza.Entidades;
using SistemaNominas_ClasesAbstractas.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelacionesEntreClases_Mendoza.Formularios
{
    public partial class frmAdminHerencia : Form
    {
        public frmAdminHerencia()
        {
            InitializeComponent();
        }

        private void frmAdminHerencia_Load(object sender, EventArgs e)
        {
            if (TListaPersona.Lista_Persona.Count == 0)
            {
                DatosDisenador();
                DatosCliente();
            }

            MostrarDatos();
        }

        public static void DatosIniciales()
        {
            if (TListaPersona.Lista_Persona.Count == 0)
            {
                TListaPersona.Lista_Persona.Add(new Disenador("D01", "07582", "Jennifer", "Mendoza", 'F', DateTime.Now, "Activo", "Calle 123", "555-1234", "Diseñadora", "Senior", DateTime.Now, 40));
                TListaPersona.Lista_Persona.Add(new Disenador("D02", "07583", "Carlos", "Gomez", 'M', DateTime.Now, "Activo", "Calle 456", "555-5678", "Branding", "Junior", DateTime.Now, 30));
                TListaPersona.Lista_Persona.Add(new Disenador("D03", "07584", "Ana", "Lopez", 'F', DateTime.Now, "Activo", "Calle 789", "555-9012", "Publicidad", "SemiSenior", DateTime.Now, 50));
                TListaPersona.Lista_Persona.Add(new Disenador("D04", "07588", "Luis", "Mera", 'M', DateTime.Now, "Activo", "Av Central", "555-1111", "UX/UI", "Senior", DateTime.Now, 45));
                TListaPersona.Lista_Persona.Add(new Disenador("D05", "07589", "Carla", "Ruiz", 'F', DateTime.Now, "Activo", "Av Quito", "555-2222", "Animacion", "Junior", DateTime.Now, 25));
                TListaPersona.Lista_Persona.Add(new Disenador("D06", "07590", "Mario", "Vera", 'M', DateTime.Now, "Activo", "Av Loja", "555-3333", "Editorial", "SemiSenior", DateTime.Now, 38));
                TListaPersona.Lista_Persona.Add(new Disenador("D07", "07591", "Lucia", "Perez", 'F', DateTime.Now, "Activo", "Av Norte", "555-4444", "Fotografia", "Senior", DateTime.Now, 60));

                TListaPersona.Lista_Persona.Add(new Cliente("C01", "07585", "Perez", "Maria", 'F', DateTime.Now, "Activo", "Calle 123", "555-1234", "Regular", "Empresa A", DateTime.Now, 1000));
                TListaPersona.Lista_Persona.Add(new Cliente("C02", "07586", "Garcia", "Juan", 'M', DateTime.Now, "Activo", "Calle 456", "555-5678", "VIP", "Empresa B", DateTime.Now, 5000));
                TListaPersona.Lista_Persona.Add(new Cliente("C03", "07587", "Rodriguez", "Luis", 'M', DateTime.Now,
                    "Activo", "Calle 789", "555-9012", "Regular", "Empresa C", DateTime.Now, 2000));
                TListaPersona.Lista_Persona.Add(new Cliente("C04", "07592", "Morales", "Andrea", 'F', DateTime.Now, "Activo", "Av Sur", "555-5555", "VIP", "Empresa D", DateTime.Now, 3500));
                TListaPersona.Lista_Persona.Add(new Cliente("C05", "07593", "Torres", "Miguel", 'M', DateTime.Now, "Activo", "Av Sol", "555-6666", "Regular", "Empresa E", DateTime.Now, 800));
                TListaPersona.Lista_Persona.Add(new Cliente("C06", "07594", "Castro", "Diana", 'F', DateTime.Now, "Activo", "Av Luna", "555-7777", "VIP", "Empresa F", DateTime.Now, 4200));
                TListaPersona.Lista_Persona.Add(new Cliente("C07", "07595", "Salazar", "Pedro", 'M', DateTime.Now, "Activo", "Av Rio", "555-8888", "Regular", "Empresa G", DateTime.Now, 1500));
            }
        }

        public void DatosDisenador()
        {
            TListaPersona.Lista_Persona.Add(new Disenador("D01", "07582", "Jennifer", "Mendoza", 'F', DateTime.Now,
                "Activo", "Calle 123", "555-1234", "Diseñadora", "Senior", DateTime.Now, 40));
            TListaPersona.Lista_Persona.Add(new Disenador("D02", "07583", "Carlos", "Gomez", 'M', DateTime.Now,
                "Activo", "Calle 456", "555-5678", "Fijo", "Junior", DateTime.Now, 30));
            TListaPersona.Lista_Persona.Add(new Disenador("D03", "07584", "Ana", "Lopez", 'F', DateTime.Now,
                "Activo", "Calle 789", "555-9012", "Contratados", "Mid-Level", DateTime.Now, 20));
        }

        public void DatosCliente()
        {
            TListaPersona.Lista_Persona.Add(new Cliente("C01", "07585", "Perez", "Maria", 'F', DateTime.Now,
                "Activo", "Calle 123", "555-1234", "Regular", "Empresa A", DateTime.Now, 1000));
            TListaPersona.Lista_Persona.Add(new Cliente("C02", "07586", "Garcia", "Juan", 'M', DateTime.Now,
                "Activo", "Calle 456", "555-5678", "VIP", "Empresa B", DateTime.Now, 5000));
            TListaPersona.Lista_Persona.Add(new Cliente("C03", "07587", "Rodriguez", "Luis", 'M', DateTime.Now,
                "Activo", "Calle 789", "555-9012", "Regular", "Empresa C", DateTime.Now, 2000));
        }
        public void MostrarDatos()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = TListaPersona.Lista_Persona.ToList();
        }
        public void Nuevo()
        {
            try
            {
                frmEditHerencia frm = new frmEditHerencia();
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    Persona ob = frm.CrearObjeto();
                    TListaPersona.Insert(ob);
                    frm.Close();
                    label10.Text = "Registro Ingresado";
                }
                else
                {
                    frm.Close();
                    label10.Text = "Registro Cancelado";
                }
                MostrarDatos();
            }
            catch (Exception ex)
            {
                label10.Text = ex.Message;
                label10.ForeColor = Color.Red;
            }

        }
        public void Modificar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    frmEditHerencia frm = new frmEditHerencia();
                    Persona oax = dataGridView1.CurrentRow.DataBoundItem as Persona;
                    frm.setDatos(oax);
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        Persona objp = frm.CrearObjeto();
                        int pos = TListaPersona.Buscar(oax.Codigo);
                        if (pos >= 0)
                        {
                            TListaPersona.Edit(pos, objp);
                            MessageBox.Show("Se ha actualizado...");
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el registro...");
                        }
                        frm.Close();
                    }
                    else
                    {
                        frm.Close();
                        MessageBox.Show("Actualización cancelada...");
                    }
                }
                MostrarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar Curso " + ex.Message);
            }
        }

        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    //no var si no DialogResult
                    var res = MessageBox.Show("¿Esta seguro de eliminar Registro?", "Eliminar", MessageBoxButtons.YesNo);
                    if (res.ToString().Equals("Yes"))//res == DialogResult.Yes
                    {
                        Persona obp = dataGridView1.CurrentRow.DataBoundItem as Persona;
                        TListaPersona.Delete(TListaPersona.Buscar(obp.Codigo));
                    }
                }
                MostrarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar Registro " + ex.Message);
            }

        }


        private void button4_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal principal = new frmMenuPrincipal();
            principal.Show();
            this.Hide();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var clientes = TListaPersona.Lista_Persona
                    .OfType<Cliente>()
                    .ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = clientes;
        }

        private void disenadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var disenador = TListaPersona.Lista_Persona
                    .OfType<Disenador>()
                    .ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = disenador;
        }
    }
}
