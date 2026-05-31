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
    public partial class frmEditAgregacion : Form
    {
        Proyecto pr;
        Material mt;
        public frmEditAgregacion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        public Proyecto CrearObjeto()
        {
            string idProyecto = comboBox1.Text;
            string nombreProyecto = textBox1.Text;
            string tipoDiseno = comboBox2.Text;
            double presupuesto = double.Parse(textBox2.Text);
            DateTime fechaInicio = dateTimePicker1.Value;
            DateTime fechaEntrega = dateTimePicker2.Value;
            string estado = comboBox3.Text;

            string codigoMaterial = comboBox4.Text;
            string nombre = textBox3.Text;
            int cantidad = int.Parse(textBox4.Text);
            double costoUnitario = double.Parse(textBox5.Text);

            mt = new Material(codigoMaterial, nombre, cantidad, costoUnitario);

            pr = new Proyecto(idProyecto, nombreProyecto,
                tipoDiseno, presupuesto,
                fechaInicio, fechaEntrega,
                estado, mt);

            return pr;
        }

        public Boolean Validar()
        {
            bool texto =
                !string.IsNullOrWhiteSpace(comboBox1.Text) &&
                !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrWhiteSpace(comboBox2.Text) &&
                !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrWhiteSpace(comboBox3.Text) &&
                !string.IsNullOrWhiteSpace(comboBox4.Text) &&
                !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrWhiteSpace(textBox4.Text) &&
                !string.IsNullOrWhiteSpace(textBox5.Text) &&
                !string.IsNullOrWhiteSpace(textBox6.Text);

            return texto;
        }

        public void setDatos(Proyecto op)
        {
            comboBox1.Text = op.IdProyecto;
            textBox1.Text = op.NombreProyecto;
            comboBox2.Text = op.TipoDiseno;
            textBox2.Text = op.Presupuesto.ToString();
            dateTimePicker1.Value = op.FechaInicio;
            dateTimePicker2.Value = op.FechaEntrega;
            comboBox3.Text = op.Estado;

            comboBox4.Text = op.Material.CodigoMaterial;
            textBox3.Text = op.Material.Nombre;
            textBox4.Text = op.Material.Cantidad.ToString();
            textBox5.Text = op.Material.CostoUnitario.ToString();
            textBox6.Text = op.Material.CalcularCosto().ToString();
        }

        public void DatosProyecto()
        {
            Material m1 = new Material("MAT001", "Adobe Illustrator", 1, 500);
            Material m2 = new Material("MAT002", "Vinil Adhesivo", 2, 300);

            TListaProyecto.Lista_Proyecto.Add(new Proyecto("PR001", "Diseño Logo Empresa", "Logo", 500, DateTime.Now, DateTime.Now, "Activo", m1));

            TListaProyecto.Lista_Proyecto.Add(new Proyecto("PR002", "Banner Publicitario", "Banner", 1000, DateTime.Now, DateTime.Now, "Pendiente", m2));
        }
        private void frmEditAgregacion_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("PR001");
            comboBox1.Items.Add("PR002");
            comboBox1.Items.Add("PR003");
            comboBox1.Items.Add("PR004");
            comboBox1.Items.Add("PR005");
            comboBox1.Items.Add("PR006");
            comboBox1.Items.Add("PR007");
            comboBox1.Items.Add("PR008");

            comboBox2.Items.Add("Diseño de Logo");
            comboBox2.Items.Add("Restauración Fotográfica");
            comboBox2.Items.Add("Branding Corporativo");
            comboBox2.Items.Add("Diseño Publicitario");
            comboBox2.Items.Add("Diseño Web");
            comboBox2.Items.Add("Edición de Video");
            comboBox2.Items.Add("Packaging");
            comboBox2.Items.Add("Diseño Redes Sociales");

            comboBox3.Items.Add("Activo");
            comboBox3.Items.Add("Pendiente");
            comboBox3.Items.Add("Finalizado");
        }
        public void Guardar()
        {
            try
            {
                if (Validar())
                {
                    Proyecto pr = CrearObjeto();
                    TListaProyecto.Insert(pr);
                    MessageBox.Show("Proyecto Guardado");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Complete todos los campos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Limpiar()
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals("PR001"))
            {
                textBox1.Text = "Diseño de Logo";
            }
            else if (comboBox1.Text.Equals("PR002"))
            {
                textBox1.Text = "Restauración Fotográfica";
            }
            else if (comboBox1.Text.Equals("PR003"))
            {
                textBox1.Text = "Branding Corporativo";
            }
            else if (comboBox1.Text.Equals("PR004"))
            {
                textBox1.Text = "Diseño Publicitario";
            }
            else if (comboBox1.Text.Equals("PR005"))
            {
                textBox1.Text = "Diseño Web";
            }
            else if (comboBox1.Text.Equals("PR006"))
            {
                textBox1.Text = "Edición de Video";
            }
            else if (comboBox1.Text.Equals("PR007"))
            {
                textBox1.Text = "Packaging";
            }
            else
            {
                textBox1.Text = "Diseño Redes Sociales";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();

            if (comboBox2.Text.Equals("Diseño de Logo"))
            {
                textBox2.Text = "500";

                comboBox4.Items.Add("MAT001");
            }

            if (comboBox2.Text.Equals("Restauración Fotográfica"))
            {
                textBox2.Text = "1200";

                comboBox4.Items.Add("MAT002");
            }

            if (comboBox2.Text.Equals("Branding Corporativo"))
            {
                textBox2.Text = "2500";

                comboBox4.Items.Add("MAT003");
            }

            if (comboBox2.Text.Equals("Diseño Publicitario"))
            {
                textBox2.Text = "1800";

                comboBox4.Items.Add("MAT004");
            }

            if (comboBox2.Text.Equals("Diseño Web"))
            {
                textBox2.Text = "3500";

                comboBox4.Items.Add("MAT005");
            }

            if (comboBox2.Text.Equals("Edición de Video"))
            {
                textBox2.Text = "2800";

                comboBox4.Items.Add("MAT006");
            }

            if (comboBox2.Text.Equals("Packaging"))
            {
                textBox2.Text = "1600";

                comboBox4.Items.Add("MAT007");
            }

            if (comboBox2.Text.Equals("Diseño Redes Sociales"))
            {
                textBox2.Text = "900";

                comboBox4.Items.Add("MAT008");
            }
        }

        public void CalcularTotal()
        {
            try
            {
                int cantidad = int.Parse(textBox4.Text);
                double costo = double.Parse(textBox5.Text);

                double total = cantidad * costo;

                textBox6.Text = total.ToString();
            }
            catch
            {

            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text.Equals("MAT001"))
            {
                textBox3.Text = "Adobe Illustrator";
                textBox4.Text = "1";
                textBox5.Text = "120";
            }

            if (comboBox4.Text.Equals("MAT002"))
            {
                textBox3.Text = "Papel Fotografico";
                textBox4.Text = "10";
                textBox5.Text = "15";
            }

            if (comboBox4.Text.Equals("MAT003"))
            {
                textBox3.Text = "Manual Corporativo";
                textBox4.Text = "2";
                textBox5.Text = "80";
            }

            if (comboBox4.Text.Equals("MAT004"))
            {
                textBox3.Text = "Lona Banner";
                textBox4.Text = "5";
                textBox5.Text = "40";
            }

            if (comboBox4.Text.Equals("MAT005"))
            {
                textBox3.Text = "Plantilla UI";
                textBox4.Text = "1";
                textBox5.Text = "150";
            }

            if (comboBox4.Text.Equals("MAT006"))
            {
                textBox3.Text = "Adobe Premiere";
                textBox4.Text = "1";
                textBox5.Text = "200";
            }

            if (comboBox4.Text.Equals("MAT007"))
            {
                textBox3.Text = "Cartulina Couche";
                textBox4.Text = "20";
                textBox5.Text = "5";
            }

            if (comboBox4.Text.Equals("MAT008"))
            {
                textBox3.Text = "Plantillas Canva";
                textBox4.Text = "3";
                textBox5.Text = "25";
            }

            CalcularTotal();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Proyecto pr = CrearObjeto();
               MessageBox.Show(pr.ImprimirProyecto());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAdminAgregacion admin = new frmAdminAgregacion();
            admin.Show();
            this.Close();
        }
    }
}
