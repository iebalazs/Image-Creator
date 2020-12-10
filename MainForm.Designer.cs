namespace Image_Creator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radioButtonContoured = new System.Windows.Forms.RadioButton();
            this.radioButtonShaded = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonLinear = new System.Windows.Forms.RadioButton();
            this.radioButtonSpotted = new System.Windows.Forms.RadioButton();
            this.showButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DrawButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip5 = new System.Windows.Forms.ToolTip(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openButton
            // 
            this.openButton.BackColor = System.Drawing.Color.LightCyan;
            this.openButton.Location = new System.Drawing.Point(12, 12);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(86, 30);
            this.openButton.TabIndex = 0;
            this.openButton.Text = "Open Image";
            this.toolTip1.SetToolTip(this.openButton, "Select the image that you want to be drawn");
            this.openButton.UseVisualStyleBackColor = false;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(141, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // radioButtonContoured
            // 
            this.radioButtonContoured.AutoSize = true;
            this.radioButtonContoured.Location = new System.Drawing.Point(18, 27);
            this.radioButtonContoured.Name = "radioButtonContoured";
            this.radioButtonContoured.Size = new System.Drawing.Size(90, 21);
            this.radioButtonContoured.TabIndex = 3;
            this.radioButtonContoured.Text = "contoured";
            this.radioButtonContoured.UseVisualStyleBackColor = true;
            // 
            // radioButtonShaded
            // 
            this.radioButtonShaded.AutoSize = true;
            this.radioButtonShaded.Checked = true;
            this.radioButtonShaded.Location = new System.Drawing.Point(18, 54);
            this.radioButtonShaded.Name = "radioButtonShaded";
            this.radioButtonShaded.Size = new System.Drawing.Size(73, 21);
            this.radioButtonShaded.TabIndex = 4;
            this.radioButtonShaded.TabStop = true;
            this.radioButtonShaded.Text = "shaded";
            this.radioButtonShaded.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonShaded);
            this.groupBox1.Controls.Add(this.radioButtonContoured);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(12, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(123, 87);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Style of figure";
            this.toolTip2.SetToolTip(this.groupBox1, "Select the style which can be eather contoured or shaded");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonLinear);
            this.groupBox2.Controls.Add(this.radioButtonSpotted);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(12, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(123, 71);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Style of drawn lines";
            this.toolTip3.SetToolTip(this.groupBox2, "Select the style of drawn spots which can be eather linear or spotted");
            // 
            // radioButtonLinear
            // 
            this.radioButtonLinear.AutoSize = true;
            this.radioButtonLinear.Location = new System.Drawing.Point(18, 44);
            this.radioButtonLinear.Name = "radioButtonLinear";
            this.radioButtonLinear.Size = new System.Drawing.Size(50, 17);
            this.radioButtonLinear.TabIndex = 1;
            this.radioButtonLinear.Text = "linear";
            this.radioButtonLinear.UseVisualStyleBackColor = true;
            // 
            // radioButtonSpotted
            // 
            this.radioButtonSpotted.AutoSize = true;
            this.radioButtonSpotted.Checked = true;
            this.radioButtonSpotted.Location = new System.Drawing.Point(18, 20);
            this.radioButtonSpotted.Name = "radioButtonSpotted";
            this.radioButtonSpotted.Size = new System.Drawing.Size(60, 17);
            this.radioButtonSpotted.TabIndex = 0;
            this.radioButtonSpotted.TabStop = true;
            this.radioButtonSpotted.Text = "spotted";
            this.radioButtonSpotted.UseVisualStyleBackColor = true;
            // 
            // showButton
            // 
            this.showButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.showButton.Location = new System.Drawing.Point(12, 258);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(86, 29);
            this.showButton.TabIndex = 7;
            this.showButton.Text = "Show Figure";
            this.toolTip4.SetToolTip(this.showButton, "Show the figure considering the selected styles");
            this.showButton.UseVisualStyleBackColor = false;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "COM7",
            "COM8",
            "COM9"});
            this.comboBox1.Location = new System.Drawing.Point(109, 326);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Select COM Port:";
            // 
            // DrawButton
            // 
            this.DrawButton.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.DrawButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DrawButton.Location = new System.Drawing.Point(292, 319);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(149, 52);
            this.DrawButton.TabIndex = 10;
            this.DrawButton.Text = "Draw Figure";
            this.toolTip5.SetToolTip(this.DrawButton, "Draw the figure by the plotter");
            this.DrawButton.UseVisualStyleBackColor = false;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(17, 377);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(424, 10);
            this.progressBar1.TabIndex = 13;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(451, 396);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.DrawButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.openButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Image Creator";
            this.Click += new System.EventHandler(this.openButton_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton radioButtonContoured;
        private System.Windows.Forms.RadioButton radioButtonShaded;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonLinear;
        private System.Windows.Forms.RadioButton radioButtonSpotted;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.ToolTip toolTip4;
        private System.Windows.Forms.ToolTip toolTip5;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
    }
}

