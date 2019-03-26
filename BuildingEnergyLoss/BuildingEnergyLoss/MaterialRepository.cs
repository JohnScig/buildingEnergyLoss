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
        }
    }
}
