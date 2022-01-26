using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Race
    {
        public int MAX_HP { get; protected set; }
        public int BonusHP { get; protected set; }
        public int BonusAttDmg { get; protected set; }
        public int BonusAttSpeed { get; protected set; }
        public int BonusAttRange { get; protected set; }
    }
}
