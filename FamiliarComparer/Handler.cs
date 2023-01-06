using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FamiliarComparer
{
    public class Handler
    {

        public static BindingList<Familiar> GetFams()
        {
            List<Familiar> output = new List<Familiar>();

            List<string> lines = File.ReadAllLines("data.csv").ToList();

            for (int i = 1; i < lines.Count; i++)
            {
                string[] data = lines[i].Split(',');
                int attack = Int32.Parse(data[0]);
                int critdmg = Int32.Parse(data[1]);

                output.Add(new Familiar(attack, critdmg));
            }

            output.Sort((fam1, fam2) =>
            {
                return fam2.TotalDMG.CompareTo(fam1.TotalDMG);
            });

            BindingList<Familiar> result = new BindingList<Familiar>(output);

            return result;

        }

        public static void SaveFams(BindingList<Familiar> fams)
        {
            List<string> lines = new();

            lines.Add("attack,critdmg");

            foreach (var fam in fams)
            {
                lines.Add($"{fam.Attack},{fam.CritDMG}");
            }

            File.WriteAllLines("data.csv", lines.ToArray());

        }

        

    }
}
