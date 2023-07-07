using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controlll
{
    public class Login
    {
        controlll.StrConection conectionDB = new controlll.StrConection();
        public string IsLogin (string user, string clave)
        {
    
            string strSQL = "execute Login '" + user + "','" + clave + "'";
            string strCon = conectionDB.ConectDB();
            Console.WriteLine(strSQL);
            using (SqlConnection cnn = new SqlConnection(strCon))
            {
                using (SqlCommand myCommand = new SqlCommand(strSQL, cnn))
                {
                    cnn.Open();
                    //myCommand.Parameters.AddWithValue("@userID", user);
                    using (SqlDataReader reader = myCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Console.WriteLine(reader["nombre1"].ToString());
                            string res = string.Format("{0},{1},{2},{3} ", reader["id_usuario"], reader["fk_rol"], reader["nombre1"], reader["apellido1"]);
                            return res;
                        }
                    }
                }
            }
            return "";
        }
    }
}
