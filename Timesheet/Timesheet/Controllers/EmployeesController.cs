using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Timesheet.Models;
using Timesheet.Repository;

namespace Timesheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(EmployeesController));
        public ITimesheet repo;
        
        public EmployeesController(ITimesheet repo)
        {
            this.repo = repo;
        }

        // GET: api/Employees
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            _log4net.Info("Get Api Initiated");
            var attendees = repo.GetAll();
            if (attendees == null)
            {
                return BadRequest();
            }
            return Ok(attendees);

        }
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            var record = repo.GetById(id);
            if (record == null)
            {
                return BadRequest();
            }
            return Ok(record);
        }

        [HttpPost]
        [Route("PostNewEmployee")]

        public IActionResult PostNewEmployee(Employee record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            var response = repo.AddEmployee(record);
            return Ok(response);
        }

            [HttpPut]
            [Route("UpdateEmployee")]

            public IActionResult UpdateAttendeeRecord(Employee record)
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest("Cannot save the changes!");
                }
                var response = repo.UpdateEmployee(record);
                return Ok(response);

            }

            [HttpDelete]
            [Route("DeleteEmployee")]
            public IActionResult DeleteEmployee(int id)
            {
                var record = repo.GetById(id);
                if (record == null)
                {
                    return BadRequest("Record Not Found!");
                }
                var response = repo.DeleteEmployee(record);
                return Ok(response);
            }

    }
}
