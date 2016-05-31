using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class PerfilesNegocio
    {
        public List<Perfiles> list()
        {
            try
            {
                PerfilesDAL _perfilesDAL = new PerfilesDAL();
                return _perfilesDAL.obtenerPerfiles();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
