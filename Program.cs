internal class Program
{
    private static void Main(string[] args)
    {
        UserMenu menu = new();
        UserInput Input = new();
        Category category = menu.CategorySwitch();

        bool quit = false;
        while (true)
        {
            Console.WriteLine("\n********* Main Menu *********\n ");
            Console.Clear();
            switch (category)
            {
                case Category.Orders:
                    menu.OrderChoice();
                    break;

                case Category.Products:
                    
                    break;

                case Category.Sales:
                    
                    break;

                case Category.Machines:
                    
                    break;

                case Category.Quit:
                    quit = Input.QuitMessage();
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