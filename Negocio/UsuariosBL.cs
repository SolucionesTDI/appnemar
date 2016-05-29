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
    }
}
