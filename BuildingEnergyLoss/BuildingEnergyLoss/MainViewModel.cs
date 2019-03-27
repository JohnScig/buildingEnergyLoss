using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingEnergyLoss
{
    class MainViewModel
    {
        public MaterialRepository MaterialRepository { get; set; } = new MaterialRepository();

        public List<Material> GetMaterials()
        {
            return MaterialRepository.GetMaterials();
        }

        public string GetFinalResult(ViewModelGeneral viewModelFloor, ViewModelGeneral viewModelRoof, ViewModelGeneral viewModelWalls, ViewModel_Surroundings viewModelSurroundings)
        {

            double floorHeatLoss = viewModelFloor.CalculateOverallHeatLoss(MaterialRepository) * viewModelSurroundings.GroundModifiers();
            double roofHeatLoss = viewModelRoof.CalculateOverallHeatLoss(MaterialRepository) * viewModelSurroundings.AllModifiers();
            double wallHeatLoss = viewModelWalls.CalculateOverallHeatLoss(MaterialRepository) * viewModelSurroundings.AllModifiers();

            return floorHeatLoss + roofHeatLoss + wallHeatLoss.ToString();
        }
    }
}
