using CarFactory.Models.CarBody;
using CarFactory.Models.CarColor;
using CarFactory.Models.Engine;
using CarFactory.Models.Transmission;

namespace CarFactory.Models.Car;

public interface ICar
{
    public IBody Body { get; }
    public IColor Color { get; }
    public Engine.IEngine Engine { get; }
    public Transmission.ITransmission Transmission { get; }
    public int MaxSpeed { get; }
    public int NumberOfGears { get; }

    public void PrintConfiguration();
}
