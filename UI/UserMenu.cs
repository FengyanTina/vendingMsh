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

                case OrderCategory.ShowAvailableRooms:
                    
                    break;

                case OrderCategory.ShowReservations:
                    
                    break;

                case OrderCategory.SearchRoom:
                   
                    break;

                case OrderCategory.AddRoom:
                   
                    break;

                case OrderCategory.RemoveRoom:
                    
                    break;

                case OrderCategory.UpdateRoomStatus:
                    
                    break;

                case OrderCategory.MakingReservation:
                  
                    break;

                case OrderCategory.ShowSingleReservation:
                  

                    break;

                case OrderCategory.CheckIn:
                    
                    break;

                case OrderCategory.CheckOut:
                    
                    Console.ReadLine();
                    break;

                case OrderCategory.ShowPaymentOption:
                    
                    break;

                case OrderCategory.UpdateReservationDate:
                   
                    break;

                case OrderCategory.ReadReviews:
                    
                    break;

                case OrderCategory.RemoveReview:
                    
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


}

public enum OrderCategory
{
    ShowOrderList = 1,
    ShowAvailableRooms,
    SearchRoom,
    AddRoom,
    RemoveRoom,
    UpdateRoomStatus,
    MakingReservation,
    ShowReservations,
    ShowSingleReservation,
    UpdateReservationDate,
    CheckIn,
    CheckOut,
    ShowPaymentOption,
    ReadReviews,
    RemoveReview,
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