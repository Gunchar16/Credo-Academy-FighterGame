using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Elf : Race 
    {
        public Elf()
        {
            BonusHP = -40;
            MAX_HP = 100 + BonusHP;
            BonusAttRange = 0;
            BonusAttSpeed = 1;
            BonusAttDmg = 0;
        }
    }
}
