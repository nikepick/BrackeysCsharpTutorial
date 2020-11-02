using System;
using System.Collections.Generic;

namespace brackeyCsharp1
{
    class Animal
    {
        public static int count = 0;
        public String name;
        public int numberOfLimbs;
        public String eats;


        public void Print()
        {
            Console.WriteLine("Name:" + name);
            Console.WriteLine("Number of Limbs:" + numberOfLimbs);
            Console.WriteLine("Eats:" + eats);
            Console.WriteLine("Total Animals:" + count);
            Console.WriteLine();
        }
    }

    class Dog : Animal
    {
        int numberOfSpots;

        public Dog(String _name, int limbs, String _eats, int _numberOfSpots)
        {
            numberOfLimbs = limbs;
            eats = _eats;
            name = _name;
            numberOfSpots = _numberOfSpots;
            count++;
        }
        public void PrintDog()
        {
            Console.WriteLine("Name:" + name);
            Console.WriteLine("Number of Limbs:" + numberOfLimbs);
            Console.WriteLine("Eats:" + eats);
            Console.WriteLine("Number of Spots:" + numberOfSpots);
            Console.WriteLine("Total Animals:" + count);
            Console.WriteLine();
        }

    }

    class Player
    {
        private int _health = 100;

        public int health
        {
            get => _health;
            set
            {
                if (value < 0)
                {
                    _health = 0;
                }
                else if (value > 100)
                {
                    _health = 100;
                }
                else
                {
                    _health = value;
                }
            }

        }
    }

    interface IItem
    {
        String name { set; get; }
        int goldValue { set; get; }

        void Equip();
        void Sell();
    }

    interface IDamagable
    {
        int durability {set;get;}
        void TakeDamage(int amount);
    }

    interface IPartOfQuest
    {
        void TurnIn();
    }
    class Sword : IItem, IDamagable, IPartOfQuest
    {
        public string name { get; set; }
        public int goldValue { get; set; }
        public int durability { get; set; }

        public Sword(string _name)
        {
            name = _name;
            goldValue = 100;
        }
        public void Equip()
        {
            System.Console.WriteLine(name + " Equipped");
        }

        public void Sell()
        {
            System.Console.WriteLine(name + " sold for " + goldValue + " orens");
        }

        public void TakeDamage(int amount)
        {
            durability -= amount;
        }

        public void TurnIn()
        {
           System.Console.WriteLine(name+ "turned in");
        }
    }

     class Axe  : IItem,IDamagable
    {
        public string name { get; set; }
        public int goldValue { get; set; }
        public int durability { get; set; }

        public Axe(string _name)
        {
            name = _name;
            goldValue = 100;
        }
        public void Equip()
        {
            System.Console.WriteLine(name + " Equipped");
        }

        public void Sell()
        {
            System.Console.WriteLine(name + " sold for " + goldValue + " orens");
        }

        public void TakeDamage(int amount)
        {
            durability -= amount;
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Dog kutta = new Dog("kutta", 4, "dog food", 7);
            kutta.PrintDog();
            System.Console.WriteLine();

            Player tom = new Player();
            tom.health = -200;
            System.Console.WriteLine(tom.health);
            System.Console.WriteLine();
            tom.health = 1000;
            System.Console.WriteLine(tom.health);
            System.Console.WriteLine();
            tom.health = 43;
            System.Console.WriteLine(tom.health);


            Sword sword = new Sword("Silver Master Sword");
            sword.Equip();
            sword.TakeDamage(20);
            sword.Sell();

            Axe axe = new Axe("Hellwinder");
            axe.Equip();
            axe.TakeDamage(23);
            axe.Sell();
            
            //Inventory

            IItem[] inventory = new IItem[2];
            inventory[0] = sword;
            inventory[1] = axe;

            //Loop through and turn in all quest items

            for (int i = 0; i < inventory.Length; i++)
            {
                IPartOfQuest questItem = inventory[i] as IPartOfQuest;
                if (questItem != null)
                {
                    questItem.TurnIn();
                }
            }
        }
    }
}


