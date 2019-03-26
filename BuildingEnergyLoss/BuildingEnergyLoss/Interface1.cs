using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingEnergyLoss
{
    public interface IMaterial
    {
        double UnitHeatResistance();
    }

    public interface IMaterialRepository
    {
        List<Material> GetMaterials();
        //List<string> GetMaterials();
    }

    public interface IFabric
    {
        double AreaFabricHeatLoss();
        double UnitFabricHeatLoss();
    }

}
