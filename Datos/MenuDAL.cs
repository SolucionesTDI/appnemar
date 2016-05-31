using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Conexion;
using Entidades;

namespace Datos
{
    public class MenuDAL
    {
        private Conexion.Conexion cn;

        public MenuDAL()
        {
            cn = new Conexion.Conexion();
        }

        public List<Menu> GetMenus(int idperfil)
        {
            List<Menu> list = new List<Menu>();
            Menu ent;
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_MENUS_BYPERFIL", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idperfil", idperfil);
                    cn.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        ent = new Menu();
                        ent.Idmenu = (int)reader["idmenu"];
                        ent.nommenu = (string)reader["nommenu"];
                        ent.urlmenu = (string)reader["urlmenu"];
                        ent.orden = (int)reader["orden"];
                        ent.idpadre = (int)reader["idpadre"];
                        ent.icono = (string)reader["icono"];
                        list.Add(ent);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error BD No se pudo obtener la lista de menus " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error code No se pudo obtener la lista de menus " + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return list;
        }
    }
}
