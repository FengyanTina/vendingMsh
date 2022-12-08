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

    public RefillOrder ShowUppdateOrderDetailsByOrderProductId(int orderId, int productId)
    {
       return orderDB.SearchOrderDetailsByOrderProductId(orderId, productId);
    }

     public RefillOrder GetOrderByOrdeId(int orderId)
    {
       return orderDB.SearchOrderByOrderId(orderId);
    }

     public List<Product> GetProductList()
    {
       return productDB.GetProducts();
    }

    public Product GetProductByName(string name)
    {
        return productDB.SearchProductByName(name);
    }

    public int AddProduct(string name)
    {
        return productDB.InsertProduct(name);
    }

    public void RemoveProductById(int id)
    {
        productDB.DeleteProductById(id);
    }

    public void UpdateProductById(int id, string name)
    {
        productDB.UpdateProductById(id,name);
    }

    public List<Machine> GetMachineList()
    {
        return machineDB.GetMachines();
    }

    public Machine SearchMachineById(int id)
    {
        return machineDB.SearchMachineById(id);
    }

     public int AddMachine(string location, string model)
    {
        return machineDB.InsertMachine(location,model);
    }

    public void RemoveMachineById(int id)
    {
        machineDB.DeleteMachineById(id);
    }

     public void UpdateMachineById(int id, string location, string model)
    {
        machineDB.UpdateMachineById(id,location,model);
    }

    public List<Employee> GetEmployees()
    {
        return employeeDB.GetEmployees();
    }

    public Employee SearchEmployeeById(int id)
    {
        return employeeDB.SearchEmployeeById(id);
    }

    public int AddEmployee(string name,string email,string phone)
    {
        return employeeDB.InsertEmployee(name,email,phone);
    }

    public void UpdateEmployeeById(int id,string name,string email,string phone)
    {
        employeeDB.UpdateEmployeeById(id,name,email,phone);
    }

    public void RemoveEmployeeById(int id)
    {
        employeeDB.DeleteEmployeeById(id);
    }

}