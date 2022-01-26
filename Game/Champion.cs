using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Champion : Fighter
    {
        public string Name { get; set; }
        public Race race { get; set; }

        public Champion()
        {
            HP = 100;
            AttDmg = 16;
            AttRange = 1;
            AttSpeed = 1;
            Pos = 0;
        }
        public void ChooseRace()
        {
            Console.WriteLine("Choose your race!\n\n1 - Orc\n2 - Human\n3 - Elf");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    race = new Orc();
                    break;
                case 2:
                    race = new Human();
                    break;
                case 3:
                    race = new Elf();
                    break;
                default:
                    throw new Exception("Please, enter a valid input");
            }
            var directory = Directory.GetParent(Directory.GetCurrentDirectory());
            for (; directory.ToString().Contains("bin"); directory = directory.Parent);
            string[] allLines = File.ReadAllLines(Path.Combine(directory.ToString(), @"Resources\" ,$"{race.GetType().Name}Names.txt"));
            Random rnd = new Random();
            Name = allLines[rnd.Next(allLines.Length)];

        }
        public void RaceBonus()
        {
            if (race != null)
            {
                HP += race.BonusHP;
                AttDmg += race.BonusAttDmg;
                AttSpeed += race.BonusAttSpeed;
                AttRange += race.BonusAttRange;
                return;
            }
            throw new NullReferenceException("Race uninitialized!");
        }
        public bool CanBeHealed()
        {
            return HP + 20 <= race.MAX_HP;
        }

        public bool CanAttack(Enemy enemy)
        {
            return CanDamage(enemy) && enemy.IsAlive && this.IsAlive;
        }

        public bool CanDamage(Enemy enemy)
        {
            return Pos + AttRange >= enemy.Pos;
        }
        public override string ToString()
        {
            return $"{base.ToString()}\n\nRace:\t{race.GetType().Name}\nName:\t{Name}"; 
        }

    }
}