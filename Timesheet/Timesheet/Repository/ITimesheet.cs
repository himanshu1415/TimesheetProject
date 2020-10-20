using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheet.Models;
namespace Timesheet.Repository
{
   public interface ITimesheet
    {
        public IEnumerable<Employee> GetAll();

        public Employee GetById(int id);

        public int AddEmployee(Employee record);

        public int UpdateEmployee(Employee record);

        public int DeleteEmployee(Employee record);
    }
}
