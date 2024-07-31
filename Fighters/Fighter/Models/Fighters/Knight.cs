using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters;
public class Knight : Fighter
{
    public Knight( string name, IRace race, IArmor armor, IWeapon weapon )
        : base( name, race, armor, weapon )
    {
        ClassHealth = 67;
        ClassDamage = 14;
    }
}
