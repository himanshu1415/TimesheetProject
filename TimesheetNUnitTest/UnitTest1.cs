using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;


namespace TimesheetNUnitTest
{
    public class Tests
    { List<Employee> emp = new List<Employee>();
        IQueryable<Employee> empdata;
        Mock<DbSet<Employee>> mockSet;
        Mock<TimesheetDBContext> empcontextmock;
        [SetUp]
        public void Setup()
        {
            emp = new List<Employee>()
            { 
              new Employee{EmployeeId = "FT111", EmployeeName="Himanshu", EmployeeEmail="1415himanshu1415@gmail.com",Gender="M"},
              new Employee{EmployeeId = "CS101", EmployeeName="Shivam", EmployeeEmail="shivam@gmail.com",Gender="M"}
            };
            empdata = emp.AsQueryable();
            mockSet = new Mock<DbSet<Employee>>();
            mockSet.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(empdata.Provider);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(empdata.Expression);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(empdata.ElementType);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(empdata.GetEnumerator());
            var p = new DbContextOptions<TimesheetDBContext>();
            empcontextmock = new Mock<TimesheetDBContext>(p);
            empcontextmock.Setup(x => x.Employee).Returns(mockSet.Object);
        }

        [Test]
         public void GetAllTest()
            {
                var emprepo = new TimesheetRepository(empcontextmock.Object);
                var emplist = emprepo.GetAll();
                Assert.AreEqual(2, emplist.Count());
            }
       
    }
}
