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
        PerfilesDAL _perfilesDAL;
        public int insertarPerfil(Perfiles _objperfil, List<Menu> _lstmenu)
        {
            try
            {
                _perfilesDAL = new PerfilesDAL();
                return _perfilesDAL.insertarPerfil(_objperfil,_lstmenu);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void modificarPerfil(Perfiles _objperfil)
        {
            try
            {

                _perfilesDAL = new PerfilesDAL();
                _perfilesDAL.modificarPerfil(_objperfil);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void eliminarPerfil(Perfiles _objperfil)
        {
            try
            {

                _perfilesDAL = new PerfilesDAL();
                _perfilesDAL.eliminarPerfil(_objperfil);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Perfiles> list(int id=0,string filtro=null)
        {
            try
            {

                _perfilesDAL = new PerfilesDAL();
                return _perfilesDAL.obtenerPerfiles(id,filtro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Menu> listmenus(int id=0)
        {
            try
            {

                _perfilesDAL = new PerfilesDAL();
                return _perfilesDAL.obtenerMenus(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
