using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class CatSedesNegocio
    {
        public int insertarSede(CatSedes _catsedes)
        {
            CatSedesDAL _catsedesDAL = new CatSedesDAL();
            return _catsedesDAL.insertarSede(_catsedes);
        }
        public void modificarSede(CatSedes _catsedes)
        {

            CatSedesDAL _catsedesDAL = new CatSedesDAL();
            _catsedesDAL.modificarSede(_catsedes);
        }

        public void eliminarSede(CatSedes _catsedes)
        {
            CatSedesDAL _catsedesDAL = new CatSedesDAL();
            _catsedesDAL.eliminarSede(_catsedes);
        }

        public List<CatSedes> list()
        {
            CatSedesDAL _catsedesDAL = new CatSedesDAL();
            return _catsedesDAL.obtenerSedes();
        }
    }
}
