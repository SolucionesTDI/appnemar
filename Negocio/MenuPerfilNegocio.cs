using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;


namespace Negocio
{
    public class MenuPerfilNegocio
    {
        MenuPerfilDAL _menuperfilesDAL = new MenuPerfilDAL();

        public int insertarMenuPerfil(Perfiles _objperfil, Menu _objmenu)
        {
            try
            {
                return _menuperfilesDAL.insertarMenuPerfil(_objperfil, _objmenu);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void actualizarMenuPerfiles(Perfiles _objperfil,List<Menu> _lstmenu)
        {
            try
            {
                _menuperfilesDAL.actualizarMenuPerfiles(_objperfil,_lstmenu);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<MenuPerfil> obtenerMenuPerfiles(int id=0)
        {
            try
            {
                return _menuperfilesDAL.obtenerMenuPerfiles(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
