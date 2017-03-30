using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameconsole.Models
{
    
    class Enemy
    {
        public static int MAX_HEALTH = 9999;
        public static int MAX_ATTACK = 100;
        public static int MAX_SPEED = 4;
        public static int MAX_DEFENSE = 10;

        public string Name;
        public string Type; //todo change this to a class or enum
        public double Health;
        public double AttackPower;
        public double Speed;
        public double Defense;
               

        public Enemy(Random randomSeed) {
            Name = "sam";
            Type = "test dummy";
            Health = NewRandom(MAX_HEALTH, randomSeed);
            AttackPower = NewRandom(MAX_ATTACK, randomSeed);
            Speed = NewRandom(MAX_SPEED, randomSeed);
            Defense = NewRandom(MAX_DEFENSE, randomSeed);
        }

        /// <summary>
        /// Returns a new random double
        /// </summary>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public double NewRandom(int maxValue, Random randomSeed)
        {            
            //Random random = new Random();
            return randomSeed.NextDouble() * maxValue;
        }
        
        /// <summary>
        /// Logs the stats of the current Enemy out to the console
        /// </summary>
        public void LogEnemy()
        {
            Console.WriteLine("name: " + Name);
            Console.WriteLine("type: " + Type);
            Console.WriteLine("health: " + Health);
            Console.WriteLine("attack: " + AttackPower);
            Console.WriteLine("defense: " + Defense);
            Console.WriteLine("speed: " + Speed);
        }
    }
}
