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
    /// Clase de Acceso a Datos de la Entidad Puestos
    /// </summary>
    public class CatPuestosDAL
    {
        private Conexion.Conexion cn;

        public CatPuestosDAL()
        {
            cn = new Conexion.Conexion();
        }
        public int insertarPuesto(CatPuestos _catpuestos)
        {
            int id = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("spd_cat_puestos_ins", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@descripcion", _catpuestos.descripcion);
                    cn.OpenConnection();
                    id = (int)command.ExecuteScalar();
                 }

            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo insertar el registro del puesto" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo insertar el registro del puesto" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return id;

        }

        public void modificarPuesto(CatPuestos _catpuestos)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("spd_cat_puestos_upd", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idpuesto", _catpuestos.idpuesto);
                    command.Parameters.AddWithValue("@descripcion", _catpuestos.descripcion);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                 }

            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo modificar el registro del puesto" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el registro del puesto" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }

        }

        public void eliminarPuesto(CatPuestos _catpuestos)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("spd_cat_puestos_del", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idpuesto", _catpuestos.idpuesto);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                  }

            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el registro del puesto" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el registro del puesto" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
        }

        public List<CatPuestos> obtenerPuestos(string filtro = null)
        {
            List<CatPuestos> list = new List<CatPuestos>();
            CatPuestos cat;
            try
            {
                using (SqlCommand command = new SqlCommand("spd_catalogos_get", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    //command.Parameters.AddWithValue("@idpuesto", id == 0 ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@tipo", "puestos");
                    command.Parameters.AddWithValue("@filtro", string.IsNullOrEmpty(filtro) ? (object)DBNull.Value : filtro);
                    cn.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    
                        while (reader.Read())
                        {
                            cat = new CatPuestos();
                            cat.idpuesto = (int)reader["idpuesto"];
                            cat.descripcion = (string)reader["descripcion"];
                            cat.fecharegistro = (DateTime)reader["fecharegistro"];
                            list.Add(cat);
                        }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo obtener registros del catalogo de puestos" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener registros del catalogo de puestos" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return list;
        }
    }
}
