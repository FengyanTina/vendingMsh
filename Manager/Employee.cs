public class Employee
{
    public int employee_id { get; set; }
    public string? employee_name { get; set; }
    public string? employee_phone { get; set; }
    public string? employee_email { get; set; }
    
    public override string ToString()
    {
        return employee_id + "\t\t\t" + employee_name  + "\t\t" + employee_phone  + "\t\t" + employee_email;
    }
}