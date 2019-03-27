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
        public double Area { get; set; }


        public double BuildFloor(MaterialRepository rep)
        {
            List<IMaterial> _floorMats = new List<IMaterial>();
            _floorMats.Add(rep.CreateMaterial(FloorMaterial01, FloorMaterial01Girth));
            _floorMats.Add(rep.CreateMaterial(FloorMaterial02, FloorMaterial02Girth));
            _floorMats.Add(rep.CreateMaterial(FloorMaterial03, FloorMaterial03Girth));
            _floorMats.Add(rep.CreateMaterial(FloorMaterial04, FloorMaterial04Girth));

            return (new Fabric("Floor", _floorMats, Area)).AreaFabricHeatLoss();
        }
    }
}
