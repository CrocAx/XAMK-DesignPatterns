class Program
{
    static void Main(string[] args)
    {
        //Setting two different class variables with instances to check if the singleton is working on 2 different instances.
        Logger l1 = Logger.GetInstance();
        Logger l2 = Logger.GetInstance();

        l1.loggerMessage();
        l2.loggerMessage();

        if (l1 == l2)
        {
            Console.WriteLine("Singleton is working on both instances.");
        }
        else
        {
            Console.WriteLine("Something went wrong!");
        }

        Console.ReadLine();

    }
}

public sealed class Logger
{
    private static Logger Instance = new Logger(); //Creating a Logger class
    private Logger() { } //Setting a private constructor so it cannot be called with 'new' operator
    public static Logger GetInstance() //This is a static method that controls the access to the singleton instance
    {
        if (Instance == null)
        {
            Instance = new Logger();
        }
        return Instance;
    }

    public void loggerMessage() //Singleton function which is executed on its instance.
    {
        Console.WriteLine("Singleton class code has been called!");

    }
}