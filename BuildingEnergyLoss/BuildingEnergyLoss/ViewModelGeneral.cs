using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingEnergyLoss
{
    class ViewModelGeneral
    {
        public string Material01 { get; set; }
        public double Material01Girth { get; set; }
        public string Material02 { get; set; }
        public double Material02Girth { get; set; }
        public string Material03 { get; set; }
        public double Material03Girth { get; set; }
        public string Material04 { get; set; }
        public double Material04Girth { get; set; }

        public double Area { get; set; }


        public double CalculateOverallHeatLoss(MaterialRepository rep)
        {
            List<IMaterial> WallMats = new List<IMaterial>();
            WallMats.Add(rep.CreateMaterial(Material01, Material01Girth));
            WallMats.Add(rep.CreateMaterial(Material02, Material02Girth));
            WallMats.Add(rep.CreateMaterial(Material03, Material03Girth));
            WallMats.Add(rep.CreateMaterial(Material04, Material04Girth));

            return (new Fabric(WallMats, Area)).AreaFabricHeatLoss();
        }
    }
}
