using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_OOP
{
    public class Player
    {
        public string Name;
        public string ResultRecord;
        public int CalculatedPoints
        {
            get { return CalcPoints(ResultRecord); }
        }

        public override string ToString()
        {
            return $"{Name} {ResultRecord} - {CalculatedPoints}";
        }
        public int CalcPoints(string RR) //RR - result record
        {
            int totalPoints = 0;
            for (int i = 0; i < RR.Length; i++)
            {
                if (RR[i] == 'W')
                {
                    totalPoints += 3;
                }
                else if (RR[i] == 'D')
                {
                    totalPoints += 1;
                }
            }
            return totalPoints;
        }
    }
}
