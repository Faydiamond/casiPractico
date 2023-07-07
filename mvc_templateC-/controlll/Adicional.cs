using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controlll
{
    public class Adicional
    {
        //traer adicionales
        public IEnumerable<Modelss.Adicionales> GetAdicionals()
        {
            using (Modelss.EF.pizeerriaEntities db = new Modelss.EF.pizeerriaEntities())
            {
                IEnumerable<Modelss.Adicionales> lst = (from d in db.adicionales
                                                      select new Modelss.Adicionales
                                                      {
                                                          id_adicional = d.id_adicional,
                                                          adicional    = d.adicional
                                                      }).ToList();
                return lst;
            }
        }

       
       
    }
}
