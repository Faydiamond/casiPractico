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
    public partial class vista_pedidoUser : Form
    {
        static int id = 0;
        
        static string nombre = "";
        static string apellido = "";
        int percent = 0;
        controlll.Ordenes pordenes = new controlll.Ordenes();
        int id_ird = 0;
        string producto = "";
        string direccion = "";
        string adicional = "";
        string estado = "";
        string intrucciones = "";
        public vista_pedidoUser(int id_usuario, string nombre1, string apellido1)
        {
            InitializeComponent();
            id = id_usuario;
            nombre = nombre1;
            apellido = apellido1;
        }

        private void vista_pedidoUser_Load(object sender, EventArgs e)
        {
            allOrders();
            
        }

        public void allOrders()
        {
            dataGridView1.DataSource = pordenes.GetOrdersByUsers(id);
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             id_ird = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            producto = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            direccion = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            adicional = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            estado = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            intrucciones = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            //MessageBox.Show(id_ird.ToString());
            label4.Text = producto;
            label6.Text = direccion;
            label8.Text = estado;
            Console.WriteLine("Estado  ", dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
            if (estado == "Order Placed")
            {
                percent = 20;
            } else if (estado == "Prep")
            {
                percent = 40;
            }
            else if (estado == "Bake")
            {
                percent = 60;
            }
            else if (estado == "Quality Check")
            {
                percent = 80;
            }
            else if (estado == "Out for delivery")
            {
                percent = 100;
            }
            label2.Text = percent.ToString();
            progressBar1.Value = percent;

        }
    }
}
