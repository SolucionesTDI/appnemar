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
    public class MinutasDAL
    {
        private Conexion.Conexion cn;
        public MinutasDAL()
        {
            cn = new Conexion.Conexion();
        }

        public int InsMinuta(Minutas obj)
        {
            int idminuta = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_SESIONES_SET", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idtema", obj.ObjTemas.idtema);
                    command.Parameters.AddWithValue("@objetivo", obj.Objetivo);
                    command.Parameters.AddWithValue("@descripcion", obj.Descripcion);
                    command.Parameters.AddWithValue("@fechafin", obj.Fechafin);
                    command.Parameters.AddWithValue("@idusuario", obj.ObjUsuarios.User.IdUser);
                    command.Parameters.AddWithValue("@idtipo", obj.ObjTipoSesion.IdTipo);
                    if (obj.IdSesion > 0)
                    {
                        command.Parameters.AddWithValue("@idsesion", obj.IdSesion);
                    }
                    SqlParameter ParamEstatus = new SqlParameter("@idnew", DbType.Int32);
                    ParamEstatus.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(ParamEstatus);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                    idminuta = Convert.ToInt32(command.Parameters["@idnew"].Value);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error BD Insertar la Minuta. " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Code al Insertar la Minuta. " + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }

            return idminuta;
        }

        public List<Minutas> GetMinutas(MinutasFiltros obj)
        {
            List<Minutas> list = new List<Minutas>();
            Minutas ent;
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_SESIONES_GET", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idtema", string.IsNullOrEmpty(obj.TemasCadena) ? (object)DBNull.Value: obj.TemasCadena);
                    command.Parameters.AddWithValue("@fechaini", obj.FechaIni.HasValue ? obj.FechaIni.Value.Date : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@fechafin", obj.FechaFin.HasValue ? obj.FechaFin.Value.Date : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@idusuarios", string.IsNullOrEmpty(obj.UsuariosCadena)? (object)DBNull.Value:obj.UsuariosCadena);
                    command.Parameters.AddWithValue("@idtipos", string.IsNullOrEmpty(obj.TipoSesionCadena) ? (object)DBNull.Value : obj.TipoSesionCadena);
                    command.Parameters.AddWithValue("@idstatus", string.IsNullOrEmpty(obj.StatusCadena)? (object)DBNull.Value:obj.StatusCadena);
                    command.Parameters.AddWithValue("@tipoentrega", string.IsNullOrEmpty(obj.TiempoEntregaCadena)?(object)DBNull.Value:obj.TiempoEntregaCadena);

                    cn.OpenConnection();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ent = new Minutas() { ObjTemas = new CatTemas(), ObjUsuarios = new UsuariosDatos() { User = new Usuarios() }, ObjTipoSesion = new CatTipoSesion(), ObjStatus = new CatStatus() };
                            ent.IdSesion = (int)reader["idsesion"];
                            ent.Objetivo = (string)reader["objetivo"];
                            ent.Descripcion = (string)reader["descripcion"];
                            ent.Fechafin = reader["fechafin"]==DBNull.Value ?null:(DateTime?)(DateTime)reader["fechafin"];
                            ent.FechaConclusion =reader["fechaconclusion"]==DBNull.Value?null: (DateTime?)(DateTime)reader["fechaconclusion"];
                            ent.Conclusion = (string)reader["conclusiones"];
                            ent.Fecharegistro = (DateTime)reader["fecharegistro"];
                            ent.ObjTemas.idtema = (int)reader["idtema"];
                            ent.ObjTemas.descripcion = (string)reader["nomtema"];
                            ent.ObjUsuarios.User.IdUser = (int)reader["idusuario"];
                            ent.ObjUsuarios.User.Username = (string)reader["username"];
                            ent.ObjUsuarios.NombreUser = (string)reader["nombreusuario"];
                            ent.ObjTipoSesion.IdTipo = (int)reader["idtipo"];
                            ent.ObjTipoSesion.TipoSesion = (string)reader["tiposesion"];
                            ent.ObjTipoSesion.Clave = (string)reader["clave"];
                            ent.ObjStatus.idstatus = (int)reader["idstatus"];
                            ent.ObjStatus.nomstatus = (string)reader["nomstatus"];
                            ent.LabelDias = (string)reader["labeldias"];
                            ent.TiempoEntrega = (string)reader["tiempoentrega"];

                            list.Add(ent);
                        }
                    }


                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error BD No se pudo obtener la lista de minutas " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error code No se pudo obtener la lista de minutas " + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return list;
        }

        public Minutas GetMinutasbyFolio(Minutas obj)
        {
            Minutas ent = new Minutas() { ObjTemas = new CatTemas(), ObjUsuarios = new UsuariosDatos() { User = new Usuarios() }, ObjTipoSesion = new CatTipoSesion(), ObjStatus = new CatStatus() };

            try
            {
                using (SqlCommand command = new SqlCommand("SPD_SESIONES_GET", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idsesion", obj.IdSesion);
                   
                    cn.OpenConnection();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ent.IdSesion = (int)reader["idsesion"];
                            ent.Objetivo = (string)reader["objetivo"];
                            ent.Descripcion = (string)reader["descripcion"];
                            ent.Fechafin = reader["fechafin"] == DBNull.Value ? null : (DateTime?)(DateTime)reader["fechafin"];
                            ent.FechaConclusion = reader["fechaconclusion"] == DBNull.Value ? null : (DateTime?)(DateTime)reader["fechaconclusion"];
                            ent.Conclusion = (string)reader["conclusiones"];
                            ent.Fecharegistro = (DateTime)reader["fecharegistro"];
                            ent.ObjTemas.idtema = (int)reader["idtema"];
                            ent.ObjTemas.descripcion = (string)reader["nomtema"];
                            ent.ObjUsuarios.User.IdUser = (int)reader["idusuario"];
                            ent.ObjUsuarios.User.Username = (string)reader["username"];
                            ent.ObjUsuarios.NombreUser = (string)reader["nombreusuario"];
                            ent.ObjTipoSesion.IdTipo = (int)reader["idtipo"];
                            ent.ObjTipoSesion.TipoSesion = (string)reader["tiposesion"];
                            ent.ObjTipoSesion.Clave = (string)reader["clave"];
                            ent.ObjStatus.idstatus = (int)reader["idstatus"];
                            ent.ObjStatus.nomstatus = (string)reader["nomstatus"];
                            ent.LabelDias = (string)reader["labeldias"];
                            ent.TiempoEntrega = (string)reader["tiempoentrega"];

                            
                        }
                    }


                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error BD No se pudo obtener la Minuta" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error code No se pudo obtener la Minuta " + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return ent;
        }
        public void InsUsuariosbyMinuta(MinutasUsuarios obj)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_SESIONES_USUARIOS_SET", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idusuario", obj.ObjUsuarios.User.IdUser);
                    command.Parameters.AddWithValue("@idsesion", obj.ObjMinutas.IdSesion);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error BD no se pudo agregar el usuario en la minuta " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error BD no se pudo agregar el usuario en la minuta " + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
        }

        public void DelUsuarioMinuta(MinutasUsuarios obj)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_SESIONES_USUARIOS_DEL", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idusersesion", obj.IdSesionUser);
                    command.Parameters.AddWithValue("@idusergestiona", obj.ObjUsuarios.User.IdUser);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error BD no se pudo eliminar el usuario en la minuta " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error BD no se pudo eliminar el usuario en la minuta " + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
        }

        public List<MinutasUsuarios> GetUsuariosSesion(MinutasUsuarios obj)
        {
            List<MinutasUsuarios> list = new List<MinutasUsuarios>();
            MinutasUsuarios ent;
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_SESIONES_USUARIOS_GET", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idsesion", obj.ObjMinutas.IdSesion);
                    command.Parameters.AddWithValue("@idusuario", obj.ObjUsuarios.User.IdUser > 0 ? obj.ObjUsuarios.User.IdUser : (object)DBNull.Value);

                    cn.OpenConnection();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ent = new MinutasUsuarios() { ObjUsuarios = new UsuariosDatos() { User = new Usuarios() } };
                            ent.IdSesionUser = (int)reader["idsesionuser"];
                            ent.IdUserMinuta = (int)reader["idusuario"];
                            ent.ObjUsuarios.NombreCompleto = (string)reader["nombrecompleto"];
                            list.Add(ent);
                        }
                    }


                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error BD No se pudo obtener la lista de usuarios de la sesion " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error code No se pudo obtener la lista de usuarios de la sesion" + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return list;
        }

        public List<MinutasAcuerdos> GetAcuerdos(MinutasAcuerdos obj)
        {
            List<MinutasAcuerdos> list = new List<MinutasAcuerdos>();
            MinutasAcuerdos ent;
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_SESIONES_ACUERDOS_GET", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idsesion", obj.ObjMinutas.IdSesion);
                    command.Parameters.AddWithValue("@idusuariosesion", obj.ObjUserSesion.IdUserSesion);
                    command.Parameters.AddWithValue("@idacuerdo", obj.IdAcuerdo == 0 ? (object)DBNull.Value : obj.IdAcuerdo);
                    command.Parameters.AddWithValue("@idusuariomostrar", obj.ObjUserSesion.IdUserMostrar == 0 ? (object)DBNull.Value : obj.ObjUserSesion.IdUserMostrar);

                    cn.OpenConnection();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ent = new MinutasAcuerdos()
                            {
                                ObjMinutas = new Minutas() { ObjStatus = new CatStatus() }
                                ,
                                ObjUserSesion = new UsuariosDatos() { User = new Usuarios() }
                                ,
                                ObjTipoacuerdo = new CatTipoAcuerdo()
                            };
                            ent.IdAcuerdo = (int)reader["idacuerdo"];
                            ent.ObjMinutas.IdSesion = (int)reader["idsesion"];
                            ent.FechaIni = (DateTime)reader["fechaini"];
                            ent.FechaFin = (DateTime)reader["fechafin"];
                            ent.Descripcion = (string)reader["descripcion"];
                            ent.FechaRegistro = (DateTime)reader["fecharegistro"];
                            ent.FechaIniReal = reader["fechaini_real"] == DBNull.Value ? null : (DateTime?)(DateTime)reader["fechaini_real"];
                            ent.FechaFinReal = reader["fechafin_real"] == DBNull.Value ? null : (DateTime?)(DateTime)reader["fechafin_real"];
                            ent.ObjMinutas.ObjStatus.idstatus = (int)reader["idstatus"];
                            ent.ObjMinutas.ObjStatus.nomstatus = (string)reader["nomstatus"];
                            ent.IdUserMinuta = (int)reader["idusuario"];
                            ent.ObjUserSesion.User.Username = (string)reader["username"];
                            ent.ObjUserSesion.NombreCompleto = (string)reader["nombrecompleto"];
                            ent.ObjTipoacuerdo.IdTipoAcuerdo = (int)reader["idtipoacuerdo"];
                            ent.ObjTipoacuerdo.TipoAcuerdo = (string)reader["nomtipoacuerdo"];
                            ent.Diasentrega = (int)reader["diasentrega"];
                            ent.TiempoEntrega = (string)reader["tiempoentrega"];
                            ent.ObjUserSesion.IdUserSesion = (int)reader["idusuariosesion"];
                            ent.LabelDias = (string)reader["labeldias"];
                            list.Add(ent);
                        }
                    }


                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error BD No se pudo obtener la lista de acuerdos " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error code No se pudo obtener la lista de acuerdos " + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return list;
        }

        public MinutasAcuerdos GetAcuerdosByFolio(MinutasAcuerdos obj)
        {
            MinutasAcuerdos ent = new MinutasAcuerdos()
            {
                ObjMinutas = new Minutas() { ObjStatus = new CatStatus() }
                ,
                ObjUserSesion = new UsuariosDatos() { User = new Usuarios() }
                ,
                ObjTipoacuerdo = new CatTipoAcuerdo()
            };
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_SESIONES_ACUERDOS_GET", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idsesion", obj.ObjMinutas.IdSesion);
                    command.Parameters.AddWithValue("@idusuariosesion", obj.ObjUserSesion.IdUserSesion);
                    command.Parameters.AddWithValue("@idacuerdo", obj.IdAcuerdo);

                    cn.OpenConnection();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ent.IdAcuerdo = (int)reader["idacuerdo"];
                            ent.ObjMinutas.IdSesion = (int)reader["idsesion"];
                            ent.FechaIni = (DateTime)reader["fechaini"];
                            ent.FechaFin = (DateTime)reader["fechafin"];
                            ent.Descripcion = (string)reader["descripcion"];
                            ent.FechaRegistro = (DateTime)reader["fecharegistro"];
                            ent.FechaIniReal = reader["fechaini_real"] == DBNull.Value ? null : (DateTime?)(DateTime)reader["fechaini_real"];
                            ent.FechaFinReal = reader["fechafin_real"] == DBNull.Value ? null : (DateTime?)(DateTime)reader["fechafin_real"];
                            ent.ObjMinutas.ObjStatus.idstatus = (int)reader["idstatus"];
                            ent.ObjMinutas.ObjStatus.nomstatus = (string)reader["nomstatus"];
                            ent.IdUserMinuta = (int)reader["idusuario"];
                            ent.ObjUserSesion.User.Username = (string)reader["username"];
                            ent.ObjUserSesion.NombreCompleto = (string)reader["nombrecompleto"];
                            ent.ObjTipoacuerdo.IdTipoAcuerdo = (int)reader["idtipoacuerdo"];
                            ent.ObjTipoacuerdo.TipoAcuerdo = (string)reader["nomtipoacuerdo"];
                            ent.Diasentrega = (int)reader["diasentrega"];
                            ent.TiempoEntrega = (string)reader["tiempoentrega"];
                            ent.ObjUserSesion.IdUserSesion = (int)reader["idusuariosesion"];
                        }
                    }


                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error BD No se pudo obtener el acuerdo seleccionado " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error code No se pudo obtener el acuerdo seleccionado " + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return ent;
        }

        public void InsAcuerdos(MinutasAcuerdos obj)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_SESIONES_ACUERDOS_SET", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ARRAYACUERDOS", obj.ArrayAcuerdos);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error BD no se pudo agregar el acuerdo " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error BD no se pudo agregar el acuerdo " + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
        }

        public void DelAcuerdo(MinutasAcuerdos obj)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_SESIONES_ACUERDOS_DEL", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idacuerdo", obj.IdAcuerdo);
                    command.Parameters.AddWithValue("@idusuario", obj.ObjUserSesion.User.IdUser);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error BD no se pudo eliminar el ACUERDO " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error BD no se pudo eliminar el ACUERDO " + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
        }

        public void CancelarSesion(Minutas obj)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_SESIONES_STATUS_CANCELAR", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idsesion", obj.IdSesion);
                    command.Parameters.AddWithValue("@idusuario", obj.ObjUsuarios.User.IdUser);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error BD no se pudo cancelar la minuta " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error BD no se pudo cancelar la minuta " + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
        }

        public List<MinutasComentarios> GetComentariosAcuerdos(MinutasComentarios obj)
        {
            List<MinutasComentarios> list = new List<MinutasComentarios>();
            MinutasComentarios ent;
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_SESIONES_ACUERDOS_COMENTARIOS_GET", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idacuerdo", obj.ObjMinutaAcuerdo.IdAcuerdo == 0 ? (object)DBNull.Value : obj.ObjMinutaAcuerdo.IdAcuerdo);
                    command.Parameters.AddWithValue("@idusuario", obj.ObjUsercoment.IdUser == 0 ? (object)DBNull.Value : obj.ObjUsercoment.IdUser);
                    command.Parameters.AddWithValue("@idcomentario", obj.Idcomentario == 0 ? (object)DBNull.Value : obj.Idcomentario);
                    if(obj.Activo)
                    {
                        command.Parameters.AddWithValue("@activo", obj.Activo );
                    }
                    cn.OpenConnection();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ent = new MinutasComentarios()
                            {
                                ObjMinutas = new Minutas() { ObjStatus = new CatStatus() }
                                ,
                                ObjUsercoment = new Usuarios(), ObjUserDatos=new UsuariosDatos(), ObjStatuscoment=new CatStatus()
                                
                            };
                            ent.Idcomentario = (int)reader["idcomentario"];
                            ent.Comentarios = (string)reader["comentarios"];
                            ent.FechaRegistro = (DateTime)reader["fecharegistro"];
                            ent.Activo= (bool)reader["activo"];
                            ent.ObjUsercoment.IdUser = (int)reader["idusuario"];
                            ent.ObjUserDatos.NombreCompleto = (string)reader["nombrecompleto"];
                            ent.ObjUsercoment.Username = (string)reader["username"];
                            ent.ObjStatuscoment.idstatus = (int)reader["idstatus"];
                            ent.ObjStatuscoment.nomstatus = (string)reader["nomstatus"];
                            
                            list.Add(ent);
                        }
                    }


                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error BD No se pudo obtener la lista de comentarios del acuerdo " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error code No se pudo obtener la lista de comentarios del acuerdo " + ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }
            return list;
        }
    }
}
