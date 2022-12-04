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
    

}

