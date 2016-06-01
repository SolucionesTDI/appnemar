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
    public class CatalogosDAL
    {
        private Conexion.Conexion cn;

        public CatalogosDAL()
        {
            cn = new Conexion.Conexion();
        }

        public List<Catalogos> GetCatalogos(Catalogos obj)
        {
            List<Catalogos> list = new List<Catalogos>();
            Catalogos cat;
            try
            {
                using (SqlCommand command = new SqlCommand("spd_catalogos_get", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@tipo", obj.Tipo);
                    if(obj.Enlace>0)
                    {
                        command.Parameters.AddWithValue("@idenlace", obj.Enlace);
                    }
                    cn.OpenConnection();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            cat = new Catalogos();
                            cat.IdCat = (int)reader["id"];
                            cat.NomCat = (string)reader["nomcat"];
                            list.Add(cat);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo obtener registros del catalogo" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener registros del catalogo" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return list;
        }
    }
}
