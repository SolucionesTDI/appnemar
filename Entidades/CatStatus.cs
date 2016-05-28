using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    /// <summary>
    /// Clase de la Entidad Status
    /// </summary>
    public class CatStatus
    {
        public int idstatus { get; set; }
        public string nomstatus { get; set; }
        public int orden { get; set; }
        public DateTime fecharegistro { get; set; }
        public Boolean activo { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public CatStatus() { }
    }
}
