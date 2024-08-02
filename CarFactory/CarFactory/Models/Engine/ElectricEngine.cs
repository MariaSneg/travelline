namespace CarFactory.Models.Engine;
public class ElectricEngine : IEngine
{
    public string Name
    {
        get => "Electric Engine";
    }
    public int MaxSpeed
    {
        get => 170;
    }
}
