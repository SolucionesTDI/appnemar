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


                using (SqlCommand command = new SqlCommand("SPD_CAT_STATUS_INS", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nomstatus", _catstatus.nomstatus);
                    command.Parameters.AddWithValue("@orden", _catstatus.orden);

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

        public void modificarStatus(CatStatus _catstatus)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_CAT_STATUS_UPD", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idstatus", _catstatus.idstatus);
                    command.Parameters.AddWithValue("@nomstatus", _catstatus.nomstatus);
                    command.Parameters.AddWithValue("@orden", _catstatus.orden);

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

        public void eliminarStatus(CatStatus _catstatus)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_CAT_STATUS_DEL", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idstatus", _catstatus.idstatus);

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

        public List<CatStatus> obtenerStatus()
        {
            List<CatStatus> list = new List<CatStatus>();
            CatStatus cat;
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_CAT_STATUS_GET", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        cn.OpenConnection();
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
