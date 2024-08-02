namespace Fighters.Models.Races;
internal class Human : IRace
{
    public string Name
    {
        get => "Human";
    }
    public int Health
    {
        get => 40;
    }
    public int Damage
    {
        get => 10;
    }
    public int Armor
    {
        get => 5;
    }
}
