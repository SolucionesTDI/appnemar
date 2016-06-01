using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Catalogos
    {
        public int IdCat { get; set; }
        public string Tipo { get; set; }
        public int Enlace { get; set; }
        public string NomCat { get; set; }
    }
    public class CatTipoSesion
    {
        public int IdTipo { get; set; }
        public string TipoSesion { get; set; }
        public string Clave { get; set; }
        public bool Activo { get; set; }
    }

    public class CatTipoAcuerdo
    {
        public int IdTipoAcuerdo { get; set; }
        public string TipoAcuerdo { get; set; }
        public string Clave { get; set; }
        public bool Activo { get; set; }
    }


}
