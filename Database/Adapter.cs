using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Database
{
    public class Adapter
    {
        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");
        private SqlConnection _sqlConn;
        public SqlConnection sqlConn
        {
            get { return _sqlConn; }
            set { _sqlConn = value; }
        }
        protected void OpenConnection()
        {
            //string cs = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            string connectionString = "Server=localhost;Database=valkimia; Integrated Security=True;";
            this.sqlConn = new SqlConnection(connectionString);
            try
            {
                this.sqlConn.Open();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        protected void CloseConnection()
        {
            this.sqlConn.Close();
            this.sqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
