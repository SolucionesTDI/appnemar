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
            try
            {
                CatStatusDAL _catstatusDAL = new CatStatusDAL();
                return _catstatusDAL.insertarStatu(_catstatus);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void modificarStatu(CatStatus _catstatus)
        {
            try
            {
                CatStatusDAL _catstatusDAL = new CatStatusDAL();
                _catstatusDAL.modificarStatus(_catstatus);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void eliminarStatu(CatStatus _catstatus)
        {
            try
            {
                CatStatusDAL _catstatusDAL = new CatStatusDAL();
                _catstatusDAL.eliminarStatus(_catstatus);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CatStatus> list(string filtro=null)
        {
            try
            {
                CatStatusDAL _catstatusDAL = new CatStatusDAL();
                return _catstatusDAL.obtenerStatus(filtro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
