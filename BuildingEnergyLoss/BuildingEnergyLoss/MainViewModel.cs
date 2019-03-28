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

        public string GetFinalResult(ViewModelGeneral viewModelFloor, ViewModelGeneral viewModelRoof, ViewModelGeneral viewModelWalls,
            ViewModelGeneral viewModelWindows, ViewModelSurroundings viewModelSurroundings, ViewModelHeatGain viewModelHeatGain)
        {

            double floorHeatLoss = viewModelFloor.CalculateOverallHeatLoss(MaterialRepository) * viewModelSurroundings.GroundModifiers();
            double roofHeatLoss = viewModelRoof.CalculateOverallHeatLoss(MaterialRepository) * viewModelSurroundings.AllModifiers();
            double wallHeatLoss = viewModelWalls.CalculateOverallHeatLoss(MaterialRepository) * viewModelSurroundings.AllModifiers();
            double windowHeatLoss = viewModelWindows.CalculateOverallHeatLoss(MaterialRepository) * viewModelSurroundings.AllModifiers();

            return (floorHeatLoss + roofHeatLoss + wallHeatLoss + windowHeatLoss - viewModelHeatGain.CalculateHeatGain()).ToString();
        }
    }
}
