using Fighters.Models.Fighters;

namespace Fighters
{
    public class GameManager
    {
        private List<IFighter> _fighters = new();
        private BattleManager _battleManager = new BattleManager();
        private FighterCreator _fighterCreator = new FighterCreator();

        public void Game()
        {
            PrintMenu();
            string command = "addFighter";
            while ( command != "exit" )
            {
                try
                {
                    command = Console.ReadLine();
                    switch ( command )
                    {
                        case "addFighter":
                            AddNewFighter();
                            break;
                        case "battle":
                            Battle();
                            break;
                        case "print":
                            PrintFighters();
                            break;
                        case "exit":
                            break;
                        default:
                            Console.WriteLine( "Unknown command" );
                            break;
                    }
                }
                catch ( Exception e )
                {
                    Console.WriteLine( e.Message );
                }
            }
        }

        private void PrintFighters()
        {
            for ( int i = 0; i < _fighters.Count; i++ )
            {
                Console.WriteLine( $"{i}:" );
                _fighters[ i ].Print();
            }
        }

        private void Battle()
        {
            if ( _fighters.Count < 2 )
            {
                Console.WriteLine( "Для боя нужны два бойца" );
                return;
            }
            int firstIndex = -1;
            int secondIndex = -1;

            Console.WriteLine( "Введите номер первого бойца:" );
            if ( !int.TryParse( Console.ReadLine(), out firstIndex ) || firstIndex < 0 || firstIndex >= _fighters.Count )
            {
                throw new ArgumentException( "Неверный номер бойца" );
            }

            Console.WriteLine( "Введите номер второго бойца:" );
            if ( !int.TryParse( Console.ReadLine(), out secondIndex ) || secondIndex < 0 || secondIndex >= _fighters.Count )
            {
                throw new ArgumentException( "Неверный номер бойца" );
            }

            IFighter winner = _battleManager.Play( _fighters[ firstIndex ], _fighters[ secondIndex ] );
            Console.WriteLine( $"Победил: {winner.Name}" );
        }

        private void AddNewFighter()
        {
            _fighters.Add( _fighterCreator.CreateNewFighter() );
            Console.WriteLine( "Боец добавлен" );
        }

        public void PrintMenu()
        {
            Console.WriteLine( "Меню" );
            Console.WriteLine( "add - добавить бойца" );
            Console.WriteLine( "battle - начать бой" );
            Console.WriteLine( "print - напечатать данные о всех бойцах" );
            Console.WriteLine( "exit - выход" );
        }
    }
}
