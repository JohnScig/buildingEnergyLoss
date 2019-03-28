using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildingEnergyLoss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadComboBoxes();
        }

        private MainViewModel _mainViewModel = new MainViewModel();
        private ViewModelGeneral _viewModelFloor = new ViewModelGeneral();
        private ViewModelGeneral _viewModelWall = new ViewModelGeneral();
        private ViewModelGeneral _viewModelRoof = new ViewModelGeneral();
        private ViewModelGeneral _viewModelWindows = new ViewModelGeneral();
        private ViewModelSurroundings _viewModelSurroundings = new ViewModelSurroundings();
        private ViewModelHeatGain _viewModelHeatGain = new ViewModelHeatGain();

        public void LoadComboBoxes()
        {
            List<ComboBox> comboBoxes = new List<ComboBox>()
            {
                cBox_FloorMaterial01, cBox_FloorMaterial02, cBox_FloorMaterial03, cBox_FloorMaterial04,
                cBox_WallMaterial01, cBox_WallMaterial02, cBox_WallMaterial03, cBox_WallMaterial04, cBox_WindowMaterial01,
                cBox_RoofMaterial01, cBox_RoofMaterial02, cBox_RoofMaterial03, cBox_RoofMaterial04
            };

            foreach (ComboBox cBox in comboBoxes)
            {
                //cBox.DataSource = materialRepository.GetMaterials();
                cBox.DataSource = _mainViewModel.GetMaterials();
                cBox.BindingContext = new BindingContext();
                cBox.DisplayMember = nameof(Material.Name);
                cBox.ValueMember = nameof(Material.Name);
            }
        }

        public void SendSurroundingsData()
        {
            _viewModelSurroundings.OutsideTemp = int.Parse(tBox_OutTemp.Text);
            _viewModelSurroundings.InsideTemp = int.Parse(tBox_InTemp.Text);

            if (rBtn_WindWindy.Checked)
            {
                _viewModelSurroundings.WindModifier = 1.03;
            }
            else
            {
                _viewModelSurroundings.WindModifier = 1;
            }
            if (rBtn_CoverNone.Checked)
            {
                _viewModelSurroundings.CoverageModifier = 1.06;
            }
            else if (rBtn_CoverPartial.Checked)
            {
                _viewModelSurroundings.CoverageModifier = 1.03;
            }
            else
            {
                _viewModelSurroundings.CoverageModifier = 1;
            }
        }

        public void SendFloorData()
        {
            _viewModelFloor.Material01 = cBox_FloorMaterial01.SelectedValue.ToString();
            _viewModelFloor.Material02 = cBox_FloorMaterial02.SelectedValue.ToString();
            _viewModelFloor.Material03 = cBox_FloorMaterial03.SelectedValue.ToString();
            _viewModelFloor.Material04 = cBox_FloorMaterial04.SelectedValue.ToString();

            _viewModelFloor.Material01Girth = double.Parse(tbox_FloorGirth01.Text);
            _viewModelFloor.Material02Girth = double.Parse(tbox_FloorGirth02.Text);
            _viewModelFloor.Material03Girth = double.Parse(tbox_FloorGirth03.Text);
            _viewModelFloor.Material04Girth = double.Parse(tbox_FloorGirth04.Text);

            _viewModelFloor.Area = double.Parse(tBox_FloorArea.Text);
        }

        public void SendWindowData()
        {
            _viewModelWindows.Material01 = cBox_WindowMaterial01.SelectedValue.ToString();

            _viewModelWindows.Material01Girth = double.Parse(tBox_WindowGirth01.Text);

            _viewModelWindows.Area = double.Parse(tBox_WinArea.Text);

        }

        public void SendWallData()
        {
            _viewModelWall.Material01 = cBox_WallMaterial01.SelectedValue.ToString();
            _viewModelWall.Material02 = cBox_WallMaterial02.SelectedValue.ToString();
            _viewModelWall.Material03 = cBox_WallMaterial03.SelectedValue.ToString();
            _viewModelWall.Material04 = cBox_WallMaterial04.SelectedValue.ToString();

            _viewModelWall.Material01Girth = double.Parse(tbox_WallGirth01.Text);
            _viewModelWall.Material02Girth = double.Parse(tbox_WallGirth02.Text);
            _viewModelWall.Material03Girth = double.Parse(tbox_WallGirth03.Text);
            _viewModelWall.Material04Girth = double.Parse(tbox_WallGirth04.Text);

            _viewModelWall.Area = double.Parse(tBox_WallArea.Text);
        }

        public void SendRoofData()
        {
            _viewModelRoof.Material01 = cBox_RoofMaterial01.SelectedValue.ToString();
            _viewModelRoof.Material02 = cBox_RoofMaterial02.SelectedValue.ToString();
            _viewModelRoof.Material03 = cBox_RoofMaterial03.SelectedValue.ToString();
            _viewModelRoof.Material04 = cBox_RoofMaterial04.SelectedValue.ToString();

            _viewModelRoof.Material01Girth = double.Parse(tbox_RoofGirth01.Text);
            _viewModelRoof.Material02Girth = double.Parse(tbox_RoofGirth02.Text);
            _viewModelRoof.Material03Girth = double.Parse(tbox_RoofGirth03.Text);
            _viewModelRoof.Material04Girth = double.Parse(tbox_RoofGirth04.Text);

            _viewModelRoof.Area = double.Parse(tBox_RoofArea.Text);
        }

        public void SendHeatGainData()
        {
            _viewModelHeatGain.NumOfPeople = int.Parse(tBox_NumOfPeople.Text);
            _viewModelHeatGain.NumOfAppliances = int.Parse(tBox_NumOfAppliances.Text);
        }

        private void btn_Calculate_Click(object sender, EventArgs e)
        {
            SendFloorData();
            SendWallData();
            SendRoofData();
            SendWindowData();
            SendSurroundingsData();
            SendHeatGainData();

            tBox_Result.Text = _mainViewModel.GetFinalResult(_viewModelFloor, _viewModelRoof, _viewModelWall, _viewModelWindows, _viewModelSurroundings, _viewModelHeatGain);
        }
    }
}



