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
            this.drawCubeButton = new System.Windows.Forms.Button();
            this.deleteCubeButton = new System.Windows.Forms.Button();
            this.startRotationButton = new System.Windows.Forms.Button();
            this.stopRotationButton = new System.Windows.Forms.Button();
            this.myControlElement2 = new WindowsFormsControlLibrary1.MyControlElement();
            this.myControlElement1 = new WindowsFormsControlLibrary1.MyControlElement();
            this.changeColorButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // drawCubeButton
            // 
            this.drawCubeButton.Location = new System.Drawing.Point(57, 721);
            this.drawCubeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.drawCubeButton.Name = "drawCubeButton";
            this.drawCubeButton.Size = new System.Drawing.Size(168, 94);
            this.drawCubeButton.TabIndex = 2;
            this.drawCubeButton.Text = "Draw cube";
            this.drawCubeButton.UseVisualStyleBackColor = true;
            this.drawCubeButton.Click += new System.EventHandler(this.drawCubeButton_Click);
            // 
            // deleteCubeButton
            // 
            this.deleteCubeButton.Location = new System.Drawing.Point(276, 721);
            this.deleteCubeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deleteCubeButton.Name = "deleteCubeButton";
            this.deleteCubeButton.Size = new System.Drawing.Size(161, 94);
            this.deleteCubeButton.TabIndex = 3;
            this.deleteCubeButton.Text = "Delete cube";
            this.deleteCubeButton.UseVisualStyleBackColor = true;
            this.deleteCubeButton.Click += new System.EventHandler(this.deleteCubeButton_Click);
            // 
            // startRotationButton
            // 
            this.startRotationButton.Location = new System.Drawing.Point(504, 719);
            this.startRotationButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.startRotationButton.Name = "startRotationButton";
            this.startRotationButton.Size = new System.Drawing.Size(165, 95);
            this.startRotationButton.TabIndex = 4;
            this.startRotationButton.Text = "Start rotation";
            this.startRotationButton.UseVisualStyleBackColor = true;
            this.startRotationButton.Click += new System.EventHandler(this.startRotationButton_Click);
            // 
            // stopRotationButton
            // 
            this.stopRotationButton.Location = new System.Drawing.Point(732, 716);
            this.stopRotationButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stopRotationButton.Name = "stopRotationButton";
            this.stopRotationButton.Size = new System.Drawing.Size(184, 98);
            this.stopRotationButton.TabIndex = 5;
            this.stopRotationButton.Text = "Stop rotation";
            this.stopRotationButton.UseVisualStyleBackColor = true;
            this.stopRotationButton.Click += new System.EventHandler(this.stopRotationButton_Click);
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
            this.changeColorButton.Location = new System.Drawing.Point(969, 714);
            this.changeColorButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.changeColorButton.Name = "changeColorButton";
            this.changeColorButton.Size = new System.Drawing.Size(170, 99);
            this.changeColorButton.TabIndex = 6;
            this.changeColorButton.Text = "Change color";
            this.changeColorButton.UseVisualStyleBackColor = true;
            this.changeColorButton.Click += new System.EventHandler(this.changeColorButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 849);
            this.Controls.Add(this.changeColorButton);
            this.Controls.Add(this.stopRotationButton);
            this.Controls.Add(this.startRotationButton);
            this.Controls.Add(this.deleteCubeButton);
            this.Controls.Add(this.drawCubeButton);
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
        private System.Windows.Forms.Button drawCubeButton;
        private System.Windows.Forms.Button deleteCubeButton;
        private System.Windows.Forms.Button startRotationButton;
        private System.Windows.Forms.Button stopRotationButton;
        private System.Windows.Forms.Button changeColorButton;
    }
}


