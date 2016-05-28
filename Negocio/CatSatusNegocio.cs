using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class CatSatusNegocio
    {
        public int insertarStatu(CatStatus _catstatus)
        {
            CatStatusDAL _catstatusDAL = new CatStatusDAL();
            return _catstatusDAL.insertarStatu(_catstatus);
        }
        public void modificarStatu(CatStatus _catstatus)
        {

            CatStatusDAL _catstatusDAL = new CatStatusDAL();
            _catstatusDAL.modificarStatus(_catstatus);
        }

        public void eliminarStatu(CatStatus _catstatus)
        {
            CatStatusDAL _catstatusDAL = new CatStatusDAL();
            _catstatusDAL.eliminarStatus(_catstatus);
        }

        public List<CatStatus> list()
        {
            CatStatusDAL _catstatusDAL = new CatStatusDAL();
            return _catstatusDAL.obtenerStatus();
        }
    }
}
