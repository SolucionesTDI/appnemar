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


                using (SqlCommand command = new SqlCommand("SPD_CAT_PUESTOS_INS", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@descripcion", _catpuestos.descripcion);

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
                        throw new Exception("No se pudo guardar", ex);
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

        public void modificarPuesto(CatPuestos _catpuestos)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_CAT_PUESTOS_UPD", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idpuesto", _catpuestos.idpuesto);
                    command.Parameters.AddWithValue("@descripcion", _catpuestos.descripcion);

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

        public void eliminarPuesto(CatPuestos _catpuestos)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_CAT_PUESTOS_DEL", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idpuesto", _catpuestos.idpuesto);

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

        public List<CatPuestos> obtenerPuestos()
        {
            List<CatPuestos> list = new List<CatPuestos>();
            CatPuestos cat;
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_CAT_PUESTOS_GET", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        cn.OpenConnection();
                        while (reader.Read())
                        {
                            cat = new CatPuestos();
                            cat.idpuesto = (int)reader["idpuesto"];
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
