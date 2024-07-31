using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters;
public class Barbarian : Fighter
{
    public Barbarian(string name, IRace race, IArmor armor, IWeapon weapon) 
        :base(name, race, armor, weapon)
    {
        ClassHealth = 56;
        ClassDamage = 13;
    }
}
