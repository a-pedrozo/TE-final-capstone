using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public class InspectionSqlDAO
    {
        private string connectionString;

        public InspectionSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

    }
}
