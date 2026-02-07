using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class MainForm : Form
    {


        private bool _cubeExists = false;
        private bool _rotationRunning = false;

        private void UpdateUiState()
        {
            
            button1.Enabled = !_rotationRunning;                 
            button2.Enabled = _cubeExists && !_rotationRunning;  
            button3.Enabled = _cubeExists && !_rotationRunning;  
            button4.Enabled = _rotationRunning;                  
            button5.Enabled = true;                              
        }


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            myControlElement1.InitGraph();
            myControlElement2.InitGraph();
            myControlElement1.ShowHiddenEdges = true;   
            myControlElement2.ShowHiddenEdges = false; 
            _cubeExists = false;
            _rotationRunning = false;
            UpdateUiState();

        }
         
        private void drawCubeButton_Click(object sender, EventArgs e)
        {
            myControlElement1.Kbase = 120;
            myControlElement1.AddCube(30, 60, 45);

            myControlElement2.Kbase = 40;
            myControlElement2.AddCube(10, 30, 75);

            _cubeExists = true;
            _rotationRunning = false;
            UpdateUiState();

        }

        private void deleteCubeButton_Click(object sender, EventArgs e)
        {
            myControlElement1.DeleteCube();
            myControlElement2.DeleteCube();
            _cubeExists = false;
            _rotationRunning = false;
            UpdateUiState();
        }

        private void startRotationButton_Click(object sender, EventArgs e)
        {
            myControlElement1.StartCube(30, 15, 60);
            myControlElement2.StartCube(20, 15, 90);
            _rotationRunning = true;
            UpdateUiState();
        }

        private void stopRotationButton_Click(object sender, EventArgs e)
        {
            myControlElement1.StopCube();
            myControlElement2.StopCube();
            _rotationRunning = false;
            UpdateUiState();
        }

        private void changeColorButton_Click(object sender, EventArgs e)
        {
            using (var dlg = new ColorDialog())
            {
                dlg.FullOpen = true;
                dlg.Color = Color.Bisque; 

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    myControlElement1.SetBackColor(dlg.Color);
                    myControlElement2.SetBackColor(dlg.Color);
                }
            }
        }
    }
}
