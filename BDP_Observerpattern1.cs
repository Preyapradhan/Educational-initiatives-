 //Observer Pattern (Blog Notification System)
// IObserver interface
public interface IObserver
{
    void Update(string articleTitle);
}

// ISubject interface
public interface ISubject
{
    void Subscribe(IObserver observer);
    void Unsubscribe(IObserver observer);
    void NotifyObservers();
}

// Concrete Subject (Blog)
public class Blog : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private string latestArticle;

    public void PublishArticle(string title)
    {
        latestArticle = title;
        NotifyObservers();
    }

    public void Subscribe(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Unsubscribe(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(latestArticle);
        }
    }
}

// Concrete Observer (User)
public class User : IObserver
{
    private string username;

    public User(string name)
    {
        this.username = name;
    }

    public void Update(string articleTitle)
    {
        Console.WriteLine($"{username} has been notified of a new article: {articleTitle}");
    }
}

// Program to demonstrate the Observer pattern
public class Program
{
    public static void Main()
    {
        Blog techBlog = new Blog();
        User user1 = new User("Alice");
        User user2 = new User("Bob");

        techBlog.Subscribe(user1);
        techBlog.Subscribe(user2);

        techBlog.PublishArticle("Observer Pattern in C#");

        // Unsubscribe one user
        techBlog.Unsubscribe(user1);

        techBlog.PublishArticle("Another Design Pattern Article");
    }
}
