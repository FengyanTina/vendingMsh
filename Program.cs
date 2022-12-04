internal class Program
{
    private static void Main(string[] args)
    {
        ProductDB db = new ProductDB();
        Console.WriteLine($"ID" + "  " + " Name");
        foreach (var item in db.GetProducts())
        {
            Console.WriteLine(item);
        }
        
}
}