namespace GeneticAlgorithmTimetablingSystem
{
    partial class HardConstraints
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbConstraint = new System.Windows.Forms.PictureBox();
            this.Title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.description = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbConstraint)).BeginInit();
            this.SuspendLayout();
            // 
            // pbConstraint
            // 
            this.pbConstraint.BackColor = System.Drawing.Color.Transparent;
            this.pbConstraint.Location = new System.Drawing.Point(36, 46);
            this.pbConstraint.Name = "pbConstraint";
            this.pbConstraint.Size = new System.Drawing.Size(105, 136);
            this.pbConstraint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbConstraint.TabIndex = 0;
            this.pbConstraint.TabStop = false;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(210)))));
            this.Title.Location = new System.Drawing.Point(361, 11);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(87, 33);
            this.Title.TabIndex = 74;
            this.Title.Text = "Rule 1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.panel1.Location = new System.Drawing.Point(452, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 1);
            this.panel1.TabIndex = 75;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.panel2.Location = new System.Drawing.Point(36, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(320, 1);
            this.panel2.TabIndex = 76;
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.description.Location = new System.Drawing.Point(185, 74);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(246, 20);
            this.description.TabIndex = 77;
            this.description.Text = "Overlapping of classes in a same time";
            // 
            // HardConstraints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.description);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.pbConstraint);
            this.Name = "HardConstraints";
            this.Size = new System.Drawing.Size(807, 192);
            ((System.ComponentModel.ISupportInitialize)(this.pbConstraint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbConstraint;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label description;
    }
}
