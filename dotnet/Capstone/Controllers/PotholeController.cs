using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;

namespace Capstone.Controllers
{
    [Route("pothole/")]
    [ApiController]
    public class PotholeController : ControllerBase
    {
        private readonly IPotholeDAO potholeDAO;

        public PotholeController(IPotholeDAO potholeDAO)
        {
            this.potholeDAO = potholeDAO;
        }

        [HttpGet]

        public ActionResult GetAllPotholes()
        {
            List<Pothole> potholes = potholeDAO.GetAllPotholes();
            if (potholes == null)
            {
                return NotFound("Your list is empty or not found");
            }
            return Ok(potholes);
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddPothole(Pothole newPothole)
        {
            //newPothole.DateReported = DateTime.Today; date reported moved to report table
            newPothole = potholeDAO.AddPothole(newPothole);

            if (newPothole == null)
            {
                return NotFound("This did not work");
            }

            return Ok(newPothole);
        }

        [HttpGet("{potholeId}")]
        public ActionResult GetPothole(int potholeId)
        {
            Pothole pothole = potholeDAO.GetPothole(potholeId);

            if (pothole == null)
            {
                return NotFound("Your pothole is empty or not found");
            }
            return Ok(pothole);
        }


        [HttpDelete("{potholeId}")]
        [Authorize(Roles = "admin")]
        public ActionResult DeletePothole(int potholeId)
        {

            bool deleted = potholeDAO.DeletePothole(potholeId);

            if(deleted == false)
            {
                return BadRequest("Unable to delete pothole--please check pothole ID and try again");
            }

            return Ok();
        }

    
    }
}
