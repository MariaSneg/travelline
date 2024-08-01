namespace Fighters.Models.Races;
internal class Goblin : IRace
{
    public string Name
    {
        get => "Goblin";
    }
    public int Health
    {
        get => 40;
    }
    public int Damage
    {
        get => 16;
    }
    public int Armor
    {
        get => 12;
    }
}
