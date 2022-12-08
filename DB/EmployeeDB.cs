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
        var employees = connection.Query<Employee>("SELECT * FROM employee;").ToList();
        return employees;
    }

    public Employee SearchEmployeeById(int id)//tested
    {
        Open();
        var employee = connection.QuerySingle<Employee>(@$"SELECT * FROM `employee` WHERE employee_id = {id};");
        return employee;
    }

    public int InsertEmployee(string name, string email,string phoneNr) //tested
    {
         Open();
        string sql = @$"INSERT INTO employee (employee_name,employee_email,employee_phone) VALUES ('{name}','{email}','{phoneNr}');SELECT LAST_INSERT_ID();";
        int id = connection.QuerySingle<int>(sql);
        return id;
    }

    public void DeleteEmployeeById(int id)  //tested
    {
         Open();
        var deletedEmployee = connection.Query<Product>(@$"DELETE FROM `employee` WHERE employee_id = {id};");
    }

    public void UpdateEmployeeById(int id,string name, string email,string phone) //trsted
    {
         Open();
        var updatedEmployee = connection.Query<Employee>(@$"UPDATE `employee` SET employee_name = '{name}',employee_email = '{email}',employee_phone = '{phone}' WHERE employee_id = {id};");
    }
    

}

