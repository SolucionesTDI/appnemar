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
            try
            {
                CatSedesDAL _catsedesDAL = new CatSedesDAL();
                return _catsedesDAL.insertarSede(_catsedes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void modificarSede(CatSedes _catsedes)
        {
            try
            {
                CatSedesDAL _catsedesDAL = new CatSedesDAL();
                _catsedesDAL.modificarSede(_catsedes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void eliminarSede(CatSedes _catsedes)
        {
            try
            {
                CatSedesDAL _catsedesDAL = new CatSedesDAL();
                _catsedesDAL.eliminarSede(_catsedes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CatSedes> list(string filtro = null)
        {
            try
            {
                CatSedesDAL _catsedesDAL = new CatSedesDAL();
                return _catsedesDAL.obtenerSedes(filtro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
