using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheet.Models;

namespace Timesheet.Repository
{
    public class TimesheetRepository : ITimesheet
    {
        private TimesheetDBContext context;
        public TimesheetRepository(TimesheetDBContext context)
        {
            this.context = context;

        }
        public int AddEmployee(Employee record)
        {
            context.Employee.Add(record);
            int response = context.SaveChanges();
            return response;
        }

        public int DeleteEmployee(Employee record)
        {
            context.Employee.Remove(record);
            var response = context.SaveChanges();
            return response;
        }

        public IEnumerable<Employee> GetAll()
        {
            var list = context.Employee.ToList();
            return list;
        }

        public Employee GetById(int id)
        {
            Employee record = context.Employee.Find(id);
            return record;
        }

        public int UpdateEmployee(Employee record)
        {
            context.Entry(record).State = EntityState.Modified;
            int response = context.SaveChanges();
            return response;
        }
    }
}
