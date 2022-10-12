using BlazorServerAppTest.Data;
using BlazorServerAppTest.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerAppTest.Services
{
    public class EmployeeManager : IEmployee
    {
        readonly EmployeeDBContext _dbContext = new();
        public EmployeeManager(EmployeeDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        //To Get all employee details
        public List<Employee> GetEmployee()
        {
            try
            {
                return _dbContext.Employees.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new employee record
        public void AddEmployee(Employee employee)
        {
            try
            {
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        
        //To Update the records of a particluar employee
        public void UpdateEmployee(Employee employee)
        {
            try
            {
                _dbContext.Entry(employee).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        
        //Get the details of a particular user
        public Employee GetEmployeeData(int id)
        {
            try
            {
                Employee? employee = _dbContext.Employees.Find(id);
                if (employee != null)
                {
                    return employee;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
        //To Delete the record of a particular user
        public void DeleteEmployee(int id)
        {
            try
            {
                Employee? employee = _dbContext.Employees.Find(id);
                if (employee != null)
                {
                    _dbContext.Employees.Remove(employee);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
