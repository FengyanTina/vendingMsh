public class UserInput
{
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