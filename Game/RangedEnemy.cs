using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class RangedEnemy : Enemy    
    {
        public RangedEnemy()
        {
            AttRange = 10;
            HP = 40;
            AttDmg = 1;
        }
    }
}
