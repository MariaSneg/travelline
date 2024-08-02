namespace CarFactory.Models.Engine;

public class RotaryEngine : IEngine
{
    public string Name
    {
        get => "Rotary Engine";
    }
    public int MaxSpeed
    {
        get => 200;
    }
}
