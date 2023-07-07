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
    public partial class Menu : Form
    {
        static int id = 0;
        static string nombre = "";
        static string apellido = "";

        public Menu(int id_usuario,string nombre1,string apellido1)
        {
            InitializeComponent();
            id = id_usuario;
            nombre = nombre1;
            apellido = apellido1;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            label2.Text = string.Format("{0} {1}", nombre, apellido);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrearProducto crpro = new CrearProducto(id, nombre, apellido);
            crpro.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CrearOrden crorden = new CrearOrden(id, nombre, apellido);
            crorden.Show();
            this.Hide();
        }

        public static implicit operator Menu(MenuUser v)
        {
            throw new NotImplementedException();
        }
    }
}
