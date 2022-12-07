public class UserInput
{
    DataManager dbManager = new();

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
            int id = dbManager.AddMachine(location,model);
             Console.WriteLine("------- Added Machine ID ------");
             Console.WriteLine(id);
             Console.WriteLine("-------- Added Machine ------");
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
        
        throw new ArgumentNullException("Products not found!",e);
      } 

    }
    
    public void updateProductByIdInput()
    {
        int id = TryGetInt("Enter product ID to be updated");
        string name = GetString("Enter new product name");
        dbManager.UpdateProductById(id,name);
        Console.WriteLine ("-------- updated Product ------");
        Console.WriteLine("Product ID\tProduct Name");
        Console.WriteLine (dbManager.GetProductByName(name));
        Console.ReadLine ();
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
             int id = dbManager.AddProduct(insertName);
             Console.WriteLine("------- Added Product ID ------");
             Console.WriteLine(id);
             Console.WriteLine("-------- Added Product ------");
             Console.WriteLine("Product ID\tProduct Name");
             Console.WriteLine(dbManager.GetProductByName(insertName));
             Console.ReadLine();
         
    }

    public void PrintProduct()
    {
         string searchName = GetString("Enter product name: ");
        if(dbManager.GetProductByName(searchName)!=null)
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
                Console.WriteLine("Product ID\tProduct Name");
                foreach (var item in dbManager.GetProductList())
                {
                    Console.WriteLine(item);  
                }
                Console.ReadLine();
            }
        }
        catch (Exception e)
      {
        
        throw new ArgumentNullException("Products not found!",e);
      } 

    }

    public void SearchOrderByOrderIdInput()
    {
       int orderId= TryGetInt("Enter searching order ID: ");
       
      try
      {
        if ((dbManager.GetOrderByOrdeId(orderId)!=null))
        {
            Console.WriteLine("Refillorder ID\t Product ID\tProduct Name\tMachine ID\tOrder Date\tProduct Price(Kr)\tQuantity\tTotalMoney(Kr)\n");
            Console.WriteLine( dbManager.GetOrderByOrdeId(orderId));  
        }
      }
      catch (Exception e)
      {
        
        throw new ArgumentNullException("Order not found!",e);
      } 
    }

    public void UpdateOrderMachineEmployeeByIdInput()
    {
        int orderId= TryGetInt("Enter updateing order ID: ");
        int employeeId= TryGetInt("Enter new employee ID: ");
        int machineId= TryGetInt("Enter new machine ID: ");
        
        dbManager.UpdateOrderMachineEmployeeById(orderId, employeeId,machineId);
        Console.WriteLine ("Order has been updated, new order details is: ");
        Console.WriteLine("Refillorder ID\t Product ID\tProduct Name\tMachine ID\tOrder Date\tProduct Price(Kr)\tQuantity\tTotalMoney(Kr)\n");
        Console.WriteLine(dbManager.GetOrderByOrdeId(orderId));
    }

    public void UpdateOrderProductByIdInput()
    {
        int orderId= TryGetInt("Enter updateing order ID: ");
        int productId= TryGetInt("Enter updateing product ID: ");
        int newProductId= TryGetInt("Enter new product ID: ");
        int productQuantity= TryGetInt("Enter updateing prodct Quantity: ");
        
        dbManager.UpdateOrderProductById(orderId,productId,productQuantity,newProductId);
        Console.WriteLine ("Order has been updated, new order details is: ");
        Console.WriteLine("Refillorder ID\t Product ID\tProduct Name\tMachine ID\tOrder Date\tProduct Price(Kr)\tQuantity\tTotalMoney(Kr)\n");
        Console.WriteLine(dbManager.ShowUppdateOrderDetailsByOrderProductId(orderId,newProductId));
    }

    public void PrintOrderListByMachineId()
    {
        Console.WriteLine("\n---------------------------------------------- Order List By MahcineID -------------------------------------------\n");
        int machineId = TryGetInt("Mchine Id: ");

        try
        {
            if (dbManager.GetRefillOrdersByMachineId(machineId).Count() != 0)
            {
                Console.WriteLine("Refillorder ID\t Product ID\tProduct Name\tMachine ID\tOrder Date\tProduct Price(Kr)\tQuantity\tTotalMoney(Kr)\n");
                foreach (var item in dbManager.GetRefillOrdersByMachineId(machineId))
                {
                    Console.WriteLine(item + " \n");
                }
            }
        }
         catch (Exception e)
        {
            throw new ArgumentNullException("Order list not found",e);
        }
        Console.ReadLine(); 
    }

    public void PrintOrderListByOrderId()
    {
        Console.WriteLine("\n---------------------------------------------- Order List By OrderID -------------------------------------------\n");
        int orderId = TryGetInt("Order Id: ");

        try
        {
            if (dbManager.GetRefillOrdersByMachineId(orderId).Count() != 0)
            {
                Console.WriteLine("Refillorder ID\t Product ID\tProduct Name\tMachine ID\tOrder Date\tProduct Price(Kr)\tQuantity\tTotalMoney(Kr)\n");
                foreach (var item in dbManager.GetRefillOrdersByMachineId(orderId))
                {
                    Console.WriteLine(item + " \n");
                }
            }
        }
        catch (Exception e)
        {
            throw new ArgumentNullException("Order list not found",e);
        }
        Console.ReadLine(); 
    }

    public void PrintOrderList()
    {
         Console.WriteLine("\n------------------------------------------- Order List ---------------------------------------\n");
        try
        {
            if (dbManager.GetRefillOrders().Count() != 0)
            {
                Console.WriteLine("Refillorder ID\t Product ID\tProduct Name\tMachine ID\tOrder Date\tProduct Price(Kr)\tQuantity\tTotalMoney(Kr)\n");
                foreach (var item in dbManager.GetRefillOrders())
                {
                    Console.WriteLine(item + " \n");
                }
            }
        }
        catch (Exception e)
        {
            throw new ArgumentNullException("Order list not found",e);
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