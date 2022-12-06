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

     public RefillOrder SearchOrderByOrderId(int orderId)
    {
        Open();
        var order = connection.QuerySingle<RefillOrder>($@"SELECT refillorders.refillorder_id,orderdetails.product_id,products.product_name,refillorders.machine_id,refillorders.order_date,orderdetails.product_price,sum(orderdetails.order_quantity) AS order_quantity, (product_price*order_quantity)AS order_totalPay,refillorders.employee_id
        FROM (((products 
        LEFT JOIN orderdetails ON products.product_id = orderdetails.product_id)
        LEFT JOIN refillorders ON refillorders.refillOrder_id = orderdetails.refillOrder_id)
        INNER JOIN employee ON employee.employee_id = refillorders.employee_id)
        WHERE orderdetails.refillOrder_id = {orderId};");
        return order;
    }



    public RefillOrder SearchOrderDetailsByOrderProductId(int orderId,int productId)
    {
        Open();
        var order = connection.QuerySingle<RefillOrder>($@"SELECT refillorders.refillorder_id,orderdetails.product_id,products.product_name,refillorders.machine_id,refillorders.order_date,orderdetails.product_price,sum(orderdetails.order_quantity) AS order_quantity, (product_price*order_quantity)AS order_totalPay,refillorders.employee_id
        FROM (((products 
        LEFT JOIN orderdetails ON products.product_id = orderdetails.product_id)
        LEFT JOIN refillorders ON refillorders.refillOrder_id = orderdetails.refillOrder_id)
        INNER JOIN employee ON employee.employee_id = refillorders.employee_id)
        WHERE orderdetails.refillOrder_id = {orderId} AND orderdetails.product_id = {productId};");
        return order;
    }

    public void DeleteOrderById(int number)
    {
        Open();
        
    }

    public List<RefillOrder> RefillOrderList()
    {
        Open();
        var orders = connection.Query<RefillOrder>($@"SELECT refillorders.refillorder_id,orderdetails.product_id,products.product_name,refillorders.machine_id,refillorders.order_date,orderdetails.product_price,sum(orderdetails.order_quantity) AS order_quantity, (product_price*order_quantity)AS order_totalPay,refillorders.employee_id
        FROM (((products 
        LEFT JOIN orderdetails ON products.product_id = orderdetails.product_id)
        LEFT JOIN refillorders ON refillorders.refillOrder_id = orderdetails.refillOrder_id)
        INNER JOIN employee ON employee.employee_id = refillorders.employee_id)
        GROUP BY products.product_id,refillorders.machine_id;").ToList();
        return orders;
    }

    public List<RefillOrder> SearchOrderByMachineId(int number)
    {
        Open();
        var OrderByMachineIdList = connection.Query<RefillOrder>($@"SELECT refillorders.refillorder_id,orderdetails.product_id,products.product_name,refillorders.machine_id,refillorders.order_date,orderdetails.product_price,sum(orderdetails.order_quantity) AS order_quantity, (product_price*order_quantity)AS order_totalPay,refillorders.employee_id
        FROM (((products 
        LEFT JOIN orderdetails ON products.product_id = orderdetails.product_id)
        LEFT JOIN refillorders ON refillorders.refillOrder_id = orderdetails.refillOrder_id)
        LEFT JOIN employee ON employee.employee_id = refillorders.employee_id)
        WHERE refillorders.machine_id ={number}
        GROUP BY products.product_id;").ToList();
        return OrderByMachineIdList;
    }


}
