using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters;
public interface IFighter
{
    public string Name { get; }
    public IRace Race { get; }
    public IArmor Armor { get; }
    public IWeapon Weapon { get; }
    public int CurrentHealth { get; }
    public int ClassHealth { get; }
    public int ClassDamage { get; }

    public void SetArmor( IArmor armor );
    public void SetWeapon( IWeapon weapon );
    public int GetCurrentHealth();
    public int GetMaxHealth();

    public int CalculateDamage();
    public int CalculateArmor();

    public void TakeDamage( int damage );
    public bool IsAlive();
    public void Print();
}
