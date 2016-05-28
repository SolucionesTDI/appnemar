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


                using (SqlCommand command = new SqlCommand("SPD_CAT_TEMAS_INS", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@descripcion", _cattemas.descripcion);

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

        public void modificarTema(CatTemas _cattemas)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_CAT_TEMAS_UPD", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idtema", _cattemas.idtema);
                    command.Parameters.AddWithValue("@descripcion", _cattemas.descripcion);

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

        public void eliminarTema(CatTemas _cattemas)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_CAT_TEMAS_DEL", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idtema", _cattemas.idtema);

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

        public List<CatTemas> obtenerTemas()
        {
            List<CatTemas> list = new List<CatTemas>();
            CatTemas cat;
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_CAT_TEMAS_GET", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
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
