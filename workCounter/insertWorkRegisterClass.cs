using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace workCounter
{
    class insertWorkRegisterClass
    {
        private databaseConnectionClass _databaseConnectionClass = new databaseConnectionClass();
        private DateTime _startTime;
        private DateTime _endTime;
        private string _message;
        public insertWorkRegisterClass(DateTime startTime,DateTime endTime,string message)
        {
            _startTime = startTime;
            _endTime = endTime;
            _message = message;
            _message = _message.Replace('\'', ' ');
        }
        string databaseCommandString()
        {
            return String.Format("insert into workRegister(startDate,endDate,message) values('{0}','{1}','{2}')", _startTime.ToString(), _endTime.ToString(),_message);
        }
        public void insert()
        {
            try
            {
                SqlCommand command = new SqlCommand(databaseCommandString(), _databaseConnectionClass.openConnection());
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("The inserting cannot be done!");
            }

        }
    }
}
