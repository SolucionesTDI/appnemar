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


                using (SqlCommand command = new SqlCommand("SPD_CAT_DEPARTAMENTOS_INS", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@descripcion", _catdepartamentos.descripcion);
                                     
                    try
                    {
                        cn.OpenConnection();
                        id = (int)command.ExecuteScalar();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("No se pudo guardar",ex);
                    }
                    finally
                    {
                        cn.CloseConnection();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
         
           return id;
                                     
           
        }

        public void modificarDepartamento(CatDepartamentos _catdepartamentos)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_CAT_DEPARTAMENTOS_UPD", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@iddpeto", _catdepartamentos.iddepto);
                    command.Parameters.AddWithValue("@descripcion", _catdepartamentos.descripcion);

                    try
                    {
                        cn.OpenConnection();
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("No se pudo actualizar el registro", ex);
                    }
                    finally
                    {
                        cn.CloseConnection();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void eliminarDepartamento(CatDepartamentos _catdepartamentos)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_CAT_DEPARTAMENTOS_DEL", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@iddpeto", _catdepartamentos.iddepto);
               
                    try
                    {
                        cn.OpenConnection();
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("No se pudo eliminar el registro", ex);
                    }
                    finally
                    {
                        cn.CloseConnection();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CatDepartamentos> obtenerDepartamentos()
        {
            List<CatDepartamentos> list = new List<CatDepartamentos>();
            CatDepartamentos cat;
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_CAT_DEPARTAMENTOS_GET", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        cn.OpenConnection();
                        while (reader.Read())
                        {
                            cat = new CatDepartamentos();
                            cat.iddepto = (int)reader["iddepto"];
                            cat.descripcion = (string)reader["descripcion"];
                            cat.fecharegistro = (DateTime)reader["fecharegistro"];
                            list.Add(cat);
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("No se pudo obtener los datos", ex);
                    }
                    finally
                    {
                        cn.CloseConnection();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
    }
}
