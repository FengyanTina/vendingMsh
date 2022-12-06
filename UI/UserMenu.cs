public class UserMenu
{
      DataManager dbManager = new();
     UserInput userInput = new();
     

    public void OrderChoice() 
    {
        bool quit = false;
        while (!quit)
        {
            Console.Clear();
            Console.WriteLine("\n********* Order Category Choice*********\n ");
           OrderCategory OrderChoice = OrderCategorySwitch();

            switch (OrderChoice)
            {
                case OrderCategory.ShowOrderList:
                    userInput.PrintOrderList();
                    break;

                case OrderCategory.AddOrder:
                    
                    break;

                case OrderCategory.DeleteOrderById:
                    
                    break;

                case OrderCategory.SearchOrderByMachinId:
                   
                    break;

                case OrderCategory.UppdateOrder:
                   
                    break;

                case OrderCategory.Quit:

                    quit = userInput.QuitMessage();
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }
    }
    
    public OrderCategory OrderCategorySwitch()
    {
        foreach (string c in Enum.GetNames(typeof(OrderCategory)))
           { 
            Console.WriteLine("[{1}]:  {0,-20} ", c, 
                              Enum.Format(typeof(OrderCategory), 
                              Enum.Parse(typeof(OrderCategory), c), "d"));
           }

           OrderCategory orderChoice =(OrderCategory)userInput.TryGetInt("Select one of the options:");    
        return orderChoice;
    }


    public Category CategorySwitch()
    {
        foreach (string c in Enum.GetNames(typeof(Category)))
           { 
            Console.WriteLine("[{1}]:  {0,-20} ", c, 
                              Enum.Format(typeof(Category), 
                              Enum.Parse(typeof(Category), c), "d"));
           }
        Category category = (Category)userInput.TryGetInt("Select one of the options:");
        return category;
    }

    public ProductCategory ProductCategorySwitch()
    {
        foreach (string c in Enum.GetNames(typeof(ProductCategory)))
           { 
            Console.WriteLine("[{1}]:  {0,-20} ", c, 
                              Enum.Format(typeof(ProductCategory), 
                              Enum.Parse(typeof(ProductCategory), c), "d"));
           }
        ProductCategory productCategory = (ProductCategory)userInput.TryGetInt("Select one of the options:");
        return productCategory;
    }

    public SalesAndStockCategory SalesAndStockCategorySwitch()
    {
        foreach (string c in Enum.GetNames(typeof(SalesAndStockCategory)))
           { 
            Console.WriteLine("[{1}]:  {0,-20} ", c, 
                              Enum.Format(typeof(SalesAndStockCategory), 
                              Enum.Parse(typeof(SalesAndStockCategory), c), "d"));
           }
        SalesAndStockCategory salesCategory = (SalesAndStockCategory)userInput.TryGetInt("Select one of the options:");
        return salesCategory;
    }

    public EmployeeCategory EmployeeCategorySwitch()
    {
        foreach (string c in Enum.GetNames(typeof(EmployeeCategory)))
           { 
            Console.WriteLine("[{1}]:  {0,-20} ", c, 
                              Enum.Format(typeof(EmployeeCategory), 
                              Enum.Parse(typeof(EmployeeCategory), c), "d"));
           }
        EmployeeCategory employeeCategory = (EmployeeCategory)userInput.TryGetInt("Select one of the options:");
        return employeeCategory;
    }


}

public enum OrderCategory
{
    ShowOrderList = 1,
    AddOrder,
    UppdateOrder,
    DeleteOrderById,
    SearchOrderByMachinId,
    Quit,
}

public enum ProductCategory
{
    ShowProductList = 1,
    AddProduct,
    UppdateProduct,
    DeleteProductById,
    SearchProductByMachinId,
    Quit,
}

public enum SalesAndStockCategory
{
    ShowSalesList = 1,
    AddSales,
    ShowSalesByMachinId,
    ShowSalesByProductId,
    Quit,
}

public enum EmployeeCategory
{
    ShowEmployeeList = 1,
    AddEmployee,
    DeleteEmployeeById,
    UpdateEmployeeById,
    Quit,
}

public enum Category
{
    Orders = 1,
    Products,
    Sales,
    Machines,
    Emoloyees,
    Quit,
}