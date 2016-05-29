using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Menu
    {
        public int Idmenu { get; set; }
        public string nommenu { get; set; }
        public string urlmenu { get; set; }
        public int orden { get; set; }
        public int idpadre { get; set; }
        public DateTime fecharegistro { get; set; }
        public Boolean activo { get; set; }
        public string icono { get; set; }
        public Menu() { }
    }
}
