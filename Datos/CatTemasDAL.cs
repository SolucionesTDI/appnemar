using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;
using System.Data;

namespace Datos
{
    /// <summary>
    /// Clase de Acceso a Datos de la Entidad Temas
    /// </summary>
    public class CatTemasDAL
    {
        private Conexion.Conexion cn;

        public CatTemasDAL()
        {
            cn = new Conexion.Conexion();
        }
        public int insertarTema(CatTemas _cattemas)
        {
            int id = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("spd_cat_temas_ins", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@descripcion", _cattemas.descripcion);
                    cn.OpenConnection();
                    id = (int)command.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo insertar el registro del tema" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo insertar el registro del tema" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return id;
        }
        public void modificarTema(CatTemas _cattemas)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("spd_cat_temas_upd", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idtema", _cattemas.idtema);
                    command.Parameters.AddWithValue("@descripcion", _cattemas.descripcion);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo modificar el registro del tema" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modifcar el registro del tema" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }

        }

        public void eliminarTema(CatTemas _cattemas)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("spd_cat_temas_del", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idtema", _cattemas.idtema);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el registro del tema" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el registro del tema" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
        }

        public List<CatTemas> obtenerTemas(string filtro=null)
        {
            List<CatTemas> list = new List<CatTemas>();
            CatTemas cat;
            try
            {
                using (SqlCommand command = new SqlCommand("spd_catalogos_get", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    //command.Parameters.AddWithValue("@idpuesto", id == 0 ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@tipo", "temas");
                    command.Parameters.AddWithValue("@filtro", string.IsNullOrEmpty(filtro) ? (object)DBNull.Value : filtro);
                    SqlDataReader reader = command.ExecuteReader();
                    cn.OpenConnection();
                    while (reader.Read())
                    {
                        cat = new CatTemas();
                        cat.idtema = (int)reader["idtema"];
                        cat.descripcion = (string)reader["descripcion"];
                        cat.fecharegistro = (DateTime)reader["fecharegistro"];
                        list.Add(cat);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo obtener registros del catalogo de temas" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener registros del catalogo de temas" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return list;
        }
    }
}
