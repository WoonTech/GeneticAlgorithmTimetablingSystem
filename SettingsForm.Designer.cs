namespace GeneticAlgorithmTimetablingSystem
{
    partial class SettingsForm
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
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnPeriods = new System.Windows.Forms.Panel();
            this.cbAutumn = new System.Windows.Forms.CheckBox();
            this.cbSpring = new System.Windows.Forms.CheckBox();
            this.sliderAutumn = new ColorSlider.ColorSlider();
            this.sliderSpring = new ColorSlider.ColorSlider();
            this.label3 = new System.Windows.Forms.Label();
            this.lblWeekSpring = new System.Windows.Forms.Label();
            this.lblWeekAutumn = new System.Windows.Forms.Label();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelParameter = new System.Windows.Forms.Panel();
            this.sliderTrackBestDNA = new ColorSlider.ColorSlider();
            this.sliderReplace = new ColorSlider.ColorSlider();
            this.sliderDNA = new ColorSlider.ColorSlider();
            this.lblDNA = new System.Windows.Forms.Label();
            this.lblReplace = new System.Windows.Forms.Label();
            this.lblTrackBestDNA = new System.Windows.Forms.Label();
            this.panelSchedulePrototype = new System.Windows.Forms.Panel();
            this.sliderCrossoverPB = new ColorSlider.ColorSlider();
            this.sliderMutationPB = new ColorSlider.ColorSlider();
            this.sliderMutation = new ColorSlider.ColorSlider();
            this.sliderCrossover = new ColorSlider.ColorSlider();
            this.lblCrossover = new System.Windows.Forms.Label();
            this.lblMutation = new System.Windows.Forms.Label();
            this.lblCrossoverPB = new System.Windows.Forms.Label();
            this.lblMutationPB = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblParameters = new System.Windows.Forms.Label();
            this.lblPrototype = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pbPeriods = new System.Windows.Forms.PictureBox();
            this.pbPrototype = new System.Windows.Forms.PictureBox();
            this.pbParameters = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pbOptimization = new System.Windows.Forms.PictureBox();
            this.lblOptimization = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnPeriods.SuspendLayout();
            this.panelParameter.SuspendLayout();
            this.panelSchedulePrototype.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPeriods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrototype)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOptimization)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(210)))));
            label1.Location = new System.Drawing.Point(21, 19);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(108, 22);
            label1.TabIndex = 0;
            label1.Text = "SETTINGS";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(25)))), ((int)(((byte)(38)))));
            this.panel1.Controls.Add(this.pbOptimization);
            this.panel1.Controls.Add(this.lblOptimization);
            this.panel1.Controls.Add(this.pnPeriods);
            this.panel1.Controls.Add(this.pbPeriods);
            this.panel1.Controls.Add(this.lblPeriod);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pbPrototype);
            this.panel1.Controls.Add(this.pbParameters);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.panelParameter);
            this.panel1.Controls.Add(this.panelSchedulePrototype);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblParameters);
            this.panel1.Controls.Add(this.lblPrototype);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 559);
            this.panel1.TabIndex = 0;
            // 
            // pnPeriods
            // 
            this.pnPeriods.Controls.Add(this.pictureBox5);
            this.pnPeriods.Controls.Add(this.cbAutumn);
            this.pnPeriods.Controls.Add(this.cbSpring);
            this.pnPeriods.Controls.Add(this.sliderAutumn);
            this.pnPeriods.Controls.Add(this.sliderSpring);
            this.pnPeriods.Controls.Add(this.label3);
            this.pnPeriods.Controls.Add(this.lblWeekSpring);
            this.pnPeriods.Controls.Add(this.lblWeekAutumn);
            this.pnPeriods.Location = new System.Drawing.Point(244, 84);
            this.pnPeriods.Name = "pnPeriods";
            this.pnPeriods.Size = new System.Drawing.Size(294, 381);
            this.pnPeriods.TabIndex = 102;
            // 
            // cbAutumn
            // 
            this.cbAutumn.FlatAppearance.BorderSize = 0;
            this.cbAutumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAutumn.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAutumn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.cbAutumn.Location = new System.Drawing.Point(-3, 80);
            this.cbAutumn.Name = "cbAutumn";
            this.cbAutumn.Size = new System.Drawing.Size(78, 25);
            this.cbAutumn.TabIndex = 105;
            this.cbAutumn.Text = "Autumn";
            this.cbAutumn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbAutumn.UseVisualStyleBackColor = true;
            this.cbAutumn.Click += new System.EventHandler(this.cbAutumn_Click);
            this.cbAutumn.Paint += new System.Windows.Forms.PaintEventHandler(this.cbAutumn_Paint);
            // 
            // cbSpring
            // 
            this.cbSpring.FlatAppearance.BorderSize = 0;
            this.cbSpring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSpring.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSpring.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.cbSpring.Location = new System.Drawing.Point(-8, 53);
            this.cbSpring.Name = "cbSpring";
            this.cbSpring.Size = new System.Drawing.Size(78, 25);
            this.cbSpring.TabIndex = 102;
            this.cbSpring.Text = "Spring";
            this.cbSpring.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbSpring.UseVisualStyleBackColor = true;
            this.cbSpring.Click += new System.EventHandler(this.cbSpring_Click);
            this.cbSpring.Paint += new System.Windows.Forms.PaintEventHandler(this.cbSpring_Paint);
            // 
            // sliderAutumn
            // 
            this.sliderAutumn.BackColor = System.Drawing.Color.Transparent;
            this.sliderAutumn.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderAutumn.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderAutumn.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderAutumn.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderAutumn.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderAutumn.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderAutumn.Enabled = false;
            this.sliderAutumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderAutumn.ForeColor = System.Drawing.Color.White;
            this.sliderAutumn.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderAutumn.Location = new System.Drawing.Point(6, 201);
            this.sliderAutumn.Maximum = new decimal(new int[] {
            33,
            0,
            0,
            0});
            this.sliderAutumn.Minimum = new decimal(new int[] {
            22,
            0,
            0,
            0});
            this.sliderAutumn.Name = "sliderAutumn";
            this.sliderAutumn.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderAutumn.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderAutumn.ShowDivisionsText = true;
            this.sliderAutumn.ShowSmallScale = false;
            this.sliderAutumn.Size = new System.Drawing.Size(200, 28);
            this.sliderAutumn.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sliderAutumn.TabIndex = 101;
            this.sliderAutumn.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderAutumn.ThumbOuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderAutumn.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderAutumn.ThumbRoundRectSize = new System.Drawing.Size(10, 10);
            this.sliderAutumn.ThumbSize = new System.Drawing.Size(10, 10);
            this.sliderAutumn.TickAdd = 0F;
            this.sliderAutumn.TickColor = System.Drawing.Color.White;
            this.sliderAutumn.TickDivide = 0F;
            this.sliderAutumn.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderAutumn.Value = new decimal(new int[] {
            33,
            0,
            0,
            0});
            // 
            // sliderSpring
            // 
            this.sliderSpring.BackColor = System.Drawing.Color.Transparent;
            this.sliderSpring.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderSpring.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderSpring.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderSpring.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderSpring.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderSpring.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderSpring.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderSpring.ForeColor = System.Drawing.Color.White;
            this.sliderSpring.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderSpring.Location = new System.Drawing.Point(6, 141);
            this.sliderSpring.Maximum = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.sliderSpring.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.sliderSpring.Name = "sliderSpring";
            this.sliderSpring.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderSpring.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderSpring.ShowDivisionsText = true;
            this.sliderSpring.ShowSmallScale = false;
            this.sliderSpring.Size = new System.Drawing.Size(200, 28);
            this.sliderSpring.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sliderSpring.TabIndex = 100;
            this.sliderSpring.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderSpring.ThumbOuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderSpring.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderSpring.ThumbRoundRectSize = new System.Drawing.Size(10, 10);
            this.sliderSpring.ThumbSize = new System.Drawing.Size(10, 10);
            this.sliderSpring.TickAdd = 0F;
            this.sliderSpring.TickColor = System.Drawing.Color.White;
            this.sliderSpring.TickDivide = 0F;
            this.sliderSpring.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderSpring.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(210)))));
            this.label3.Location = new System.Drawing.Point(2, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 20);
            this.label3.TabIndex = 78;
            this.label3.Text = "Semester （Must Select At Least One）";
            // 
            // lblWeekSpring
            // 
            this.lblWeekSpring.AutoSize = true;
            this.lblWeekSpring.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeekSpring.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblWeekSpring.Location = new System.Drawing.Point(3, 122);
            this.lblWeekSpring.Name = "lblWeekSpring";
            this.lblWeekSpring.Size = new System.Drawing.Size(78, 16);
            this.lblWeekSpring.TabIndex = 79;
            this.lblWeekSpring.Text = "Week :  3 - 14";
            // 
            // lblWeekAutumn
            // 
            this.lblWeekAutumn.AutoSize = true;
            this.lblWeekAutumn.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeekAutumn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblWeekAutumn.Location = new System.Drawing.Point(3, 182);
            this.lblWeekAutumn.Name = "lblWeekAutumn";
            this.lblWeekAutumn.Size = new System.Drawing.Size(81, 16);
            this.lblWeekAutumn.TabIndex = 80;
            this.lblWeekAutumn.Text = "Week : 21 - 33";
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(146)))));
            this.lblPeriod.Location = new System.Drawing.Point(21, 259);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(57, 20);
            this.lblPeriod.TabIndex = 99;
            this.lblPeriod.Text = "Periods";
            this.lblPeriod.Click += new System.EventHandler(this.lblPeriod_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.label2.Location = new System.Drawing.Point(21, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 98;
            this.label2.Text = "Limitations";
            // 
            // panelParameter
            // 
            this.panelParameter.Controls.Add(this.sliderTrackBestDNA);
            this.panelParameter.Controls.Add(this.sliderReplace);
            this.panelParameter.Controls.Add(this.sliderDNA);
            this.panelParameter.Controls.Add(this.lblDNA);
            this.panelParameter.Controls.Add(this.lblReplace);
            this.panelParameter.Controls.Add(this.lblTrackBestDNA);
            this.panelParameter.Location = new System.Drawing.Point(244, 84);
            this.panelParameter.Name = "panelParameter";
            this.panelParameter.Size = new System.Drawing.Size(294, 381);
            this.panelParameter.TabIndex = 93;
            // 
            // sliderTrackBestDNA
            // 
            this.sliderTrackBestDNA.BackColor = System.Drawing.Color.Transparent;
            this.sliderTrackBestDNA.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderTrackBestDNA.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderTrackBestDNA.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderTrackBestDNA.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderTrackBestDNA.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderTrackBestDNA.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderTrackBestDNA.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderTrackBestDNA.ForeColor = System.Drawing.Color.White;
            this.sliderTrackBestDNA.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderTrackBestDNA.Location = new System.Drawing.Point(6, 171);
            this.sliderTrackBestDNA.Maximum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.sliderTrackBestDNA.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.sliderTrackBestDNA.Name = "sliderTrackBestDNA";
            this.sliderTrackBestDNA.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderTrackBestDNA.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderTrackBestDNA.ShowDivisionsText = true;
            this.sliderTrackBestDNA.ShowSmallScale = false;
            this.sliderTrackBestDNA.Size = new System.Drawing.Size(200, 28);
            this.sliderTrackBestDNA.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sliderTrackBestDNA.TabIndex = 101;
            this.sliderTrackBestDNA.Text = "colorSlider4";
            this.sliderTrackBestDNA.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderTrackBestDNA.ThumbOuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderTrackBestDNA.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderTrackBestDNA.ThumbRoundRectSize = new System.Drawing.Size(10, 10);
            this.sliderTrackBestDNA.ThumbSize = new System.Drawing.Size(10, 10);
            this.sliderTrackBestDNA.TickAdd = 0F;
            this.sliderTrackBestDNA.TickColor = System.Drawing.Color.White;
            this.sliderTrackBestDNA.TickDivide = 0F;
            this.sliderTrackBestDNA.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderTrackBestDNA.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.sliderTrackBestDNA.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sliderTrackBestDNA_Scroll);
            // 
            // sliderReplace
            // 
            this.sliderReplace.BackColor = System.Drawing.Color.Transparent;
            this.sliderReplace.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderReplace.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderReplace.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderReplace.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderReplace.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderReplace.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderReplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderReplace.ForeColor = System.Drawing.Color.White;
            this.sliderReplace.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderReplace.Location = new System.Drawing.Point(6, 111);
            this.sliderReplace.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.sliderReplace.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sliderReplace.Name = "sliderReplace";
            this.sliderReplace.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderReplace.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderReplace.ShowDivisionsText = true;
            this.sliderReplace.ShowSmallScale = false;
            this.sliderReplace.Size = new System.Drawing.Size(200, 28);
            this.sliderReplace.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sliderReplace.TabIndex = 100;
            this.sliderReplace.Text = "colorSlider3";
            this.sliderReplace.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderReplace.ThumbOuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderReplace.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderReplace.ThumbRoundRectSize = new System.Drawing.Size(10, 10);
            this.sliderReplace.ThumbSize = new System.Drawing.Size(10, 10);
            this.sliderReplace.TickAdd = 0F;
            this.sliderReplace.TickColor = System.Drawing.Color.White;
            this.sliderReplace.TickDivide = 0F;
            this.sliderReplace.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderReplace.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.sliderReplace.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sliderReplace_Scroll);
            // 
            // sliderDNA
            // 
            this.sliderDNA.BackColor = System.Drawing.Color.Transparent;
            this.sliderDNA.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderDNA.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderDNA.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderDNA.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderDNA.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderDNA.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderDNA.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderDNA.ForeColor = System.Drawing.Color.White;
            this.sliderDNA.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderDNA.Location = new System.Drawing.Point(6, 53);
            this.sliderDNA.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.sliderDNA.Minimum = new decimal(new int[] {
            750,
            0,
            0,
            0});
            this.sliderDNA.Name = "sliderDNA";
            this.sliderDNA.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderDNA.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderDNA.ShowDivisionsText = true;
            this.sliderDNA.ShowSmallScale = false;
            this.sliderDNA.Size = new System.Drawing.Size(200, 28);
            this.sliderDNA.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sliderDNA.TabIndex = 99;
            this.sliderDNA.Text = "colorSlider2";
            this.sliderDNA.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderDNA.ThumbOuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderDNA.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderDNA.ThumbRoundRectSize = new System.Drawing.Size(10, 10);
            this.sliderDNA.ThumbSize = new System.Drawing.Size(10, 10);
            this.sliderDNA.TickAdd = 0F;
            this.sliderDNA.TickColor = System.Drawing.Color.White;
            this.sliderDNA.TickDivide = 0F;
            this.sliderDNA.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderDNA.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.sliderDNA.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sliderDNA_Scroll);
            // 
            // lblDNA
            // 
            this.lblDNA.AutoSize = true;
            this.lblDNA.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDNA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblDNA.Location = new System.Drawing.Point(3, 34);
            this.lblDNA.Name = "lblDNA";
            this.lblDNA.Size = new System.Drawing.Size(103, 16);
            this.lblDNA.TabIndex = 78;
            this.lblDNA.Text = "DNA Numbers : 00";
            // 
            // lblReplace
            // 
            this.lblReplace.AutoSize = true;
            this.lblReplace.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblReplace.Location = new System.Drawing.Point(3, 92);
            this.lblReplace.Name = "lblReplace";
            this.lblReplace.Size = new System.Drawing.Size(149, 16);
            this.lblReplace.TabIndex = 79;
            this.lblReplace.Text = "Replace by Generation : 00";
            // 
            // lblTrackBestDNA
            // 
            this.lblTrackBestDNA.AutoSize = true;
            this.lblTrackBestDNA.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrackBestDNA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblTrackBestDNA.Location = new System.Drawing.Point(3, 152);
            this.lblTrackBestDNA.Name = "lblTrackBestDNA";
            this.lblTrackBestDNA.Size = new System.Drawing.Size(154, 16);
            this.lblTrackBestDNA.TabIndex = 80;
            this.lblTrackBestDNA.Text = "Track Best DNA number : 00";
            // 
            // panelSchedulePrototype
            // 
            this.panelSchedulePrototype.Controls.Add(this.sliderCrossoverPB);
            this.panelSchedulePrototype.Controls.Add(this.sliderMutationPB);
            this.panelSchedulePrototype.Controls.Add(this.sliderMutation);
            this.panelSchedulePrototype.Controls.Add(this.sliderCrossover);
            this.panelSchedulePrototype.Controls.Add(this.lblCrossover);
            this.panelSchedulePrototype.Controls.Add(this.lblMutation);
            this.panelSchedulePrototype.Controls.Add(this.lblCrossoverPB);
            this.panelSchedulePrototype.Controls.Add(this.lblMutationPB);
            this.panelSchedulePrototype.Location = new System.Drawing.Point(244, 84);
            this.panelSchedulePrototype.Name = "panelSchedulePrototype";
            this.panelSchedulePrototype.Size = new System.Drawing.Size(294, 381);
            this.panelSchedulePrototype.TabIndex = 94;
            // 
            // sliderCrossoverPB
            // 
            this.sliderCrossoverPB.BackColor = System.Drawing.Color.Transparent;
            this.sliderCrossoverPB.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderCrossoverPB.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderCrossoverPB.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderCrossoverPB.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderCrossoverPB.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderCrossoverPB.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderCrossoverPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderCrossoverPB.ForeColor = System.Drawing.Color.White;
            this.sliderCrossoverPB.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderCrossoverPB.Location = new System.Drawing.Point(6, 171);
            this.sliderCrossoverPB.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.sliderCrossoverPB.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.sliderCrossoverPB.Name = "sliderCrossoverPB";
            this.sliderCrossoverPB.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderCrossoverPB.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderCrossoverPB.ShowDivisionsText = true;
            this.sliderCrossoverPB.ShowSmallScale = false;
            this.sliderCrossoverPB.Size = new System.Drawing.Size(200, 28);
            this.sliderCrossoverPB.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sliderCrossoverPB.TabIndex = 101;
            this.sliderCrossoverPB.Text = "colorSlider7";
            this.sliderCrossoverPB.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderCrossoverPB.ThumbOuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderCrossoverPB.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderCrossoverPB.ThumbRoundRectSize = new System.Drawing.Size(10, 10);
            this.sliderCrossoverPB.ThumbSize = new System.Drawing.Size(10, 10);
            this.sliderCrossoverPB.TickAdd = 0F;
            this.sliderCrossoverPB.TickColor = System.Drawing.Color.White;
            this.sliderCrossoverPB.TickDivide = 0F;
            this.sliderCrossoverPB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderCrossoverPB.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.sliderCrossoverPB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sliderCrossoverPB_Scroll);
            // 
            // sliderMutationPB
            // 
            this.sliderMutationPB.BackColor = System.Drawing.Color.Transparent;
            this.sliderMutationPB.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderMutationPB.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderMutationPB.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderMutationPB.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderMutationPB.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderMutationPB.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderMutationPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderMutationPB.ForeColor = System.Drawing.Color.White;
            this.sliderMutationPB.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderMutationPB.Location = new System.Drawing.Point(6, 240);
            this.sliderMutationPB.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.sliderMutationPB.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderMutationPB.Name = "sliderMutationPB";
            this.sliderMutationPB.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderMutationPB.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderMutationPB.ShowDivisionsText = true;
            this.sliderMutationPB.ShowSmallScale = false;
            this.sliderMutationPB.Size = new System.Drawing.Size(200, 28);
            this.sliderMutationPB.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sliderMutationPB.TabIndex = 100;
            this.sliderMutationPB.Text = "colorSlider6";
            this.sliderMutationPB.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderMutationPB.ThumbOuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderMutationPB.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderMutationPB.ThumbRoundRectSize = new System.Drawing.Size(10, 10);
            this.sliderMutationPB.ThumbSize = new System.Drawing.Size(10, 10);
            this.sliderMutationPB.TickAdd = 0F;
            this.sliderMutationPB.TickColor = System.Drawing.Color.White;
            this.sliderMutationPB.TickDivide = 0F;
            this.sliderMutationPB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderMutationPB.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderMutationPB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sliderMutationPB_Scroll);
            // 
            // sliderMutation
            // 
            this.sliderMutation.BackColor = System.Drawing.Color.Transparent;
            this.sliderMutation.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderMutation.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderMutation.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderMutation.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderMutation.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderMutation.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderMutation.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderMutation.ForeColor = System.Drawing.Color.White;
            this.sliderMutation.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderMutation.Location = new System.Drawing.Point(6, 111);
            this.sliderMutation.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderMutation.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sliderMutation.Name = "sliderMutation";
            this.sliderMutation.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderMutation.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderMutation.ShowDivisionsText = true;
            this.sliderMutation.ShowSmallScale = false;
            this.sliderMutation.Size = new System.Drawing.Size(200, 28);
            this.sliderMutation.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sliderMutation.TabIndex = 99;
            this.sliderMutation.Text = "colorSlider5";
            this.sliderMutation.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderMutation.ThumbOuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderMutation.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderMutation.ThumbRoundRectSize = new System.Drawing.Size(10, 10);
            this.sliderMutation.ThumbSize = new System.Drawing.Size(10, 10);
            this.sliderMutation.TickAdd = 0F;
            this.sliderMutation.TickColor = System.Drawing.Color.White;
            this.sliderMutation.TickDivide = 0F;
            this.sliderMutation.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderMutation.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderMutation.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sliderMutation_Scroll);
            // 
            // sliderCrossover
            // 
            this.sliderCrossover.BackColor = System.Drawing.Color.Transparent;
            this.sliderCrossover.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderCrossover.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderCrossover.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderCrossover.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderCrossover.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderCrossover.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderCrossover.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderCrossover.ForeColor = System.Drawing.Color.White;
            this.sliderCrossover.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderCrossover.Location = new System.Drawing.Point(6, 53);
            this.sliderCrossover.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderCrossover.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sliderCrossover.Name = "sliderCrossover";
            this.sliderCrossover.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderCrossover.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderCrossover.ShowDivisionsText = true;
            this.sliderCrossover.ShowSmallScale = false;
            this.sliderCrossover.Size = new System.Drawing.Size(200, 28);
            this.sliderCrossover.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sliderCrossover.TabIndex = 98;
            this.sliderCrossover.Text = "colorSlider1";
            this.sliderCrossover.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderCrossover.ThumbOuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.sliderCrossover.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.sliderCrossover.ThumbRoundRectSize = new System.Drawing.Size(10, 10);
            this.sliderCrossover.ThumbSize = new System.Drawing.Size(10, 10);
            this.sliderCrossover.TickAdd = 0F;
            this.sliderCrossover.TickColor = System.Drawing.Color.White;
            this.sliderCrossover.TickDivide = 0F;
            this.sliderCrossover.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderCrossover.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderCrossover.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sliderCrossover_Scroll);
            // 
            // lblCrossover
            // 
            this.lblCrossover.AutoSize = true;
            this.lblCrossover.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrossover.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblCrossover.Location = new System.Drawing.Point(3, 34);
            this.lblCrossover.Name = "lblCrossover";
            this.lblCrossover.Size = new System.Drawing.Size(121, 16);
            this.lblCrossover.TabIndex = 78;
            this.lblCrossover.Text = "Crossover Points : 00";
            // 
            // lblMutation
            // 
            this.lblMutation.AutoSize = true;
            this.lblMutation.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMutation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblMutation.Location = new System.Drawing.Point(3, 92);
            this.lblMutation.Name = "lblMutation";
            this.lblMutation.Size = new System.Drawing.Size(102, 16);
            this.lblMutation.TabIndex = 79;
            this.lblMutation.Text = "Mutation Size : 00";
            // 
            // lblCrossoverPB
            // 
            this.lblCrossoverPB.AutoSize = true;
            this.lblCrossoverPB.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrossoverPB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblCrossoverPB.Location = new System.Drawing.Point(3, 152);
            this.lblCrossoverPB.Name = "lblCrossoverPB";
            this.lblCrossoverPB.Size = new System.Drawing.Size(144, 16);
            this.lblCrossoverPB.TabIndex = 80;
            this.lblCrossoverPB.Text = "Crossover Probability : 00";
            // 
            // lblMutationPB
            // 
            this.lblMutationPB.AutoSize = true;
            this.lblMutationPB.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMutationPB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblMutationPB.Location = new System.Drawing.Point(3, 219);
            this.lblMutationPB.Name = "lblMutationPB";
            this.lblMutationPB.Size = new System.Drawing.Size(137, 16);
            this.lblMutationPB.TabIndex = 81;
            this.lblMutationPB.Text = "Mutation Probability : 00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.label12.Location = new System.Drawing.Point(21, 311);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 20);
            this.label12.TabIndex = 92;
            this.label12.Text = "About";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.label4.Location = new System.Drawing.Point(21, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 76;
            this.label4.Text = "Genetic Algorithm";
            // 
            // lblParameters
            // 
            this.lblParameters.AutoSize = true;
            this.lblParameters.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParameters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(146)))));
            this.lblParameters.Location = new System.Drawing.Point(21, 114);
            this.lblParameters.Name = "lblParameters";
            this.lblParameters.Size = new System.Drawing.Size(79, 20);
            this.lblParameters.TabIndex = 75;
            this.lblParameters.Text = "Parameters";
            this.lblParameters.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblPrototype
            // 
            this.lblPrototype.AutoSize = true;
            this.lblPrototype.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrototype.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.lblPrototype.Location = new System.Drawing.Point(21, 145);
            this.lblPrototype.Name = "lblPrototype";
            this.lblPrototype.Size = new System.Drawing.Size(131, 20);
            this.lblPrototype.TabIndex = 74;
            this.lblPrototype.Text = "Schedule Prototype";
            this.lblPrototype.Click += new System.EventHandler(this.label2_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(0, 58);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(8, 50);
            this.pictureBox5.TabIndex = 104;
            this.pictureBox5.TabStop = false;
            // 
            // pbPeriods
            // 
            this.pbPeriods.Image = ((System.Drawing.Image)(resources.GetObject("pbPeriods.Image")));
            this.pbPeriods.Location = new System.Drawing.Point(17, 263);
            this.pbPeriods.Name = "pbPeriods";
            this.pbPeriods.Size = new System.Drawing.Size(2, 13);
            this.pbPeriods.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbPeriods.TabIndex = 100;
            this.pbPeriods.TabStop = false;
            // 
            // pbPrototype
            // 
            this.pbPrototype.Image = ((System.Drawing.Image)(resources.GetObject("pbPrototype.Image")));
            this.pbPrototype.Location = new System.Drawing.Point(17, 149);
            this.pbPrototype.Name = "pbPrototype";
            this.pbPrototype.Size = new System.Drawing.Size(2, 13);
            this.pbPrototype.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbPrototype.TabIndex = 97;
            this.pbPrototype.TabStop = false;
            this.pbPrototype.Visible = false;
            // 
            // pbParameters
            // 
            this.pbParameters.Image = ((System.Drawing.Image)(resources.GetObject("pbParameters.Image")));
            this.pbParameters.Location = new System.Drawing.Point(17, 118);
            this.pbParameters.Name = "pbParameters";
            this.pbParameters.Size = new System.Drawing.Size(2, 13);
            this.pbParameters.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbParameters.TabIndex = 96;
            this.pbParameters.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(210, 70);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(1, 400);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 95;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(25, 503);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(138, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 94;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(25, 463);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 77;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(15, 58);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(550, 1);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 73;
            this.pictureBox3.TabStop = false;
            // 
            // pbOptimization
            // 
            this.pbOptimization.Image = ((System.Drawing.Image)(resources.GetObject("pbOptimization.Image")));
            this.pbOptimization.Location = new System.Drawing.Point(17, 179);
            this.pbOptimization.Name = "pbOptimization";
            this.pbOptimization.Size = new System.Drawing.Size(2, 13);
            this.pbOptimization.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbOptimization.TabIndex = 104;
            this.pbOptimization.TabStop = false;
            this.pbOptimization.Visible = false;
            // 
            // lblOptimization
            // 
            this.lblOptimization.AutoSize = true;
            this.lblOptimization.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptimization.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(192)))), ((int)(((byte)(142)))));
            this.lblOptimization.Location = new System.Drawing.Point(21, 175);
            this.lblOptimization.Name = "lblOptimization";
            this.lblOptimization.Size = new System.Drawing.Size(88, 20);
            this.lblOptimization.TabIndex = 103;
            this.lblOptimization.Text = "Optimization";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnPeriods.ResumeLayout(false);
            this.pnPeriods.PerformLayout();
            this.panelParameter.ResumeLayout(false);
            this.panelParameter.PerformLayout();
            this.panelSchedulePrototype.ResumeLayout(false);
            this.panelSchedulePrototype.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPeriods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrototype)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbParameters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOptimization)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDNA;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblParameters;
        private System.Windows.Forms.Label lblPrototype;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblTrackBestDNA;
        private System.Windows.Forms.Label lblReplace;
        private System.Windows.Forms.Panel panelParameter;
        private System.Windows.Forms.Panel panelSchedulePrototype;
        private System.Windows.Forms.Label lblCrossover;
        private System.Windows.Forms.Label lblMutation;
        private System.Windows.Forms.Label lblCrossoverPB;
        private System.Windows.Forms.Label lblMutationPB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pbPrototype;
        private System.Windows.Forms.PictureBox pbParameters;
        private ColorSlider.ColorSlider sliderCrossover;
        private ColorSlider.ColorSlider sliderTrackBestDNA;
        private ColorSlider.ColorSlider sliderReplace;
        private ColorSlider.ColorSlider sliderDNA;
        private ColorSlider.ColorSlider sliderCrossoverPB;
        private ColorSlider.ColorSlider sliderMutationPB;
        private ColorSlider.ColorSlider sliderMutation;
        private System.Windows.Forms.PictureBox pbPeriods;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnPeriods;
        private ColorSlider.ColorSlider sliderAutumn;
        private ColorSlider.ColorSlider sliderSpring;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblWeekSpring;
        private System.Windows.Forms.Label lblWeekAutumn;
        private System.Windows.Forms.CheckBox cbSpring;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.CheckBox cbAutumn;
        private System.Windows.Forms.PictureBox pbOptimization;
        private System.Windows.Forms.Label lblOptimization;
    }
}