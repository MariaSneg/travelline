namespace Fighters.Models.Races;
internal class Gnome : IRace
{
    public string Name
    {
        get => "Gnome";
    }
    public int Health
    {
        get => 35;
    }
    public int Damage
    {
        get => 15;
    }
    public int Armor
    {
        get => 10;
    }
}
