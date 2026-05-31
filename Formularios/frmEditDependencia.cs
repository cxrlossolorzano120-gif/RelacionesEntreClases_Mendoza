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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RelacionesEntreClases_Mendoza.Formularios
{
    public partial class frmEditDependencia : Form
    {
        ExportadorPDF ex;
        Proyecto pro;

        public frmEditDependencia()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string codigo = textBox1.Text;

            for (int i = 0; i < TListaProyecto.Lista_Proyecto.Count; i++)
            {
                Proyecto p =
                    TListaProyecto.Lista_Proyecto[i];

                if (p.IdProyecto.Equals(codigo))
                {
                    pro = p;

                    textBox2.Text = p.NombreProyecto;
                    textBox3.Text = p.TipoDiseno;
                    textBox4.Text = p.Estado;
                    textBox5.Text = p.Presupuesto.ToString();
                    textBox6.Text = p.Material.Nombre;
                    textBox7.Text = p.TotalProyecto().ToString();

                    break;
                }
            }
        }

        public void setDatos(ExportadorPDF ep)
        {
            textBox8.Text = ep.CodigoExportacion;
            dateTimePicker1.Value = ep.FechaExportacion;
            comboBox1.Text = ep.Formato;
            ex = ep;
        }

        public ExportadorPDF CrearObjeto()
        {
            string codigo = "EXP" + DateTime.Now.Millisecond;
            DateTime fecha = DateTime.Now;
            string formato = comboBox1.Text;
            ex = new ExportadorPDF(codigo, fecha, formato);

            return ex;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExportadorPDF ex = new ExportadorPDF();
            ex.ExportarProyecto(pro);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ExportadorPDF ep = CrearObjeto();
                TListaExportadorPDF.Insert(ep);
                MessageBox.Show("Exportacion registrada");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmEditDependencia_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("PDF");
            comboBox1.Items.Add("WORD");
            comboBox1.Items.Add("EXCEL");

            if (TListaProyecto.Lista_Proyecto.Count == 0)
            {
                frmAdminAgregacion frm =
                    new frmAdminAgregacion();

                frm.DatosProyecto();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
