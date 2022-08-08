using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IPotholeDAO
    {
        List<Pothole> GetAllPotholes();

        Pothole AddPothole(Pothole newPothole);
        
    }
}
