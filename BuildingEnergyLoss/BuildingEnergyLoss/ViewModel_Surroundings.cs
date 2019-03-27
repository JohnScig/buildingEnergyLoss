using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingEnergyLoss
{
    public class ViewModel_Surroundings
    {
        public int OutsideTemp { get; set; }
        public int InsideTemp { get; set; }

        public double WindModifier { get; set; }
        public double CoverageModifier { get; set; }

        public double GroundModifiers()
        {
            return Math.Abs(InsideTemp - 3);
        }

        public double AllModifiers()
        {
            return (Math.Abs(InsideTemp - OutsideTemp)) * WindModifier * CoverageModifier;
        }
    }
}
