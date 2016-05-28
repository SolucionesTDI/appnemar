using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase de la Entidad Sedes
    /// </summary>
    public class CatSedes
    {
        public int idsede { get; set; }
        public string descripcion { get; set; }
        public DateTime fecharegistro { get; set; }
        public Boolean activo { get; set; }

        //COMANETARIO CHACA
        /// <summary>
        /// Constructor
        /// </summary>
        public CatSedes() { }
    }
}
