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
            ControlTextBinary = new Controls.CustomTextBoxModel();
            groupBox2 = new GroupBox();
            ControlTextDecimal = new Controls.CustomTextBoxModel();
            groupBox3 = new GroupBox();
            ControlTextOctal = new Controls.CustomTextBoxModel();
            groupBox4 = new GroupBox();
            ControlTextHexadecimal = new Controls.CustomTextBoxModel();
            groupBox5 = new GroupBox();
            ControlLabelBit = new Controls.CustomLabelModel();
            ControlLabelByte = new Controls.CustomLabelModel();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ControlTextBinary);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(133, 225);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Binário";
            // 
            // ControlTextBinary
            // 
            ControlTextBinary.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ControlTextBinary.Location = new Point(6, 22);
            ControlTextBinary.Multiline = true;
            ControlTextBinary.Name = "ControlTextBinary";
            ControlTextBinary.ScrollBars = ScrollBars.Vertical;
            ControlTextBinary.Size = new Size(121, 183);
            ControlTextBinary.TabIndex = 8;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ControlTextDecimal);
            groupBox2.Location = new Point(152, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(133, 71);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Decimal";
            // 
            // ControlTextDecimal
            // 
            ControlTextDecimal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ControlTextDecimal.Location = new Point(6, 22);
            ControlTextDecimal.Name = "ControlTextDecimal";
            ControlTextDecimal.Size = new Size(121, 29);
            ControlTextDecimal.TabIndex = 8;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(ControlTextOctal);
            groupBox3.Location = new Point(152, 89);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(133, 71);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Octal";
            // 
            // ControlTextOctal
            // 
            ControlTextOctal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ControlTextOctal.Location = new Point(6, 21);
            ControlTextOctal.Name = "ControlTextOctal";
            ControlTextOctal.Size = new Size(121, 29);
            ControlTextOctal.TabIndex = 9;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(ControlTextHexadecimal);
            groupBox4.Location = new Point(152, 166);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(133, 71);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Hexadecimal";
            // 
            // ControlTextHexadecimal
            // 
            ControlTextHexadecimal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ControlTextHexadecimal.Location = new Point(6, 21);
            ControlTextHexadecimal.Name = "ControlTextHexadecimal";
            ControlTextHexadecimal.Size = new Size(121, 29);
            ControlTextHexadecimal.TabIndex = 10;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(ControlLabelByte);
            groupBox5.Controls.Add(ControlLabelBit);
            groupBox5.Location = new Point(291, 12);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(200, 225);
            groupBox5.TabIndex = 6;
            groupBox5.TabStop = false;
            groupBox5.Text = "Dados técnicos";
            // 
            // ControlLabelBit
            // 
            ControlLabelBit.AutoSize = true;
            ControlLabelBit.Location = new Point(6, 30);
            ControlLabelBit.Name = "ControlLabelBit";
            ControlLabelBit.Size = new Size(29, 15);
            ControlLabelBit.TabIndex = 2;
            ControlLabelBit.Text = "Bits:";
            // 
            // ControlLabelByte
            // 
            ControlLabelByte.AutoSize = true;
            ControlLabelByte.Location = new Point(6, 56);
            ControlLabelByte.Name = "ControlLabelByte";
            ControlLabelByte.Size = new Size(38, 15);
            ControlLabelByte.TabIndex = 3;
            ControlLabelByte.Text = "Bytes:";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 254);
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
        private Controls.CustomTextBoxModel ControlTextBinary;
        private Controls.CustomTextBoxModel ControlTextDecimal;
        private Controls.CustomTextBoxModel ControlTextOctal;
        private Controls.CustomTextBoxModel ControlTextHexadecimal;
        private Controls.CustomLabelModel ControlLabelBit;
        private Controls.CustomLabelModel ControlLabelByte;
    }
}
