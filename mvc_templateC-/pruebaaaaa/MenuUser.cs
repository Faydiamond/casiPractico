using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pruebaaaaa
{
    public partial class MenuUser : Form
    {
        static int id = 0;
        static string nombre = "";
        static string apellido = "";
        public MenuUser(int id_usuario, string nombre1, string apellido1)
        {
            InitializeComponent();
            id = id_usuario;
            nombre = nombre1;
            apellido = apellido1;
        }

        private void MenuUser_Load(object sender, EventArgs e)
        {
            label1.Text = string.Format("{0} {1}", nombre, apellido);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrearOrden crorden = new CrearOrden(id, nombre, apellido);
            crorden.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vista_pedidoUser vpe = new vista_pedidoUser(id, nombre, apellido);
            vpe.Show();
            this.Hide();
        }
    }
}
