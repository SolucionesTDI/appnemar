using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class CatTemasNegocio
    {
        public int insertarTema(CatTemas _cattemas)
        {
            CatTemasDAL _cattemasDAL = new CatTemasDAL();
            return _cattemasDAL.insertarTema(_cattemas);
        }
        public void modificarTema(CatTemas _cattemas)
        {

            CatTemasDAL _cattemasDAL = new CatTemasDAL(); ;
            _cattemasDAL.modificarTema(_cattemas);
        }

        public void eliminarTema(CatTemas _cattemas)
        {
            CatTemasDAL _cattemasDAL = new CatTemasDAL();
            _cattemasDAL.eliminarTema(_cattemas);
        }

        public List<CatTemas> list()
        {
            CatTemasDAL _cattemasDAL = new CatTemasDAL();
            return _cattemasDAL.obtenerTemas();
        }
    }
}
