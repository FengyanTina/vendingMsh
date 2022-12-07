public class DataManager
{
    EmployeeDB employeeDB = new ();
    MachineDB machineDB = new ();
    RefillOrderDB orderDB = new ();
    ProductDB productDB = new ();
    SaleDB saleDB = new ();

    public List<RefillOrder> GetRefillOrders()
    {
       return orderDB.RefillOrderList();
    }

    public List<RefillOrder> GetRefillOrdersByMachineId(int id)
    {
       return orderDB.SearchOrderByMachineId(id);
    }

    public void UpdateOrderProductById(int orderId, int productId, int productQuantity, int newProductId)
    {
       orderDB.UpdateOrderProductById(orderId,productId,productQuantity,newProductId);
    }

    public void UpdateOrderMachineEmployeeById(int orderId, int employeeId,  int machineId)
    {
       orderDB.UpdateOrderMachineEmployeeById(orderId,employeeId,machineId);
    }

    public RefillOrder GetOrderDetailsByOrderProductId(int orderId,int productId)
    {
       return orderDB.SearchOrderDetailsByOrderProductId(orderId,productId);
    }

     public RefillOrder GetOrderByOrdeId(int orderId)
    {
       return orderDB.SearchOrderByOrderId(orderId);
    }

     public List<Product> GetProductList()
    {
       return productDB.GetProducts();
    }
}