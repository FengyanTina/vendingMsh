public class UserInput
{
    DataManager dbManager = new();
    // UserMenu menu = new();
    
    public void PrintOrderList()
    {
         Console.WriteLine("\n******************************* Order List ************************\n");
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
        Console.Write(prompt);

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