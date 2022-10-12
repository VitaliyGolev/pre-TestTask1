namespace BlazorServerAppTest.Data
{
    public class Employee
    {
        public int employeeID { get; set; }
        public string name { get; set; } = null!;
        public byte age { get; set; }
        public string email { get; set; } = null!;
        public string? gender { get; set; } = null;
    }
}
