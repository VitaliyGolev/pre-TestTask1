using BlazorServerAppTest.Data;

namespace BlazorServerAppTest.Interfaces
{
    public interface IEmployee
    {
        public List<Employee> GetEmployee();
        public void AddEmployee(Employee employee);
        public void UpdateEmployee(Employee employee);
        public Employee GetEmployeeData(int id);
        public void DeleteEmployee(int id);
    }
}
