using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingEnergyLoss
{
    class MaterialRepository : IMaterialRepository
    {
        public List<Material> GetMaterials()
        {
            var ret = new List<Material>()
            { new Material("Ytong"),
            new Material("Polystyrene"),
            new Material ("Concrete"),
            new Material ("Glass Wool"),
            new Material ("Plasterboard"),
            new Material ("Plaster")};
            return ret;

            //cBox.Items.Add("Ytong");
            //cBox.Items.Add("Concrete");
            //cBox.Items.Add("Polystyrene");
            //cBox.Items.Add("Glass Wool");
            //cBox.Items.Add("Plasterboard");
            //cBox.Items.Add("Plaster");
            //cBox.Items.Add("No Material");
        }

    }
}
