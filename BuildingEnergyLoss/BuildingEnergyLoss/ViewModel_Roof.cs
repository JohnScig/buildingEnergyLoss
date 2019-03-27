using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildingEnergyLoss
{
    public class ViewModel_Roof
    {
        public string RoofMaterial01 { get; set; }
        public double RoofMaterial01Girth { get; set; }
        public string RoofMaterial02 { get; set; }
        public double RoofMaterial02Girth { get; set; }
        public string RoofMaterial03 { get; set; }
        public double RoofMaterial03Girth { get; set; }
        public string RoofMaterial04 { get; set; }
        public double RoofMaterial04Girth { get; set; }


        public Material RoofMat01 { get; set; }
        public Material RoofMat02 { get; set; }
        public Material RoofMat03 { get; set; }
        public Material RoofMat04 { get; set; }
        public List<IMaterial> RoofMats;
        //public List<string> RoofMatStrings;

        public Fabric Roofs { get; set; }
        public double AreaHeatLoss { get; set; }
        public double Area { get; set; }

        public void BuildRoof(MaterialRepository rep)
        {
            //MaterialRepository rep = new MaterialRepository();
            RoofMats = new List<IMaterial>();
            if (!string.IsNullOrWhiteSpace(RoofMaterial01))
            {
                RoofMat01 = rep.CreateMaterial(RoofMaterial01, RoofMaterial01Girth);
                RoofMats.Add(RoofMat01);

            }

            if (!string.IsNullOrWhiteSpace(RoofMaterial02))
            {
                RoofMat02 = rep.CreateMaterial(RoofMaterial02, RoofMaterial02Girth);
                RoofMats.Add(RoofMat02);
            }

            if (!string.IsNullOrWhiteSpace(RoofMaterial03))
            {
                RoofMat03 = rep.CreateMaterial(RoofMaterial03, RoofMaterial03Girth);
                RoofMats.Add(RoofMat03);
            }

            if (!string.IsNullOrWhiteSpace(RoofMaterial04))
            {
                RoofMat04 = rep.CreateMaterial(RoofMaterial04, RoofMaterial04Girth);
                RoofMats.Add(RoofMat04);
            }

            Roofs = new Fabric("Roof", RoofMats, Area);
            //MessageBox.Show(Roofs.UnitFabricHeatLoss().ToString());
            MessageBox.Show(Roofs.AreaFabricHeatLoss().ToString());
            AreaHeatLoss = Roofs.AreaFabricHeatLoss();
        }
    }
}
