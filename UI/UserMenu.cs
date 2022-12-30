public class UserMenu
{
    DataManager dbManager = new();
    UserInput userInput = new();
    
    public void StockMenu()
    {
       
        while (true)
        {
        userInput.PrintStockByMachine();
            
        }

    }

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
                case OrderCategory.ShowAllOrderList:
                    userInput.PrintOrderList();
                    break;

                case OrderCategory.DeleteOrderByOrderId:
                    userInput.ReamoveOrderByIdInput();
                    break;

                case OrderCategory.UppdateOrderProductByOrderId:
                    userInput.UpdateOrderProductByIdInput();
                    break;
                case OrderCategory.UpdateOrderMachineEmployeeByOrderId:
                    userInput.UpdateOrderMachineEmployeeByIdInput();
                    break;

                case OrderCategory.SearchOrderByMachinId:
                     userInput.PrintOrderListByMachineId();
                    break;

                case OrderCategory.SearchOrderByOrderId:
                     userInput.PrintOrderListByOrderId();
                    break;
                case OrderCategory.SearchOrderByProductId:
                     userInput.PrintOrderListByProductId();
                    break;

                case OrderCategory.AddOrder:
                   userInput.AddOrderInput();
                    break;
                case OrderCategory.UppdateOrderStatus:
                   userInput.UpdateOrderStatusByIdInput();
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
                     userInput.AddProductInput();
                    break;

                case ProductCategory.DeleteProductById:
                    userInput.DeleteProductInput();
                    break;

                case ProductCategory.ShowProductList:
                    userInput.PrintProductList();
                    break;

                case ProductCategory.SearchProductByName:
                   userInput.PrintProduct();
                    break;

                case ProductCategory.UppdateProduct:
                   userInput.UpdateProductByIdInput();
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

    public void MachineChoice() 
    {
        bool quit = false;
        while (!quit)
        {
            Console.Clear();
            Console.WriteLine("\n********* Product Category Choice*********\n ");
           MachineCategory machineChoice = MachineCategorySwitch();

            switch (machineChoice)
            {
                case MachineCategory.AddMachine:
                     userInput.AddMachineInput();
                    break;

                case MachineCategory.DeleteMachine:
                    userInput.DeleteMachineInput();
                    break;

                case MachineCategory.SearchMachineById:
                   userInput.SearchMachineByIdInnput();
                    break;

                case MachineCategory.ShowMachineList:
                   userInput.PrintMachineList();
                    break;

                case MachineCategory.UppdateMachine:
                   userInput.UpdatedMachineInput();
                    break;

                case MachineCategory.Quit:
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
                    userInput.AddSalesInput();
                    break;

                case SalesCategory.ShowAllProductSalesList:
                    userInput.PrintAllProductSalesList();
                    break;

                case SalesCategory.ShowSalesPerformenceByMachinId:
                    userInput.PrintSalePerformenceByMachineId();
                    break;

                case SalesCategory.ShowSalesPerformanceByProductId:
                   userInput.PrintSalePerformanceByProductId();
                    break;
                case SalesCategory.Stock:
                   userInput.PrintStockByMachine();
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
                   userInput.AddEmployeeInput();
                    break;

                case EmployeeCategory.DeleteEmployeeById:
                    userInput.DeleteEmployeeByIdInput();
                    break;

                case EmployeeCategory.SearchEmployee:
                    userInput.SearchEmployeeByIdInnput();
                    break;

                case EmployeeCategory.UpdateEmployeeById:
                   userInput.UpdateEmployeeInput();
                    break;
                 case EmployeeCategory.EmployeeList:
                    userInput.PrintEmployeeList();
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

    public MachineCategory MachineCategorySwitch()
    {
        foreach (string c in Enum.GetNames(typeof(MachineCategory)))
           { 
            Console.WriteLine("[{1}]:  {0,-20} ", c, 
                              Enum.Format(typeof(MachineCategory), 
                              Enum.Parse(typeof(MachineCategory), c), "d"));
           }

           MachineCategory machineChoice =(MachineCategory)userInput.TryGetInt("Select one of the options:");    
        return machineChoice;
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
    SearchProductByName,
    Quit,
}

public enum MachineCategory
{
    ShowMachineList = 1,
    AddMachine,
    UppdateMachine,
    DeleteMachine,
    SearchMachineById,
    Quit,
}

public enum OrderCategory
{
    ShowAllOrderList = 1,
    SearchOrderByMachinId,
    SearchOrderByOrderId,
    SearchOrderByProductId,
    UppdateOrderProductByOrderId,
    UpdateOrderMachineEmployeeByOrderId,
    UppdateOrderStatus,
    AddOrder,
    DeleteOrderByOrderId,
    Quit,
}

public enum SalesCategory
{
    AddSales = 1,
    ShowAllProductSalesList,
    ShowSalesPerformenceByMachinId,
    ShowSalesPerformanceByProductId,
    Stock,
    Quit,
}

public enum EmployeeCategory
{
    AddEmployee= 1,
    SearchEmployee,
    DeleteEmployeeById,
    UpdateEmployeeById,
    EmployeeList,
    Quit,
}

public enum Category
{
    Orders = 1,
    Products,
    Sales,
    Machines,
    Emoloyees,
    StockChecking,
    Quit,
}