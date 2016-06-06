using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;
using Conexion;

namespace Datos
{
    public class MenuPerfilDAL
    {

        private Conexion.Conexion cn;

        public MenuPerfilDAL()
        {
            cn = new Conexion.Conexion();
        }

        public int insertarMenuPerfil(Perfiles _objperfil, Menu _objmenu)
        {
            int id = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("spd_menuperfiles_ins", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idmenu", _objmenu.Idmenu);
                    command.Parameters.AddWithValue("@idperfil", _objperfil.IdPerfil);
                    command.Parameters.AddWithValue("@usergestiono", _objperfil.IdUsuario);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo insertar el registro del menu perfil" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo insertar el registro del menu perfil" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return id;
        }
        public void actualizarMenuPerfiles(Perfiles _objperfil, List<Menu> _lstmenu)
        {
            try
            {

                eliminarMenuPerfiles(_objperfil);
                foreach (Entidades.Menu _objmenu in _lstmenu.GroupBy(i => i.Idmenu).Select(g => g.First()).ToList())
                {

                    insertarMenuPerfil(_objperfil, _objmenu);

                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo actualizar el registro del menu perfil" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo actualizar el registro del menu perfil" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }

        }
        public void eliminarMenuPerfiles(Perfiles _objperfil)
        {
           
            try
            {
                using (SqlCommand command = new SqlCommand("spd_menuperfiles_del", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idperfil", _objperfil.IdPerfil);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el registro del menu perfil" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el registro del menu perfil" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
         
        }

        public List<MenuPerfil> obtenerMenuPerfiles(int id = 0)
        {
            List<MenuPerfil> list = new List<MenuPerfil>();
            MenuPerfil obj;
            try
            {
                using (SqlCommand command = new SqlCommand("spd_menuperfiles_get", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idperfil", id == 0 ? (object)DBNull.Value : id);
                    cn.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        obj = new MenuPerfil();
                        obj.objMenu = new Menu();
                        obj.objPerfil = new Perfiles();
                        obj.idmenuperfil = (int)reader["idmenuperfil"];
                        obj.objMenu.Idmenu = (int)reader["idmenu"];
                        obj.objPerfil.IdPerfil = (int)reader["idperfil"];
                        obj.fecharegistro = (DateTime)reader["fecharegistro"];
                        list.Add(obj);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo obtener registros de los menu perfiles" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener registros de los menu perfiles" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return list;
        }
    }
}
