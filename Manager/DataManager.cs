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
}