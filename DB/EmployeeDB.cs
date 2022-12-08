using Dapper;
using MySqlConnector;
using System.Data;
public class EmployeeDB 
{
    
    private MySqlConnection connection;


    public EmployeeDB()
    {
        connection = new MySqlConnection(("Server=localhost;Database=vendingmachine;Uid=Tina;Pwd=123456;"));

    }
      public void Open()
    {
        try
        {
           if(connection.State != ConnectionState.Open)
            connection.Open(); 
        }
        catch (Exception e)
        {
            
            throw new FieldAccessException("DB is not accessable",e);
        }
    }

     public List<Employee> GetEmployees() //tested
    {
        Open();
        var employees = connection.Query<Employee>("SELECT employee_id, employee_location, employee_model FROM employees;").ToList();
        return employees;
    }

    public Employee SearchMachineById(int id)//tested
    {
        Open();
        var employee = connection.QuerySingle<Employee>(@$"SELECT * FROM `employees` WHERE employee_id = {id};");
        return employee;
    }

    public int InsertEmployee(string location, string model) //tested
    {
         Open();
        string sql = @$"INSERT INTO employees (employee_location,employee_model) VALUES ('{location}','{model}');SELECT LAST_INSERT_ID();";
        int id = connection.QuerySingle<int>(sql);
        return id;
    }

    public void DeleteEmployeeById(int id) //tested
    {
         Open();
        var deletedEmployee = connection.Query<Product>(@$"DELETE FROM `employees` WHERE employee_id = {id};");
    }

    public void UpdateEmployeeById(int id,string newLocation, string newModel) 
    {
         Open();
        var updatedEmployee = connection.Query<Employee>(@$"UPDATE `employees` SET employee_location = '{newLocation}',employee_model = '{newModel}' WHERE employee_id = {id};");
    }
    

}

