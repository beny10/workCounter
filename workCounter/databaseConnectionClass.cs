using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace workCounter
{
    class databaseConnectionClass
    {
        private SqlConnection _connection
        {
            get;
            set;
        }
        string databaseConnectionString()
        {
            databaseConnectionStringClass databaseConnectionStringClass = new databaseConnectionStringClass();
            return databaseConnectionStringClass.connectionString();
        }
        public databaseConnectionClass()
        {
            _connection=new SqlConnection(databaseConnectionString());
        }

        public SqlConnection openConnection()
        {
            try
            {
                _connection.Open();
                return _connection;
            }
            catch
            {
                MessageBox.Show("The connection cannot be done!");
            }
            return null;
        }
        public void closeConnection()
        {
            try
            {
                _connection.Close();
            }
            catch
            {
                //
            }
        }
    }
}
