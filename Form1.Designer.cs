namespace PersonelSistemi
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lBLhKSAYI = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonçıkış = new System.Windows.Forms.Button();
            this.buttonGİRİŞ = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.msktxtPAROLA = new System.Windows.Forms.MaskedTextBox();
            this.radioButtonKULLANICI = new System.Windows.Forms.RadioButton();
            this.radioByÖNETİCİ = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TXTkULLANICIAD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CadetBlue;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 144);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(468, 182);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox2.Controls.Add(this.lBLhKSAYI);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.buttonçıkış);
            this.groupBox2.Controls.Add(this.buttonGİRİŞ);
            this.groupBox2.Location = new System.Drawing.Point(89, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(297, 102);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // lBLhKSAYI
            // 
            this.lBLhKSAYI.AutoSize = true;
            this.lBLhKSAYI.Location = new System.Drawing.Point(127, 61);
            this.lBLhKSAYI.Name = "lBLhKSAYI";
            this.lBLhKSAYI.Size = new System.Drawing.Size(12, 16);
            this.lBLhKSAYI.TabIndex = 8;
            this.lBLhKSAYI.Text = ".";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "GİRİŞ HAKKI";
            // 
            // buttonçıkış
            // 
            this.buttonçıkış.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonçıkış.Font = new System.Drawing.Font("Georgia", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonçıkış.Location = new System.Drawing.Point(197, 7);
            this.buttonçıkış.Name = "buttonçıkış";
            this.buttonçıkış.Size = new System.Drawing.Size(94, 32);
            this.buttonçıkış.TabIndex = 6;
            this.buttonçıkış.Text = "ÇIKIŞ";
            this.buttonçıkış.UseVisualStyleBackColor = true;
            this.buttonçıkış.Click += new System.EventHandler(this.buttonçıkış_Click);
            // 
            // buttonGİRİŞ
            // 
            this.buttonGİRİŞ.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonGİRİŞ.Font = new System.Drawing.Font("Georgia", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonGİRİŞ.Location = new System.Drawing.Point(99, 6);
            this.buttonGİRİŞ.Name = "buttonGİRİŞ";
            this.buttonGİRİŞ.Size = new System.Drawing.Size(92, 33);
            this.buttonGİRİŞ.TabIndex = 5;
            this.buttonGİRİŞ.Text = "GİRİŞ";
            this.buttonGİRİŞ.UseVisualStyleBackColor = true;
            this.buttonGİRİŞ.Click += new System.EventHandler(this.buttonGİRİŞ_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(468, 152);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(156, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "WELCOME!";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.msktxtPAROLA);
            this.groupBox1.Controls.Add(this.radioButtonKULLANICI);
            this.groupBox1.Controls.Add(this.radioByÖNETİCİ);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TXTkULLANICIAD);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(89, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 132);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // msktxtPAROLA
            // 
            this.msktxtPAROLA.Location = new System.Drawing.Point(130, 49);
            this.msktxtPAROLA.Name = "msktxtPAROLA";
            this.msktxtPAROLA.Size = new System.Drawing.Size(161, 22);
            this.msktxtPAROLA.TabIndex = 2;
            this.msktxtPAROLA.MouseEnter += new System.EventHandler(this.msktxtPAROLA_MouseEnter);
            this.msktxtPAROLA.MouseLeave += new System.EventHandler(this.msktxtPAROLA_MouseLeave);
            // 
            // radioButtonKULLANICI
            // 
            this.radioButtonKULLANICI.AutoSize = true;
            this.radioButtonKULLANICI.Location = new System.Drawing.Point(181, 79);
            this.radioButtonKULLANICI.Name = "radioButtonKULLANICI";
            this.radioButtonKULLANICI.Size = new System.Drawing.Size(110, 20);
            this.radioButtonKULLANICI.TabIndex = 4;
            this.radioButtonKULLANICI.TabStop = true;
            this.radioButtonKULLANICI.Text = "KULLANICI";
            this.radioButtonKULLANICI.UseVisualStyleBackColor = true;
            // 
            // radioByÖNETİCİ
            // 
            this.radioByÖNETİCİ.AutoSize = true;
            this.radioByÖNETİCİ.Location = new System.Drawing.Point(72, 79);
            this.radioByÖNETİCİ.Name = "radioByÖNETİCİ";
            this.radioByÖNETİCİ.Size = new System.Drawing.Size(100, 20);
            this.radioByÖNETİCİ.TabIndex = 3;
            this.radioByÖNETİCİ.TabStop = true;
            this.radioByÖNETİCİ.Text = "YÖNETİCİ";
            this.radioByÖNETİCİ.UseVisualStyleBackColor = true;
            this.radioByÖNETİCİ.CheckedChanged += new System.EventHandler(this.radioByÖNETİCİ_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "YETKİ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "PAROLA:";
            // 
            // TXTkULLANICIAD
            // 
            this.TXTkULLANICIAD.Location = new System.Drawing.Point(130, 15);
            this.TXTkULLANICIAD.Name = "TXTkULLANICIAD";
            this.TXTkULLANICIAD.Size = new System.Drawing.Size(161, 22);
            this.TXTkULLANICIAD.TabIndex = 1;
            this.TXTkULLANICIAD.MouseEnter += new System.EventHandler(this.TXTkULLANICIAD_MouseEnter);
            this.TXTkULLANICIAD.MouseLeave += new System.EventHandler(this.TXTkULLANICIAD_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "KULLANICI AD:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(468, 326);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Georgia", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PERSONEL SİSTEMİ GİRİŞ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TXTkULLANICIAD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonKULLANICI;
        private System.Windows.Forms.RadioButton radioByÖNETİCİ;
        private System.Windows.Forms.Button buttonGİRİŞ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonçıkış;
        private System.Windows.Forms.Label lBLhKSAYI;
        private System.Windows.Forms.MaskedTextBox msktxtPAROLA;
    }
}

