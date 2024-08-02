using CarFactory.Models.Car;
using CarFactory.Models.CarBody;
using CarFactory.Models.CarColor;
using CarFactory.Models.Engine;
using CarFactory.Models.Transmission;

namespace CarFactory;

public class CarCreator
{
    public ICar CreateCar()
    {
        IBody body = AddBody();
        IColor color = AddColor();
        IEngine engine = AddEngine();
        ITransmission transmission = AddTransmission();

        return new Car( body, color, engine, transmission );
    }

    private IBody AddBody()
    {
        Console.WriteLine( "Введите тип кузова: (Cabriolet, Crossover, Hatchback, Sedan)" );
        string body = Console.ReadLine().ToLower();
        switch ( body )
        {
            case "cabriolet":
                return new Cabriolet();
            case "crossover":
                return new Crossover();
            case "hatchback":
                return new Hatchback();
            case "sedan":
                return new Sedan();
            default:
                throw new ArgumentException( "Такого кузова не существует" );
        }
    }

    private IColor AddColor()
    {
        Console.WriteLine( "Введите цвет: (Black, White, Blue, Red)" );
        string color = Console.ReadLine().ToLower();
        switch ( color )
        {
            case "black":
                return new Black();
            case "white":
                return new White();
            case "blue":
                return new Blue();
            case "red":
                return new Red();
            default:
                throw new ArgumentException( "Такого цвета не существует" );
        }
    }

    private IEngine AddEngine()
    {
        Console.WriteLine( "Введите тип двигателя: (Diesel, Electric, Gasoline, Rotary)" );
        string engine = Console.ReadLine().ToLower();
        switch ( engine )
        {
            case "diesel":
                return new DieselEngine();
            case "electric":
                return new ElectricEngine();
            case "gasoline":
                return new GasolineEngine();
            case "rotary":
                return new RotaryEngine();
            default:
                throw new ArgumentException( "Такого двигателя не существует" );
        }
    }

    private ITransmission AddTransmission()
    {
        Console.WriteLine( "Введите тип коробки передач: (Automatic, Manual, Robotized)" );
        string engine = Console.ReadLine().ToLower();
        switch ( engine )
        {
            case "automatic":
                return new AutomaticTransmission();
            case "manual":
                return new ManualTransmission();
            case "robotized":
                return new RobotizedTransmission();
            default:
                throw new ArgumentException( "Такой коробки передач не существует" );
        }
    }
}
