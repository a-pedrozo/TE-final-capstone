using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public class RepairSqlDAO
    {
        private string connectionString;

        public RepairSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
    }
}
