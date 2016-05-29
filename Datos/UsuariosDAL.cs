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
    public class UsuariosDAL
    {
        Conexion.Conexion cn;
        public UsuariosDAL()
        {
            cn = new Conexion.Conexion();
        }

        public Usuarios Sigin(string user, string password)
        {
            Usuarios usuario = new Usuarios() { Perfil=new Perfiles()};
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_USUARIO_SIGIN", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@usuario", user);
                    command.Parameters.AddWithValue("@pass", password);

                    cn.OpenConnection();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario.IdUser=(int)reader["idusuario"];
                            usuario.Username=(string)reader["username"];
                            usuario.Perfil.IdPerfil=(int)reader["idperfil"];
                            usuario.Perfil.NomPerfil=(string)reader["nomperfil"];
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error BD al Autenticar Usuario. " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Code al Autenticar Usuario. "+ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }

            return usuario;
        }
          

    }
}
