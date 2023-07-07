using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelss;


namespace pruebaaaaa
{
    public partial class CrearOrden : Form
    {
        static int id = 0;
        string instrucciones = "";
        static string nombre = "";
        static string apellido = "";
        
        controlll.Productos pcontrol = new controlll.Productos();
        controlll.Adicional padicional = new controlll.Adicional();
        controlll.Estados pestados = new controlll.Estados();
        controlll.Ordenes pordenes = new controlll.Ordenes();
        Modelss.Productos p = new Modelss.Productos();

        //variables

        int tamano      = 0;
        int pizza       = 0;
        int adicional   = 0;
        public CrearOrden(int id_usuario, string nombre1, string apellido1)
        {
            InitializeComponent();
            id = id_usuario;
            nombre = nombre1;
            apellido = apellido1;
            
        }

        private void CrearOrden_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = pcontrol.GetProducts();
            comboBox1.ValueMember = "id_producto";
            comboBox1.DisplayMember = "producto";

            comboBox2.DataSource = padicional.GetAdicionals();
            comboBox2.ValueMember = "id_adicional";
            comboBox2.DisplayMember = "adicional";

            
            comboBox3.DataSource = pestados.GetStates();
            comboBox3.ValueMember = "id_estado";
            allOrders();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            Modelss.Productos productoSeleccionado = (Modelss.Productos)comboBox1.SelectedItem;
            string x = comboBox1.SelectedValue.ToString();
            int number2;
            bool canConvert2 = int.TryParse(x, out number2);
            if (canConvert2 == true )
            {
                pizza = number2;
                
            }
               
        }

      

        private void button1_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                tamano = 1;
            }
            if (radioButton2.Checked)
            {
                tamano = 2;
            }
            if (radioButton3.Checked)
            {
                tamano = 3;
            }


            instrucciones = textBox1.Text;
            int id_orden = 0;
            /////////////////////////
            if (textBox2.Text != "")
            {
                id_orden = int.Parse(textBox2.Text);
                
            }
            bool resultInsert = pordenes.CrearOrden(id_orden,id, 1, pizza, adicional,tamano, instrucciones);
            if (resultInsert == true)
            {
                MessageBox.Show("Los datos se guardaron correctamente");
                textBox1.Text = "";
                
                 allOrders();
            }
            else if (resultInsert == false)
            {
                MessageBox.Show("Los datos  no se guardaron.");
            }


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Modelss.Adicionales adicionalSeleccionado = (Modelss.Adicionales)comboBox2.SelectedItem;
            adicional = adicionalSeleccionado.id_adicional;
            Console.WriteLine("Quien   " + adicional);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Aqui");
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            var item = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        public void allOrders()
        {
            dataGridView1.DataSource = pordenes.GetOrders();
        }

        public void allStates ()
        {
            pestados.GetStates();
        }

      
    }
}
