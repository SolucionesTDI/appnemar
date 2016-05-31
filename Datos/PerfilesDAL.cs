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
    public class PerfilesDAL
    {
        private Conexion.Conexion cn;

        public PerfilesDAL()
        {
            cn = new Conexion.Conexion();
        }
        public List<Perfiles> obtenerPerfiles(int id=0)
        {
            List<Perfiles> list = new List<Perfiles>();
            Perfiles cat;
            try
            {
                using (SqlCommand command = new SqlCommand("spd_perfiles_get", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id == 0 ? (object)DBNull.Value : id);
                    cn.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cat = new Perfiles();
                        cat.IdPerfil = (int)reader["idperfil"];
                        cat.NomPerfil = (string)reader["nomperfil"];
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
