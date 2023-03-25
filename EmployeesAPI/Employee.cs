namespace EmployeesAPI
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }

    }
    public class EmployeeInsert
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }

    }
}
