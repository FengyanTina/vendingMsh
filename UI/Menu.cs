public class Menu
{
     public DataManager dbManager = new();
    public UserInput userInput = new();

    public void GetEmployeeMenu(int employeeId) 
    {
        bool quit = false;
        while (!quit)
        {
            Console.Clear();
            Console.WriteLine("\n********* Employee Menu *********\n ");
            MenuChoiceEmployee choice = EmployeeEnumSwitch();

            switch (choice)
            {
                case MenuChoice.ShowRooms:
                    userInput.PrintAllRooms();
                    break;

                case MenuChoice.ShowAvailableRooms:
                    userInput.PrintAvailableRooms();
                    break;

                case MenuChoice.ShowReservations:
                    userInput.PrintAllReservations();
                    break;

                case MenuChoice.SearchRoom:
                    userInput.SearchRoomByIdInput();
                    break;

                case MenuChoice.AddRoom:
                    userInput.AddRoomInput();
                    break;

                case MenuChoice.RemoveRoom:
                    userInput.RemoveRoomByIdInput();
                    break;

                case MenuChoice.UpdateRoomStatus:
                    userInput.UpdateRoomStatusInput();
                    break;

                case MenuChoice.MakingReservation:
                    reservationManager.EmployeeBookRoom(employeeId);
                    break;

                case MenuChoice.ShowSingleReservation:
                    userInput.ShowSingleReservationByIdInput();

                    break;

                case MenuChoice.CheckIn:
                    userInput.EmployeeCheckinInput(employeeId);
                    break;

                case MenuChoice.CheckOut:
                    userInput.EmployeeCheckOutInput(employeeId);
                    Console.ReadLine();
                    break;

                case MenuChoice.ShowPaymentOption:
                    quit = userInput.PaymentChoiceInput(quit);
                    break;

                case MenuChoice.UpdateReservationDate:
                    userInput.EmployeeReservationUpdate(employeeId);
                    break;

                case MenuChoice.ReadReviews:
                    userInput.PrintAllReviews();
                    break;

                case MenuChoice.RemoveReview:
                    userInput.RemoveReviewByIdInput();
                    break;

                case MenuChoice.Quit:

                    quit = userInput.QuitMessage();
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }
    }
    public MenuChoice EmployeeEnumSwitch()
    {
        foreach (string c in Enum.GetNames(typeof(MenuChoice)))
           { 
            Console.WriteLine("[{1}]:  {0,-20} ", c, 
                              Enum.Format(typeof(MenuChoice), 
                              Enum.Parse(typeof(MenuChoice), c), "d"));
           }
        MenuChoice choice = (MenuChoice)userInput.TryGetInt("Select one of the options:");
        return choice;
    }
}

public enum MenuChoice
{
    ShowRooms = 1,
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