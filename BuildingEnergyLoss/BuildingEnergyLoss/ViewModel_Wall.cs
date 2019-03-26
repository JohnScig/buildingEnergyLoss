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


        public Material WallMat01 { get; set; }
        public Material WallMat02 { get; set; }
        public Material WallMat03 { get; set; }
        public Material WallMat04 { get; set; }
        public List<IMaterial> WallMats;

        public Fabric Walls { get; set; }
        public double AreaHeatLoss { get; set; }
        public double Area { get; set; }


        public void BuildWall()
        {
            WallMats = new List<IMaterial>();
            if (!string.IsNullOrWhiteSpace(WallMaterial01))
            {
                WallMat01 = new Material(WallMaterial01, WallMaterial01Girth);
                WallMats.Add(WallMat01);
            }

            if (!string.IsNullOrWhiteSpace(WallMaterial02))
            {
                WallMat02 = new Material(WallMaterial02, WallMaterial02Girth);
                WallMats.Add(WallMat02);
            }

            if (!string.IsNullOrWhiteSpace(WallMaterial03))
            {
                WallMat03 = new Material(WallMaterial03, WallMaterial03Girth);
                WallMats.Add(WallMat03);
            }

            if (!string.IsNullOrWhiteSpace(WallMaterial04))
            {
                WallMat04 = new Material(WallMaterial04, WallMaterial04Girth);
                WallMats.Add(WallMat04);
            }

            Walls = new Fabric("Wall", WallMats, Area);
            //MessageBox.Show(Walls.UnitFabricHeatLoss().ToString());
            //MessageBox.Show(Walls.AreaFabricHeatLoss().ToString());
            AreaHeatLoss = Walls.AreaFabricHeatLoss();
        }
    }
}
