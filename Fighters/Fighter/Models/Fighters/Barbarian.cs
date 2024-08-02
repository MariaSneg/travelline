using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters;
public class Barbarian : Fighter
{
    public Barbarian( string name, IRace race, IArmor armor, IWeapon weapon )
        : base( name, race, armor, weapon )
    {
        ClassHealth = 86;
        ClassDamage = 13;

        CurrentHealth = GetMaxHealth();
    }
}
