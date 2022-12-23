internal class Program
{
   

    private static void Main(string[] args)
    {
         
        UserMenu menu = new();
        UserInput Input = new();
        Category category = menu.CategorySwitch();

        bool quit = false;
        while (!quit)
        {
            Console.WriteLine("\n********* Main Menu *********\n ");
            Console.Clear();
            switch (category)
            {
                case Category.Orders:
                    menu.OrderChoice();
                    break;

                case Category.Products:
                    menu.ProductChoice();
                    
                    break;

                case Category.Sales:
                    menu.SalesChoice();
                    
                    break;

                case Category.Machines:
                    menu.MachineChoice();
                    break;

                 case Category.Emoloyees:
                    menu.EmployeeChoice();
                    break;
                case Category.StockChecking:
                
                    menu.StockMenu();
                   //Input.PrintStockByMachine();
                  
                    break;

                case Category.Quit:
                    quit = Input.QuitMessage();
                    Environment.Exit(0);
                    break;

                default:
                    break;

            }
            
        }
    }
}