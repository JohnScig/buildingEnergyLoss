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

        public ViewModel_Floor _viewModelFloor = new ViewModel_Floor();
        public ViewModel_Wall _viewModelWall = new ViewModel_Wall();
        public ViewModel_Roof _viewModelRoof = new ViewModel_Roof();
        public ViewModel_Surroundings _viewModelSurroundings = new ViewModel_Surroundings();

        public void LoadComboBoxes()
        {
            List<ComboBox> comboBoxes = new List<ComboBox>()
            {
                cBox_FloorMaterial01, cBox_FloorMaterial02, cBox_FloorMaterial03, cBox_FloorMaterial04,
                cBox_WallMaterial01, cBox_WallMaterial02, cBox_WallMaterial03, cBox_WallMaterial04,
                cBox_RoofMaterial01, cBox_RoofMaterial02, cBox_RoofMaterial03, cBox_RoofMaterial04
            };
            IMaterialRepository rep = new MaterialRepository();
            foreach (ComboBox cBox in comboBoxes)
            {
                cBox.DataSource = rep.GetMaterials();
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
            _viewModelFloor.FloorMaterial01 = cBox_FloorMaterial01.SelectedValue.ToString();
            Debug.WriteLine(cBox_FloorMaterial01.SelectedValue.ToString());
            _viewModelFloor.FloorMaterial02 = cBox_FloorMaterial02.SelectedValue.ToString();
            _viewModelFloor.FloorMaterial03 = cBox_FloorMaterial03.SelectedValue.ToString();
            _viewModelFloor.FloorMaterial04 = cBox_FloorMaterial04.SelectedValue.ToString();

            _viewModelFloor.FloorMaterial01Girth = double.Parse(tbox_FloorGirth01.Text);
            _viewModelFloor.FloorMaterial02Girth = double.Parse(tbox_FloorGirth02.Text);
            _viewModelFloor.FloorMaterial03Girth = double.Parse(tbox_FloorGirth03.Text);
            _viewModelFloor.FloorMaterial04Girth = double.Parse(tbox_FloorGirth04.Text);

            _viewModelFloor.Area = double.Parse(tBox_FloorArea.Text);
        }

        public void SendWallData()
        {
            _viewModelWall.WallMaterial01 = cBox_WallMaterial01.SelectedValue.ToString();
            _viewModelWall.WallMaterial02 = cBox_WallMaterial02.SelectedValue.ToString();
            _viewModelWall.WallMaterial03 = cBox_WallMaterial03.SelectedValue.ToString();
            _viewModelWall.WallMaterial04 = cBox_WallMaterial04.SelectedValue.ToString();

            _viewModelWall.WallMaterial01Girth = double.Parse(tbox_WallGirth01.Text);
            _viewModelWall.WallMaterial02Girth = double.Parse(tbox_WallGirth02.Text);
            _viewModelWall.WallMaterial03Girth = double.Parse(tbox_WallGirth03.Text);
            _viewModelWall.WallMaterial04Girth = double.Parse(tbox_WallGirth04.Text);

            _viewModelWall.Area = double.Parse(tBox_WallArea.Text);
        }

        public void SendRoofData()
        {
            _viewModelRoof.RoofMaterial01 = cBox_RoofMaterial01.SelectedValue.ToString();
            _viewModelRoof.RoofMaterial02 = cBox_RoofMaterial02.SelectedValue.ToString();
            _viewModelRoof.RoofMaterial03 = cBox_RoofMaterial03.SelectedValue.ToString();
            _viewModelRoof.RoofMaterial04 = cBox_RoofMaterial04.SelectedValue.ToString();

            _viewModelRoof.RoofMaterial01Girth = double.Parse(tbox_RoofGirth01.Text);
            _viewModelRoof.RoofMaterial02Girth = double.Parse(tbox_RoofGirth02.Text);
            _viewModelRoof.RoofMaterial03Girth = double.Parse(tbox_RoofGirth03.Text);
            _viewModelRoof.RoofMaterial04Girth = double.Parse(tbox_RoofGirth04.Text);

            _viewModelRoof.Area = double.Parse(tBox_RoofArea.Text);
        }

        private void btn_Calculate_Click(object sender, EventArgs e)
        {
            SendFloorData();
            SendWallData();
            SendRoofData();
            SendSurroundingsData();
            _viewModelFloor.BuildFloor();
            _viewModelWall.BuildWall();
            _viewModelRoof.BuildRoof();
            double result = (_viewModelFloor.AreaHeatLoss + _viewModelWall.AreaHeatLoss + _viewModelRoof.AreaHeatLoss)*_viewModelSurroundings.AllModifiers();
            tBox_Result.Text = result.ToString();
        }
    }
}
