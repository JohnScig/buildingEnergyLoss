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
            List<IMaterial> Mats = new List<IMaterial>();
            Mats.Add(rep.CreateMaterial(Material01, Material01Girth));
            Mats.Add(rep.CreateMaterial(Material02, Material02Girth));
            Mats.Add(rep.CreateMaterial(Material03, Material03Girth));
            Mats.Add(rep.CreateMaterial(Material04, Material04Girth));

            return (new Fabric(Mats, Area)).AreaFabricHeatLoss();
        }
    }
}
