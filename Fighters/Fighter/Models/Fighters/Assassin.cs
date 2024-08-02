using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters;
public class Assassin : Fighter
{
    public Assassin( string name, IRace race, IArmor armor, IWeapon weapon )
        : base( name, race, armor, weapon )
    {
        ClassHealth = 78;
        ClassDamage = 12;

        CurrentHealth = GetMaxHealth();
    }
}
