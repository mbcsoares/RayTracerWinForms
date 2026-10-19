namespace RayTracerWinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBoxRender = new PictureBox();
            panelControls = new Panel();
            lblStatus = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            numSpp = new NumericUpDown();
            numCamZ = new NumericUpDown();
            numCamY = new NumericUpDown();
            numCamX = new NumericUpDown();
            lblFov = new Label();
            trackFov = new TrackBar();
            numHeight = new NumericUpDown();
            numWidth = new NumericUpDown();
            btnSavePng = new Button();
            btnRender = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRender).BeginInit();
            panelControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSpp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCamZ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCamY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCamX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackFov).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numWidth).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxRender
            // 
            pictureBoxRender.BackColor = Color.Black;
            pictureBoxRender.Dock = DockStyle.Fill;
            pictureBoxRender.Location = new Point(0, 0);
            pictureBoxRender.Name = "pictureBoxRender";
            pictureBoxRender.Size = new Size(800, 450);
            pictureBoxRender.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxRender.TabIndex = 0;
            pictureBoxRender.TabStop = false;
            // 
            // panelControls
            // 
            panelControls.Controls.Add(lblStatus);
            panelControls.Controls.Add(label7);
            panelControls.Controls.Add(label6);
            panelControls.Controls.Add(label5);
            panelControls.Controls.Add(label4);
            panelControls.Controls.Add(label3);
            panelControls.Controls.Add(label2);
            panelControls.Controls.Add(label1);
            panelControls.Controls.Add(numSpp);
            panelControls.Controls.Add(numCamZ);
            panelControls.Controls.Add(numCamY);
            panelControls.Controls.Add(numCamX);
            panelControls.Controls.Add(lblFov);
            panelControls.Controls.Add(trackFov);
            panelControls.Controls.Add(numHeight);
            panelControls.Controls.Add(numWidth);
            panelControls.Controls.Add(btnSavePng);
            panelControls.Controls.Add(btnRender);
            panelControls.Dock = DockStyle.Left;
            panelControls.Location = new Point(0, 0);
            panelControls.Name = "panelControls";
            panelControls.Size = new Size(300, 450);
            panelControls.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(12, 421);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(56, 20);
            lblStatus.TabIndex = 17;
            lblStatus.Text = "Pronto.";
            lblStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(73, 285);
            label7.Name = "label7";
            label7.Size = new Size(191, 20);
            label7.TabIndex = 16;
            label7.Text = "Ângulo do campo de visão:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 229);
            label6.Name = "label6";
            label6.Size = new Size(75, 40);
            label6.TabIndex = 15;
            label6.Text = "Amostras\r\npor pixel: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 189);
            label5.Name = "label5";
            label5.Size = new Size(25, 20);
            label5.TabIndex = 14;
            label5.Text = "Z: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 156);
            label4.Name = "label4";
            label4.Size = new Size(24, 20);
            label4.TabIndex = 13;
            label4.Text = "Y: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 118);
            label3.Name = "label3";
            label3.Size = new Size(25, 20);
            label3.TabIndex = 12;
            label3.Text = "X: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 42);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 11;
            label2.Text = "Largura: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 75);
            label1.Name = "label1";
            label1.Size = new Size(56, 20);
            label1.TabIndex = 10;
            label1.Text = "Altura: ";
            // 
            // numSpp
            // 
            numSpp.Location = new Point(114, 229);
            numSpp.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            numSpp.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSpp.Name = "numSpp";
            numSpp.Size = new Size(150, 27);
            numSpp.TabIndex = 9;
            numSpp.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numCamZ
            // 
            numCamZ.DecimalPlaces = 1;
            numCamZ.Location = new Point(114, 182);
            numCamZ.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numCamZ.Minimum = new decimal(new int[] { 50, 0, 0, int.MinValue });
            numCamZ.Name = "numCamZ";
            numCamZ.Size = new Size(150, 27);
            numCamZ.TabIndex = 8;
            numCamZ.Value = new decimal(new int[] { 6, 0, 0, 0 });
            // 
            // numCamY
            // 
            numCamY.DecimalPlaces = 1;
            numCamY.Location = new Point(114, 149);
            numCamY.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numCamY.Minimum = new decimal(new int[] { 50, 0, 0, int.MinValue });
            numCamY.Name = "numCamY";
            numCamY.Size = new Size(150, 27);
            numCamY.TabIndex = 7;
            numCamY.Value = new decimal(new int[] { 15, 0, 0, 65536 });
            // 
            // numCamX
            // 
            numCamX.DecimalPlaces = 1;
            numCamX.Location = new Point(114, 116);
            numCamX.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numCamX.Minimum = new decimal(new int[] { 50, 0, 0, int.MinValue });
            numCamX.Name = "numCamX";
            numCamX.Size = new Size(150, 27);
            numCamX.TabIndex = 6;
            // 
            // lblFov
            // 
            lblFov.AutoSize = true;
            lblFov.Location = new Point(199, 319);
            lblFov.Name = "lblFov";
            lblFov.Size = new Size(65, 20);
            lblFov.TabIndex = 5;
            lblFov.Text = "FOV: 60°";
            // 
            // trackFov
            // 
            trackFov.LargeChange = 10;
            trackFov.Location = new Point(12, 319);
            trackFov.Maximum = 120;
            trackFov.Minimum = 10;
            trackFov.Name = "trackFov";
            trackFov.Size = new Size(167, 56);
            trackFov.SmallChange = 10;
            trackFov.TabIndex = 4;
            trackFov.TickStyle = TickStyle.None;
            trackFov.Value = 60;
            trackFov.ValueChanged += trackFov_ValueChanged;
            // 
            // numHeight
            // 
            numHeight.Location = new Point(114, 68);
            numHeight.Maximum = new decimal(new int[] { 720, 0, 0, 0 });
            numHeight.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            numHeight.Name = "numHeight";
            numHeight.Size = new Size(150, 27);
            numHeight.TabIndex = 3;
            numHeight.Value = new decimal(new int[] { 600, 0, 0, 0 });
            // 
            // numWidth
            // 
            numWidth.Location = new Point(114, 35);
            numWidth.Maximum = new decimal(new int[] { 1280, 0, 0, 0 });
            numWidth.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            numWidth.Name = "numWidth";
            numWidth.Size = new Size(150, 27);
            numWidth.TabIndex = 2;
            numWidth.Value = new decimal(new int[] { 800, 0, 0, 0 });
            // 
            // btnSavePng
            // 
            btnSavePng.Location = new Point(138, 381);
            btnSavePng.Name = "btnSavePng";
            btnSavePng.Size = new Size(120, 29);
            btnSavePng.TabIndex = 1;
            btnSavePng.Text = "Salvar PNG";
            btnSavePng.UseVisualStyleBackColor = true;
            btnSavePng.Click += btnSavePng_Click;
            // 
            // btnRender
            // 
            btnRender.Location = new Point(12, 381);
            btnRender.Name = "btnRender";
            btnRender.Size = new Size(120, 29);
            btnRender.TabIndex = 0;
            btnRender.Text = "Renderizar";
            btnRender.UseVisualStyleBackColor = true;
            btnRender.Click += btnRender_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelControls);
            Controls.Add(pictureBoxRender);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBoxRender).EndInit();
            panelControls.ResumeLayout(false);
            panelControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSpp).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCamZ).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCamY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCamX).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackFov).EndInit();
            ((System.ComponentModel.ISupportInitialize)numHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numWidth).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxRender;
        private Panel panelControls;
        private NumericUpDown numWidth;
        private Button btnSavePng;
        private Button btnRender;
        private TrackBar trackFov;
        private NumericUpDown numHeight;
        private NumericUpDown numericUpDown4;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numCamY;
        private NumericUpDown numCamX;
        private NumericUpDown numCamZ;
        private NumericUpDown numSpp;
        private Label lblFov;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label7;
        private Label label6;
        private Label lblStatus;
    }
}
