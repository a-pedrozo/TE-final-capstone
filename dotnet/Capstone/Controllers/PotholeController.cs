using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;

namespace Capstone.Controllers
{
    [Route("pothole")]
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

    }
}
