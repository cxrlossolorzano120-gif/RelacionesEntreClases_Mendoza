using RelacionesEntreClases_Mendoza.Controladores;
using RelacionesEntreClases_Mendoza.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelacionesEntreClases_Mendoza.Formularios
{
    public partial class frmAdminComposicion : Form
    {
        public frmAdminComposicion()
        {
            InitializeComponent();
        }

        private void frmAdminComposicion_Load(object sender, EventArgs e)
        {
            if (TListaPersona.Lista_Persona.Count == 0)
            {
                frmAdminHerencia frm = new frmAdminHerencia();

                frm.DatosDisenador();
                frm.DatosCliente();
            }

            MostrarDatos();
        }
        public void MostrarDatos()
        {
            dataGridView1.DataSource = null;

            dataGridView1.DataSource =
                TListaFactura.Lista_Factura.ToList();

            dataGridView1.Columns["Cliente"].Visible = false;
            dataGridView1.Columns["Proyecto"].Visible = false;
        }

        public void Nuevo()
        {
            try
            {
                frmEditComposicion frm =
                    new frmEditComposicion();

                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    Factura ob = frm.CrearObjeto();

                    if (ob != null)
                    {
                        TListaFactura.Insert(ob);
                    }

                    frm.Close();

                    label1.Text =
                        "Registro Ingresado";
                }
                else
                {
                    frm.Close();

                    label1.Text =
                        "Registro Cancelado";
                }

                MostrarDatos();
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
                label1.ForeColor = Color.Red;
            }
        }



        public void Modificar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    frmEditComposicion frm = new frmEditComposicion();
                    Factura obp = dataGridView1.CurrentRow.DataBoundItem as Factura;
                    frm.setDatos(obp);
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        Factura objp =
                            frm.CrearObjeto();
                            TListaFactura.Edit(TListaFactura.Buscar(obp.NumeroFactura), objp);
                        frm.Close();
                        MessageBox.Show("Se ha actualizado...");
                    }
                    else
                    {
                        frm.Close();

                        MessageBox.Show(
                            "Actualizacion cancelada...");
                    }
                }

                MostrarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al actualizar Factura " +
                    ex.Message);
            }
        }

        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var res =
                        MessageBox.Show(
                            "¿Esta seguro de eliminar Registro?",
                            "Eliminar",
                            MessageBoxButtons.YesNo);

                    if (res.ToString().Equals("Yes"))
                    {
                        Factura obp =
                            dataGridView1.CurrentRow.DataBoundItem as Factura;

                        TListaFactura.Delete(
                            TListaFactura.Buscar(obp.NumeroFactura));
                    }
                }

                MostrarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al eliminar Registro " +
                    ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal principal =
               new frmMenuPrincipal();

            principal.Show();

            this.Hide();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lista =
                TListaFactura.Lista_Factura
                .Where(x => x.Cliente != null)
                .ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
        }

        private void proyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lista =
                TListaFactura.Lista_Factura
                .Where(x => x.Proyecto != null)
                .ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
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
    }
}
