using RelacionesEntreClases_Mendoza.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelacionesEntreClases_Mendoza
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAdminHerencia adminHerencia = new frmAdminHerencia();
            adminHerencia.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAdminAgregacion adminAgregacion = new frmAdminAgregacion();
            adminAgregacion.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAdminComposicion adminComposicion = new frmAdminComposicion();
            adminComposicion.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmAdminAsociacion admin = new frmAdminAsociacion();
            admin.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmAdminDependencia dep = new frmAdminDependencia();
            dep.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
