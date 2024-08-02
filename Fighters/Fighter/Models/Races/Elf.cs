namespace Fighters.Models.Races;
internal class Elf : IRace
{
    public string Name
    {
        get => "Elf";
    }
    public int Health
    {
        get => 50;
    }
    public int Damage
    {
        get => 20;
    }
    public int Armor
    {
        get => 10;
    }
}

