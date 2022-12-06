public class DataManager
{
    EmployeeDB employeeDB = new EmployeeDB();
    MachineDB machineDB = new MachineDB();
    RefillOrderDB orderDB = new RefillOrderDB();
    ProductDB productDB = new ProductDB();
    SaleDB saleDB = new SaleDB();

    public List<RefillOrder> GetRefillOrders()
    {
       return orderDB.RefillOrderList();
    }
}