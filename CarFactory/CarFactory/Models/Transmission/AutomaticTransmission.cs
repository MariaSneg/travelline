namespace CarFactory.Models.Transmission;

public class AutomaticTransmission : ITransmission
{
    public string Name
    {
        get => "Automatic Transmission";
    }
    public int NumberOfGears
    {
        get => 4;
    }
}
