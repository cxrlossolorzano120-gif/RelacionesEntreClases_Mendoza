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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RelacionesEntreClases_Mendoza.Formularios
{
    public partial class frmEditHerencia : Form
    {
        public frmEditHerencia()
        {
            InitializeComponent();
        }
        Persona per;
        public void setDatos(Persona op)
        {
            textBox1.Text = op.Codigo.ToString();
            textBox2.Text = op.Cedula;
            textBox3.Text = op.Nombre;
            textBox4.Text = op.Apellido;
            dateTimePicker1.Value = op.Fechanaci;
            textBox5.Text = op.Telefono;
            textBox6.Text = op.Direccion;
            comboBox1.Text = op.Estado;

            if (op.Sexo == 'F')
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;

            if (op is Disenador od)
            {
                radioButton2.Checked = true;

                label13.Text = "Especialidad";
                label15.Text = "Nivel Profesional";
                label16.Text = "Fecha Contrato";
                label17.Text = "Horas Trabajadas";

                comboBox2.Text = od.Especialidad;
                comboBox3.Text = od.NivelProfesional;
                dateTimePicker2.Value = od.FechaContrato;
                textBox7.Text = od.Horastrabajadas.ToString();
            }
            else if (op is Cliente oc)
            {
                radioButton3.Checked = true;

                label13.Text = "Tipo";
                label15.Text = "Empresa";
                label16.Text = "Fecha Pedido";
                label17.Text = "Monto Abonado";

                comboBox2.Text = oc.Tipo;
                comboBox3.Text = oc.Empresa;
                dateTimePicker2.Value = oc.FechaPedido;
                textBox7.Text = oc.Monto.ToString();
            }
        }

        public Persona CrearObjeto()
        {
            Persona per;

            string codigo = textBox1.Text;
            string cedula = textBox2.Text;
            string nombre = textBox3.Text;
            string apellido = textBox4.Text;
            DateTime fechanaci = dateTimePicker1.Value;
            char sexo = radioButton1.Checked ? 'F' : 'M';
            string direccion = textBox5.Text;
            string telefono = textBox6.Text;
            string estado = comboBox1.Text;

            if (radioButton2.Checked)
            {
                string especialidad = comboBox2.Text;
                string nivelProfesional = comboBox3.Text;
                DateTime fechaContrato = dateTimePicker2.Value;
                double horasTrabajadas = double.Parse(textBox7.Text);

                per = new Disenador(codigo, cedula, nombre, apellido, sexo, fechanaci, estado, direccion, telefono, especialidad, nivelProfesional, fechaContrato, horasTrabajadas);
            }
            else
            {
                string tipo = comboBox2.Text;
                string empresa = comboBox3.Text;
                DateTime fechaPedido = dateTimePicker2.Value;
                double monto = double.Parse(textBox7.Text);

                per = new Cliente(codigo, cedula, nombre, apellido, sexo, fechanaci, estado, direccion, telefono, tipo, empresa, fechaPedido, monto);
            }

            return per;
        }
        public Boolean Validar()
        {
            bool textValido =
                !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrWhiteSpace(textBox4.Text) &&
                !string.IsNullOrWhiteSpace(textBox5.Text) &&
                !string.IsNullOrWhiteSpace(textBox6.Text) &&
                !string.IsNullOrWhiteSpace(textBox7.Text);

            bool comboValido =
                comboBox1.SelectedIndex >= 0 &&
                comboBox2.SelectedIndex >= 0 &&
                comboBox3.SelectedIndex >= 0;

            bool radioValido =
                radioButton1.Checked || radioButton2.Checked || radioButton3.Checked;

            bool fechaValida = dateTimePicker1.Value <= DateTime.Now && dateTimePicker2.Value <= DateTime.Now;

            return textValido && comboValido && radioValido && fechaValida;
        }
        public void Guardar()
        {
            try
            {
                if (Validar())
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Los campos con (*) son obligatorios");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
        }

        
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();

                label13.Text = "Tipo";
                label15.Text = "Empresa";
                label16.Text = "Fecha Pedido";
                label17.Text = "Monto Abonado";

                comboBox2.Items.Add("Activo");
                comboBox2.Items.Add("Nuevo");

                comboBox3.Items.Add("Empresa A");
                comboBox3.Items.Add("Empresa B");
                comboBox3.Items.Add("Empresa C");
                comboBox3.Items.Add("Empresa D");
            
        }



        private void frmEditHerencia_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Soltero");
            comboBox1.Items.Add("Casado");
            comboBox1.Items.Add("Divorciado");

            if (radioButton3.Checked)
            {
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();

                label13.Text = "Tipo";
                label15.Text = "Empresa";
                label16.Text = "Fecha Pedido";
                label17.Text = "Monto Abonado";

                comboBox2.Items.Add("Activo");
                comboBox2.Items.Add("Nuevo");

                comboBox3.Items.Add("Empresa A");
                comboBox3.Items.Add("Empresa B");
                comboBox3.Items.Add("Empresa C");
                comboBox3.Items.Add("Empresa D");
            }

            if (radioButton2.Checked)
            {
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();

                label13.Text = "Especialidad";
                label15.Text = "Nivel Profesional";
                label16.Text = "Fecha Contrato";
                label17.Text = "Horas Trabajadas";

                comboBox2.Items.Add("Branding");
                comboBox2.Items.Add("Publicidad");
                comboBox2.Items.Add("UX/UI");
                comboBox2.Items.Add("Animacion");
                comboBox2.Items.Add("Editorial");
                comboBox2.Items.Add("Fotografia");

                comboBox3.Items.Add("Junior");
                comboBox3.Items.Add("SemiSenior");
                comboBox3.Items.Add("Senior");
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
       
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();

                label13.Text = "Especialidad";
                label15.Text = "Nivel Profesional";
                label16.Text = "Fecha Contrato";
                label17.Text = "Horas Trabajadas";

                comboBox2.Items.Add("Branding");
                comboBox2.Items.Add("Publicidad");
                comboBox2.Items.Add("UX/UI");
                comboBox2.Items.Add("Animacion");
                comboBox2.Items.Add("Editorial");
                comboBox2.Items.Add("Fotografia");

                comboBox3.Items.Add("Junior");
                comboBox3.Items.Add("SemiSenior");
                comboBox3.Items.Add("Senior");
            
        }
    }
}
