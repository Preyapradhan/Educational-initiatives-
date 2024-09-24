//Command Pattern (Smart Home System)
// Command Interface
public interface ICommand
{
    void Execute();
}

// Receiver Class (Light)
public class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Light is ON");
    }

    public void TurnOff()
    {
        Console.WriteLine("Light is OFF");
    }
}

// Concrete Command to Turn On Light
public class TurnOnLightCommand : ICommand
{
    private Light _light;

    public TurnOnLightCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOn();
    }
}

// Concrete Command to Turn Off Light
public class TurnOffLightCommand : ICommand
{
    private Light _light;

    public TurnOffLightCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOff();
    }
}

// Invoker Class (Remote Control)
public class RemoteControl
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void PressButton()
    {
        _command.Execute();
    }
}

// Program to demonstrate the Command pattern
public class Program
{
    public static void Main()
    {
        Light livingRoomLight = new Light();

        ICommand turnOn = new TurnOnLightCommand(livingRoomLight);
        ICommand turnOff = new TurnOffLightCommand(livingRoomLight);

        RemoteControl remote = new RemoteControl();

        remote.SetCommand(turnOn);
        remote.PressButton();

        remote.SetCommand(turnOff);
        remote.PressButton();
    }
}
