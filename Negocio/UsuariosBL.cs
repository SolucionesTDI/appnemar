using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using Entidades;
namespace Negocio
{
    public class UsuariosBL
    {
        private UsuariosDAL dal;

        public UsuariosBL()
        {
            dal = new UsuariosDAL();
        }

        public Usuarios Sigin(string user, string password)
        {
            try
            {
                return dal.Sigin(user, password);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
        public void insertUsuario(UsuariosDatos _catusuariosdatos)
        {
            try
            {
                UsuariosDAL _catusuariosdal = new UsuariosDAL();
                _catusuariosdal.insertarUsuarios(_catusuariosdatos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void modificarUsuario(UsuariosDatos _catusuariosdatos)
        {
            try
            {
                UsuariosDAL _catusuariosdal = new UsuariosDAL();
                _catusuariosdal.modificarUsuarios(_catusuariosdatos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void eliminarUsuario(UsuariosDatos _catusuariosdatos)
        {
            try
            {
                UsuariosDAL _catusuariosdal = new UsuariosDAL();
                _catusuariosdal.eliminarUsuario(_catusuariosdatos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void cambiarPassword(UsuariosDatos _catusuariosdatos)
        {
            try
            {
                UsuariosDAL _catusuariosdal = new UsuariosDAL();
                _catusuariosdal.cambiarPassword(_catusuariosdatos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<UsuariosDatos> list(int idsede=0,int iddepto=0,int idpuesto=0, int idusuario=0,string filtro = null)
        {
            try
            {
                UsuariosDAL _catusuariosdal = new UsuariosDAL();
                return _catusuariosdal.obtenerUsuarios(idsede, iddepto, idpuesto, idusuario, filtro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
