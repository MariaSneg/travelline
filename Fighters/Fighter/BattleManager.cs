using Fighters.Models.Fighters;

namespace Fighters
{
    public class BattleManager
    {
        public IFighter Play( IFighter fighterA, IFighter fighterB )
        {
            while ( true )
            {
                var firstFighterDamage = GetRandomDamage( fighterA );
                fighterB.TakeDamage( firstFighterDamage );
                Console.WriteLine( $"{fighterB.Name} получил {firstFighterDamage} урона, остаток здоровья {fighterB.GetCurrentHealth()}" );
                if ( !fighterB.IsAlive() )
                {
                    return fighterA;
                }

                var secondFighterDamage = GetRandomDamage( fighterB );
                fighterA.TakeDamage( secondFighterDamage );
                Console.WriteLine( $"{fighterA.Name} получил {secondFighterDamage} урона, остаток здоровья {fighterA.GetCurrentHealth()}" );
                if ( !fighterA.IsAlive() )
                {
                    return fighterB;
                }
            }
        }

        private int GetRandomDamage( IFighter fighter )
        {
            Random random = new Random();
            double baseDamage = IsCriticalDamage() ? fighter.CalculateDamage() * 2 : fighter.CalculateDamage();

            double randomFactor = random.NextDouble() * 0.4 - 0.2;

            return ( int )( baseDamage * ( 1 + randomFactor ) );
        }

        private bool IsCriticalDamage()
        {
            Random random = new Random();
            return random.NextDouble() > 0.5;
        }
    }
}