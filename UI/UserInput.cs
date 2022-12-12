public class UserInput
{
    DataManager dbManager = new();

    public void PrintStockByMachine()
    {
        Console.WriteLine("\n------------------------------------------- Stock List ---------------------------------------\n");
        int mId = TryGetInt("Enter machine Id");
        try
        {
            if (dbManager.GetStockByMachineId(mId).Count() != 0)
            {
                Console.WriteLine("Product ID\tProduct Name\t\tOrder Quantity\t\tSale Quantity\t\tStock");
                foreach (var item in dbManager.GetStockByMachineId(mId))
                {
                    Console.WriteLine(item.product_id + "\t\t" +  item.product_name+ "\t\t" + item.Oqt + "\t\t\t" + item.Sqt +  "\t\t\t" + item.Qt);
                }
                Console.ReadLine();
            }
        }
        catch (Exception e)
        {

            throw new ArgumentNullException("Products not found!", e);
        }


    }
    
     public void PrintSalePerformanceByProductId()
   {
     Console.WriteLine("\n------------------------------------------- Product SaleList on Different Machine ---------------------------------------\n");
     int id = TryGetInt("Eenter Product ID:");
        try
        {
            if (dbManager.GetSalePerformenceByProductId(id).Count() != 0)
            {
                Console.WriteLine("Product ID " + "\t" + "Product Name" + "\t" + " Sale Price(Kr/unit)"+"\t"+ "Quantity"  +"\t"+ "Total Money(Kr)"+"\t"+ "MachineId\n" );
                foreach (var item in dbManager.GetSalePerformenceByProductId(id))
                {
                    Console.WriteLine(item.product_id + "\t\t" + item.product_name + "\t\t" + item.product_price + "\t\t" + item.sale_quantity + "\t\t" + item.sale_totalMoney+ "\t\t" + item.machine_id);
                }
                Console.ReadLine();
            }
            else if (dbManager.GetSalePerformenceByProductId(id).Count() != 0)
            {
                Console.WriteLine ("Not sold!");
                Console.ReadLine();
            }
        }
        catch (Exception e)
        {

            throw new ArgumentNullException("Products not found!", e);
        }
   }
   
    public void PrintSalePerformenceByMachineId()
   {
     Console.WriteLine("\n------------------------------------------- Machine SaleList ---------------------------------------\n");
     int id = TryGetInt("Eenter Mahcine ID:");
        try
        {
            if (dbManager.GetSalePerformenceByMachineId(id).Count() != 0)
            {
                Console.WriteLine("Product ID " + "\t" + "Product Name" + "\t" + " Sale Price(Kr/unit)"+"\t"+ "Quantity"  +"\t"+ "Total Money(Kr)\n");
                foreach (var item in dbManager.GetSalePerformenceByMachineId(id))
                {
                    Console.WriteLine(item.product_id + "\t\t" + item.product_name + "\t\t" + item.product_price + "\t\t" + item.sale_quantity + "\t\t" + item.sale_totalMoney);
                }
                Console.ReadLine();
            }
            
        }
        catch (Exception e)
        {

            throw new ArgumentNullException("Products not found!", e);
        }
   }
   
   public void PrintAllProductSalesList()
   {
     Console.WriteLine("\n------------------------------------------- All Product SaleList ---------------------------------------\n");
        try
        {
            if (dbManager.GetAllProductTotalSalesPerformence().Count() != 0)
            {
                Console.WriteLine("Product ID " + "\t" + "Product Name" + "\t" + " Sale Price(Kr/unit)"+"\t"+ "Quantity"  +"\t"+ "Total Money(Kr)\n");
                foreach (var item in dbManager.GetAllProductTotalSalesPerformence())
                {
                    Console.WriteLine(item.product_id + "\t\t" + item.product_name + "\t\t" + item.product_price + "\t\t" + item.sale_quantity + "\t\t" + item.sale_totalMoney);
                }
                Console.ReadLine();
            }
        }
        catch (Exception e)
        {

            throw new ArgumentNullException("Products not found!", e);
        }
   }
   
    public void DeleteEmployeeByIdInput()
    {
        int id = TryGetInt("Enter employee ID to be deleted");
        dbManager.RemoveEmployeeById(id);
        Console.WriteLine("Employee has been removed!");
        Console.ReadLine();
    }

    public void UpdateEmployeeInput()
    {
        int id = TryGetInt("Enter employee id to be updated:");
        string name = GetString("Enter employee name: ");
        string email = GetString("Enter employee email:");
        string phone = GetString("Enter employee phone:");
        dbManager.UpdateEmployeeById(id, name, email, phone);
        Console.WriteLine("-------- Updated Employee ------");
        Console.WriteLine("Employee ID " + "\t\t" + "Employee Name" + "\t\t" + "Employee Phone" + "\t\t" + "Employee Email\n");
        Console.WriteLine(dbManager.SearchEmployeeById(id));
        Console.ReadLine();
    }

    public void AddEmployeeInput()
    {
        string name = GetString("Enter employee name: ");
        string email = GetString("Enter employee email:");
        string phone = GetString("Enter employee phone:");
        int id = dbManager.AddEmployee(name, email, phone);
        Console.WriteLine("------- Added Employee ID ------");
        Console.WriteLine(id);
        Console.WriteLine("------------------- Added Employee -------------------");
        Console.WriteLine("Employee ID " + "\t\t" + "Employee Name" + "\t\t" + "Employee Phone" + "\t\t" + "Employee Email\n");
        Console.WriteLine(dbManager.SearchEmployeeById(id));
        Console.ReadLine();
    }

    public void SearchEmployeeByIdInnput()
    {
        int id = TryGetInt("Enter Employee ID");
        if (dbManager.SearchEmployeeById(id) != null)
        {
            Console.WriteLine("Employee ID " + "\t\t" + "Employee Name" + "\t\t" + "Employee Phone" + "\t\t" + "Employee Email\n");
            Console.WriteLine(dbManager.SearchEmployeeById(id));
            Console.ReadLine();
        }
    }

    public void PrintEmployeeList()
    {
        Console.WriteLine("\n------------------------------------------- Employee List ---------------------------------------\n");
        try
        {
            if (dbManager.GetEmployees().Count() != 0)
            {
                Console.WriteLine("Employee ID " + "\t\t" + "Employee Name" + "\t\t" + "Employee Phone" + "\t\t" + "Employee Email\n");
                foreach (var item in dbManager.GetEmployees())
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            }
        }
        catch (Exception e)
        {

            throw new ArgumentNullException("Products not found!", e);
        }
    }

    public void UpdatedMachineInput()
    {
        int id = TryGetInt("Enter Machine ID");
        string newLocation = GetString("Enter new location");
        string newModel = GetString("Enter new model ");
        dbManager.UpdateMachineById(id, newLocation, newModel);
        Console.WriteLine("------------------ Updated Machine -------------------");
        Console.WriteLine("Machine ID\tMachine Location\t\tMaichine Model");
        Console.WriteLine(dbManager.SearchMachineById(id));
        Console.ReadLine();
    }

    public void DeleteMachineInput()
    {
        int id = TryGetInt("Enter Machine id to be deleted");
        dbManager.RemoveMachineById(id);
        Console.WriteLine("Machine has been removed!");
        Console.ReadLine();
    }

    public void AddMachineInput()
    {
        string location = GetString("Enter machine location: ");
        string model = GetString("Enter machine model:");
        int id = dbManager.AddMachine(location, model);
        Console.WriteLine("--------- Added Machine ID ------");
        Console.WriteLine(id);
        Console.WriteLine("------------ Added Machine -----------");
        Console.WriteLine("Machine ID\tMachine Location\t\tMaichine Model");
        Console.WriteLine(dbManager.SearchMachineById(id));
        Console.ReadLine();
    }

    public void SearchMachineByIdInnput()
    {
        int id = TryGetInt("Enter Machine ID");
        if (dbManager.SearchMachineById(id) != null)
        {
            Console.WriteLine("Machine ID\tMachine Location\t\t   Maichine Model");
            Console.WriteLine(dbManager.SearchMachineById(id));
            Console.ReadLine();
        }
    }

    public void PrintMachineList()
    {
        Console.WriteLine("\n------------------------------------------- Machine List ---------------------------------------\n");
        try
        {
            if (dbManager.GetMachineList().Count() != 0)
            {
                Console.WriteLine("Machine ID\tMachine Location\t\t   Maichine Model");
                foreach (var item in dbManager.GetMachineList())
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            }
        }
        catch (Exception e)
        {

            throw new ArgumentNullException("Products not found!", e);
        }

    }

    public void UpdateProductByIdInput()
    {
        int id = TryGetInt("Enter product ID to be updated");
        string name = GetString("Enter new product name");
        dbManager.UpdateProductById(id, name);
        Console.WriteLine("-------- updated Product ------");
        Console.WriteLine("Product ID\tProduct Name");
        Console.WriteLine(dbManager.GetProductByName(name));
        Console.ReadLine();
    }

    public void DeleteProductInput()
    {
        int id = TryGetInt("Enter product ID to be deleted");
        dbManager.RemoveProductById(id);
        Console.WriteLine("Product has been removed!");
        Console.ReadLine();
    }

    public void AddProductInput()
    {
        string insertName = GetString("Enter product name: ");
        Console.WriteLine("Order Price");
        double orderP = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Sale Price");
        double saleP = Convert.ToDouble(Console.ReadLine());
        int id = dbManager.AddProduct(insertName, orderP, saleP);
        Console.WriteLine("------- Added Product ID ------");
        Console.WriteLine(id);
        Console.WriteLine("--------------- Added Product --------------\n");
        Console.WriteLine("Product ID\t Product Name\t Order Price\tSale Price");
        Console.WriteLine(dbManager.GetProductById(id));
        Console.WriteLine(dbManager.GetProductById(id).sale_price);
        Console.ReadLine();

    }

    public void PrintProduct()
    {
        string searchName = GetString("Enter product name: ");
        if (dbManager.GetProductByName(searchName) != null)
        {
            Console.WriteLine("Product ID\tProduct Name");
            Console.WriteLine(dbManager.GetProductByName(searchName));
            Console.ReadLine();
        }
    }

    public void PrintProductList()
    {
        Console.WriteLine("\n------------------------------------------- Product List ---------------------------------------\n");
        try
        {
            if (dbManager.GetProductList().Count() != 0)
            {
                Console.WriteLine("Product ID\t Product Name\t Order Price\tSale Price");
                foreach (var item in dbManager.GetProductList())
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            }
        }
        catch (Exception e)
        {

            throw new ArgumentNullException("Products not found!", e);
        }

    }

    public void AddRefillOrderInput()
    {
        Console.WriteLine("Enter order Date:");
        DateTime orderDate = DateTime.Parse(Console.ReadLine());
        int employeeId = TryGetInt("Enter employee ID: ");
        int machineId = TryGetInt("Enter machine ID: ");
        bool status = false;
        int refillOrderId = dbManager.AddRefillOrder(machineId, employeeId, orderDate, status,employeeId);
        Console.WriteLine("----------- Added RefillOrder ID ------");
        Console.WriteLine(refillOrderId);
        Console.ReadLine();
        int pId = TryGetInt("Product Id");
        int quantity = TryGetInt("Enter quantity");

        double oPrice = dbManager.GetProductById(pId).order_price;
        int detailId = dbManager.AddRefillOrderDetails(refillOrderId, pId, oPrice, quantity);
        Console.WriteLine("Order Details Id");
        Console.WriteLine(detailId);

        // double sPrice = dbManager.GetProductById(pId).sale_price;
        // sPrice = Convert.ToDouble(Console.ReadLine ());

        Console.WriteLine("------------------------------------ Added Refillorder Details -----------------------------------------");
        try
        {
            if (dbManager.GetOrderListByOrdeId(refillOrderId).Count() != 0)
            {
                Console.WriteLine("Refillorder ID\t Product ID\tProduct Name\tMachine ID\tOrder Date\tProduct Price(Kr)\tQuantity\tTotalMoney(Kr)\tEmplyee\t\tIsDone\t\tOrder By EmployeeID\n");
                foreach (var item in dbManager.GetOrderListByOrdeId(refillOrderId))
                {
                    Console.WriteLine(item + " \n");
                }
            }
        }
        catch (Exception e)
        {
            throw new ArgumentNullException("Order list not found", e);
        }
        Console.ReadLine();
    }

    public void ReamoveOrderByIdInput()
    {
        int orderId = TryGetInt("Enter  order ID: ");
        dbManager.RemoveOrderById(orderId);
        Console.WriteLine("Order has been deleted!");
        Console.ReadLine();
    }

    public void SearchOrderByOrderIdInput()
    {
        int orderId = TryGetInt("Enter searching order ID: ");

        try
        {
            if (dbManager.GetOrderListByOrdeId(orderId).Count() != 0)
            {
                Console.WriteLine("Refillorder ID\t Product ID\tProduct Name\tMachine ID\tOrder Date\tProduct Price(Kr)\tQuantity\tTotalMoney(Kr)\tEmplyee\t\tIsDone\t\tChecked By EmployeeID By EmployeeID\n");
                foreach (var item in dbManager.GetOrderListByOrdeId(orderId))
                {
                    Console.WriteLine(item + " \n");
                }
            }
        }
        catch (Exception e)
        {
            throw new ArgumentNullException("Order list not found", e);
        }
        Console.ReadLine();
    }

    public void UpdateOrderMachineEmployeeByIdInput()
    {
        int orderId = TryGetInt("Enter updateing order ID: ");
        int employeeId = TryGetInt("Enter new employee ID: ");
        int machineId = TryGetInt("Enter new machine ID: ");

        dbManager.UpdateOrderMachineEmployeeById(orderId, employeeId, machineId);
        Console.WriteLine("Order has been updated, new order details is: ");
        try
        {
            if (dbManager.GetOrderListByOrdeId(orderId).Count() != 0)
            {
                Console.WriteLine("\nRefillorder ID\t Product ID\tProduct Name\tMachine ID\tOrder Date\tProduct Price(Kr)\tQuantity\tTotalMoney(Kr)\tEmplyee \tIsDone\t\tChecked By EmployeeID\n");
                foreach (var item in dbManager.GetOrderListByOrdeId(orderId))
                {
                    Console.WriteLine(item + " \n");
                }
            }
        }
        catch (Exception e)
        {
            throw new ArgumentNullException("Order list not found", e);
        }
        Console.ReadLine();

    }

    public void UpdateOrderStatusByIdInput()
    {

        int orderId = TryGetInt("Enter updateing order ID: ");
        bool status;
        Console.WriteLine("Select Status number:\n[1] Order is completed.\n[0] Order is not completed");
        int input = TryGetInt("Is the order completed(1/2): ");
         int employeeId = TryGetInt("Enter checked by employee ID : ");
        if (input == 1)
        {
            status = true;
            dbManager.UpdateOrderStatustById(orderId, employeeId, status);
        }
        else if (input == 2)
        {
            status = false;
            dbManager.UpdateOrderStatustById(orderId, employeeId, status);
        }
        else 
        {
            Console.WriteLine ("Plese input 0 or 1!");
        }
         
        // Console.WriteLine("Is order done(True/False): ");
        // string input = Console.ReadLine().ToLower();
        //bool status;
        // bool status = Convert.ToBoolean(input);
        //    try
        //    {
        //     Console.WriteLine("Is order done(True/False): ");
        //     string input = Console.ReadLine().ToLower(); 
        //     status = Convert.ToBoolean(input);

        //    }
        //    catch (Exception e)
        //    {

        //     throw new ArgumentException("Input true or false",e);
        //    }
        //int employeeId = TryGetInt("Enter checked by employee ID : ");

        //dbManager.UpdateOrderStatustById(orderId, employeeId, status);
        Console.WriteLine("Order has been updated, new order details is: ");
        try
        {
            if (dbManager.GetOrderListByOrdeId(orderId).Count() != 0)
            {
                Console.WriteLine("\nRefillorder ID\t Product ID\tProduct Name\tMachine ID\tOrder Date\tProduct Price(Kr)\tQuantity\tTotalMoney(Kr)\tEmplyee \tIsDone\t\tChecked By EmployeeID\n");
                foreach (var item in dbManager.GetOrderListByOrdeId(orderId))
                {
                    Console.WriteLine(item + " \n");
                }
            }
        }
        catch (Exception e)
        {
            throw new ArgumentNullException("Order list not found", e);
        }
        Console.ReadLine();

    }

    public void UpdateOrderProductByIdInput()
    {
        int orderId = TryGetInt("Enter updateing order ID: ");
        int productId = TryGetInt("Enter updateing product ID: ");
        int newProductId = TryGetInt("Enter new product ID: ");
        int productQuantity = TryGetInt("Enter updateing prodct Quantity: ");

        dbManager.UpdateOrderProductById(orderId, productId, productQuantity, newProductId);
        Console.WriteLine("Order has been updated, new order details is: ");
        Console.WriteLine("\nRefillorder ID\t Product ID\tProduct Name\tMachine ID\tOrder Date\tProduct Price(Kr)\tQuantity\tTotalMoney(Kr)\tEmplyee \tIsDone\t\tChecked By EmployeeID\n");
        Console.WriteLine(dbManager.ShowUppdateOrderDetailsByOrderProductId(orderId, newProductId));
        Console.ReadLine();
    }

    public void PrintOrderListByMachineId()
    {
        Console.WriteLine("\n---------------------------------------------- Order List By MahcineID -------------------------------------------\n");
        int machineId = TryGetInt("Mchine Id: ");

        try
        {
            if (dbManager.GetRefillOrdersByMachineId(machineId).Count() != 0)
            {
                Console.WriteLine("\nRefillorder ID\t Product ID\tProduct Name\tMachine ID\tOrder Date\tProduct Price(Kr)\tQuantity\tTotalMoney(Kr)\tEmplyee \tIsDone\t\tChecked By EmployeeID\n");
                foreach (var item in dbManager.GetRefillOrdersByMachineId(machineId))
                {
                    Console.WriteLine(item + " \n");
                }
            }
        }
        catch (Exception e)
        {
            throw new ArgumentNullException("Order list not found", e);
        }
        Console.ReadLine();
    }

    public void PrintOrderListByOrderId()
    {
        Console.WriteLine("\n---------------------------------------------- Order List By OrderID -------------------------------------------\n");
        int orderId = TryGetInt("Order Id: ");

        try
        {
            if (dbManager.GetOrderListByOrdeId(orderId).Count() != 0)
            {
                Console.WriteLine("\nRefillorder ID\t Product ID\tProduct Name\tMachine ID\tOrder Date\tProduct Price(Kr)\tQuantity\tTotalMoney(Kr)\tEmplyee \tIsDone\t\tChecked By EmployeeID\n");
                foreach (var item in dbManager.GetOrderListByOrdeId(orderId))
                {
                    Console.WriteLine(item + " \n");
                }
            }
        }
        catch (Exception e)
        {
            throw new ArgumentNullException("Order list not found", e);
        }
        Console.ReadLine();
    }

    public void PrintOrderList()
    {
        Console.WriteLine("\n-------------------------------------------------------------- Order List --------------------------------------------------------------------\n");
        try
        {
            if (dbManager.GetRefillOrders().Count() != 0)
            {
                Console.WriteLine("\nRefillorder ID\t Product ID\tProduct Name\tMachine ID\tOrder Date\tProduct Price(Kr)\tQuantity\tTotalMoney(Kr)\tEmployee \tIsDone\t\tChecked By EmployeeID\n");
                foreach (var item in dbManager.GetRefillOrders())
                {
                    Console.WriteLine(item + " \n");
                }
            }
        }
        catch (Exception e)
        {
            throw new ArgumentNullException("Order list not found", e);
        }
        Console.ReadLine();
    }

    public string GetString(string prompt)
    {
        Console.WriteLine(prompt);

        return Console.ReadLine();
    }

    public void NoTryMessage()
    {
        Console.Write("\nNO more try. Bye!");
    }

    public bool QuitMessage()
    {
        bool quit;
        Console.WriteLine("You have chosen to quit the program");
        quit = true;
        return quit;
    }

    public int TryGetInt(string prompt)
    {
        int input = 0;
        while (input < 3)
        {
            Console.WriteLine(prompt);
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                return id;
            }
            else
            {
                if (input < 2)
                {
                    Console.WriteLine("Enter a correct number,try again");
                }

                else
                {
                    Console.WriteLine("No more try! Press enter to return to menu");
                }
                input++;
            }
        }
        return 0;
    }

}