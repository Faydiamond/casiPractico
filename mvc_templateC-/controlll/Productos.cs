using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controlll
{
    public class Productos
    {
        controlll.StrConection conectionDB = new controlll.StrConection();

        //crear producto
        public bool CrearProducto(int id, string producto, string desc, int stock, float price, byte[] imagen)
        {
            string strSQL = "";
            string stringConection = conectionDB.ConectDB();
            if (id > 0)
            {
                //edit
                strSQL = string.Format("execute  update_productoo {0},'{1}','{2}',{3},{4} ", id, producto, desc, stock, price);
            }
            else if (id == 0)
            {
                strSQL = string.Format("execute  create_producto '{0}','{1}',{2},{3},'{4}' ", producto, desc, stock, price, imagen);
            }

            //string strSQL = "Select * From [User] where UserId = @userID";
            Console.WriteLine(strSQL);
            using (SqlConnection cnn = new SqlConnection(stringConection))
            {
                using (SqlCommand myCommand = new SqlCommand(strSQL, cnn))
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand(strSQL, cnn);
                    comando.ExecuteNonQuery();
                    return true;
                }
            }
            return false;
        }

        //traer productos
        public IEnumerable<Modelss.Productos> GetProducts()
        {
            using (Modelss.EF.pizeerriaEntities db = new Modelss.EF.pizeerriaEntities())
            {
                IEnumerable<Modelss.Productos> lst = (from d in db.productos
                                                           select new Modelss.Productos
                                                           {
                                                               id_producto = d.id_producto,
                                                               producto = d.producto,
                                                               descripcion = d.descripcion,
                                                               stock = d.stock,
                                                               precio_venta = (float)d.precio_venta
                                                           }).ToList();
                return lst;
            }
        }


    }
}
