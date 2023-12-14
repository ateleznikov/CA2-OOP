using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_OOP
{
    public class Team : IComparable<Team>
    {
        public string Name;
        public List<Player> Players;
        public int TotalPoints
        {
            get { return CalcPoints(Players); }
        }

        public override string ToString()
        {
            return $"{Name} - {TotalPoints}";
        }
        public int CalcPoints(List<Player> players)
        {
            int totalPoints = 0;
            foreach (Player p in players)
            {
                totalPoints += p.CalculatedPoints;
            }
            return totalPoints;
        }
        public int CompareTo(Team other)
        {
            if (other == null) return 1;
            return other.TotalPoints.CompareTo(this.TotalPoints);
        }
    }
}
