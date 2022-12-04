using Dapper;
using MySqlConnector;
using System.Data;

public class DBConnection
{
  private MySqlConnection connection;

   public DBConnection() 
    {
        Connect();
    //    connection = new MySqlConnection("Server=localhost;Database=vendingmachine;Uid=Tina;Pwd=123456;");
        Open();
    }

    public MySqlConnection Connect() 
    {
        // Eventuellt vill man inte skriva in serveradress/databas/uid/pwd här, utan skicka
        // in som parameter i konstruktorn eller nåt annat fiffigt.
        return connection = new MySqlConnection("Server=localhost;Database=videoteket;Uid=Tina;Pwd=123456;");
        
    }


    // public DBConnection()
    // {
    //     connection = new MySqlConnection(("Server=localhost;Database=videoteket;Uid=Tina;Pwd=123456;"));

    // }
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