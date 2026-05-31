using RelacionesEntreClases_Mendoza.Controladores;
using RelacionesEntreClases_Mendoza.Entidades;
using System;
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
    public partial class frmAdminAgregacion : Form
    {
        public frmAdminAgregacion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void frmAdminAgregacion_Load(object sender, EventArgs e)
        {
            if (TListaProyecto.Lista_Proyecto.Count == 0)
            {
                DatosProyecto();
            }

            MostrarDatos();
        }

        public void DatosProyecto()
        {
            Material m1 = new Material("MAT001", "Vinil Adhesivo", 5, 20);
            Material m2 = new Material("MAT002", "Papel Fotografico", 10, 15);
            Material m3 = new Material("MAT003", "Tinta Full Color", 3, 50);
            Material m4 = new Material("MAT004", "Lona Publicitaria", 8, 35);
            Material m5 = new Material("MAT005", "Cartulina", 20, 5);
            Material m6 = new Material("MAT006", "Acrilico", 4, 80);
            Material m7 = new Material("MAT007", "Foam", 12, 18);
            Material m8 = new Material("MAT008", "Tela Banner", 6, 40);
            Material m9 = new Material("MAT009", "Sticker", 30, 2);
            Material m10 = new Material("MAT010", "PVC", 7, 60);

            TListaProyecto.Lista_Proyecto.Add(new Proyecto("PR001", "Diseño Logo Empresa", "Logo", 500, DateTime.Now, DateTime.Now, "Activo", m1));
            TListaProyecto.Lista_Proyecto.Add(new Proyecto("PR002", "Banner Publicitario", "Banner", 1000, DateTime.Now, DateTime.Now, "Pendiente", m2));
            TListaProyecto.Lista_Proyecto.Add(new Proyecto("PR003", "Publicidad Digital", "Publicidad", 1500, DateTime.Now, DateTime.Now, "Finalizado", m3));
            TListaProyecto.Lista_Proyecto.Add(new Proyecto("PR004", "Diseño Menu Restaurante", "Logo", 700, DateTime.Now, DateTime.Now, "Activo", m4));
            TListaProyecto.Lista_Proyecto.Add(new Proyecto("PR005", "Flyers Promocionales", "Publicidad", 1200, DateTime.Now, DateTime.Now, "Pendiente", m5));
            TListaProyecto.Lista_Proyecto.Add(new Proyecto("PR006", "Rotulacion Vehicular", "Banner", 1800, DateTime.Now, DateTime.Now, "Finalizado", m6));
            TListaProyecto.Lista_Proyecto.Add(new Proyecto("PR007", "Diseño Packaging", "Logo", 900, DateTime.Now, DateTime.Now, "Activo", m7));
            TListaProyecto.Lista_Proyecto.Add(new Proyecto("PR008", "Impresion Gigantografia", "Banner", 2500, DateTime.Now, DateTime.Now, "Pendiente", m8));
            TListaProyecto.Lista_Proyecto.Add(new Proyecto("PR009", "Diseño Stickers", "Publicidad", 650, DateTime.Now, DateTime.Now, "Activo", m9));
            TListaProyecto.Lista_Proyecto.Add(new Proyecto("PR010", "Señaletica Corporativa", "Banner", 3000, DateTime.Now, DateTime.Now, "Finalizado", m10));
        }

        public void MostrarDatos()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = TListaProyecto.Lista_Proyecto.ToList();
        }

        public void Nuevo()
        {
            try
            {
                frmEditAgregacion frm = new frmEditAgregacion();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    Proyecto ob = frm.CrearObjeto();

                    TListaProyecto.Insert(ob);

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
                    frmEditAgregacion frm = new frmEditAgregacion();

                    Proyecto obp =
                        dataGridView1.CurrentRow.DataBoundItem as Proyecto;

                    frm.setDatos(obp);

                    frm.ShowDialog();

                    if (frm.DialogResult == DialogResult.OK)
                    {
                        Proyecto objp = frm.CrearObjeto();

                        TListaProyecto.Edit(
                            TListaProyecto.Buscar(obp.IdProyecto),
                            objp);

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
                MessageBox.Show("Error al actualizar Proyecto " + ex.Message);
            }
        }

        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var res = MessageBox.Show(
                        "¿Esta seguro de eliminar Registro?",
                        "Eliminar",
                        MessageBoxButtons.YesNo);

                    if (res.ToString().Equals("Yes"))
                    {
                        Proyecto obp =
                            dataGridView1.CurrentRow.DataBoundItem as Proyecto;

                        TListaProyecto.Delete(
                            TListaProyecto.Buscar(obp.IdProyecto));
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

        private void activoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lista = TListaProyecto.Lista_Proyecto
                .Where(x => x.Estado.Equals("Activo"))
                .ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
        }

        private void pendienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lista = TListaProyecto.Lista_Proyecto
                .Where(x => x.Estado.Equals("Pendiente"))
                .ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
        }

        private void finalizadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lista = TListaProyecto.Lista_Proyecto
                .Where(x => x.Estado.Equals("Finalizado"))
                .ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
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
