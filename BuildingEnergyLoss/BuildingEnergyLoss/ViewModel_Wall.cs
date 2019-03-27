using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildingEnergyLoss
{
    public class ViewModel_Wall
    {
        public string WallMaterial01 { get; set; }
        public double WallMaterial01Girth { get; set; }
        public string WallMaterial02 { get; set; }
        public double WallMaterial02Girth { get; set; }
        public string WallMaterial03 { get; set; }
        public double WallMaterial03Girth { get; set; }
        public string WallMaterial04 { get; set; }
        public double WallMaterial04Girth { get; set; }
        public string WindowsMaterial01 { get; set; }
        public double WindowsMaterial01Girth { get; set; }

        public double Area { get; set; }


        public double BuildWall(MaterialRepository rep)
        {
            List <IMaterial> WallMats = new List<IMaterial>();
            WallMats.Add(rep.CreateMaterial(WallMaterial01, WallMaterial01Girth));
            WallMats.Add(rep.CreateMaterial(WallMaterial02, WallMaterial02Girth));
            WallMats.Add(rep.CreateMaterial(WallMaterial03, WallMaterial03Girth));
            WallMats.Add(rep.CreateMaterial(WallMaterial04, WallMaterial04Girth));

            return (new Fabric("Wall", WallMats, Area)).AreaFabricHeatLoss();
        }
    }
}
