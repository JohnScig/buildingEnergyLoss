using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildingEnergyLoss
{
    public class ViewModel_Floor
    {
        public string FloorMaterial01 { get; set; }
        public double FloorMaterial01Girth { get; set; }
        public string FloorMaterial02 { get; set; }
        public double FloorMaterial02Girth { get; set; }
        public string FloorMaterial03 { get; set; }
        public double FloorMaterial03Girth { get; set; }
        public string FloorMaterial04 { get; set; }
        public double FloorMaterial04Girth { get; set; }


        public Material FloorMat01 { get; set; }
        public Material FloorMat02 { get; set; }
        public Material FloorMat03 { get; set; }
        public Material FloorMat04 { get; set; }
        public List<IMaterial> FloorMats;
        //public List<string> FloorMatStrings;

        public Fabric Floors { get; set; }
        public double AreaHeatLoss { get; set; }
        public double Area { get; set; }


        public void BuildFloor(MaterialRepository rep)
        {
            //MaterialRepository rep = new MaterialRepository();
            FloorMats = new List<IMaterial>();
            if (!string.IsNullOrWhiteSpace(FloorMaterial01))
            {
                FloorMat01 = rep.CreateMaterial(FloorMaterial01, FloorMaterial01Girth);
                FloorMats.Add(FloorMat01);

            }

            if (!string.IsNullOrWhiteSpace(FloorMaterial02))
            {
                FloorMat02 = rep.CreateMaterial(FloorMaterial02, FloorMaterial02Girth);
                FloorMats.Add(FloorMat02);
            }

            if (!string.IsNullOrWhiteSpace(FloorMaterial03))
            {
                FloorMat03 = rep.CreateMaterial(FloorMaterial03, FloorMaterial03Girth);
                FloorMats.Add(FloorMat03);
            }

            if (!string.IsNullOrWhiteSpace(FloorMaterial04))
            {
                FloorMat04 = rep.CreateMaterial(FloorMaterial04, FloorMaterial04Girth);
                FloorMats.Add(FloorMat04);
            }

            Floors = new Fabric("Floor", FloorMats, Area);
            //MessageBox.Show(Floors.UnitFabricHeatLoss().ToString());
            //MessageBox.Show(Floors.AreaFabricHeatLoss().ToString());
            AreaHeatLoss = Floors.AreaFabricHeatLoss();
        }
    }
}
