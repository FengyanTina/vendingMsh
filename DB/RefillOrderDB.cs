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
            if (connection.State != ConnectionState.Open)
                connection.Open();
        }
        catch (Exception e)
        {

            throw new FieldAccessException("DB is not accessable", e);
        }
    }

    public int InsertRefillOrder(int typeID, int statusID, double price)
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

    public void UpdateOrderProductById(int orderId, int productId, int productQuantity, int newProductId)
    {
        Open();
        var updateOrderProduct = connection.Query<RefillOrder>($@"UPDATE orderdetails o
        SET o.product_id={newProductId},o.order_quantity ={productQuantity}
        WHERE o.refillOrder_id = {orderId} AND o.product_id ={productId};");
    }

    public void UpdateOrderMachineEmployeeById(int orderId, int employeeId,  int machineId)
    { 
        Open();
        var updateOrderMachineEmployee = connection.Query<RefillOrder>($@"UPDATE refillorders r
        SET r.employee_id = {employeeId},
           r.machine_id = {machineId}
            WHERE r.refillOrder_id = {orderId};");
    }

     public RefillOrder SearchOrderByOrderId(int orderId)//tested
    {
        Open();
        var order = connection.QuerySingle<RefillOrder>($@"SELECT r.refillorder_id,o.product_id,p.product_name,r.machine_id,r.order_date,o.product_price,sum(o.order_quantity) AS order_quantity, (product_price*order_quantity)AS order_totalPay,r.employee_id FROM (((products p LEFT JOIN orderdetails o ON p.product_id = o.product_id) LEFT JOIN refillorders r ON r.refillOrder_id = o.refillOrder_id) INNER JOIN employee e ON e.employee_id = r.employee_id) WHERE o.refillOrder_id = = {orderId};");
        return order;
    }



    public RefillOrder SearchOrderDetailsByOrderProductId(int orderId,int productId) //for uppdate order product
    {
        Open();
        var order = connection.QuerySingle<RefillOrder>($@"SELECT r.refillorder_id,o.product_id,p.product_name,r.machine_id,r.order_date,o.product_price,sum(o.order_quantity) AS order_quantity, (product_price*order_quantity)AS order_totalPay,r.employee_id
        FROM (((products p
        LEFT JOIN orderdetails o ON p.product_id = o.product_id)
        LEFT JOIN refillorders r ON r.refillOrder_id = o.refillOrder_id)
        INNER JOIN employee e ON e.employee_id = r.employee_id)
        WHERE r.refillorder_id = {orderId} o.product_id = {productId}
        GROUP BY r.refillOrder_id;");
        return order;
    }

    public void DeleteOrderById(int number)
    {
        Open();
        
    }

    public List<RefillOrder> RefillOrderList()//tested
    {
        Open();
        var orders = connection.Query<RefillOrder>($@"SELECT r.refillorder_id,o.product_id,p.product_name,r.machine_id,r.order_date,o.product_price,sum(o.order_quantity) AS order_quantity, (product_price*order_quantity)AS order_totalPay,r.employee_id
        FROM (((products p 
        LEFT JOIN orderdetails o ON p.product_id = o.product_id)
        LEFT JOIN refillorders r ON r.refillOrder_id = o.refillOrder_id)
        INNER JOIN employee e ON e.employee_id = r.employee_id)
        GROUP BY p.product_id,r.machine_id;").ToList();
        return orders;
    }

    public List<RefillOrder> SearchOrderByMachineId(int number)//tested
    {
        Open();
        var OrderByMachineIdList = connection.Query<RefillOrder>($@"SELECT r.refillorder_id,o.product_id,p.product_name,r.machine_id,r.order_date,o.product_price,sum(o.order_quantity) AS order_quantity, (product_price*order_quantity)AS order_totalPay,r.employee_id
        FROM (((products p
        LEFT JOIN orderdetails o ON p.product_id = o.product_id)
        LEFT JOIN refillorders r ON r.refillOrder_id = o.refillOrder_id)
        LEFT JOIN employee e ON e.employee_id = r.employee_id)
        WHERE r.machine_id ={number}
        GROUP BY p.product_id;").ToList();
        return OrderByMachineIdList;
    }


}
