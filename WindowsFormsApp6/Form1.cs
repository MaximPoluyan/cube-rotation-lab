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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myControlElement1.InitGraph();
            myControlElement2.InitGraph();
            myControlElement1.ShowHiddenEdges = true;   // большое: пунктир показываем
            myControlElement2.ShowHiddenEdges = false;  // малое: только видимые

        }

        private void button1_Click(object sender, EventArgs e)
        {
            myControlElement1.Kbase = 120;
            myControlElement1.AddCube(30, 60, 45);

            myControlElement2.Kbase = 40;
            myControlElement2.AddCube(10, 30, 75);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            myControlElement1.DeleteCube();
            myControlElement2.DeleteCube();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myControlElement1.StartCube(30, 15, 60);
            myControlElement2.StartCube(20, 15, 90);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            myControlElement1.StopCube();
            myControlElement2.StopCube();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var dlg = new ColorDialog())
            {
                dlg.FullOpen = true;
                dlg.Color = Color.Bisque; // или возьми текущий цвет, если добавим свойство

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    myControlElement1.SetBackColor(dlg.Color);
                    myControlElement2.SetBackColor(dlg.Color);
                }
            }
        }
    }
}
