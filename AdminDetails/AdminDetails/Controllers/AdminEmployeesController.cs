using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminDetails.Models;
using Microsoft.AspNetCore.Authorization;

namespace AdminDetails.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class AdminEmployeesController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AdminEmployeesController));
        private readonly TimesheetDBContext _context;

        public AdminEmployeesController(TimesheetDBContext context)
        {
            _context = context;
        }

        // GET: api/AdminEmployees
        [HttpGet]
        public async Task<List<AdminEmployee>> Get()
        {
            return await _context.AdminEmployee.ToListAsync();
           
        }

        // GET: api/AdminEmployees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminEmployee>> GetAdminEmployee(string id)
        {
            var adminEmployee = await _context.AdminEmployee.FindAsync(id);

            if (adminEmployee == null)
            {
                return NotFound();
            }

            return adminEmployee;
        }

        // PUT: api/AdminEmployees/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminEmployee(string id, AdminEmployee adminEmployee)
        {
            if (id != adminEmployee.AdminID)
            {
                return BadRequest();
            }

            _context.Entry(adminEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminEmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AdminEmployees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AdminEmployee>> PostAdminEmployee(AdminEmployee adminEmployee)
        {
            _context.AdminEmployee.Add(adminEmployee);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AdminEmployeeExists(adminEmployee.AdminID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAdminEmployee", new { id = adminEmployee.AdminID }, adminEmployee);
        }

        // DELETE: api/AdminEmployees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AdminEmployee>> DeleteAdminEmployee(string id)
        {
            var adminEmployee = await _context.AdminEmployee.FindAsync(id);
            if (adminEmployee == null)
            {
                return NotFound();
            }

            _context.AdminEmployee.Remove(adminEmployee);
            await _context.SaveChangesAsync();

            return adminEmployee;
        }

        private bool AdminEmployeeExists(string id)
        {
            return _context.AdminEmployee.Any(e => e.AdminID == id);
        }
    }
}
