using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    /// <summary>
    /// Clase de la Entidad Departamentos
    /// </summary>
    public class CatDepartamentos
    {
        public int iddepto { get; set; }
        public string descripcion { get; set; }
        public DateTime fecharegistro { get; set; }
        public Boolean activo { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public CatDepartamentos() { }
    }
}
