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
    public class PerfilesDAL
    {
        private Conexion.Conexion cn;

        public PerfilesDAL()
        {
            cn = new Conexion.Conexion();
        }
       
        public int insertarPerfil(Perfiles _objperfil, List<Menu> _lstmenu)
        {
            int id = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("spd_perfiles_ins", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nombreperfil", _objperfil.NomPerfil);
                    command.Parameters.AddWithValue("@usergestiono", _objperfil.IdUsuario);
                    cn.OpenConnection();
                    id = (int)command.ExecuteScalar();
                    Perfiles _objperfiltemp = new Perfiles();
                    _objperfiltemp = _objperfil;
                    _objperfiltemp.IdPerfil = id;
                    MenuPerfilDAL _objmenuperfil = new MenuPerfilDAL();

                    foreach (Entidades.Menu _objmenu in _lstmenu.GroupBy(i=>i.Idmenu).Select(g=>g.First()).ToList())
                    {

                        _objmenuperfil.insertarMenuPerfil(_objperfiltemp, _objmenu);

                    }
                  

                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo insertar el registro del perfil" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo insertar el registro del perfil" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }

            return id;


        }

        public void modificarPerfil(Perfiles _objperfil)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("spd_perfiles_upd", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idperfil", _objperfil.IdPerfil);
                    command.Parameters.AddWithValue("@nombreperfil", _objperfil.NomPerfil);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();      
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo modificar el registro del perfil" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el registro del perfil" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }

        }

        public void eliminarPerfil(Perfiles _objperfil)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("spd_perfiles_del", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idperfil", _objperfil.IdPerfil);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el registro del perfil" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el registro del perfil" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
        }
        public List<Perfiles> obtenerPerfiles(int id=0,string filtro = null)
        {
            List<Perfiles> list = new List<Perfiles>();
            Perfiles cat;
            try
            {
                using (SqlCommand command = new SqlCommand("spd_perfiles_get", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id == 0 ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@filtro", string.IsNullOrEmpty(filtro) ? (object)DBNull.Value : filtro);
                    cn.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cat = new Perfiles();
                        cat.IdPerfil = (int)reader["idperfil"];
                        cat.NomPerfil = (string)reader["nomperfil"];
                        cat.FechaRegistro = (DateTime)reader["fecharegistro"];
                        list.Add(cat);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo obtener registros de los perfiles" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener registros de los perfiles" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return list;
        }

        public List<Menu> obtenerMenus(int id=0)
        {
            List<Menu> list = new List<Menu>();
            Menu obj;
            try
            {
                using (SqlCommand command = new SqlCommand("spd_menu_get", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idmenu", id == 0 ? (object)DBNull.Value : id);
                    cn.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        obj = new Menu();
                        obj.Idmenu = (int)reader["idmenu"];
                        obj.nommenu = "&nbsp;&nbsp;<i class='" + (string) reader["icono"] + "'></i>&nbsp;&nbsp;" + (string)reader["nombre"];
                        obj.idpadre = (int)reader["idpadre"];
                  
                        list.Add(obj);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo obtener registros del catalogo de departamentos" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener registros del catalogo de departamentos" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return list;
        }

    }
}
