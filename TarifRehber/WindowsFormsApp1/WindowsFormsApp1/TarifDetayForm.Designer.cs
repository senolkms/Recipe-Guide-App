namespace WindowsFormsApp1
{
    partial class TarifDetayForm
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
            this.txtTarifAdi = new System.Windows.Forms.TextBox();
            this.txtKategori = new System.Windows.Forms.TextBox();
            this.txtHazirlamaSuresi = new System.Windows.Forms.TextBox();
            this.txtTalimatlar = new System.Windows.Forms.TextBox();
            this.txtMaliyet = new System.Windows.Forms.TextBox();
            this.txtMalzemeler = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTarifAdi
            // 
            this.txtTarifAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTarifAdi.Location = new System.Drawing.Point(341, 74);
            this.txtTarifAdi.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtTarifAdi.Name = "txtTarifAdi";
            this.txtTarifAdi.Size = new System.Drawing.Size(228, 38);
            this.txtTarifAdi.TabIndex = 0;
            // 
            // txtKategori
            // 
            this.txtKategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKategori.Location = new System.Drawing.Point(341, 126);
            this.txtKategori.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtKategori.Name = "txtKategori";
            this.txtKategori.Size = new System.Drawing.Size(228, 38);
            this.txtKategori.TabIndex = 1;
            // 
            // txtHazirlamaSuresi
            // 
            this.txtHazirlamaSuresi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtHazirlamaSuresi.Location = new System.Drawing.Point(341, 176);
            this.txtHazirlamaSuresi.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtHazirlamaSuresi.Name = "txtHazirlamaSuresi";
            this.txtHazirlamaSuresi.Size = new System.Drawing.Size(228, 38);
            this.txtHazirlamaSuresi.TabIndex = 2;
            // 
            // txtTalimatlar
            // 
            this.txtTalimatlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTalimatlar.Location = new System.Drawing.Point(208, 239);
            this.txtTalimatlar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtTalimatlar.Multiline = true;
            this.txtTalimatlar.Name = "txtTalimatlar";
            this.txtTalimatlar.Size = new System.Drawing.Size(244, 229);
            this.txtTalimatlar.TabIndex = 3;
            // 
            // txtMaliyet
            // 
            this.txtMaliyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMaliyet.Location = new System.Drawing.Point(692, 489);
            this.txtMaliyet.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtMaliyet.Name = "txtMaliyet";
            this.txtMaliyet.Size = new System.Drawing.Size(124, 38);
            this.txtMaliyet.TabIndex = 4;
            this.txtMaliyet.TextChanged += new System.EventHandler(this.txtMaliyet_TextChanged);
            // 
            // txtMalzemeler
            // 
            this.txtMalzemeler.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMalzemeler.Location = new System.Drawing.Point(692, 271);
            this.txtMalzemeler.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtMalzemeler.Multiline = true;
            this.txtMalzemeler.Name = "txtMalzemeler";
            this.txtMalzemeler.Size = new System.Drawing.Size(235, 181);
            this.txtMalzemeler.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(25, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 38);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tarif Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(25, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 38);
            this.label2.TabIndex = 7;
            this.label2.Text = "Kategori:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(25, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(314, 38);
            this.label3.TabIndex = 8;
            this.label3.Text = "Hazirlanma Süresi(dk):";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(25, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 38);
            this.label4.TabIndex = 9;
            this.label4.Text = "Talimatlar:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(503, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 38);
            this.label5.TabIndex = 10;
            this.label5.Text = "Malzemeler:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(503, 489);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 38);
            this.label6.TabIndex = 11;
            this.label6.Text = "Maliyet:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(677, 73);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(281, 170);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 42);
            this.button1.TabIndex = 13;
            this.button1.Text = "Geri Dön";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TarifDetayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1000, 646);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMalzemeler);
            this.Controls.Add(this.txtMaliyet);
            this.Controls.Add(this.txtTalimatlar);
            this.Controls.Add(this.txtHazirlamaSuresi);
            this.Controls.Add(this.txtKategori);
            this.Controls.Add(this.txtTarifAdi);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "TarifDetayForm";
            this.Text = "TarifDetayForm";
            this.Load += new System.EventHandler(this.TarifDetayForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTarifAdi;
        private System.Windows.Forms.TextBox txtKategori;
        private System.Windows.Forms.TextBox txtHazirlamaSuresi;
        private System.Windows.Forms.TextBox txtTalimatlar;
        private System.Windows.Forms.TextBox txtMaliyet;
        private System.Windows.Forms.TextBox txtMalzemeler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
    }
}