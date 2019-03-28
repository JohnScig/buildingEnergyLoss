using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingEnergyLoss
{
    class ViewModelHeatGain
    {
        public int NumOfAppliances { get; set; }
        public int NumOfPeople { get; set; }

        public int CalculateHeatGain()
        {
            return NumOfAppliances * 100 + NumOfPeople * 75;
        }

    }
}
