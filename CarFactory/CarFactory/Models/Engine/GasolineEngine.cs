namespace CarFactory.Models.Engine;

public class GasolineEngine : IEngine
{
    public string Name
    {
        get => "Gasoline Engine";
    }
    public int MaxSpeed
    {
        get => 160;
    }
}
