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
    public partial class frmEditComposicion : Form
    {

        Cliente cli;
        Proyecto pro;
        Factura fac;

        public frmEditComposicion()
        {
            InitializeComponent();
        }

        public void setDatos(Factura fc)
        {
            if (fc.Cliente != null)
            {
                textBox1.Text = fc.Cliente.Cedula;
                textBox2.Text = fc.Cliente.Nombre;
                textBox3.Text = fc.Cliente.Empresa;

                cli = fc.Cliente;
            }

            if (fc.Proyecto != null)
            {
                comboBox1.Text = fc.Proyecto.IdProyecto;
                textBox4.Text = fc.Proyecto.NombreProyecto;
                textBox9.Text = fc.Proyecto.Estado;

                double subtotal = fc.Proyecto.TotalProyecto();

                textBox5.Text = subtotal.ToString();
                textBox10.Text = subtotal.ToString();

                double descuento = 0;

                if (subtotal > 100)
                {
                    descuento = subtotal * 0.20;
                }

                double iva = (subtotal - descuento) * 0.15;
                double total = subtotal - descuento + iva;

                textBox6.Text = descuento.ToString();
                textBox7.Text = iva.ToString();
                textBox8.Text = total.ToString();

                pro = fc.Proyecto;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Factura fc =
                    CrearObjeto();

                TListaFactura.Insert(fc);

                MessageBox.Show(
                    "Factura registrada");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmEditComposicion_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            if (TListaPersona.Lista_Persona.Count == 0)
            {
                frmAdminHerencia frmH = new frmAdminHerencia();

                frmH.DatosCliente();
                frmH.DatosDisenador();
            }

            if (TListaProyecto.Lista_Proyecto.Count == 0)
            {
                frmAdminAgregacion frmA = new frmAdminAgregacion();

                frmA.DatosProyecto();
            }

            for (int i = 0; i < TListaProyecto.Lista_Proyecto.Count; i++)
            {
                comboBox1.Items.Add(TListaProyecto.Lista_Proyecto[i].IdProyecto);
            }
        }

        public void CalcularFactura()
        {
            double subtotal =
                double.Parse(textBox5.Text);

            double descuento = 0;

            if (subtotal > 100)
            {
                descuento = subtotal * 0.20;
            }

            double iva = (subtotal - descuento) * 0.15;

            double total = subtotal - descuento + iva;

            textBox6.Text = descuento.ToString();
            textBox7.Text = iva.ToString();
            textBox8.Text = total.ToString();
        }

        public Factura CrearObjeto()
        {
            if (cli == null || pro == null)
            {
                MessageBox.Show("Debe buscar cliente y proyecto");
                return null;
            }

            string numeroFactura = "FAC" + DateTime.Now.Millisecond;
            DateTime fecha = DateTime.Now;
            double iva = 15;

            fac = new Factura(numeroFactura, fecha, iva, cli, pro);

            return fac;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cedula = textBox1.Text;

            for (int i = 0; i < TListaPersona.Lista_Persona.Count; i++)
            {
                Persona per = TListaPersona.Lista_Persona[i];

                if (per is Cliente)
                {
                    Cliente c = per as Cliente;

                    if (c.Cedula.Equals(cedula))
                    {
                        cli = c;

                        textBox2.Text = c.Nombre;
                        textBox3.Text = c.Empresa;

                        break;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string codigo = comboBox1.Text;

            for (int i = 0; i < TListaProyecto.Lista_Proyecto.Count; i++)
            {
                Proyecto p = TListaProyecto.Lista_Proyecto[i];

                if (p.IdProyecto.Equals(codigo))
                {
                    pro = p;

                    textBox4.Text = p.NombreProyecto;
                    textBox9.Text = p.Estado;

                    double subtotal = p.TotalProyecto();

                    textBox5.Text = subtotal.ToString();
                    textBox10.Text = subtotal.ToString();

                    CalcularFactura();

                    break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cliente: " + cli.Nombre + "\n" +
                "Empresa: " + cli.Empresa + "\n" +
                "Monto Cliente: $" + cli.Monto + "\n\n" +

                "Proyecto: " + pro.NombreProyecto + "\n" +
                "Estado: " + pro.Estado + "\n" +
                "Subtotal: $" + pro.TotalProyecto() + "\n\n" +

                "IVA: $" + textBox7.Text + "\n" +
                "TOTAL PAGAR: $" + textBox8.Text);     

    }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmAdminComposicion frm = new frmAdminComposicion();
            frm.Show();
            this.Hide();
        }
    }
}