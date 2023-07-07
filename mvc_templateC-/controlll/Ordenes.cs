using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controlll
{
    public class Ordenes
    {
        controlll.StrConection conectionDB = new controlll.StrConection();
        //crera ordenes
        public bool CrearOrden(int id_orden,int usuario, int estado, int producto, int adicional, int tamano, string instrucciones)
        {
            string strSQL = "";
            string stringConection = conectionDB.ConectDB();
            if (id_orden > 0)
            {
                //edit
                strSQL = string.Format("execute  update_order {0},{1},{2},{3},{4},{5},'{6}' ", id_orden, usuario, producto, estado, adicional, tamano, instrucciones);

                Console.WriteLine("////////////////////////////////////////////");
                Console.WriteLine(strSQL);
                Console.WriteLine("////////////////////////////////////////////");
            }
            else if (id_orden == 0)
            {
                strSQL = string.Format("execute  create_orden {0},{1},{2},{3},{4},'{5}' ", usuario, producto, estado, adicional, tamano, instrucciones);
            }
            

            

            //string strSQL = "Select * From [User] where UserId = @userID";
            Console.WriteLine("Xrear Orden : ", strSQL);
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


        //traer ordenes
        public IEnumerable<Modelss.Ordenes> GetOrders()
        {
            using (Modelss.EF.pizeerriaEntities db = new Modelss.EF.pizeerriaEntities())
            {
                IEnumerable<Modelss.Ordenes> lst = (from o in db.ordenes 
                                                      join usuarios in db.usuarios
                                                      on o.fk_usuario equals usuarios.id_usuario
                                                      join productos in db.productos
                                                      on o.fk_producto equals productos.id_producto
                                                      join tamanos in db.tamanos
                                                      on o.fk_tamano equals tamanos.id_tamano
                                                      join adicionales in db.adicionales
                                                      on o.fk_adicional equals adicionales.id_adicional
                                                      join estados in db.estados
                                                      on o.fk_estado equals estados.id_estado
                                                      
                                                      select new Modelss.Ordenes
                                                      {
                                                          id_orden = o.id_orden,
                                                          usuario = usuarios.nombre1,
                                                          direccion = usuarios.direccion,
                                                          telefono =usuarios.telefono,
                                                          producto = productos.producto,
                                                          tamano = tamanos.tamano,
                                                          adicional = adicionales.adicional,
                                                          instrucciones = o.instrucciones,
                                                          estado = estados.estado
                                                      }

                                                      ).ToList();
                return lst;
            }
        }


        //tarer ordenes opor usuario
        //traer ordenes
        public IEnumerable<Modelss.OrdenesUser> GetOrdersByUsers(int id_user)
        {
            using (Modelss.EF.pizeerriaEntities db = new Modelss.EF.pizeerriaEntities())
            {
                IEnumerable<Modelss.OrdenesUser> lst = (from o in db.ordenes
                                                    
                                                    join usuarios in db.usuarios
                                                    on o.fk_usuario equals usuarios.id_usuario
                                                    join productos in db.productos
                                                    on o.fk_producto equals productos.id_producto
                                                    join tamanos in db.tamanos
                                                    on o.fk_tamano equals tamanos.id_tamano
                                                    join adicionales in db.adicionales
                                                    on o.fk_adicional equals adicionales.id_adicional
                                                    join estados in db.estados
                                                    on o.fk_estado equals estados.id_estado
                                                    where o.fk_usuario == id_user

                                                    select new Modelss.OrdenesUser
                                                    {
                                                        id_orden = o.id_orden,
                                                        direccion = usuarios.direccion,
                                                        telefono = usuarios.telefono,
                                                        producto = productos.producto,
                                                        tamano = tamanos.tamano,
                                                        adicional = adicionales.adicional,
                                                        instrucciones = o.instrucciones,
                                                        estado = estados.estado
                                                    }

                                                      ).ToList();
                return lst;
            }
        }

    }

}
