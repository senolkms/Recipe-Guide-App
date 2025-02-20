using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class TarifEkleForm : Form
    {
        string connectionString = @"Server=SENOL\SENOL;Database=TarifRehberi;Integrated Security=True;";
        List<string> secilenMalzemeler = new List<string>();

        public TarifEkleForm()
        {
            InitializeComponent();
            //KategorileriYukle();
            MalzemeleriYukle();
            BirimleriYukle(cmbBirim); // Birimleri yükle
            BirimleriYukle(cmbBirim2);
        }

        private void KategorileriYukle()
        {
            cmbKategori.Items.Add("Ana Yemek");
            cmbKategori.Items.Add("Tatlı");
            cmbKategori.Items.Add("Kahvaltı");
            cmbKategori.Items.Add("Yan Yemek");
            cmbKategori.Items.Add("Çorba");
        }

        private void BirimleriYukle(ComboBox cmb)
        {
            cmb.Items.Add("Kg");
            cmb.Items.Add("Adet");
            cmb.Items.Add("Litre");
            cmb.Items.Add("Gram");
            cmb.Items.Add("Paket");
            // Diğer birimleri ekle
        }

        private void MalzemeleriYukle()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MalzemeAdi FROM Malzemeler";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cmbMalzemeler.Items.Add(reader["MalzemeAdi"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Malzemeler yüklenirken bir hata oluştu: " + ex.Message);
                }
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return; // Eğer formda eksik varsa, işlemi iptal et.
            }
            if (cmbMalzemeler.SelectedItem != null)
            {
                secilenMalzemeler.Add(cmbMalzemeler.SelectedItem.ToString());
                cmbMalzemeler.SelectedItem = null;
                MessageBox.Show("Malzeme eklendi.");
            }
            else
            {
                MessageBox.Show("Lütfen bir malzeme seçin.");
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!ValidateFormMalzeme())
            {
                return; // Eğer formda eksik varsa, işlemi iptal et.
            }
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Malzemeler (MalzemeAdi, ToplamMiktar, MalzemeBirim, BirimFiyat) VALUES (@MalzemeAdi, @ToplamMiktar, @MalzemeBirim, @BirimFiyat)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MalzemeAdi", txtYeniMalzeme.Text);
                command.Parameters.AddWithValue("@ToplamMiktar", txtAdet2.Text);
                command.Parameters.AddWithValue("@MalzemeBirim", cmbBirim2.SelectedItem.ToString());
                command.Parameters.AddWithValue("@BirimFiyat", decimal.Parse(txtBirimFiyat.Text)); // Birim fiyatı al
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Malzeme başarıyla eklendi.");
                    cmbMalzemeler.Items.Add(txtYeniMalzeme.Text);
                    txtYeniMalzeme.Clear();
                    txtAdet2.Clear();
                    txtBirimFiyat.Clear(); // TextBox'ı temizle
                    cmbBirim2.Items.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Malzeme eklenirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (cmbKategori.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir kategori seçin.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Tarifler (TarifAdi, Kategori, HazirlamaSuresi, Talimatlar, Resim) OUTPUT INSERTED.TarifID VALUES (@TarifAdi, @Kategori, @HazirlamaSuresi, @Talimatlar, @Resim)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TarifAdi", txtTarifAdi.Text);
                command.Parameters.AddWithValue("@Kategori", cmbKategori.SelectedItem.ToString());
                command.Parameters.AddWithValue("@HazirlamaSuresi", int.Parse(txtHazirlamaSuresi.Text));
                command.Parameters.AddWithValue("@Talimatlar", txtTalimatlar.Text);
                command.Parameters.AddWithValue("@Resim", txtResimYolu.Text);

                try
                {
                    connection.Open();
                    int tarifID = (int)command.ExecuteScalar();

                    foreach (var malzeme in secilenMalzemeler)
                    {
                        string malzemeQuery = "INSERT INTO TarifMalzeme (TarifID, MalzemeID, MalzemeMiktar) VALUES (@TarifID, (SELECT TOP 1 MalzemeID FROM Malzemeler WHERE MalzemeAdi = @MalzemeAdi), @MalzemeMiktar)";
                        SqlCommand malzemeCommand = new SqlCommand(malzemeQuery, connection);
                        malzemeCommand.Parameters.AddWithValue("@TarifID", tarifID);
                        malzemeCommand.Parameters.AddWithValue("@MalzemeAdi", malzeme);
                        malzemeCommand.Parameters.AddWithValue("@MalzemeMiktar", 1); // Varsayılan miktar

                        malzemeCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Tarif ve malzemeler başarıyla eklendi.");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tarif eklenirken bir hata oluştu: " + ex.Message);
                }
            }
        }
        private bool ValidateForm()
        {
            // TextBox kontrolleri
            if (string.IsNullOrWhiteSpace(txtTarifAdi.Text))
            {
                MessageBox.Show("Lütfen tarif adını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTarifAdi.Focus();
                return false;
            }
            if (cmbKategori.SelectedItem == null)
            {
                MessageBox.Show("Lütfen kategori seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbKategori.Focus();
                return false;
            }
            if (!int.TryParse(txtHazirlamaSuresi.Text, out int hazirlamaSuresi))
            {
                MessageBox.Show("Lütfen geçerli bir hazırlama süresi giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHazirlamaSuresi.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTalimatlar.Text))
            {
                MessageBox.Show("Lütfen talimat giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHazirlamaSuresi.Focus();
                return false;
            }
            if (cmbMalzemeler.SelectedItem == null)
            {
                MessageBox.Show("Lütfen malzeme seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMalzemeler.Focus();
                return false;
            }
            if (!int.TryParse(txtAdet.Text, out int adet))
            {
                MessageBox.Show("Lütfen geçerli bir adet sayısı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdet.Focus();
                return false;
            }
            if (cmbBirim.SelectedItem == null)
            {
                MessageBox.Show("Lütfen birim seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBirim.Focus();
                return false;
            }
            return true; // Eğer tüm kontroller geçildiyse true döner.
        }
        private bool ValidateFormMalzeme()
        {
            if (string.IsNullOrWhiteSpace(txtYeniMalzeme.Text))
            {
                MessageBox.Show("Lütfen malzeme adını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYeniMalzeme.Focus();
                return false;
            }
            if (!int.TryParse(txtAdet2.Text, out int adet2))
            {
                MessageBox.Show("Lütfen geçerli bir adet sayısı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdet2.Focus();
                return false;
            }
            if (cmbBirim2.SelectedItem == null)
            {
                MessageBox.Show("Lütfen birim seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBirim2.Focus();
                return false;
            }
            if (!decimal.TryParse(txtBirimFiyat.Text, out decimal birimFiyat))
            {
                MessageBox.Show("Lütfen geçerli bir birim fiyatı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBirimFiyat.Focus();
                return false;
            }

            return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 asForm = new Form1();
            asForm.ShowDialog();
        }

  
    }
}

