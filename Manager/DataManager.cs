public class DataManager
{
    EmployeeDB employeeDB = new EmployeeDB();
    MachineDB machineDB = new MachineDB();
    OrderDB orderDB = new OrderDB();
    ProductDB productDB = new ProductDB();
    SaleDB saleDB = new SaleDB();

    public int AddOrder()
    {
       return int id = orderDB.InsertOrder();
    }
}