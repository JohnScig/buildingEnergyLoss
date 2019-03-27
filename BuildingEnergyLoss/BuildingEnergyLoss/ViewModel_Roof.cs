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

        public double Area { get; set; }

        public double BuildRoof(MaterialRepository rep)
        {
            List<IMaterial> RoofMats = new List<IMaterial>();
            RoofMats.Add(rep.CreateMaterial(RoofMaterial01, RoofMaterial01Girth));
            RoofMats.Add(rep.CreateMaterial(RoofMaterial02, RoofMaterial02Girth));
            RoofMats.Add(rep.CreateMaterial(RoofMaterial03, RoofMaterial03Girth));
            RoofMats.Add(rep.CreateMaterial(RoofMaterial04, RoofMaterial04Girth));

            return (new Fabric("Roof", RoofMats, Area)).AreaFabricHeatLoss();
        }
    }
}
