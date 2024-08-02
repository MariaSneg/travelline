namespace CarFactory.Models.Transmission;

public class RobotizedTransmission : ITransmission
{
    public string Name
    {
        get => "Robotized Transmission";
    }
    public int NumberOfGears
    {
        get => 4;
    }
}
