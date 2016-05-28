using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Conexion
{
    public class Conexion
    {
        public SqlConnection _connection;

        public SqlConnection Connection
        {
            get
            {
                //if(_connection == null)
                //{
                _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
                //}
                return _connection;
            }
        }

        public SqlConnection AllConnection(string conn)
        {

            //if (_connection == null)
            //{
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings[conn].ConnectionString);
            //}
            return _connection;

        }
        public void OpenConnection()
        {
            if (_connection.State == ConnectionState.Closed || _connection.State == ConnectionState.Broken)
            {
                _connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
        public void Dispose()
        {
            // Close connection
        }
    }
}
