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

    public int InsertOrderDetails (int refillOrderID, int productID, double productPrice,int quantity)//tested
    {
        Open();
        var r = new DynamicParameters();
        r.Add("@refillorder_id", refillOrderID);
        r.Add("@product_id", productID);
        r.Add("@product_price", productPrice);
        r.Add("@order_quantity", quantity);
        string sql = $@"INSERT INTO orderdetails (refillorder_id, product_id, product_price,order_quantity) VALUES (@refillorder_id,@product_id,@product_price,@order_quantity); SELECT LAST_INSERT_ID() ";
        int Id = connection.Query<int>(sql, r).First();
        return Id;
    }

    public int InsertRefillOrder(int machineID, int employeeID, DateTime date,bool status)//tested
    {
        Open();
        var r = new DynamicParameters();
        r.Add("@machine_id", machineID);
        r.Add("@employee_id", employeeID);
        r.Add("@order_date", date);
         r.Add("@order_status", status);
        string sql = $@"INSERT INTO refillorders (machine_id, employee_id, order_date,order_status) VALUES (@machine_id,@employee_id,@order_date,@order_status); SELECT LAST_INSERT_ID() ";
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

    public void UpdateOrderMachineEmployeeById(int orderId, int employeeId,  int machineId)//tested
    { 
        Open();
        var updateOrderMachineEmployee = connection.Query<RefillOrder>($@"UPDATE refillorders r
        SET r.employee_id = {employeeId},
           r.machine_id = {machineId}
            WHERE r.refillOrder_id = {orderId};");
    }

     public void UpdateOrderStatusById(int orderId, int employeeId,  bool isDone)
    { 
        Open();
        var updateOrderstatus = connection.Query<RefillOrder>($@"UPDATE refillorders r
        SET r.order_status = {isDone},
           r.checkedBy_employee = {employeeId}
            WHERE r.refillOrder_id = {orderId};");
    }

     public List<RefillOrder> SearchOrdersByOrderId(int orderId)//tested
    {
        Open();
        var orders = connection.Query<RefillOrder>($@"SELECT r.refillorder_id,o.product_id,p.product_name,r.machine_id,r.order_date,o.product_price,sum(o.order_quantity) AS order_quantity, (product_price*order_quantity)AS order_totalPay,r.employee_id,r.checkedBy_employee FROM (((products p LEFT JOIN orderdetails o ON p.product_id = o.product_id) LEFT JOIN refillorders r ON r.refillOrder_id = o.refillOrder_id) INNER JOIN employee e ON e.employee_id = r.employee_id) WHERE o.refillOrder_id = {orderId} GROUP BY o.product_id;").ToList();
        return orders;
    }



    public RefillOrder SearchOrderDetailsByOrderProductId(int orderId,int productId) //for uppdate order product//tested
    {
        Open();
        var order = connection.QuerySingle<RefillOrder>($@"SELECT r.refillorder_id,o.product_id,p.product_name,r.machine_id,r.order_date,o.product_price,o.order_quantity , (product_price*order_quantity)AS order_totalPay,r.employee_id,r.checkedBy_employee
        FROM (((products p
        LEFT JOIN orderdetails o ON p.product_id = o.product_id)
        LEFT JOIN refillorders r ON r.refillOrder_id = o.refillOrder_id)
        INNER JOIN employee e ON e.employee_id = r.employee_id)
        WHERE r.refillorder_id = {orderId} AND o.product_id ={productId};");
        return order;
    }

    public void DeleteOrderById(int number)
    {
        Open();
        var deletedorder = connection.Query<RefillOrder>(@$"DELETE FROM `products` WHERE refillorder_id = {number};");
    }

    public List<RefillOrder> RefillOrderList()//tested
    {
        Open();
        var orders = connection.Query<RefillOrder>($@"SELECT r.refillorder_id,o.product_id,p.product_name,r.machine_id,r.order_date,o.product_price,sum(o.order_quantity) AS order_quantity, (product_price*order_quantity)AS order_totalPay,r.employee_id,r.checkedBy_employee
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
        var OrderByMachineIdList = connection.Query<RefillOrder>($@"SELECT r.refillorder_id,o.product_id,p.product_name,r.machine_id,r.order_date,o.product_price,sum(o.order_quantity) AS order_quantity, (product_price*order_quantity)AS order_totalPay,r.employee_id,r.checkedBy_employee
        FROM (((products p
        LEFT JOIN orderdetails o ON p.product_id = o.product_id)
        LEFT JOIN refillorders r ON r.refillOrder_id = o.refillOrder_id)
        LEFT JOIN employee e ON e.employee_id = r.employee_id)
        WHERE r.machine_id ={number}
        GROUP BY r.refillorder_id, o.product_id;").ToList();
        return OrderByMachineIdList;
    }


}
