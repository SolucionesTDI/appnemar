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


                using (SqlCommand command = new SqlCommand("SPD_CAT_SEDES_INS", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@descripcion", _catsedes.descripcion);

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

        public void modificarSede(CatSedes _catsedes)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_CAT_SEDES_UPD", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idsede", _catsedes.idsede);
                    command.Parameters.AddWithValue("@descripcion", _catsedes.descripcion);

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

        public void eliminarSede(CatSedes _catsedes)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_CAT_SEDES_DEL", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idsede", _catsedes.idsede);

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

        public List<CatSedes> obtenerSedes()
        {
            List<CatSedes> list = new List<CatSedes>();
            CatSedes cat;
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_CAT_SEDES_GET", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        cn.OpenConnection();
                        while (reader.Read())
                        {
                            cat = new CatSedes();
                            cat.idsede = (int)reader["idsede"];
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
