using Dapper;
using MySqlConnector;
using System.Data;
public class RefillOrderDB 
{
    
    private MySqlConnection connection;


    public RefillOrderDB()
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

    public int InsertOrder(int typeID, int statusID, double price)
    {
        Open();
        var r = new DynamicParameters();
        r.Add("@roomType_id", typeID);
        r.Add("@roomStatus_id", statusID);
        r.Add("@room_price", price);
        string sql = $@"INSERT INTO rooms (roomType_id, roomStatus_id, room_price) VALUES (@roomType_id,@roomStatus_id,@room_price); SELECT LAST_INSERT_ID() ";
        int Id = connection.Query<int>(sql, r).First();
        return Id;
    }

     public void UpdateProduct(int roomToUpdate, int newRoomStatus)
    {
        Open();
        var updateRefillOrder = connection.Query<RefillOrder>($"UPDATE rooms SET roomStatus_id={newRoomStatus} WHERE room_id = {roomToUpdate};");
    }

     public void DeleteProductById(int number)
    {
        Open();
        var deleteOrderDB = connection.Query<RefillOrder>($@"DELETE FROM rooms WHERE room_id = {number};");
    }

    public List<RefillOrder> GetProductList()
    {
        Open();
        var rooms = connection.Query<RefillOrder>("SELECT room_id,roomType_name,roomStatus_name,room_price FROM ((rooms INNER JOIN roomtype ON rooms.roomType_id=roomtype.roomType_id) INNER JOIN roomstatus ON rooms.roomStatus_id=roomstatus.roomStatus_id) ;").ToList();
        return rooms;
    }
    

}
