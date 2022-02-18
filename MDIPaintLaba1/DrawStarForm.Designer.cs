namespace MDIPaintLaba1
{
    partial class DrawStarForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.rayNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.innerRadNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.outherRadNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.angleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rayNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.innerRadNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outherRadNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество лучей";
            // 
            // rayNumericUpDown
            // 
            this.rayNumericUpDown.Location = new System.Drawing.Point(135, 12);
            this.rayNumericUpDown.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.rayNumericUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.rayNumericUpDown.Name = "rayNumericUpDown";
            this.rayNumericUpDown.Size = new System.Drawing.Size(85, 23);
            this.rayNumericUpDown.TabIndex = 1;
            this.rayNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // innerRadNumericUpDown
            // 
            this.innerRadNumericUpDown.Location = new System.Drawing.Point(135, 41);
            this.innerRadNumericUpDown.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.innerRadNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.innerRadNumericUpDown.Name = "innerRadNumericUpDown";
            this.innerRadNumericUpDown.Size = new System.Drawing.Size(85, 23);
            this.innerRadNumericUpDown.TabIndex = 2;
            this.innerRadNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // outherRadNumericUpDown
            // 
            this.outherRadNumericUpDown.Location = new System.Drawing.Point(135, 70);
            this.outherRadNumericUpDown.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.outherRadNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.outherRadNumericUpDown.Name = "outherRadNumericUpDown";
            this.outherRadNumericUpDown.Size = new System.Drawing.Size(85, 23);
            this.outherRadNumericUpDown.TabIndex = 3;
            this.outherRadNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Внутренний радиус ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Внешний радиус";
            // 
            // angleNumericUpDown
            // 
            this.angleNumericUpDown.Location = new System.Drawing.Point(135, 99);
            this.angleNumericUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.angleNumericUpDown.Name = "angleNumericUpDown";
            this.angleNumericUpDown.Size = new System.Drawing.Size(85, 23);
            this.angleNumericUpDown.TabIndex = 6;
            this.angleNumericUpDown.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Угол в градусах";
            // 
            // DrawStarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 136);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.angleNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.outherRadNumericUpDown);
            this.Controls.Add(this.innerRadNumericUpDown);
            this.Controls.Add(this.rayNumericUpDown);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DrawStarForm";
            this.Text = "Настройка звезды";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DrawStarForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.rayNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.innerRadNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outherRadNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private NumericUpDown rayNumericUpDown;
        private NumericUpDown innerRadNumericUpDown;
        private NumericUpDown outherRadNumericUpDown;
        private Label label2;
        private Label label3;
        private NumericUpDown angleNumericUpDown;
        private Label label4;
    }
}