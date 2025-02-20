namespace WindowsFormsApp1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.textBoxMalzemeGiris = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbSirala = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.cmbKategoriFiltre = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaxMaliyet = new System.Windows.Forms.TextBox();
            this.txtMinMaliyet = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaxMalzemeSayisi = new System.Windows.Forms.TextBox();
            this.txtMinMalzemeSayisi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.meüToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tarifEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tarifGüncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tarifSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(58, 430);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1287, 326);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.Location = new System.Drawing.Point(654, 228);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(313, 48);
            this.textBox1.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.Location = new System.Drawing.Point(992, 228);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(257, 48);
            this.button3.TabIndex = 4;
            this.button3.Text = "Tarife Göre Ara";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SandyBrown;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meüToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1381, 48);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // textBoxMalzemeGiris
            // 
            this.textBoxMalzemeGiris.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxMalzemeGiris.Location = new System.Drawing.Point(654, 149);
            this.textBoxMalzemeGiris.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxMalzemeGiris.Multiline = true;
            this.textBoxMalzemeGiris.Name = "textBoxMalzemeGiris";
            this.textBoxMalzemeGiris.Size = new System.Drawing.Size(313, 47);
            this.textBoxMalzemeGiris.TabIndex = 6;
            this.textBoxMalzemeGiris.TextChanged += new System.EventHandler(this.textBoxMalzemeGiris_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(992, 145);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(257, 51);
            this.button1.TabIndex = 7;
            this.button1.Text = "Malzemeye Göre Ara";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbSirala
            // 
            this.cmbSirala.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbSirala.FormattingEnabled = true;
            this.cmbSirala.Location = new System.Drawing.Point(1048, 372);
            this.cmbSirala.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbSirala.Name = "cmbSirala";
            this.cmbSirala.Size = new System.Drawing.Size(255, 39);
            this.cmbSirala.TabIndex = 8;
            this.cmbSirala.SelectedIndexChanged += new System.EventHandler(this.cmbSirala_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.cmbKategoriFiltre);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMaxMaliyet);
            this.groupBox1.Controls.Add(this.txtMinMaliyet);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMaxMalzemeSayisi);
            this.groupBox1.Controls.Add(this.txtMinMalzemeSayisi);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(0, 63);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(625, 352);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtreleme Seçenekleri";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(355, 268);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(109, 46);
            this.button4.TabIndex = 22;
            this.button4.Text = "Sırala";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cmbKategoriFiltre
            // 
            this.cmbKategoriFiltre.FormattingEnabled = true;
            this.cmbKategoriFiltre.Location = new System.Drawing.Point(277, 215);
            this.cmbKategoriFiltre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbKategoriFiltre.Name = "cmbKategoriFiltre";
            this.cmbKategoriFiltre.Size = new System.Drawing.Size(276, 39);
            this.cmbKategoriFiltre.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 31);
            this.label8.TabIndex = 20;
            this.label8.Text = "Kategori:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(449, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 31);
            this.label7.TabIndex = 19;
            this.label7.Text = "Max";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(302, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 31);
            this.label6.TabIndex = 18;
            this.label6.Text = "Min";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 31);
            this.label5.TabIndex = 17;
            this.label5.Text = "Maliyet:";
            // 
            // txtMaxMaliyet
            // 
            this.txtMaxMaliyet.Location = new System.Drawing.Point(429, 161);
            this.txtMaxMaliyet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaxMaliyet.Name = "txtMaxMaliyet";
            this.txtMaxMaliyet.Size = new System.Drawing.Size(124, 38);
            this.txtMaxMaliyet.TabIndex = 16;
            // 
            // txtMinMaliyet
            // 
            this.txtMinMaliyet.Location = new System.Drawing.Point(277, 164);
            this.txtMinMaliyet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMinMaliyet.Name = "txtMinMaliyet";
            this.txtMinMaliyet.Size = new System.Drawing.Size(124, 38);
            this.txtMinMaliyet.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 31);
            this.label4.TabIndex = 14;
            this.label4.Text = "Malzeme Sayısı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(467, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 31);
            this.label3.TabIndex = 13;
            this.label3.Text = "Max";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 31);
            this.label2.TabIndex = 12;
            this.label2.Text = "Min";
            // 
            // txtMaxMalzemeSayisi
            // 
            this.txtMaxMalzemeSayisi.Location = new System.Drawing.Point(429, 72);
            this.txtMaxMalzemeSayisi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaxMalzemeSayisi.Name = "txtMaxMalzemeSayisi";
            this.txtMaxMalzemeSayisi.Size = new System.Drawing.Size(124, 38);
            this.txtMaxMalzemeSayisi.TabIndex = 11;
            // 
            // txtMinMalzemeSayisi
            // 
            this.txtMinMalzemeSayisi.Location = new System.Drawing.Point(277, 72);
            this.txtMinMalzemeSayisi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMinMalzemeSayisi.Name = "txtMinMalzemeSayisi";
            this.txtMinMalzemeSayisi.Size = new System.Drawing.Size(124, 38);
            this.txtMinMalzemeSayisi.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(879, 375);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 31);
            this.label1.TabIndex = 9;
            this.label1.Text = "Sıralama:";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button5.Location = new System.Drawing.Point(992, 294);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(257, 47);
            this.button5.TabIndex = 12;
            this.button5.Text = "Temizle";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsFormsApp1.Properties.Resources.images__2_;
            this.pictureBox2.Location = new System.Drawing.Point(1218, 51);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(138, 87);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.Adsız;
            this.pictureBox1.Location = new System.Drawing.Point(1244, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // meüToolStripMenuItem
            // 
            this.meüToolStripMenuItem.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.indir__1_;
            this.meüToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tarifEkleToolStripMenuItem,
            this.tarifGüncelleToolStripMenuItem,
            this.tarifSilToolStripMenuItem});
            this.meüToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.meüToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.meüToolStripMenuItem.Name = "meüToolStripMenuItem";
            this.meüToolStripMenuItem.Size = new System.Drawing.Size(210, 42);
            this.meüToolStripMenuItem.Text = "Tarif İşlemleri";
            // 
            // tarifEkleToolStripMenuItem
            // 
            this.tarifEkleToolStripMenuItem.BackColor = System.Drawing.Color.DarkSalmon;
            this.tarifEkleToolStripMenuItem.Name = "tarifEkleToolStripMenuItem";
            this.tarifEkleToolStripMenuItem.Size = new System.Drawing.Size(288, 42);
            this.tarifEkleToolStripMenuItem.Text = "Tarif Ekle";
            this.tarifEkleToolStripMenuItem.Click += new System.EventHandler(this.tarifEkleToolStripMenuItem_Click);
            // 
            // tarifGüncelleToolStripMenuItem
            // 
            this.tarifGüncelleToolStripMenuItem.BackColor = System.Drawing.Color.DarkSalmon;
            this.tarifGüncelleToolStripMenuItem.Name = "tarifGüncelleToolStripMenuItem";
            this.tarifGüncelleToolStripMenuItem.Size = new System.Drawing.Size(288, 42);
            this.tarifGüncelleToolStripMenuItem.Text = "Tarif Güncelle";
            this.tarifGüncelleToolStripMenuItem.Click += new System.EventHandler(this.tarifGüncelleToolStripMenuItem_Click);
            // 
            // tarifSilToolStripMenuItem
            // 
            this.tarifSilToolStripMenuItem.BackColor = System.Drawing.Color.DarkSalmon;
            this.tarifSilToolStripMenuItem.Name = "tarifSilToolStripMenuItem";
            this.tarifSilToolStripMenuItem.Size = new System.Drawing.Size(288, 42);
            this.tarifSilToolStripMenuItem.Text = "Tarif Sil";
            this.tarifSilToolStripMenuItem.Click += new System.EventHandler(this.tarifSilToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1381, 784);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxMalzemeGiris);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.cmbSirala);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem meüToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tarifEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tarifGüncelleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tarifSilToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxMalzemeGiris;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbSirala;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaxMaliyet;
        private System.Windows.Forms.TextBox txtMinMaliyet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaxMalzemeSayisi;
        private System.Windows.Forms.TextBox txtMinMalzemeSayisi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox cmbKategoriFiltre;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

