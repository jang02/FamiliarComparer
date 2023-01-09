using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiliarComparer
{
    public class Familiar
    {
        public int Id { get; set; }
        public int Attack { get; set; }
        public int CritDMG { get; set; }
        private double _totalDMG;
        private double _totalCrit;

        public double TotalDMG { get => Math.Round(_totalDMG); }
        public double TotalCrit { get => Math.Round(_totalCrit); }

        public string displayString { get => $"#{Id} Fam: {TotalDMG}";  }

        public Familiar(int num, int attack, int critDMG)
        {
            Id = num;
            Attack = attack;
            CritDMG = critDMG;

            _totalDMG = (attack * 1.8) + critDMG;
            _totalCrit = (attack * 0.8) + critDMG;

        }

        public void Update(int attack, int critDMG)
        {
            Attack = attack;
            CritDMG = critDMG;

            _totalDMG = (attack * 1.8) + critDMG;
            _totalCrit = (attack * 0.8) + critDMG;

        }



    }
}
