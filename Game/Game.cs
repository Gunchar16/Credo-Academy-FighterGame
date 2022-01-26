using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Game
{
    public class Game
    {
        private Enemy[] enemies = 
        {
            new MeleeEnemy(),
            new MeleeEnemy(),
            new RangedEnemy()
        };
        private Champion champion = new Champion();
        private int[] healthPos = new int[3];
        private int PathLength { get; set; } = 40;

        public Game()
        {
            Random rand = new Random();
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].Pos = rand.Next(0, PathLength);
            }
            for (int i = 0; i < healthPos.Length; i++)
            {
                healthPos[i] = rand.Next(0, PathLength);
            }

        }
        public void Gameplay()
        {
            champion.ChooseRace();
            champion.RaceBonus();
            Console.WriteLine(champion);
            Thread.Sleep(3000);
            while (true)
            {
                Console.Clear();
                if (champion.Pos == PathLength)
                {
                    Console.WriteLine("Congratulations! You have successfully passed the game!");
                    return;
                }
                Console.WriteLine($"{champion.Name} has advanced to the next step! Current Position: {++champion.Pos}\n{new String('-', 80)}");

                foreach (int oneHealthPos in healthPos)
                {
                    if (oneHealthPos == champion.Pos)
                    {
                        Console.WriteLine("Health Potion Found!");
                        if (champion.CanBeHealed())
                            Console.WriteLine($"Potion used, Current HP: {champion.HP+= 20}");
                        else
                            Console.WriteLine($"Potion cannot be used, HP is already: {champion.race.MAX_HP}");

                    }
                }
                foreach (var enemy in enemies)
                {
                    while(enemy.CanAttack(champion))
                    {
                        int damageDoneByEnemy = enemy.AttDmg * enemy.AttSpeed;
                        champion.HP -= damageDoneByEnemy;
                        if(!champion.IsAlive)
                        {
                            Console.WriteLine($"{champion.Name} has fallen onto the battlefield!\nGame Over!");
                            return;
                        }
                        Console.WriteLine($"{champion.Name} has been attacked for {enemy.AttSpeed} time(s) and has been damaged for {damageDoneByEnemy}! Current HP: {champion.HP}");
                        if (!champion.CanAttack(enemy))
                        {
                            Console.WriteLine($"{champion.Name} has advanced to the next step! Current Position: {++champion.Pos}\n{new String('-', 80)}");
                            continue;
                        }
                        int damageDoneByHero = champion.AttDmg * champion.AttSpeed;
                        enemy.HP -= damageDoneByHero;
                        if(!enemy.IsAlive)
                        {
                            Console.WriteLine("The enemy has fallen onto the battlefield!");
                            break;
                        }
                        Console.WriteLine($"The enemy has been attacked for {champion.AttSpeed} time(s) and has been damaged for {damageDoneByHero}! Current HP: {enemy.HP}");

                    }
                }
                Console.ReadKey();
            }
        }
    }
}