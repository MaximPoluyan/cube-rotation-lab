namespace WindowsFormsApp6
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.myControlElement2 = new WindowsFormsControlLibrary1.MyControlElement();
            this.myControlElement1 = new WindowsFormsControlLibrary1.MyControlElement();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 721);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 94);
            this.button1.TabIndex = 2;
            this.button1.Text = "Draw cube";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.drawCubeButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(276, 721);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 94);
            this.button2.TabIndex = 3;
            this.button2.Text = "Delete cube";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.deleteCubeButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(504, 719);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(165, 95);
            this.button3.TabIndex = 4;
            this.button3.Text = "Start rotation";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.startRotationButton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(732, 716);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(184, 98);
            this.button4.TabIndex = 5;
            this.button4.Text = "Stop rotation";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.stopRotationButton_Click);
            // 
            // myControlElement2
            // 
            this.myControlElement2.Location = new System.Drawing.Point(730, 211);
            this.myControlElement2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.myControlElement2.Name = "myControlElement2";
            this.myControlElement2.Size = new System.Drawing.Size(438, 368);
            this.myControlElement2.TabIndex = 1;
            // 
            // myControlElement1
            // 
            this.myControlElement1.Location = new System.Drawing.Point(14, 15);
            this.myControlElement1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.myControlElement1.Name = "myControlElement1";
            this.myControlElement1.Size = new System.Drawing.Size(680, 655);
            this.myControlElement1.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(969, 714);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(170, 99);
            this.button5.TabIndex = 6;
            this.button5.Text = "Change color";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.changeColorButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 849);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.myControlElement2);
            this.Controls.Add(this.myControlElement1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsFormsControlLibrary1.MyControlElement myControlElement1;
        private WindowsFormsControlLibrary1.MyControlElement myControlElement2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}


