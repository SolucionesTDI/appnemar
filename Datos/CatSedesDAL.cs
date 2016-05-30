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
    /// Clase de Acceso a Datos de la Entidad Sedes
    /// </summary>
    public class CatSedesDAL
    {
        private Conexion.Conexion cn;

        public CatSedesDAL()
        {
            cn = new Conexion.Conexion();
        }
        public int insertarSede(CatSedes _catsedes)
        {
            int id = 0;
            try
            {


                using (SqlCommand command = new SqlCommand("spd_cat_sede_ins", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@descripcion", _catsedes.descripcion);
                    cn.OpenConnection();
                    id = (int)command.ExecuteScalar();
                }

            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo insertar el registro de la sede" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo insertar el registro de la sede" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
           return id;
        }

        public void modificarSede(CatSedes _catsedes)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("spd_cat_sede_upd", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idsede", _catsedes.idsede);
                    command.Parameters.AddWithValue("@descripcion", _catsedes.descripcion);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo modificar el registro de la sede" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el registro de la sede" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
        }
        public void eliminarSede(CatSedes _catsedes)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("spd_cat_sede_del", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idsede", _catsedes.idsede);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                }

            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el registro de la sede" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el registro de la sede" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
        }

        public List<CatSedes> obtenerSedes(string filtro=null)
        {
            List<CatSedes> list = new List<CatSedes>();
            CatSedes cat;
            try
            {
                using (SqlCommand command = new SqlCommand("spd_catalogos_get", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    //command.Parameters.AddWithValue("@idpuesto", id == 0 ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@tipo", "sede");
                    command.Parameters.AddWithValue("@filtro", string.IsNullOrEmpty(filtro) ? (object)DBNull.Value : filtro);
                    cn.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();
                  
                    while (reader.Read())
                    {
                        cat = new CatSedes();
                        cat.idsede = (int)reader["idsede"];
                        cat.descripcion = (string)reader["descripcion"];
                        cat.fecharegistro = (DateTime)reader["fecharegistro"];
                        list.Add(cat);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo obtener registros del catalogo de sedes" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener registros del catalogo de sedes" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return list;
        }
    }
}
