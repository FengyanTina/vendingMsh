using Dapper;
using MySqlConnector;
using System.Data;
public class MachineDB 
{
    
    private MySqlConnection connection;


    public MachineDB()
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

    public List<Machine> GetMachines() //tested
    {
        Open();
        var machines = connection.Query<Machine>("SELECT machine_id, machine_location, machine_model FROM machines;").ToList();
        return machines;
    }

    public Machine SearchMachineById(int id)//tested
    {
        Open();
        var machine = connection.QuerySingle<Machine>(@$"SELECT * FROM `machines` WHERE machine_id = {id};");
        return machine;
    }

    public int InsertMachine(string location, string model) //tested
    {
         Open();
        string sql = @$"INSERT INTO machines (machine_location,machine_model) VALUES ('{location}','{model}');SELECT LAST_INSERT_ID();";
        int id = connection.QuerySingle<int>(sql);
        return id;
    }

    public void DeleteMachineById(int id) //tested
    {
         Open();
        var deletedmachine = connection.Query<Product>(@$"DELETE FROM `machines` WHERE machine_id = {id};");
    }

    public void UpdateProductById(int id,string newname) 
    {
         Open();
        var updateproduct = connection.Query<Product>(@$"UPDATE `products` SET product_name = '{newname}'WHERE product_id = {id};");
    }
    

}
