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
    public class UsuariosDAL
    {
        Conexion.Conexion cn;
        public UsuariosDAL()
        {
            cn = new Conexion.Conexion();
        }

        public Usuarios Sigin(string user, string password)
        {
            Usuarios usuario = new Usuarios() { Perfil=new Perfiles()};
            try
            {
                using (SqlCommand command = new SqlCommand("SPD_USUARIO_SIGIN", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@usuario", user);
                    command.Parameters.AddWithValue("@pass", password);

                    cn.OpenConnection();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario.IdUser=(int)reader["idusuario"];
                            usuario.Username=(string)reader["username"];
                            usuario.Perfil.IdPerfil=(int)reader["idperfil"];
                            usuario.Perfil.NomPerfil=(string)reader["nomperfil"];
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error BD al Autenticar Usuario. " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Code al Autenticar Usuario. "+ex.Message);
            }
            finally
            {
                cn.CloseConnection();
            }

            return usuario;
        }

        public void insertarUsuarios(UsuariosDatos _catusuariosdatos)
        {
           // int id = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("spd_usuarios_ins", cn.Connection))
                {
                    
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@username", _catusuariosdatos.User.Username);
                    command.Parameters.AddWithValue("@password", _catusuariosdatos.User.Password);
                    command.Parameters.AddWithValue("@usergestiono", _catusuariosdatos.User.IdUser);
                    command.Parameters.AddWithValue("@idperfil", _catusuariosdatos.User.Perfil.IdPerfil);
                    command.Parameters.AddWithValue("@nombre", _catusuariosdatos.NombreUser);
                    command.Parameters.AddWithValue("@appat", _catusuariosdatos.ApellidoPat);
                    command.Parameters.AddWithValue("@apmat", _catusuariosdatos.ApellidoMat);
                    command.Parameters.AddWithValue("@iddepartamento", _catusuariosdatos.ObjDepto.iddepto);
                    command.Parameters.AddWithValue("@idpuesto", _catusuariosdatos.ObjPuestos.idpuesto);
                    command.Parameters.AddWithValue("@idsede", _catusuariosdatos.ObjSedes.idsede);
                    cn.OpenConnection();
                    command.ExecuteNonQuery();
                   // id = (int)command.ExecuteScalar();
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

            //return id;

        }

        public void modificarUsuarios(UsuariosDatos _catusuariosdatos)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("spd_usuarios_upd", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@username", _catusuariosdatos.User.Username);
                    command.Parameters.AddWithValue("@idperfil", _catusuariosdatos.User.Perfil);
                    command.Parameters.AddWithValue("@nombre", _catusuariosdatos.NombreUser);
                    command.Parameters.AddWithValue("@appat", _catusuariosdatos.ApellidoPat);
                    command.Parameters.AddWithValue("@apmat", _catusuariosdatos.ApellidoMat);
                    command.Parameters.AddWithValue("@iddepartamento", _catusuariosdatos.ObjDepto.iddepto);
                    command.Parameters.AddWithValue("@idpuesto", _catusuariosdatos.ObjPuestos.idpuesto);
                    command.Parameters.AddWithValue("@idsede", _catusuariosdatos.ObjSedes.idsede);
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

        public void eliminarUsuario(UsuariosDatos _catusuariosdatos)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("spd_usuarios_del", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idusuario", _catusuariosdatos.User.IdUser);
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

        public void cambiarPassword(UsuariosDatos _catusuariosdatos)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("spd_usuarios_pass", cn.Connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idusuario", _catusuariosdatos.User.IdUser);
                    command.Parameters.AddWithValue("@password", _catusuariosdatos.User.Password);
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


        public List<UsuariosDatos> obtenerUsuarios(int idsede=0, int iddepto=0, int idpuesto=0, int id=0,string filtro = null)
        {
            List<UsuariosDatos> list = new List<UsuariosDatos>();
            UsuariosDatos _catusuariosdatos;
            try
            {
                using (SqlCommand command = new SqlCommand("spd_usuarios_get", cn.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id == 0 ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@filtro", string.IsNullOrEmpty(filtro) ? (object)DBNull.Value : filtro);
                    command.Parameters.AddWithValue("@idsede", id == 0 ? (object)DBNull.Value : idsede);
                    command.Parameters.AddWithValue("@idepto", id == 0 ? (object)DBNull.Value : iddepto);
                    command.Parameters.AddWithValue("@idpuesto", id == 0 ? (object)DBNull.Value : idpuesto);
                    cn.OpenConnection();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        _catusuariosdatos = new UsuariosDatos();
                        _catusuariosdatos.User.IdUser = (int)reader["idusuario"];
                        _catusuariosdatos.User.Username = (string)reader["username"];
                        _catusuariosdatos.User.Perfil.IdPerfil = (int)reader["ideperfil"];
                        _catusuariosdatos.User.Perfil.NomPerfil = (String)reader["nomperfil"];
                        _catusuariosdatos.NombreUser = (string)reader["nombre"];
                        _catusuariosdatos.ApellidoPat = (string)reader["appat"];
                        _catusuariosdatos.ApellidoMat = (string)reader["apmat"];
                        _catusuariosdatos.NombreCompleto = (string)reader["nombrecompleto"];
                        _catusuariosdatos.ObjSedes.idsede = (int)reader["idsede"];
                        _catusuariosdatos.ObjSedes.descripcion = (string)reader["nomsede"];
                        _catusuariosdatos.ObjDepto.iddepto = (int)reader["iddepto"];
                        _catusuariosdatos.ObjDepto.descripcion = (string)reader["nomdepto"];
                        _catusuariosdatos.ObjPuestos.idpuesto = (int)reader["idpuesto"];
                        _catusuariosdatos.ObjPuestos.descripcion = (string)reader["nompuesto"];
                        _catusuariosdatos.User.FechaRegistro = (DateTime)reader["fecharegistro"];
                        list.Add(_catusuariosdatos);
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
