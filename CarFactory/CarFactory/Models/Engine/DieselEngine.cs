namespace CarFactory.Models.Engine;

public class DieselEngine : IEngine
{
    public string Name
    {
        get => "Diesel Engine";
    }
    public int MaxSpeed
    {
        get => 190;
    }
}
