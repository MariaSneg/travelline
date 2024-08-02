using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters;
public class Magician : Fighter
{
    public Magician( string name, IRace race, IArmor armor, IWeapon weapon )
        : base( name, race, armor, weapon )
    {
        ClassHealth = 89;
        ClassDamage = 12;

        CurrentHealth = GetMaxHealth();
    }
}
