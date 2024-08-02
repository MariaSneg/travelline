using CarFactory.Models.CarBody;
using CarFactory.Models.CarColor;
using CarFactory.Models.Engine;
using CarFactory.Models.Transmission;

namespace CarFactory.Models.Car;

public class Car : ICar
{
    public IBody Body { get; private set; }
    public IColor Color { get; private set; }
    public Engine.IEngine Engine { get; private set; }
    public Transmission.ITransmission Transmission { get; private set; }
    public int MaxSpeed { get; private set; }
    public int NumberOfGears { get; private set; }

    public Car( IBody body, IColor color, IEngine engine, ITransmission transmission )
    {
        Body = body;
        Color = color;
        Engine = engine;
        Transmission = transmission;
        MaxSpeed = engine.MaxSpeed;
        NumberOfGears = transmission.NumberOfGears;
    }

    public void PrintConfiguration()
    {
        Console.WriteLine( $"Car Body: {Body.Name}" );
        Console.WriteLine( $"Car Color: {Color.Name}" );
        Console.WriteLine( $"Engine: {Engine.Name}" );
        Console.WriteLine( $"Transmission: {Transmission.Name}" );
        Console.WriteLine( $"Max speed: {MaxSpeed}" );
        Console.WriteLine( $"Number of gears: {NumberOfGears}" );
    }
}
