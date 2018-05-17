namespace Sudoku2
{
    partial class FormSudoku
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSudoku));
            this.BtnSolve = new System.Windows.Forms.Button();
            this.gBoxT1 = new System.Windows.Forms.GroupBox();
            this.gBoxT2 = new System.Windows.Forms.GroupBox();
            this.BtnTextOpen = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.lblDesc1 = new System.Windows.Forms.Label();
            this.lblDesc2 = new System.Windows.Forms.Label();
            this.lblDesc4 = new System.Windows.Forms.Label();
            this.lblDesc3 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.gBoxT4 = new System.Windows.Forms.GroupBox();
            this.gBoxT3 = new System.Windows.Forms.GroupBox();
            this.lblDesc8 = new System.Windows.Forms.Label();
            this.lblDesc7 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.gBoxT8 = new System.Windows.Forms.GroupBox();
            this.gBoxT7 = new System.Windows.Forms.GroupBox();
            this.lblDesc6 = new System.Windows.Forms.Label();
            this.lblDesc5 = new System.Windows.Forms.Label();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.gBoxT6 = new System.Windows.Forms.GroupBox();
            this.gBoxT5 = new System.Windows.Forms.GroupBox();
            this.lblDesc9 = new System.Windows.Forms.Label();
            this.comboBox9 = new System.Windows.Forms.ComboBox();
            this.gBoxT9 = new System.Windows.Forms.GroupBox();
            this.lblDesc10 = new System.Windows.Forms.Label();
            this.comboBox10 = new System.Windows.Forms.ComboBox();
            this.gBoxT10 = new System.Windows.Forms.GroupBox();
            this.lblRuntime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnSolve
            // 
            this.BtnSolve.Location = new System.Drawing.Point(113, 39);
            this.BtnSolve.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnSolve.Name = "BtnSolve";
            this.BtnSolve.Size = new System.Drawing.Size(79, 41);
            this.BtnSolve.TabIndex = 0;
            this.BtnSolve.Text = "BAŞLAT";
            this.BtnSolve.UseVisualStyleBackColor = true;
            this.BtnSolve.Click += new System.EventHandler(this.BtnSolve_Click);
            // 
            // gBoxT1
            // 
            this.gBoxT1.BackColor = System.Drawing.SystemColors.Control;
            this.gBoxT1.Location = new System.Drawing.Point(18, 109);
            this.gBoxT1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxT1.Name = "gBoxT1";
            this.gBoxT1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxT1.Size = new System.Drawing.Size(264, 267);
            this.gBoxT1.TabIndex = 1;
            this.gBoxT1.TabStop = false;
            this.gBoxT1.Text = "Thread 1";
            // 
            // gBoxT2
            // 
            this.gBoxT2.Location = new System.Drawing.Point(295, 109);
            this.gBoxT2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxT2.Name = "gBoxT2";
            this.gBoxT2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxT2.Size = new System.Drawing.Size(264, 267);
            this.gBoxT2.TabIndex = 11;
            this.gBoxT2.TabStop = false;
            this.gBoxT2.Text = "Thread 2";
            // 
            // BtnTextOpen
            // 
            this.BtnTextOpen.Location = new System.Drawing.Point(18, 39);
            this.BtnTextOpen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnTextOpen.Name = "BtnTextOpen";
            this.BtnTextOpen.Size = new System.Drawing.Size(82, 41);
            this.BtnTextOpen.TabIndex = 12;
            this.BtnTextOpen.Text = "DOSYAYI AÇ";
            this.BtnTextOpen.UseVisualStyleBackColor = true;
            this.BtnTextOpen.Click += new System.EventHandler(this.BtnTextOpen_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(18, 384);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(65, 21);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(295, 384);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(92, 21);
            this.comboBox2.TabIndex = 15;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // lblDesc1
            // 
            this.lblDesc1.AutoSize = true;
            this.lblDesc1.Location = new System.Drawing.Point(94, 387);
            this.lblDesc1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesc1.Name = "lblDesc1";
            this.lblDesc1.Size = new System.Drawing.Size(35, 13);
            this.lblDesc1.TabIndex = 16;
            this.lblDesc1.Text = "label1";
            // 
            // lblDesc2
            // 
            this.lblDesc2.AutoSize = true;
            this.lblDesc2.Location = new System.Drawing.Point(390, 387);
            this.lblDesc2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesc2.Name = "lblDesc2";
            this.lblDesc2.Size = new System.Drawing.Size(35, 13);
            this.lblDesc2.TabIndex = 17;
            this.lblDesc2.Text = "label2";
            // 
            // lblDesc4
            // 
            this.lblDesc4.AutoSize = true;
            this.lblDesc4.Location = new System.Drawing.Point(946, 386);
            this.lblDesc4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesc4.Name = "lblDesc4";
            this.lblDesc4.Size = new System.Drawing.Size(35, 13);
            this.lblDesc4.TabIndex = 23;
            this.lblDesc4.Text = "label2";
            // 
            // lblDesc3
            // 
            this.lblDesc3.AutoSize = true;
            this.lblDesc3.Location = new System.Drawing.Point(669, 384);
            this.lblDesc3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesc3.Name = "lblDesc3";
            this.lblDesc3.Size = new System.Drawing.Size(35, 13);
            this.lblDesc3.TabIndex = 22;
            this.lblDesc3.Text = "label1";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(572, 381);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(92, 21);
            this.comboBox3.TabIndex = 21;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(851, 384);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(92, 21);
            this.comboBox4.TabIndex = 20;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // gBoxT4
            // 
            this.gBoxT4.Location = new System.Drawing.Point(851, 109);
            this.gBoxT4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxT4.Name = "gBoxT4";
            this.gBoxT4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxT4.Size = new System.Drawing.Size(264, 267);
            this.gBoxT4.TabIndex = 19;
            this.gBoxT4.TabStop = false;
            this.gBoxT4.Text = "Thread 4";
            // 
            // gBoxT3
            // 
            this.gBoxT3.Location = new System.Drawing.Point(572, 109);
            this.gBoxT3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxT3.Name = "gBoxT3";
            this.gBoxT3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxT3.Size = new System.Drawing.Size(264, 267);
            this.gBoxT3.TabIndex = 18;
            this.gBoxT3.TabStop = false;
            this.gBoxT3.Text = "Thread 3";
            // 
            // lblDesc8
            // 
            this.lblDesc8.AutoSize = true;
            this.lblDesc8.Location = new System.Drawing.Point(667, 726);
            this.lblDesc8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesc8.Name = "lblDesc8";
            this.lblDesc8.Size = new System.Drawing.Size(35, 13);
            this.lblDesc8.TabIndex = 35;
            this.lblDesc8.Text = "label2";
            // 
            // lblDesc7
            // 
            this.lblDesc7.AutoSize = true;
            this.lblDesc7.Location = new System.Drawing.Point(392, 726);
            this.lblDesc7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesc7.Name = "lblDesc7";
            this.lblDesc7.Size = new System.Drawing.Size(35, 13);
            this.lblDesc7.TabIndex = 34;
            this.lblDesc7.Text = "label1";
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(1132, 386);
            this.comboBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(92, 21);
            this.comboBox5.TabIndex = 33;
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(18, 724);
            this.comboBox6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(92, 21);
            this.comboBox6.TabIndex = 32;
            this.comboBox6.SelectedIndexChanged += new System.EventHandler(this.comboBox6_SelectedIndexChanged);
            // 
            // gBoxT8
            // 
            this.gBoxT8.Location = new System.Drawing.Point(572, 444);
            this.gBoxT8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxT8.Name = "gBoxT8";
            this.gBoxT8.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxT8.Size = new System.Drawing.Size(264, 267);
            this.gBoxT8.TabIndex = 31;
            this.gBoxT8.TabStop = false;
            this.gBoxT8.Text = "Thread 8";
            // 
            // gBoxT7
            // 
            this.gBoxT7.Location = new System.Drawing.Point(295, 444);
            this.gBoxT7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxT7.Name = "gBoxT7";
            this.gBoxT7.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxT7.Size = new System.Drawing.Size(264, 267);
            this.gBoxT7.TabIndex = 30;
            this.gBoxT7.TabStop = false;
            this.gBoxT7.Text = "Thread 7";
            // 
            // lblDesc6
            // 
            this.lblDesc6.AutoSize = true;
            this.lblDesc6.Location = new System.Drawing.Point(113, 726);
            this.lblDesc6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesc6.Name = "lblDesc6";
            this.lblDesc6.Size = new System.Drawing.Size(35, 13);
            this.lblDesc6.TabIndex = 29;
            this.lblDesc6.Text = "label2";
            // 
            // lblDesc5
            // 
            this.lblDesc5.AutoSize = true;
            this.lblDesc5.Location = new System.Drawing.Point(1234, 392);
            this.lblDesc5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesc5.Name = "lblDesc5";
            this.lblDesc5.Size = new System.Drawing.Size(35, 13);
            this.lblDesc5.TabIndex = 28;
            this.lblDesc5.Text = "label1";
            // 
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(295, 726);
            this.comboBox7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(92, 21);
            this.comboBox7.TabIndex = 27;
            this.comboBox7.SelectedIndexChanged += new System.EventHandler(this.comboBox7_SelectedIndexChanged);
            // 
            // comboBox8
            // 
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Location = new System.Drawing.Point(572, 724);
            this.comboBox8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(92, 21);
            this.comboBox8.TabIndex = 26;
            this.comboBox8.SelectedIndexChanged += new System.EventHandler(this.comboBox8_SelectedIndexChanged);
            // 
            // gBoxT6
            // 
            this.gBoxT6.Location = new System.Drawing.Point(18, 444);
            this.gBoxT6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxT6.Name = "gBoxT6";
            this.gBoxT6.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxT6.Size = new System.Drawing.Size(264, 267);
            this.gBoxT6.TabIndex = 25;
            this.gBoxT6.TabStop = false;
            this.gBoxT6.Text = "Thread 6";
            // 
            // gBoxT5
            // 
            this.gBoxT5.Location = new System.Drawing.Point(1132, 109);
            this.gBoxT5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxT5.Name = "gBoxT5";
            this.gBoxT5.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxT5.Size = new System.Drawing.Size(264, 267);
            this.gBoxT5.TabIndex = 24;
            this.gBoxT5.TabStop = false;
            this.gBoxT5.Text = "Thread 5";
            // 
            // lblDesc9
            // 
            this.lblDesc9.AutoSize = true;
            this.lblDesc9.Location = new System.Drawing.Point(946, 726);
            this.lblDesc9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesc9.Name = "lblDesc9";
            this.lblDesc9.Size = new System.Drawing.Size(35, 13);
            this.lblDesc9.TabIndex = 38;
            this.lblDesc9.Text = "label2";
            // 
            // comboBox9
            // 
            this.comboBox9.FormattingEnabled = true;
            this.comboBox9.Location = new System.Drawing.Point(851, 724);
            this.comboBox9.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox9.Name = "comboBox9";
            this.comboBox9.Size = new System.Drawing.Size(92, 21);
            this.comboBox9.TabIndex = 37;
            this.comboBox9.SelectedIndexChanged += new System.EventHandler(this.comboBox9_SelectedIndexChanged);
            // 
            // gBoxT9
            // 
            this.gBoxT9.Location = new System.Drawing.Point(851, 444);
            this.gBoxT9.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxT9.Name = "gBoxT9";
            this.gBoxT9.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxT9.Size = new System.Drawing.Size(264, 267);
            this.gBoxT9.TabIndex = 36;
            this.gBoxT9.TabStop = false;
            this.gBoxT9.Text = "Thread 9";
            // 
            // lblDesc10
            // 
            this.lblDesc10.AutoSize = true;
            this.lblDesc10.Location = new System.Drawing.Point(1229, 724);
            this.lblDesc10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesc10.Name = "lblDesc10";
            this.lblDesc10.Size = new System.Drawing.Size(35, 13);
            this.lblDesc10.TabIndex = 42;
            this.lblDesc10.Text = "label2";
            // 
            // comboBox10
            // 
            this.comboBox10.FormattingEnabled = true;
            this.comboBox10.Location = new System.Drawing.Point(1132, 721);
            this.comboBox10.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox10.Name = "comboBox10";
            this.comboBox10.Size = new System.Drawing.Size(92, 21);
            this.comboBox10.TabIndex = 41;
            this.comboBox10.SelectedIndexChanged += new System.EventHandler(this.comboBox10_SelectedIndexChanged);
            // 
            // gBoxT10
            // 
            this.gBoxT10.Location = new System.Drawing.Point(1132, 444);
            this.gBoxT10.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxT10.Name = "gBoxT10";
            this.gBoxT10.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxT10.Size = new System.Drawing.Size(264, 267);
            this.gBoxT10.TabIndex = 40;
            this.gBoxT10.TabStop = false;
            this.gBoxT10.Text = "Thread 10";
            // 
            // lblRuntime
            // 
            this.lblRuntime.AutoSize = true;
            this.lblRuntime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRuntime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRuntime.Location = new System.Drawing.Point(236, 47);
            this.lblRuntime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRuntime.Name = "lblRuntime";
            this.lblRuntime.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblRuntime.Size = new System.Drawing.Size(75, 30);
            this.lblRuntime.TabIndex = 53;
            this.lblRuntime.Text = "ZAMAN";
            // 
            // FormSudoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 602);
            this.Controls.Add(this.lblRuntime);
            this.Controls.Add(this.lblDesc10);
            this.Controls.Add(this.comboBox10);
            this.Controls.Add(this.gBoxT10);
            this.Controls.Add(this.lblDesc9);
            this.Controls.Add(this.comboBox9);
            this.Controls.Add(this.gBoxT9);
            this.Controls.Add(this.lblDesc8);
            this.Controls.Add(this.lblDesc7);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.comboBox6);
            this.Controls.Add(this.gBoxT8);
            this.Controls.Add(this.gBoxT7);
            this.Controls.Add(this.lblDesc6);
            this.Controls.Add(this.lblDesc5);
            this.Controls.Add(this.comboBox7);
            this.Controls.Add(this.comboBox8);
            this.Controls.Add(this.gBoxT6);
            this.Controls.Add(this.gBoxT5);
            this.Controls.Add(this.lblDesc4);
            this.Controls.Add(this.lblDesc3);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.gBoxT4);
            this.Controls.Add(this.gBoxT3);
            this.Controls.Add(this.lblDesc2);
            this.Controls.Add(this.lblDesc1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.BtnTextOpen);
            this.Controls.Add(this.gBoxT2);
            this.Controls.Add(this.gBoxT1);
            this.Controls.Add(this.BtnSolve);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormSudoku";
            this.Text = "Sudoku Solver";
            this.Load += new System.EventHandler(this.FormSudoku_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSolve;
        private System.Windows.Forms.GroupBox gBoxT1;
        private System.Windows.Forms.GroupBox gBoxT2;
        private System.Windows.Forms.Button BtnTextOpen;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label lblDesc1;
        private System.Windows.Forms.Label lblDesc2;
        private System.Windows.Forms.Label lblDesc4;
        private System.Windows.Forms.Label lblDesc3;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.GroupBox gBoxT4;
        private System.Windows.Forms.GroupBox gBoxT3;
        private System.Windows.Forms.Label lblDesc8;
        private System.Windows.Forms.Label lblDesc7;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.GroupBox gBoxT8;
        private System.Windows.Forms.GroupBox gBoxT7;
        private System.Windows.Forms.Label lblDesc6;
        private System.Windows.Forms.Label lblDesc5;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.GroupBox gBoxT6;
        private System.Windows.Forms.GroupBox gBoxT5;
        private System.Windows.Forms.Label lblDesc9;
        private System.Windows.Forms.ComboBox comboBox9;
        private System.Windows.Forms.GroupBox gBoxT9;
        private System.Windows.Forms.Label lblDesc10;
        private System.Windows.Forms.ComboBox comboBox10;
        private System.Windows.Forms.GroupBox gBoxT10;
        private System.Windows.Forms.Label lblRuntime;
    }
}