using gameconsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //procedurally generated dungeons
            //loot grabber
            //action game
            //not much story - have something, but ultimately just build dopamine feeder
            //combination of clicker heroes, link to the past, stardew valley mines + items/inventory, binding of isaac

            //enemy object
            //player object
            //item
            //level object

            Random random = new Random();

            //website used to create enemies/items/levels
            for (int i = 0; i < 5; i++)
            {
                var enemy = new Enemy(random);
                enemy.LogEnemy();



            }

            Console.ReadLine();
            

        }

        
    }
}
