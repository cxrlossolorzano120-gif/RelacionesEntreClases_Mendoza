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
    public partial class frmAdminAsociacion : Form
    {
        public frmAdminAsociacion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DatosSoftware();
            MostrarDatos();
        }

        public void DatosSoftware()
        {
            if (TListaSoftwareDiseno.Lista_SoftwareDiseno.Count == 0)
            {
                TListaSoftwareDiseno.Insert(
                    new SoftwareDiseno(
                        "SW001",
                        "Adobe Photoshop",
                        "2024",
                        "Mensual",
                        250));

                TListaSoftwareDiseno.Insert(
                    new SoftwareDiseno(
                        "SW002",
                        "Adobe Illustrator",
                        "2025",
                        "Anual",
                        350));

                TListaSoftwareDiseno.Insert(
                    new SoftwareDiseno(
                        "SW003",
                        "Canva Pro",
                        "2024",
                        "Mensual",
                        80));

                TListaSoftwareDiseno.Insert(
                    new SoftwareDiseno(
                        "SW004",
                        "Adobe Premiere",
                        "2025",
                        "Vitalicia",
                        500));

                TListaSoftwareDiseno.Insert(
                    new SoftwareDiseno(
                        "SW005",
                        "Figma",
                        "2024",
                        "Anual",
                        120));
            }
        }

        public void MostrarDatos()
        {
            dataGridView1.DataSource = null;

            dataGridView1.DataSource =
                TListaSoftwareDiseno.Lista_SoftwareDiseno.ToList();
        }

        public void Nuevo()
        {
            try
            {
                frmEditAsociacion frm =
                    new frmEditAsociacion();

                frm.ShowDialog();

                MostrarDatos();

                label1.Text =
                    "Registro Ingresado";
            }
            catch (Exception ex)
            {
                label1.Text =
                    ex.Message;

                label1.ForeColor =
                    Color.Red;
            }
        }

        public void Modificar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    frmEditAsociacion frm =
                        new frmEditAsociacion();

                    frm.ShowDialog();

                    MostrarDatos();

                    MessageBox.Show(
                        "Registro Actualizado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message);
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
                            "¿Desea eliminar?",
                            "Eliminar",
                            MessageBoxButtons.YesNo);

                    if (res.ToString().Equals("Yes"))
                    {
                        SoftwareDiseno sd =
                            dataGridView1.CurrentRow.DataBoundItem as SoftwareDiseno;

                        TListaSoftwareDiseno.Delete(
                            TListaSoftwareDiseno.Buscar(sd.CodigoSoftware));
                    }
                }

                MostrarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal principal =
                new frmMenuPrincipal();

            principal.Show();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void mensualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lista =
                TListaSoftwareDiseno.Lista_SoftwareDiseno
                .Where(x => x.Licencia.Equals("Mensual"))
                .ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
        }

        private void anualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lista =
                TListaSoftwareDiseno.Lista_SoftwareDiseno
                .Where(x => x.Licencia.Equals("Anual"))
                .ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
        }

        private void vitaliciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lista =
                TListaSoftwareDiseno.Lista_SoftwareDiseno
                .Where(x => x.Licencia.Equals("Vitalicia"))
                .ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
        }

        private void frmAdminAsociacion_Load(object sender, EventArgs e)
        {

        }
    }
}
