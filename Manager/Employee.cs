public class Employee
{
    public int employee_id { get; set; }
    public string? employee_name { get; set; }
    public string? employee_phone { get; set; }
    public string? employee_email { get; set; }
    
    public override string ToString()
    {
        return $"Employee ID: "  + " " + "Employee Name"  + " " + "Employee Phone"  + " " + "Employee Email" + "\n" + employee_id + " " + employee_name  + " " + employee_phone  + " " + employee_email;
    }
}