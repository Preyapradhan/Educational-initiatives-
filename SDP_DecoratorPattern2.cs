//Decorator Pattern (Text Formatting Tool)
// Component Interface
public interface IText
{
    string GetFormattedText();
}

// Concrete Component
public class PlainText : IText
{
    private string _text;

    public PlainText(string text)
    {
        _text = text;
    }

    public string GetFormattedText()
    {
        return _text;
    }
}

// Decorator
public abstract class TextDecorator : IText
{
    protected IText _text;

    public TextDecorator(IText text)
    {
        _text = text;
    }

    public abstract string GetFormattedText();
}

// Concrete Decorator (Bold)
public class BoldText : TextDecorator
{
    public BoldText(IText text) : base(text) { }

    public override string GetFormattedText()
    {
        return $"<b>{_text.GetFormattedText()}</b>";
    }
}

// Concrete Decorator (Italic)
public class ItalicText : TextDecorator
{
    public ItalicText(IText text) : base(text) { }

    public override string GetFormattedText()
    {
        return $"<i>{_text.GetFormattedText()}</i>";
    }
}

// Program to demonstrate Decorator pattern
public class Program
{
    public static void Main()
    {
        IText plainText = new PlainText("Hello, World!");

        // Applying Bold decorator
        IText boldText = new BoldText(plainText);
        Console.WriteLine(boldText.GetFormattedText());

        // Applying Italic decorator on top of Bold
        IText italicBoldText = new ItalicText(boldText);
        Console.WriteLine(italicBoldText.GetFormattedText());
    }
}
