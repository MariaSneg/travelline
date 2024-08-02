namespace CarFactory.Models.Transmission;

public class ManualTransmission : ITransmission
{
    public string Name
    {
        get => "Manual Transmission";
    }
    public int NumberOfGears
    {
        get => 6;
    }
}
