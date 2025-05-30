namespace Perceptron
{
    partial class Form1
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
            this.plotArea = new System.Windows.Forms.PictureBox();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.colorBox = new System.Windows.Forms.ComboBox();
            this.labelColor = new System.Windows.Forms.Label();
            this.activateButton = new System.Windows.Forms.Button();
            this.labelGen = new System.Windows.Forms.Label();
            this.genCounter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.plotArea)).BeginInit();
            this.SuspendLayout();
            // 
            // plotArea
            // 
            this.plotArea.BackColor = System.Drawing.Color.PaleTurquoise;
            this.plotArea.Location = new System.Drawing.Point(403, 12);
            this.plotArea.Name = "plotArea";
            this.plotArea.Size = new System.Drawing.Size(681, 681);
            this.plotArea.TabIndex = 0;
            this.plotArea.TabStop = false;
            this.plotArea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.plotArea_MouseClick);
            // 
            // xTextBox
            // 
            this.xTextBox.BackColor = System.Drawing.Color.PaleTurquoise;
            this.xTextBox.Location = new System.Drawing.Point(12, 32);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(105, 22);
            this.xTextBox.TabIndex = 1;
            // 
            // yTextBox
            // 
            this.yTextBox.BackColor = System.Drawing.Color.PaleTurquoise;
            this.yTextBox.Location = new System.Drawing.Point(123, 32);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(105, 22);
            this.yTextBox.TabIndex = 2;
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.labelX.Location = new System.Drawing.Point(12, 13);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(13, 16);
            this.labelX.TabIndex = 3;
            this.labelX.Text = "x";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.labelY.Location = new System.Drawing.Point(120, 13);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(14, 16);
            this.labelY.TabIndex = 4;
            this.labelY.Text = "y";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 73);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(343, 38);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Add point";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(12, 117);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(343, 38);
            this.removeButton.TabIndex = 6;
            this.removeButton.Text = "Remove point";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // colorBox
            // 
            this.colorBox.BackColor = System.Drawing.Color.DarkSlateGray;
            this.colorBox.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.colorBox.FormattingEnabled = true;
            this.colorBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colorBox.Items.AddRange(new object[] {
            "Red",
            "Blue"});
            this.colorBox.Location = new System.Drawing.Point(234, 30);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(121, 24);
            this.colorBox.TabIndex = 7;
            this.colorBox.SelectedIndexChanged += new System.EventHandler(this.colorBox_SelectedIndexChanged);
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.labelColor.Location = new System.Drawing.Point(231, 13);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(39, 16);
            this.labelColor.TabIndex = 8;
            this.labelColor.Text = "Color";
            // 
            // activateButton
            // 
            this.activateButton.Location = new System.Drawing.Point(12, 211);
            this.activateButton.Name = "activateButton";
            this.activateButton.Size = new System.Drawing.Size(343, 38);
            this.activateButton.TabIndex = 9;
            this.activateButton.Text = "Activate";
            this.activateButton.UseVisualStyleBackColor = true;
            this.activateButton.Click += new System.EventHandler(this.ActivateButton_Click);
            // 
            // labelGen
            // 
            this.labelGen.AutoSize = true;
            this.labelGen.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.labelGen.Location = new System.Drawing.Point(12, 271);
            this.labelGen.Name = "labelGen";
            this.labelGen.Size = new System.Drawing.Size(35, 16);
            this.labelGen.TabIndex = 10;
            this.labelGen.Text = "Gen:";
            // 
            // genCounter
            // 
            this.genCounter.AutoSize = true;
            this.genCounter.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.genCounter.Location = new System.Drawing.Point(46, 271);
            this.genCounter.Name = "genCounter";
            this.genCounter.Size = new System.Drawing.Size(14, 16);
            this.genCounter.TabIndex = 11;
            this.genCounter.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1096, 705);
            this.Controls.Add(this.genCounter);
            this.Controls.Add(this.labelGen);
            this.Controls.Add(this.activateButton);
            this.Controls.Add(this.labelColor);
            this.Controls.Add(this.colorBox);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.yTextBox);
            this.Controls.Add(this.xTextBox);
            this.Controls.Add(this.plotArea);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.plotArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox plotArea;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.ComboBox colorBox;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.Button activateButton;
        private System.Windows.Forms.Label labelGen;
        private System.Windows.Forms.Label genCounter;
    }
}

