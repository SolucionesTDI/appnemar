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
            CatDepartamentosDAL _catdepartamentosDAL = new CatDepartamentosDAL();
            return _catdepartamentosDAL.insertarDepartamento(_catdepartamentos);
        }
        public void modificarDepartamento(CatDepartamentos _catdepartamentos)
        {

            CatDepartamentosDAL _catdepartamentosDAL = new CatDepartamentosDAL();
            _catdepartamentosDAL.modificarDepartamento(_catdepartamentos);
        }

        public void eliminarDepartamento(CatDepartamentos _catdepartamentos)
        {
            CatDepartamentosDAL _catdepartamentosDAL = new CatDepartamentosDAL();
            _catdepartamentosDAL.eliminarDepartamento(_catdepartamentos)
        }

        public List<CatDepartamentos> list()
        {
            CatDepartamentosDAL _catdepartamentosDAL = new CatDepartamentosDAL();
            return _catdepartamentosDAL.obtenerDepartamentos();
        }
    }
}
