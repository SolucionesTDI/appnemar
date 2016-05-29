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
    /// <summary>
    /// Clase de Capa de Datos Departamentos
    /// </summary>
    public class CatDepartamentosDAL
    {
        private Conexion.Conexion cn;

        public CatDepartamentosDAL()
        {
            cn = new Conexion.Conexion();
        }
        public int insertarDepartamento(CatDepartamentos _catdepartamentos)
        {
            int id = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("spd_cat_departamentos_ins", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@descripcion", _catdepartamentos.descripcion);
                    cn.OpenConnection();
                    id = (int)command.ExecuteScalar();
                 }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo insertar el registro del departamento" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo insertar el registro del departamento" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }

            return id;
                                     
           
        }

        public void modificarDepartamento(CatDepartamentos _catdepartamentos)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("spd_cat_departamentos_upd", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@iddepto", _catdepartamentos.iddepto);
                    command.Parameters.AddWithValue("@descripcion", _catdepartamentos.descripcion);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo modificar el registro del departamento" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el registro del departamento" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }

        }

        public void eliminarDepartamento(CatDepartamentos _catdepartamentos)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("spd_cat_departamentos_del", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@iddepto", _catdepartamentos.iddepto);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el registro del departamento" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el registro del departamento" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
        }

        public List<CatDepartamentos> obtenerDepartamentos(string filtro = null)
        {
            List<CatDepartamentos> list = new List<CatDepartamentos>();
            CatDepartamentos cat;
            try
            {
                using (SqlCommand command = new SqlCommand("spd_catalogos_get", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    //command.Parameters.AddWithValue("@iddepto", id == 0 ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@tipo", "departamentos");
                    command.Parameters.AddWithValue("@filtro", string.IsNullOrEmpty(filtro) ? (object)DBNull.Value : filtro);
                    cn.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        cat = new CatDepartamentos();
                        cat.iddepto = (int)reader["iddepto"];
                        cat.descripcion = (string)reader["descripcion"];
                        cat.fecharegistro = (DateTime)reader["fecharegistro"];
                        list.Add(cat);
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
