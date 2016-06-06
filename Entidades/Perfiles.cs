using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Perfiles
    {
        public int IdPerfil { get; set; }
        public string NomPerfil { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }
    }
}
