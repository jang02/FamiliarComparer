using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiliarComparer
{
    public class Familiar
    {
        public int Attack { get; set; }
        public int CritDMG { get; set; }
        public double TotalDMG { get; set; }
        public double TotalCrit { get; set; }
        public string displayString { get => $"Fam: {TotalDMG}";  }

        public Familiar(int attack, int critDMG)
        {
            Attack = attack;
            CritDMG = critDMG;

            TotalDMG = (attack * 1.8) + critDMG;
            TotalCrit = (attack * 0.8) + critDMG;

        }

        public void Update(int attack, int critDMG)
        {
            Attack = attack;
            CritDMG = critDMG;

            TotalDMG = (attack * 1.8) + critDMG;
            TotalCrit = (attack * 0.8) + critDMG;

        }



    }
}
