//Singleton Pattern (Database Connection)
public class DatabaseConnection
{
    private static DatabaseConnection _instance;
    private static readonly object _lock = new object();

    private DatabaseConnection()
    {
        Console.WriteLine("Database connection established.");
    }

    public static DatabaseConnection GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new DatabaseConnection();
                }
            }
        }
        return _instance;
    }

    public void Query(string sql)
    {
        Console.WriteLine($"Executing SQL Query: {sql}");
    }
}

// Program to demonstrate Singleton pattern
public class Program
{
    public static void Main()
    {
        DatabaseConnection db1 = DatabaseConnection.GetInstance();
        db1.Query("SELECT * FROM Users");

        DatabaseConnection db2 = DatabaseConnection.GetInstance();
        db2.Query("SELECT * FROM Products");

        // db1 and db2 will be the same instance
        Console.WriteLine(object.ReferenceEquals(db1, db2));  // Output: True
    }
}
