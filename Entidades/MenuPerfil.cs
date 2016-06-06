using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MenuPerfil
    {
        public int idmenuperfil { get; set; }
        public Menu objMenu { get; set; }
        public Perfiles objPerfil { get; set; }
        public int idusuario { get; set; }
        public DateTime fecharegistro { get; set; }
        public MenuPerfil() { }
    }
}
