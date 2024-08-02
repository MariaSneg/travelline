using CarFactory.Models.Car;

namespace CarFactory;

public class CarManager
{
    private List<ICar> _cars = new();
    private CarCreator _carCreator = new CarCreator();

    public void CarFactory()
    {
        string command = "add";
        while ( command != "exit" )
        {
            PrintMenu();
            try
            {
                command = Console.ReadLine();
                switch ( command )
                {
                    case "add":
                        AddNewCar();
                        break;
                    case "print":
                        PrintCars();
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

    private void PrintCars()
    {
        for ( int i = 0; i < _cars.Count; i++ )
        {
            Console.WriteLine( $"{i}:" );
            _cars[ i ].PrintConfiguration();
        }
    }

    private void AddNewCar()
    {
        _cars.Add( _carCreator.CreateCar() );
    }

    private void PrintMenu()
    {
        Console.WriteLine( "Меню" );
        Console.WriteLine( "add - добавить машину" );
        Console.WriteLine( "print - вывести данные о всех машинах" );
        Console.WriteLine( "exit" );
    }
}
