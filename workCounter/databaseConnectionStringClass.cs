using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workCounter
{
    class databaseConnectionStringClass
    {
        private string _database="WIN-0N34G2S9FU8";
        private string _table = "workCounter";
        public databaseConnectionStringClass()
        {
            //
        }
        public string connectionString()
        {
            return String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", _database,_table);
        }
    }
}
