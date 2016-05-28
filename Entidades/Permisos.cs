using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Permisos
    {
        public int idpermiso { get; set; }
        public string descripcion { get; set; }
        public DateTime fecharegistro { get; set; }
        public Boolean activo { get; set; }
        public string tipo { get; set; }
        public string clave { get; set; }
        public Permisos() { }
    }
}
