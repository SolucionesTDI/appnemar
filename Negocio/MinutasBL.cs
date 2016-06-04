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

        public void DelUsuarioMinuta(MinutasUsuarios obj)
        {
            try
            {
                dal.DelUsuarioMinuta(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<MinutasUsuarios> GetUsuariosSesion(MinutasUsuarios obj)
        {
            try
            {
                return dal.GetUsuariosSesion(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<MinutasAcuerdos> GetAcuerdos(MinutasAcuerdos obj)
        {
            try
            {
                return dal.GetAcuerdos(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsAcuerdos(MinutasAcuerdos obj)
        {
            try
            {
                dal.InsAcuerdos(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DelAcuerdo(MinutasAcuerdos obj)
        {
            try
            {
                dal.DelAcuerdo(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
