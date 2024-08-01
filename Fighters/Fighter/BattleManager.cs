using Fighters.Models.Fighters;

namespace Fighters
{
    public class BattleManager
    {
        public IFighter Play( IFighter fighterA, IFighter fighterB )
        {
            while ( true )
            {
                var firstFighterDamage = fighterA.CalculateDamage();
                fighterB.TakeDamage( firstFighterDamage );
                Console.WriteLine( $"{fighterB.Name} получил {firstFighterDamage} урона, остаток здоровья {fighterB.GetCurrentHealth()}" );
                if ( !fighterB.IsAlive() )
                {
                    return fighterA;
                }

                var secondFughterDamage = fighterB.CalculateDamage();
                fighterA.TakeDamage( secondFughterDamage );
                Console.WriteLine( $"{fighterA.Name} получил {firstFighterDamage} урона, остаток здоровья {fighterA.GetCurrentHealth()}" );
                if ( !fighterA.IsAlive() )
                {
                    return fighterB;
                }
            }
        }
    }
}