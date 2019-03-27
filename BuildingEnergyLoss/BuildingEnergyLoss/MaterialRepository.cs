using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingEnergyLoss
{
    public class MaterialRepository : IMaterialRepository
    {
        private List<Material> _materials = new List<Material>()
        {
        new Material() {Name="Ytong", HeatConductivity = 0.09 },
        new Material() {Name="Polystyrene", HeatConductivity = 0.03 },
        new Material() {Name="Concrete", HeatConductivity = 1.74 },
        new Material() {Name="Plasterboard", HeatConductivity = 0.34 },
        new Material() {Name="Plaster", HeatConductivity = 0.25 },
        new Material() {Name="Glass Wool", HeatConductivity = 0.039 }
        };

        public List<Material> GetMaterials()
        {
            return _materials;
        }

        public Material CreateMaterial(string name, double thickness)
        {
            foreach (Material material in _materials)
            {
                if (name == material.Name)
                {
                    return new Material() { Name = material.Name, HeatConductivity = material.HeatConductivity, Thickness = thickness };
                }
            }

            return new Material();
        }
    }
}
