using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelss
{
    class Connect
    {
         SqlConnection cnx;
        public  void conex()
        {
            cnx = new SqlConnection("Data Source=DESKTOP-3R4GENJ;Initial Catalog=pizzeria;Integrated Security=True");
        }

        public void open_cnx()
        {
            if (cnx.State == ConnectionState.Closed)
            {
                cnx.Open();
            }
        }

        public void close_cnx()
        {
            if (cnx.State == ConnectionState.Open)
            {
                cnx.Close();
            }
        }
    }
}
