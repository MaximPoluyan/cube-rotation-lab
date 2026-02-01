using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary1
{
    public partial class MyControlElement: UserControl
    {

        [Browsable(true)]
        [Category("Cube")]
        [Description("Показывать невидимые ребра пунктиром")]
        [DefaultValue(true)]
        public bool ShowHiddenEdges { get; set; } = true;

        Bitmap BM;
        Graphics Gr;
        Pen P1 = new Pen(Color.Black, 2);
        Pen P2 = new Pen(Color.Gray, 1);

        bool LogCube = false;
        double[,] X0 = { { 1, 1, 1 }, { -1, 1, 1 }, { -1, -1, 1 }, { 1, -1, 1 }, { 1, 1, -1 }, { -1, 1, -1 }, { -1, -1, -1 }, { 1, -1, -1 } };
        double[,] NV0 = { { 0, 0, 1 }, { 0, 1, 0 }, { 1, 0, 0 }, { 0, 0, -1 }, { 0, -1, 0 }, { -1, 0, 0 } };
        double[,] C = new double[3, 3];
        double[,] X = new double[8, 2];
        int[] Xscr = new int[8];
        int[] Yscr = new int[8];
        double[] NVz = new double[6];
        bool[] LineType = new bool[12];
        public double Kbase = 100;
        double K = 100;
        double Psi = 0, Teta = 0, Fi = 0;
        double Wpsi = 10, Wteta = 10, Wfi = 10;

        public MyControlElement()
        {
            InitializeComponent();
            this.Disposed += MyControlElement_Disposed;
        }
        private void MyControlElement_Disposed(object sender, EventArgs e)
        {
            
            timer1?.Stop();

            Gr?.Dispose();
            Gr = null;

            BM?.Dispose();
            BM = null;

            P1?.Dispose();
            P2?.Dispose();
        }

        private void MyControlElement_Load(object sender, EventArgs e)
        {
            pictureBox1.Left = 0;
            pictureBox1.Top = 0;
            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height - 50;

            trackBar1.Left = 0;
            trackBar1.Top = pictureBox1.Height + 5;
            trackBar1.Width = this.Width - 70;

            button1.Left = trackBar1.Width + 5;
            button1.Top = trackBar1.Top;
            button1.Width = 60;
            button1.Height = 40;
            EnsureBuffer();
            ReDrawPicture();

        }

        private void MyControlElement_Resize(object sender, EventArgs e)
        {
            pictureBox1.Left = 0;
            pictureBox1.Top = 0;
            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height - 50;

            trackBar1.Left = 0;
            trackBar1.Top = pictureBox1.Height + 5;
            trackBar1.Width = this.Width - 70;

            button1.Left = trackBar1.Width + 5;
            button1.Top = trackBar1.Top;
            button1.Width = 60;
            button1.Height = 40;
            EnsureBuffer();
            ReDrawPicture();

        }

        public void InitGraph()
        {
            // BM = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //Gr = Graphics.FromImage(BM);
            //pictureBox1.Image = BM;
            //P2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            EnsureBuffer();
            ReDrawPicture();

        }
        private void EnsureBuffer()
        {
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;

            if (w <= 0 || h <= 0) return;

            // если буфер уже нужного размера — ничего не делаем
            if (BM != null && BM.Width == w && BM.Height == h && Gr != null) return;

            // освобождаем старое
            Gr?.Dispose();
            BM?.Dispose();

            BM = new Bitmap(w, h);
            Gr = Graphics.FromImage(BM);
            pictureBox1.Image = BM;

           
            P2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
        }


        public void AddCube(double _Psi, double _Teta, double _Fi)
        {
            K = Kbase * Math.Pow(1.1, trackBar1.Value);
            Psi = _Psi * Math.PI / 180;
            Teta = _Teta * Math.PI / 180;
            Fi = _Fi * Math.PI / 180;
            LogCube = true;

            ReDrawPicture();
        }

        public void DeleteCube()
        {
            LogCube = false;
            timer1.Enabled = false;
            ReDrawPicture();

        }

        public void StartCube(double _Wpsi, double _Wteta, double _Wfi)
        {
            if (!LogCube) return;   //Принудительный возврат из метода, если куба не существует

            Wpsi = _Wpsi * Math.PI / 180;
            Wteta = _Wteta * Math.PI / 180;
            Wfi = _Wfi * Math.PI / 180;
            timer1.Enabled = true;

        }

        public void StopCube()
        {
            timer1.Enabled = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            K = Kbase * Math.Pow(1.1, trackBar1.Value);
            ReDrawPicture();
        }

        public void SetBackColor(Color cl)
        {
            pictureBox1.BackColor = cl;
            ReDrawPicture();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            trackBar1.Value = 0;
            K = Kbase;
            ReDrawPicture();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Psi += Wpsi * 0.01;
            Teta += Wteta * 0.01;
            Fi += Wfi * 0.01;

            ReDrawPicture();
        }
            

        private void ReDrawPicture()
        {
            EnsureBuffer();
            if (Gr == null || BM == null) return;
            Gr.Clear(pictureBox1.BackColor);

            if (LogCube)
            {
                //  Вычисление матрицы поворота (матрицы косинусов):
                C[0, 0] = Math.Cos(Psi) * Math.Cos(Fi) - Math.Sin(Psi) * Math.Cos(Teta) * Math.Sin(Fi);
                C[0, 1] = Math.Cos(Psi) * Math.Sin(Fi) + Math.Sin(Psi) * Math.Cos(Teta) * Math.Cos(Fi);
                C[0, 2] = Math.Sin(Psi) * Math.Sin(Teta);
                C[1, 0] = -Math.Sin(Psi) * Math.Cos(Fi) - Math.Cos(Psi) * Math.Cos(Teta) * Math.Sin(Fi);
                C[1, 1] = -Math.Sin(Psi) * Math.Sin(Fi) + Math.Cos(Psi) * Math.Cos(Teta) * Math.Cos(Fi);
                C[1, 2] = Math.Cos(Psi) * Math.Sin(Teta);
                C[2, 0] = Math.Sin(Teta) * Math.Sin(Fi);
                C[2, 1] = -Math.Sin(Teta) * Math.Cos(Fi);
                C[2, 2] = Math.Cos(Teta);


                //  Вычисление конечных (после поворота) координат вершин куба:
                for (int k = 0; k < 8; k++)
                {
                    //  математические координаты:
                    X[k, 0] = C[0, 0] * X0[k, 0] + C[0, 1] * X0[k, 1] + C[0, 2] * X0[k, 2];
                    X[k, 1] = C[1, 0] * X0[k, 0] + C[1, 1] * X0[k, 1] + C[1, 2] * X0[k, 2];

                    //  экранные координаты:
                    Xscr[k] = (int)(BM.Width / 2 + K * X[k, 0]);
                    Yscr[k] = (int)(BM.Height / 2 - K * X[k, 1]);
                }


                //   Вычисление проекции на ось Oz нормальных векторов:
                for (int k = 0; k < 6; k++)
                {
                    NVz[k] = C[2, 0] * NV0[k, 0] + C[2, 1] * NV0[k, 1] + C[2, 2] * NV0[k, 2];
                }

                //   Определение будут ли ребра куба видимыми (сплошная линия) или невидимыми (пунктирная линия):
                for (int k = 0; k < 12; k++) LineType[k] = false;
                if (NVz[0] >= 0) { LineType[0] = true; LineType[1] = true; LineType[2] = true; LineType[3] = true; }
                if (NVz[1] >= 0) { LineType[0] = true; LineType[4] = true; LineType[8] = true; LineType[9] = true; }
                if (NVz[2] >= 0) { LineType[3] = true; LineType[7] = true; LineType[8] = true; LineType[11] = true; }
                if (NVz[3] >= 0) { LineType[4] = true; LineType[5] = true; LineType[6] = true; LineType[7] = true; }
                if (NVz[4] >= 0) { LineType[2] = true; LineType[6] = true; LineType[10] = true; LineType[11] = true; }
                if (NVz[5] >= 0) { LineType[1] = true; LineType[5] = true; LineType[9] = true; LineType[10] = true; }

                // Нарисовать куб, состоящий из 12 ребер:

                if (LineType[0])
                    Gr.DrawLine(P1, Xscr[0], Yscr[0], Xscr[1], Yscr[1]);
                else if (ShowHiddenEdges)
                    Gr.DrawLine(P2, Xscr[0], Yscr[0], Xscr[1], Yscr[1]);

                if (LineType[1])
                    Gr.DrawLine(P1, Xscr[1], Yscr[1], Xscr[2], Yscr[2]);
                else if (ShowHiddenEdges)
                    Gr.DrawLine(P2, Xscr[1], Yscr[1], Xscr[2], Yscr[2]);

                if (LineType[2])
                    Gr.DrawLine(P1, Xscr[2], Yscr[2], Xscr[3], Yscr[3]);
                else if (ShowHiddenEdges)
                    Gr.DrawLine(P2, Xscr[2], Yscr[2], Xscr[3], Yscr[3]);

                if (LineType[3])
                    Gr.DrawLine(P1, Xscr[3], Yscr[3], Xscr[0], Yscr[0]);
                else if (ShowHiddenEdges)
                    Gr.DrawLine(P2, Xscr[3], Yscr[3], Xscr[0], Yscr[0]);

                if (LineType[4])
                    Gr.DrawLine(P1, Xscr[4], Yscr[4], Xscr[5], Yscr[5]);
                else if (ShowHiddenEdges)
                    Gr.DrawLine(P2, Xscr[4], Yscr[4], Xscr[5], Yscr[5]);

                if (LineType[5])
                    Gr.DrawLine(P1, Xscr[5], Yscr[5], Xscr[6], Yscr[6]);
                else if (ShowHiddenEdges)
                    Gr.DrawLine(P2, Xscr[5], Yscr[5], Xscr[6], Yscr[6]);

                if (LineType[6])
                    Gr.DrawLine(P1, Xscr[6], Yscr[6], Xscr[7], Yscr[7]);
                else if (ShowHiddenEdges)
                    Gr.DrawLine(P2, Xscr[6], Yscr[6], Xscr[7], Yscr[7]);

                if (LineType[7])
                    Gr.DrawLine(P1, Xscr[7], Yscr[7], Xscr[4], Yscr[4]);
                else if (ShowHiddenEdges)
                    Gr.DrawLine(P2, Xscr[7], Yscr[7], Xscr[4], Yscr[4]);

                if (LineType[8])
                    Gr.DrawLine(P1, Xscr[0], Yscr[0], Xscr[4], Yscr[4]);
                else if (ShowHiddenEdges)
                    Gr.DrawLine(P2, Xscr[0], Yscr[0], Xscr[4], Yscr[4]);

                if (LineType[9])
                    Gr.DrawLine(P1, Xscr[1], Yscr[1], Xscr[5], Yscr[5]);
                else if (ShowHiddenEdges)
                    Gr.DrawLine(P2, Xscr[1], Yscr[1], Xscr[5], Yscr[5]);

                if (LineType[10])
                    Gr.DrawLine(P1, Xscr[2], Yscr[2], Xscr[6], Yscr[6]);
                else if (ShowHiddenEdges)
                    Gr.DrawLine(P2, Xscr[2], Yscr[2], Xscr[6], Yscr[6]);

                if (LineType[11])
                    Gr.DrawLine(P1, Xscr[3], Yscr[3], Xscr[7], Yscr[7]);
                else if (ShowHiddenEdges)
                    Gr.DrawLine(P2, Xscr[3], Yscr[3], Xscr[7], Yscr[7]);

            }

            pictureBox1.Refresh();
        }

    }
}
