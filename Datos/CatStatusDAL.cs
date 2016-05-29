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
    
    public class CatStatusDAL
    {
        private Conexion.Conexion cn;

        public CatStatusDAL()
        {
            cn = new Conexion.Conexion();
        }
        public int insertarStatu(CatStatus _catstatus)
        {
            int id = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("spd_cat_status_ins", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nomstatus", _catstatus.nomstatus);
                    command.Parameters.AddWithValue("@orden", _catstatus.orden);
                    cn.OpenConnection();
                    id = (int)command.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo insertar el registro del status" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo insertar el registro del status" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return id;
        }

        public void modificarStatus(CatStatus _catstatus)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("spd_cat_status_upd", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idstatus", _catstatus.idstatus);
                    command.Parameters.AddWithValue("@nomstatus", _catstatus.nomstatus);
                    command.Parameters.AddWithValue("@orden", _catstatus.orden);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo modificar el registro del status" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el registro del status" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }

        }

        public void eliminarStatus(CatStatus _catstatus)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("spd_cat_status_del", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idstatus", _catstatus.idstatus);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el registro del status" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el registro del status" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
        }
        public List<CatStatus> obtenerStatus(string filtro=null)
        {
            List<CatStatus> list = new List<CatStatus>();
            CatStatus cat;
            try
            {
                using (SqlCommand command = new SqlCommand("spd_catalogos_get", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    //command.Parameters.AddWithValue("@idpuesto", id == 0 ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@tipo", "status");
                    command.Parameters.AddWithValue("@filtro", string.IsNullOrEmpty(filtro) ? (object)DBNull.Value : filtro);
                    cn.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        cat = new CatStatus();
                        cat.idstatus = (int)reader["idstatus"];
                        cat.nomstatus = (string)reader["nomstatus"];
                        cat.orden = (int)reader["orden"];
                        cat.fecharegistro = (DateTime)reader["fecharegistro"];
                        list.Add(cat);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo modificar el registro del status" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el registro del status" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }

            return list;
        }

    }
}
