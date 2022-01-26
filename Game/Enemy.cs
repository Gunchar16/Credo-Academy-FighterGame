using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Enemy : Fighter
    {

        public Enemy()
        {
            AttDmg = 10;
            HP = 80;
            AttSpeed = 1;
        }
        public bool CanAttack(Champion hero)
        {
            return CanDamage(hero) && hero.IsAlive && this.IsAlive;
        }
        public bool CanDamage(Champion hero)
        {
            return Pos - AttRange <= hero.Pos;
        }
    }
}