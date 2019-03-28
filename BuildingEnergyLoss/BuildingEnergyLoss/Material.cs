using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingEnergyLoss
{
    public class Material : IMaterial
    {
        public string Name { get; set; }
        public double HeatConductivity { get; set; }
        public double Thickness { get; set; }

        public double UnitHeatResistance()
        {
            return Thickness / HeatConductivity;
        }
    }
}