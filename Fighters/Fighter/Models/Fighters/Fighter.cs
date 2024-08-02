using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters;
public class Fighter : IFighter
{
    public string Name { get; private set; }
    public IRace Race { get; private set; }
    public IArmor Armor { get; private set; }
    public IWeapon Weapon { get; private set; }

    public int CurrentHealth { get; protected set; }
    public int ClassHealth { get; protected set; }
    public int ClassDamage { get; protected set; }

    public Fighter( string name, IRace race, IArmor armor, IWeapon weapon )
    {
        Name = name;
        Race = race;
        Armor = armor;
        Weapon = weapon;
    }

    public void SetArmor( IArmor armor )
    {
        Armor = armor;
    }

    public void SetWeapon( IWeapon weapon )
    {
        Weapon = weapon;
    }

    public int GetCurrentHealth() => CurrentHealth;

    public int GetMaxHealth() => Race.Health + ClassHealth;

    public int CalculateDamage() => Weapon.Damage + Race.Damage + ClassDamage;

    public int CalculateArmor() => Armor.Armor + Race.Armor;


    public void TakeDamage( int damage )
    {
        int newHealth = CurrentHealth - damage;
        if ( newHealth < 0 )
        {
            newHealth = 0;
        }

        CurrentHealth = newHealth;
    }

    public bool IsAlive() => CurrentHealth > 0;

    public void Print()
    {
        Console.WriteLine( $"Name: {Name}" );
        Console.WriteLine( $"Race: {Race.Name}" );
        Console.WriteLine( $"Armor: {Armor.Name}" );
        Console.WriteLine( $"Weapon: {Weapon.Name}" );
        Console.WriteLine( $"Current health: {GetCurrentHealth()}" );
        Console.WriteLine( $"Max health: {GetMaxHealth()}" );
    }
}
