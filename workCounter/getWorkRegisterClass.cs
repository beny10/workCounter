using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace workCounter
{
    class getWorkRegisterClass
    {
        public getWorkRegisterClass()
        {
            //
        }
        private databaseConnectionClass _databaseConnectionClass=new databaseConnectionClass();
        string databaseCommandString()
        {
            return "select startDate,endDate,message from workRegister";
        }
        string timeInterval(DateTime b,DateTime a)
        {
            timeIntervalClass timeIntervalClass = new timeIntervalClass(b, a);
            return timeIntervalClass.intervalAsString();
        }
        public List<List<string>> get()
        {
            List<List<string>> registers = new List<List<string>>();
            try
            {
                SqlCommand command=new SqlCommand(databaseCommandString(),_databaseConnectionClass.openConnection());
                SqlDataReader reader=command.ExecuteReader();
                while(reader.Read())
                {
                    List<string> aux = new List<string>();
                    DateTime startTime=(DateTime)reader[0];
                    DateTime endTime=(DateTime)reader[1];
                    if (startTime.Day == endTime.Day)
                        aux.Add(startTime.ToString("d"));
                    else
                        aux.Add(String.Format("{0}-{1}", startTime.ToString("d"), endTime.ToString("d")));
                    aux.Add(startTime.ToString("t"));
                    aux.Add(endTime.ToString("t"));
                    aux.Add(timeInterval(startTime, endTime));
                    aux.Add(reader[2].ToString());
                    registers.Add(aux);
                }
                _databaseConnectionClass.closeConnection();
            }
            catch
            {
                MessageBox.Show("The readind cannot be done!");
            }
            return registers;
        }
    }
}
