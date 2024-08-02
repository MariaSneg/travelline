using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;
using Fighters.Models.Fighters;
using System.Collections.Generic;

namespace Fighters
{
    public class FighterCreator
    {
        public IFighter CreateNewFighter()
        {
            Console.WriteLine( "Введите имя бойца:" );
            string name = ReadNonEmptyInput();
            Console.WriteLine( "Введите класс бойца: (Knight, Barbarian, Magician, Assassin)" );
            string classFighter = ReadNonEmptyInput();
            switch ( classFighter )
            {
                case "Knight":
                    return CreateKnight( name );
                case "Barbarian":
                    return CreateBarbarian( name );
                case "Magician":
                    return CreateMagician( name );
                case "Assassin":
                    return CreateAssassin( name );
                default:
                    throw new ArgumentException( "Такого класса нет" );
            }
        }

        private IFighter CreateKnight( string name )
        {
            IRace race = CreateRace();
            IArmor armor = CreateArmor();
            IWeapon weapon = CreateWeapon();
            return new Knight( name, race, armor, weapon );
        }

        private IFighter CreateBarbarian( string name )
        {
            IRace race = CreateRace();
            IArmor armor = CreateArmor();
            IWeapon weapon = CreateWeapon();
            return new Barbarian( name, race, armor, weapon );
        }

        private IFighter CreateMagician( string name )
        {
            IRace race = CreateRace();
            IArmor armor = CreateArmor();
            IWeapon weapon = CreateWeapon();
            return new Magician( name, race, armor, weapon );
        }

        private IFighter CreateAssassin( string name )
        {
            IRace race = CreateRace();
            IArmor armor = CreateArmor();
            IWeapon weapon = CreateWeapon();
            return new Assassin( name, race, armor, weapon );
        }

        private IRace CreateRace()
        {
            Console.WriteLine( "Введите расу бойца: (Human, Elf, Gnome, Goblin)" );
            string race = ReadNonEmptyInput();
            switch ( race )
            {
                case "Human":
                    return new Human();
                case "Elf":
                    return new Elf();
                case "Gnome":
                    return new Gnome();
                case "Goblin":
                    return new Goblin();
                default:
                    throw new ArgumentException( "Такой расы нет" );
            }
        }

        private IArmor CreateArmor()
        {
            Console.WriteLine( "Введите тип брони бойца: (Leather, Chain, Iron, NoArmor)" );
            string armor = ReadNonEmptyInput();
            switch ( armor )
            {
                case "Leather":
                    return new LeatherArmor();
                case "Chain":
                    return new ChainArmor();
                case "Iron":
                    return new IronArmor();
                case "NoArmor":
                    return new NoArmor();
                default:
                    throw new ArgumentException( "Такой брони нет" );
            }
        }

        private IWeapon CreateWeapon()
        {
            Console.WriteLine( "Введите вид оружия бойца: (Fists, Sword, Knife, Bow)" );
            string weapon = ReadNonEmptyInput();
            switch ( weapon )
            {
                case "Fists":
                    return new Fists();
                case "Sword":
                    return new Sword();
                case "Knife":
                    return new Knife();
                case "Bow":
                    return new Bow();
                default:
                    throw new ArgumentException( "Такого оружия нет" );
            }
        }

        private string ReadNonEmptyInput()
        {
            string input;
            do
            {
                input = Console.ReadLine();
                if ( string.IsNullOrWhiteSpace( input ) )
                {
                    Console.WriteLine( "Ввод не может быть пустым" );
                }
            } while ( string.IsNullOrWhiteSpace( input ) );

            return input;
        }
    }
}
