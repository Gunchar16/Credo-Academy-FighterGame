using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Fighter
    {
        public int HP { get; set; }
        public int AttDmg { get; set; }
        public int AttSpeed { get; set; }
        public int AttRange { get; set; }
        public int Pos { get; set; }
        public bool IsAlive { get { return HP > 0; } }
        public override string ToString()
        {
            return $"STATS:\n\nHP:\t{HP}\nAttack Damage:\t{AttDmg}\nAttack Speed:\t{AttSpeed}\nAttack Range:\t{AttRange}\n";
        }
    }
}