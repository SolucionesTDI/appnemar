using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class MinutasBL
    {
        private MinutasDAL dal;

        public MinutasBL()
        {
            dal = new MinutasDAL();
        }

        public int InsMinuta(Minutas obj)
        {
            try
            {
                return dal.InsMinuta(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Minutas> GetMinutas(Minutas obj)
        {
            try
            {
                return dal.GetMinutas(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsUsuariosbyMinuta(MinutasUsuarios obj)
        {
            try
            {
                dal.InsUsuariosbyMinuta(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DelUsuarioMinuta(int idusuario)
        {
            try
            {
                dal.DelUsuarioMinuta(idusuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
