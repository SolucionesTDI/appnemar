using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
namespace Negocio
{
    public class CatalogosBL
    {
        private CatalogosDAL dal;

        public CatalogosBL()
        {
            dal = new CatalogosDAL();
        }

        public List<Catalogos> GetCatalogos(Catalogos obj)
        {
            try
            {
                return dal.GetCatalogos(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
