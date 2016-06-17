using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class EmailBL
    {
        EmailDAL dal = new EmailDAL();

        public EmailBL()
        {
            dal = new EmailDAL();
        }

        public Email GetEmail(Email obj)
        {
            try
            {
                return dal.GetEmail(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
