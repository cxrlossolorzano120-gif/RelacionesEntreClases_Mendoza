using RelacionesEntreClases_Mendoza.Controladores;
using RelacionesEntreClases_Mendoza.Entidades;
using SistemaNominas_ClasesAbstractas.Entidades;
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
    public partial class frmEditAsociacion : Form
    {
        public frmEditAsociacion()
        {
            InitializeComponent();
        }

        Disenador dis;
        SoftwareDiseno sof;

        private void button1_Click(object sender, EventArgs e)
        {
            string cedula = textBox1.Text;

            for (int i = 0; i < TListaPersona.Lista_Persona.Count; i++)
            {
                Persona per = TListaPersona.Lista_Persona[i];

                if (per is Disenador)
                {
                    Disenador dis =
                        per as Disenador;

                    if (dis.Cedula.Equals(cedula))
                    {
                        textBox2.Text = dis.Nombre;
                        textBox3.Text = dis.Especialidad;

                        break;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SoftwareDiseno sd =
                    CrearObjeto();

                TListaSoftwareDiseno.Insert(sd);

                MessageBox.Show(
                    "Software asignado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmEditAsociacion_Load(object sender, EventArgs e)
        {
            if (TListaPersona.Lista_Persona.Count == 0)
            {
                frmAdminHerencia frm = new frmAdminHerencia();

                frm.DatosDisenador();
                frm.DatosCliente();
            }

            if (TListaSoftwareDiseno.Lista_SoftwareDiseno.Count == 0)
            {
                frmAdminAsociacion frmA = new frmAdminAsociacion();

                frmA.DatosSoftware();
            }

            comboBox1.Items.Clear();

            for (int i = 0; i < TListaSoftwareDiseno.Lista_SoftwareDiseno.Count; i++)
            {
                comboBox1.Items.Add(
                    TListaSoftwareDiseno.Lista_SoftwareDiseno[i].CodigoSoftware);
            }

            comboBox2.Items.Add("2023");
            comboBox2.Items.Add("2024");
            comboBox2.Items.Add("2025");

            comboBox3.Items.Add("Mensual");
            comboBox3.Items.Add("Anual");
            comboBox3.Items.Add("Vitalicia");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals("SW001"))
            {
                textBox4.Text = "Adobe Photoshop";
                comboBox2.Text = "2024";
                comboBox3.Text = "Mensual";
                textBox5.Text = "250";
            }
            else if (comboBox1.Text.Equals("SW002"))
            {
                textBox4.Text = "Adobe Illustrator";
                comboBox2.Text = "2025";
                comboBox3.Text = "Anual";
                textBox5.Text = "350";
            }
            else if (comboBox1.Text.Equals("SW003"))
            {
                textBox4.Text = "Canva Pro";
                comboBox2.Text = "2024";
                comboBox3.Text = "Mensual";
                textBox5.Text = "80";
            }
            else if (comboBox1.Text.Equals("SW004"))
            {
                textBox4.Text = "Adobe Premiere";
                comboBox2.Text = "2025";
                comboBox3.Text = "Vitalicia";
                textBox5.Text = "500";
            }
            else if (comboBox1.Text.Equals("SW005"))
            {
                textBox4.Text = "Figma";
                comboBox2.Text = "2024";
                comboBox3.Text = "Anual";
                textBox5.Text = "120";
            }

        }
        public SoftwareDiseno CrearObjeto()
        {
            string codigoSoftware =
                comboBox1.Text;

            string nombreSoftware =
                textBox4.Text;

            string version =
                comboBox2.Text;

            string licencia =
                comboBox3.Text;

            double precio =
                double.Parse(textBox5.Text);

            sof = new SoftwareDiseno(
                codigoSoftware,
                nombreSoftware,
                version,
                licencia,
                precio);

            return sof;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Diseñador: " + dis.Nombre + "\n" +
                "Especialidad: " + dis.Especialidad + "\n\n" +

                "Software: " + textBox4.Text + "\n" +
                "Version: " + comboBox2.Text + "\n" +
                "Licencia: " + comboBox3.Text + "\n" +
                "Precio: $" + textBox5.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmAdminAsociacion frm = new frmAdminAsociacion();
            frm.Show();
            this.Hide();
        }
    }
}
