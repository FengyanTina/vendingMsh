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

                case OrderCategory.DeleteOrderById:
                    
                    break;

                case OrderCategory.UppdateOrderProductById:
                    userInput.UpdateOrderProductByIdInput();
                    break;
                case OrderCategory.UpdateOrderMachineEmployeeById:
                    userInput.UpdateOrderMachineEmployeeByIdInput();
                    break;

                case OrderCategory.SearchOrderByMachinId:
                     userInput.PrintOrderListByMachineId();
                    break;

                case OrderCategory.SearchOrderByOrderId:
                     userInput.PrintOrderListByMachineId();
                    break;

                case OrderCategory.AddOrder:
                   
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

    public void ProductChoice() 
    {
        bool quit = false;
        while (!quit)
        {
            Console.Clear();
            Console.WriteLine("\n********* Product Category Choice*********\n ");
           ProductCategory productChoice = ProductCategorySwitch();

            switch (productChoice)
            {
                case ProductCategory.AddProduct:
                    userInput.PrintOrderList();
                    break;

                case ProductCategory.DeleteProductById:
                    
                    break;

                case ProductCategory.ShowProductList:
                    
                    break;

                case ProductCategory.ShowProductByMachinId:
                   
                    break;

                case ProductCategory.UppdateProduct:
                   
                    break;

                case ProductCategory.Quit:

                    quit = userInput.QuitMessage();
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }
    }

    public void SalesChoice() 
    {
        bool quit = false;
        while (!quit)
        {
            Console.Clear();
            Console.WriteLine("\n********* Product Category Choice*********\n ");
           SalesCategory salesChoice = SalesCategorySwitch();

            switch (salesChoice)
            {
                case SalesCategory.AddSales:
                    userInput.PrintOrderList();
                    break;

                case SalesCategory.ShowSalesList:
                    
                    break;

                case SalesCategory.ShowSalesByMachinId:
                    
                    break;

                case SalesCategory.ShowSalesByProductId:
                   
                    break;

                case SalesCategory.Quit:

                    quit = userInput.QuitMessage();
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }
    }

    public void EmployeeChoice() 
    {
        bool quit = false;
        while (!quit)
        {
            Console.Clear();
            Console.WriteLine("\n********* Product Category Choice*********\n ");
           EmployeeCategory employeeChoice = EmployeeCategorySwitch();

            switch (employeeChoice)
            {
                case EmployeeCategory.AddEmployee:
                    userInput.PrintOrderList();
                    break;

                case EmployeeCategory.DeleteEmployeeById:
                    
                    break;

                case EmployeeCategory.SearchEmployee:
                    
                    break;

                case EmployeeCategory.UpdateEmployeeById:
                   
                    break;

                case EmployeeCategory.Quit:

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

    public SalesCategory SalesCategorySwitch()
    {
        foreach (string c in Enum.GetNames(typeof(SalesCategory)))
           { 
            Console.WriteLine("[{1}]:  {0,-20} ", c, 
                              Enum.Format(typeof(SalesCategory), 
                              Enum.Parse(typeof(SalesCategory), c), "d"));
           }
        SalesCategory salesCategory = (SalesCategory)userInput.TryGetInt("Select one of the options:");
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

public enum ProductCategory
{
    ShowProductList = 1,
    AddProduct,
    UppdateProduct,
    DeleteProductById,
    ShowProductByMachinId,
    Quit,
}

public enum OrderCategory
{
    ShowOrderList = 1,
    AddOrder,
    UppdateOrderProductById,
    UpdateOrderMachineEmployeeById,
    DeleteOrderById,
    SearchOrderByMachinId,
    SearchOrderByOrderId,
    Quit,
}

public enum SalesCategory
{
    ShowSalesList = 1,
    AddSales,
    ShowSalesByMachinId,
    ShowSalesByProductId,
    Quit,
}

public enum EmployeeCategory
{
    AddEmployee= 1,
    SearchEmployee,
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