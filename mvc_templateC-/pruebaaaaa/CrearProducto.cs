using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using controlll;
using Modelss;
namespace pruebaaaaa
{
    public partial class CrearProducto : Form
    {
        static int id = 0;
        static string nombre = "";
        static string apellido = "";
        controlll.Productos pcontrol = new controlll.Productos();
        Modelss.Productos p = new Modelss.Productos();
        
        private DataTable dt;
        //private int dataGridView_CellContentClick;

        public CrearProducto(int id_usuario, string nombre1, string apellido1)
        {
            InitializeComponent();
            id = id_usuario;
            nombre = nombre1;
            apellido = apellido1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu(id,nombre,apellido);
            menu.Show();
            this.Hide();
        }

        private void get_allproductos()
        {
          
        }
        private void CrearProducto_Load(object sender, EventArgs e)
        {
            //List<UserViewModels> productos = (List<UserViewModels>)pcontrol.GetProducts();
            dataGridView1.DataSource = pcontrol.GetProducts();
            //     = new controlll.MainController();
            //dataGridView1.DataSource = pcontrol.GetProductos();

            //get_allproductos();


        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dt.Columns["Producto"].Ordinal)
            {
                DialogResult result;
                result = MessageBox.Show("Realmente desea eliminar este usuario?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
        }

        

        //Guaradr
        private void button3_Click(object sender, EventArgs e)
        {

            /////////////////////////////////////////
            int id_producto=0;
            string producto = textBox1.Text;
            string desc     = textBox4.Text;
            int stock;
            int price;
            bool canConvert = int.TryParse(textBox2.Text, out stock);
            bool canConvert1 = int.TryParse(textBox3.Text, out price);
            if (textBox5.Text != "")
            {
                id_producto = int.Parse(textBox5.Text);
            }
            Console.WriteLine("id ", id_producto);

            if (producto == "" || desc == "")
            {
                MessageBox.Show("Por favor diligencie todos los campos", "Error", MessageBoxButtons.OK);
            }
            else if (canConvert1 == true && canConvert == true)
            {
                bool resultInsert = pcontrol.CrearProducto(id_producto, producto, desc, stock, price, null);
                if (resultInsert == true)
                {
                    MessageBox.Show("Los datos se guardaron correctamente");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    get_allproductos();
                }
                else if (resultInsert == false)
                {
                    MessageBox.Show("Los datos  no se guardaron.");
                }
                Console.WriteLine("Id es 0 ", id_producto);


            }
            else
            {
                MessageBox.Show("Ingrese un numero ", "Error", MessageBoxButtons.OK);
            }
        }
        //cargar
       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox4.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox2.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
    }
}
