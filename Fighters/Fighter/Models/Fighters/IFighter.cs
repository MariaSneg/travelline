using Fighters.Models.Armors;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters;
public interface IFighter
{
    public string Name { get; }
    public void SetArmor( IArmor armor );
    public void SetWeapon( IWeapon weapon );
    public int GetCurrentHealth();
    public int GetMaxHealth(); 

    public int CalculateDamage();
    public int CalculateArmor();

    public void TakeDamage( int damage );
}
