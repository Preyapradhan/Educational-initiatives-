//Factory Method Pattern (Vehicle Factory)
// Product interface
public interface IVehicle
{
    void Drive();
}

// Concrete Product (Car)
public class Car : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Driving a Car");
    }
}

// Concrete Product (Truck)
public class Truck : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Driving a Truck");
    }
}

// Creator class
public abstract class VehicleFactory
{
    public abstract IVehicle CreateVehicle();
}

// Concrete Creator (Car Factory)
public class CarFactory : VehicleFactory
{
    public override IVehicle CreateVehicle()
    {
        return new Car();
    }
}

// Concrete Creator (Truck Factory)
public class TruckFactory : VehicleFactory
{
    public override IVehicle CreateVehicle()
    {
        return new Truck();
    }
}

// Program to demonstrate Factory Method pattern
public class Program
{
    public static void Main()
    {
        VehicleFactory carFactory = new CarFactory();
        IVehicle car = carFactory.CreateVehicle();
        car.Drive();

        VehicleFactory truckFactory = new TruckFactory();
        IVehicle truck = truckFactory.CreateVehicle();
        truck.Drive();
    }
}
