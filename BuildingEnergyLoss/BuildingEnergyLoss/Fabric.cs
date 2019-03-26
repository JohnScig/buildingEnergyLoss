using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingEnergyLoss
{
    public class Fabric : IFabric
    {
        public string Name { get; set; }
        public double TotalArea { get; set; }
        public List<IMaterial> Materials { get; set; } 



        public Fabric(string name, List<IMaterial> materials, double totalArea)
        {
            this.Name = name;
            this.Materials = materials;
            this.TotalArea = totalArea;
        }

        public double UnitFabricHeatLoss()
        {
            double resistanceSum = 0;
            foreach (Material material in Materials)
            {
                resistanceSum += material.UnitHeatResistance();
            }
            return (1/resistanceSum);
        }

        public double AreaFabricHeatLoss()
        {
            double resistanceSum = 0;
            foreach (Material material in Materials)
            {
                resistanceSum += material.UnitHeatResistance();
            }
            return ((1/resistanceSum)*TotalArea);
        }
    }
}
