using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexion;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class EmailDAL
    {
        Conexion.Conexion cn;

        public EmailDAL()
        {
            cn = new Conexion.Conexion();
        }

        public Email GetEmail(Email obj)
        {
            Email ent=new Email();
            try
            {

                using (SqlCommand command = new SqlCommand("SPD_SERVEREMAIL_GET", cn.Connection))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDMAIL",obj.IdMail==0 ? (object)DBNull.Value : obj.IdMail);
                    command.Parameters.AddWithValue("@USERMAIL", string.IsNullOrEmpty(obj.Usermail) ? (object)DBNull.Value : obj.Usermail);
                    command.Parameters.AddWithValue("@PRINCIPAL", (obj.Principal==null) ? (object)DBNull.Value : obj.Principal);

                    cn.OpenConnection();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ent.IdMail = (int)reader["IDMAIL"];
                            ent.Imap = (string)reader["IMAP"];
                            ent.Smtp = (string)reader["SMTP"];
                            ent.PortImap = (int)reader["PORTIMAP"];
                            ent.PortSmtp = (int)reader["PORTSMTP"];
                            ent.Ssl = (bool)reader["SSL"];
                            ent.Servermail = (string)reader["SERVER"];
                            ent.Usermail = (string)reader["USERMAIL"];
                            ent.Passmail = (string)reader["PASSMAIL"];
                            ent.Principal = (bool)reader["PRINCIPAL"];
                            ent.MailFromName = (string)reader["namefrom"];
                            ent.MailFrom = (string)reader["emailfrom"];

                        }
                    }


                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error BD No se pudo obtener los datos del email" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error code No se pudo obtener los datos del email " + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return ent;
        }


    }
}
