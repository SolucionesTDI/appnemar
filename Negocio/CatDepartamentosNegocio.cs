using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class CatDepartamentosNegocio
    {
        public int insertarDepartamento(CatDepartamentos _catdepartamentos)
        {
            try
            {
                CatDepartamentosDAL _catdepartamentosDAL = new CatDepartamentosDAL();
                return _catdepartamentosDAL.insertarDepartamento(_catdepartamentos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void modificarDepartamento(CatDepartamentos _catdepartamentos)
        {
            try
            {
                CatDepartamentosDAL _catdepartamentosDAL = new CatDepartamentosDAL();
                _catdepartamentosDAL.modificarDepartamento(_catdepartamentos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void eliminarDepartamento(CatDepartamentos _catdepartamentos)
        {
            try
            {
                CatDepartamentosDAL _catdepartamentosDAL = new CatDepartamentosDAL();
                _catdepartamentosDAL.eliminarDepartamento(_catdepartamentos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CatDepartamentos> list(string filtro = null)
        {
            try
            {
                CatDepartamentosDAL _catdepartamentosDAL = new CatDepartamentosDAL();
                return _catdepartamentosDAL.obtenerDepartamentos(filtro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
