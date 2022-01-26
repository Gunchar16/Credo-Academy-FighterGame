using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Human : Race
    {
        public Human()
        {
            BonusHP = 0;
            MAX_HP = 100 + BonusHP;
            BonusAttRange = 0;
            BonusAttSpeed = 0;
            BonusAttDmg = 0;
        }
    }
}
