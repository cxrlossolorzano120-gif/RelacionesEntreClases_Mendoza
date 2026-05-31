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
    public partial class frmAdminDependencia : Form
    {
        public frmAdminDependencia()
        {
            InitializeComponent();
        }

        public void MostrarDatos()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = TListaExportadorPDF.Lista_ExportadorPDF.ToList();
        }

        public void Nuevo()
        {
            try
            {
                frmEditDependencia frm = new frmEditDependencia();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    ExportadorPDF ep = frm.CrearObjeto();
                    TListaExportadorPDF.Insert(ep);
                    frm.Close();
                    label1.Text = "Registro Ingresado";
                }
                else
                {
                    frm.Close();
                    label1.Text = "Registro Cancelado";
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
                    frmEditDependencia frm = new frmEditDependencia();
                    ExportadorPDF ep = dataGridView1.CurrentRow.DataBoundItem as ExportadorPDF;
                    frm.setDatos(ep);
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        ExportadorPDF obj = frm.CrearObjeto();
                        TListaExportadorPDF.Edit(TListaExportadorPDF.Buscar(ep.CodigoExportacion), obj);
                        frm.Close();
                        MessageBox.Show("Se ha actualizado...");
                    }
                    else
                    {
                        frm.Close();
                        MessageBox.Show("Actualizacion cancelada...");
                    }
                }

                MostrarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar " + ex.Message);
            }
        }

        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var res = MessageBox.Show("¿Desea eliminar?", "Eliminar", MessageBoxButtons.YesNo);
                    if (res.ToString().Equals("Yes"))
                    {
                        ExportadorPDF ep = dataGridView1.CurrentRow.DataBoundItem as ExportadorPDF;
                        TListaExportadorPDF.Delete(TListaExportadorPDF.Buscar(ep.CodigoExportacion));
                    }
                }

                MostrarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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

        private void button4_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal men = new frmMenuPrincipal();
            men.Show();
            this.Hide();
        }

        private void frmAdminDependencia_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
    }
}
