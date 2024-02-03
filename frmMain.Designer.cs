namespace SistemaDeNumeracao
{
    partial class frmMain
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
            groupBox1 = new GroupBox();
            txtBin = new TextBox();
            groupBox2 = new GroupBox();
            txtDec = new TextBox();
            groupBox3 = new GroupBox();
            txtOct = new TextBox();
            groupBox4 = new GroupBox();
            txtHex = new TextBox();
            groupBox5 = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtBin);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(133, 225);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Binário";
            // 
            // txtBin
            // 
            txtBin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtBin.Location = new Point(6, 22);
            txtBin.Multiline = true;
            txtBin.Name = "txtBin";
            txtBin.ScrollBars = ScrollBars.Vertical;
            txtBin.Size = new Size(121, 183);
            txtBin.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtDec);
            groupBox2.Location = new Point(152, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(133, 71);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Decimal";
            // 
            // txtDec
            // 
            txtDec.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtDec.Location = new Point(6, 22);
            txtDec.Name = "txtDec";
            txtDec.Size = new Size(110, 29);
            txtDec.TabIndex = 2;
            txtDec.TextAlign = HorizontalAlignment.Center;
            txtDec.WordWrap = false;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtOct);
            groupBox3.Location = new Point(152, 89);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(133, 71);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Octal";
            // 
            // txtOct
            // 
            txtOct.Enabled = false;
            txtOct.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtOct.Location = new Point(6, 22);
            txtOct.Name = "txtOct";
            txtOct.Size = new Size(110, 29);
            txtOct.TabIndex = 2;
            txtOct.TextAlign = HorizontalAlignment.Center;
            txtOct.WordWrap = false;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtHex);
            groupBox4.Location = new Point(152, 166);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(133, 71);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Hexadecimal";
            // 
            // txtHex
            // 
            txtHex.Enabled = false;
            txtHex.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtHex.Location = new Point(6, 22);
            txtHex.Name = "txtHex";
            txtHex.Size = new Size(110, 29);
            txtHex.TabIndex = 2;
            txtHex.TextAlign = HorizontalAlignment.Center;
            txtHex.WordWrap = false;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label2);
            groupBox5.Controls.Add(label1);
            groupBox5.Location = new Point(291, 12);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(200, 225);
            groupBox5.TabIndex = 6;
            groupBox5.TabStop = false;
            groupBox5.Text = "Dados técnicos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 77);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 1;
            label2.Text = "Bytes: 0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 36);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "Bits: 0";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 251);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmMain";
            Text = "Conversão numérica";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private Label label2;
        private Label label1;
        public TextBox txtBin;
        public TextBox txtDec;
        public TextBox txtOct;
        public TextBox txtHex;
    }
}
