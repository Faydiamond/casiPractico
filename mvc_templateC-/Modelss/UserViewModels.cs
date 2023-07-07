using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelss
{
    public class UserViewModels
    {
        public   int id_producto { get; set; }
        public string producto { get; set; }
        public string descripcion { get; set; }
        public int stock { get; set; }
        public float precio_venta { get; set; }

    }
}
