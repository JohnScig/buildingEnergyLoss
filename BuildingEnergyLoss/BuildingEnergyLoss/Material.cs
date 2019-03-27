using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingEnergyLoss
{
    public class Material : IMaterial
    {
        public string Name { get; set; }
        public double HeatConductivity { get; set; }
        public double Thickness { get; set; }

        public double UnitHeatResistance()
        {
            return Thickness / HeatConductivity;
        }
    }
}
//public Material()
//{

//}

//public Material (string name)
//{
//    Name = name;
//}

//public double PickHeatConductivity(string name)
//{
//    ////Debug.WriteLine(name);
//    //if (name.Equals("Ytong")) return 0.09;
//    //if (name.Equals("Concrete")) return 1.74;
//    //if (name.Equals("Polystyrene")) return 0.03;
//    //if (name.Equals("Plasterboard")) return 0.34;
//    //else return 1000000;


//    switch (name)
//    {
//        case ("Ytong"): return 0.09;
//        case ("Concrete"): return 1.74;
//        case ("Polystyrene"): return 0.03;
//        case ("Plasterboard"): return 0.34;
//        case ("Plaster"): return 0.25;
//        case ("Glass Wool"): return 0.039;
//        default: return 999999;
//    }
//}