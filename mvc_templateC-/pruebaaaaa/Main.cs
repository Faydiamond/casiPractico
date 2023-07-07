using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using controlll;
namespace pruebaaaaa
{
    public partial class Main : Form
    {
        controlll.MainController controlls = new controlll.MainController();
        Modelss.Login m = new Modelss.Login();
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource =   oMainController.GetProducts();
            //int id = oMainController.IsLogin();
            //m.id_usuario = id;
            //Console.WriteLine("Que " + m.id_usuario);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controlll.Login login = new controlll.Login();
            string  res_login =login.IsLogin(textBox1.Text, textBox2.Text);
            if (res_login != "")
            {
                string[] results = res_login.Split(',');
                m.id_usuario = int.Parse( results[0]);
                m.fk_rol = int.Parse(results[1]);
                m.nombre1 = results[2];
                m.apellido1 = results[3];
                /*
                Console.WriteLine(m.id_usuario);
                Console.WriteLine(m.fk_rol);
                Console.WriteLine(m.nombre1);
                Console.WriteLine(m.apellido1);*/
                if (m.fk_rol == 1)
                {
                    Menu menu = new Menu(m.id_usuario, m.nombre1, m.apellido1);
                    menu.Show();
                    this.Hide();
                }
                if (m.fk_rol == 2)
                {
                    MenuUser menu2 = new MenuUser(m.id_usuario, m.nombre1, m.apellido1);
                    menu2.Show();
                    this.Hide();
                }
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
