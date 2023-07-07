using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controlll
{
    public class Estados
    {
        //traer estados
        public IEnumerable<Modelss.Estados> GetStates()
        {
            using (Modelss.EF.pizeerriaEntities db = new Modelss.EF.pizeerriaEntities())
            {
                IEnumerable<Modelss.Estados> lst = (from d in db.estados
                                                      select new Modelss.Estados
                                                      {
                                                          id_estado = d.id_estado,
                                                          estado = d.estado
                                                      }).ToList();
                return lst;
            }
        }

    }
}
