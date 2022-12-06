internal class Program
{
    private static void Main(string[] args)
    {
        UserMenu menu = new();
        UserInput userInput = new();
        Category category = menu.CategorySwitch();

        bool quit = false;
        while (true)
        {
            Console.WriteLine("\n********* Main Menu *********\n ");
            Console.Clear();
            switch (category)
            {
                case Category.Orders:
                    menu.OrderCategoryChoice();
                    break;

                case Category.Products:
                    
                    break;

                case Category.Sales:
                    
                    break;

                case Category.Machines:
                    
                    break;

                case Category.Quit:
                    quit = userInput.QuitMessage();
                    Environment.Exit(0);
                    break;

                default:
                    break;

            }
            // ProductDB db = new ProductDB();
            // Console.WriteLine($"ID" + "  " + " Name");
            // foreach (var item in db.GetProducts())
            // {
            //     Console.WriteLine(item);
            // }

        }
    }
}