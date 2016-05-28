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
            try
            {
                CatTemasDAL _cattemasDAL = new CatTemasDAL();
                return _cattemasDAL.insertarTema(_cattemas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void modificarTema(CatTemas _cattemas)
        {
            try
            {
                CatTemasDAL _cattemasDAL = new CatTemasDAL(); ;
                _cattemasDAL.modificarTema(_cattemas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void eliminarTema(CatTemas _cattemas)
        {
            try
            {
                CatTemasDAL _cattemasDAL = new CatTemasDAL();
                _cattemasDAL.eliminarTema(_cattemas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CatTemas> list(string filtro=null)
        {
            try
            {
                CatTemasDAL _cattemasDAL = new CatTemasDAL();
                return _cattemasDAL.obtenerTemas(filtro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
