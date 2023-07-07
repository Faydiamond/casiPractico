using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controlll
{
    public class MainController
    {
        /*
        public IEnumerable<Modelss.UserViewModels> GetProducts() {
            using (Modelss.EF.pizzeriaEntities  db=new Modelss.EF.pizzeriaEntities())
            {
                 IEnumerable<Modelss.UserViewModels> lst = (from d in db.productos
                                                           select new Modelss.UserViewModels
                                                           {
                                                               id_producto = d.id_producto,
                                                               producto = d.producto,
                                                               descripcion = d.descripcion,
                                                               stock = d.stock,
                                                               precio_venta = (float)d.precio_venta
                                                           }).ToList();
                return lst;
            }
        }*/
        
        /*
        
        public int IsLogin()
        {
            string user = "daniells@gmail.com";
            string clave = "456852";
            string strSQL = "execute Login '" + user + "','" + clave + "'";
            //string strSQL = "Select * From [User] where UserId = @userID";
            using (SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-3R4GENJ;Initial Catalog=pizzeria;Integrated Security=True"))
            {
                using (SqlCommand myCommand = new SqlCommand(strSQL, cnn))
                {
                    cnn.Open();
                    //myCommand.Parameters.AddWithValue("@userID", user);
                    using (SqlDataReader reader = myCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["nombre1"].ToString());
                            return (int)reader["id_usuario"];
                        }
                    }
                }
            }
            return 0;
        }*/

    }
}
