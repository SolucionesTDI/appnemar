using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexion;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class IndicadoresDAL
    {
        Conexion.Conexion cn;
        public IndicadoresDAL()
        {
            cn = new Conexion.Conexion();
        }

        public List<Indicadores> obtenerIndicadorSesionesStatusUsuario(int idusuario, string origen)
        {
            List<Indicadores> _lstindicadores = new List<Indicadores>();
            List<CatStatus> _lststatus = new List<CatStatus>();
            CatStatusDAL _catstatusdal = new CatStatusDAL();
            _lststatus = _catstatusdal.obtenerStatus();
            Indicadores obj;

            try
            {
                using (SqlCommand command = new SqlCommand("spd_indicadores_sesiones_get", cn.Connection))
                {
                    obj = new Indicadores();
                    obj.nombrestatus = "Total de Sesiones " +origen + "s";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idtema", DBNull.Value);
                    command.Parameters.AddWithValue("@fechaini", DBNull.Value);
                    command.Parameters.AddWithValue("@fechafin", DBNull.Value);
                    command.Parameters.AddWithValue("@idusuarios", idusuario);
                    command.Parameters.AddWithValue("@idtipos", DBNull.Value);
                    command.Parameters.AddWithValue("@idstatus", DBNull.Value);
                    command.Parameters.AddWithValue("@tipoentrega", DBNull.Value);
                    command.Parameters.AddWithValue("@idsesion", DBNull.Value);
                    command.Parameters.AddWithValue("@iduser", idusuario);
                    command.Parameters.AddWithValue("@origen","'"+ origen + "'");
                    cn.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        obj.idstatus = 0;
                        obj.idusuario = idusuario;
                        obj.indicador = (int)reader["Indicador"];
                        obj.color = "bg-purple";
                        obj.icono = "fa fa-briefcase";
                    }
                }
                _lstindicadores.Add(obj);
                foreach (CatStatus objstatus in _lststatus)
                {
                    obj = new Indicadores();
                    obj.nombrestatus = objstatus.nomstatus;
                    using (SqlCommand command = new SqlCommand("spd_indicadores_sesiones_get", cn.Connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idtema", DBNull.Value);
                        command.Parameters.AddWithValue("@fechaini", DBNull.Value);
                        command.Parameters.AddWithValue("@fechafin", DBNull.Value);
                        command.Parameters.AddWithValue("@idusuarios", idusuario);
                        command.Parameters.AddWithValue("@idtipos", DBNull.Value);
                        command.Parameters.AddWithValue("@idstatus", objstatus.idstatus);
                        command.Parameters.AddWithValue("@tipoentrega", DBNull.Value);
                        command.Parameters.AddWithValue("@idsesion", DBNull.Value);
                        command.Parameters.AddWithValue("@iduser", idusuario);
                        command.Parameters.AddWithValue("@origen", "'" + origen + "'");
                        cn.OpenConnection();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            obj.idstatus = obj.idstatus;
                            obj.idusuario = idusuario;
                            obj.indicador = (int)reader["Indicador"];
                            obj.color = objstatus.color;
                            obj.icono = objstatus.icono;
                        }
                    }
                    _lstindicadores.Add(obj);

                }


            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo obtener el indicador" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener el indicador" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }

            return _lstindicadores;

        }


    public List<Indicadores> obtenerIndicadorAcuerdosStatusUsuario(int idusuario)
        {
            List<Indicadores> _lstindicadores = new List<Indicadores>();
            List<CatStatus> _lststatus = new List<CatStatus>();
            CatStatusDAL _catstatusdal = new CatStatusDAL();
            _lststatus = _catstatusdal.obtenerStatus();
            Indicadores obj;
          
            try
            {
                using (SqlCommand command = new SqlCommand("spd_indicadores_acuerdos_get", cn.Connection))
                {
                    obj = new Indicadores();
                    obj.nombrestatus = "Total de Acuerdos";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idstatus", DBNull.Value);
                    command.Parameters.AddWithValue("@idusuario", idusuario);
                    cn.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        obj.idstatus = 0;
                        obj.idusuario = idusuario;
                        obj.indicador = (int)reader["Indicador"];
                        obj.color = "bg-purple";
                        obj.icono = "fa fa-briefcase";

                    }
                }
                _lstindicadores.Add(obj);
                foreach (CatStatus objstatus in _lststatus)
                {
                    obj = new Indicadores();
                    obj.nombrestatus = objstatus.nomstatus;
                    using (SqlCommand command = new SqlCommand("spd_indicadores_acuerdos_get", cn.Connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idstatus", objstatus.idstatus);
                        command.Parameters.AddWithValue("@idusuario", idusuario);
                        cn.OpenConnection();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            obj.idstatus = objstatus.idstatus;
                            obj.idusuario = idusuario;
                            obj.indicador = (int)reader["Indicador"];
                            obj.color = objstatus.color;
                            obj.icono = objstatus.icono;

                        }
                    }
                    _lstindicadores.Add(obj);

                }

               
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo obtener el indicador" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener el indicador" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }

            return _lstindicadores;

        }
       

    }
}
