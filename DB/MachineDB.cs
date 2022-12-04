using Dapper;
using MySqlConnector;
using System.Data;
public class MachineDB 
{
    
    private MySqlConnection connection;


    public MachineDB()
    {
        connection = new MySqlConnection(("Server=localhost;Database=videoteket;Uid=Tina;Pwd=123456;"));

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
