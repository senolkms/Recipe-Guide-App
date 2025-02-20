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
    public partial class Form1 : Form
    {
        string connectionString = @"Server=SENOL\SENOL;Database=TarifRehberi;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VerileriGetir();  // Form açıldığında veriler yüklensin
            cmbSirala.Items.Add("Maliyete Göre Artan");
            cmbSirala.Items.Add("Maliyete Göre Azalan");
            cmbSirala.Items.Add("Malzeme Sayısına Göre Azalan");
            cmbSirala.Items.Add("Malzeme Sayısına Göre Artan");
            cmbSirala.Items.Add("Hazırlama Süresine Göre Azalan");
            cmbSirala.Items.Add("Hazırlama Süresine Göre Artan");
            KategorileriYukle();

        }
        private void KategorileriYukle()
        {
            cmbKategoriFiltre.Items.Add("Ana Yemek");
            cmbKategoriFiltre.Items.Add("Tatlı");
            cmbKategoriFiltre.Items.Add("Kahvaltı");
            cmbKategoriFiltre.Items.Add("Yan Yemek");
            cmbKategoriFiltre.Items.Add("Çorba");
        }
        private void VerileriGetir()
        {
            // SQL sorgusu: Tarifler tablosundaki tüm verileri çek
            string query = "SELECT TarifID,TarifAdi FROM Tarifler";

            // SQL bağlantısı ve komutunu kullanarak veritabanından veri çekme işlemi
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);  // Veriyi DataTable içine doldur

                    // DataGridView'e verileri bağla
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void tarifEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Tarif ekleme formu açılıyor
            TarifEkleForm ekleForm = new TarifEkleForm();
            ekleForm.ShowDialog();  // Yeni formu modal olarak aç

        }
        private void tarifGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Tarif ekleme formu açılıyor
            TarifGuncelleForm guncelleForm = new TarifGuncelleForm();
            guncelleForm.ShowDialog();  // Yeni formu modal olarak aç
        }
        private void tarifSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Tarif ekleme formu açılıyor
            TarifSilForm silForm = new TarifSilForm();
            silForm.ShowDialog();  // Yeni formu modal olarak aç
        }
        private void button1_Click(object sender, EventArgs e)
        {
            {
                List<string> kullaniciMalzemeleri = textBoxMalzemeGiris.Text
                    .Split(',')
                    .Select(m => m.Trim().ToLower())
                    .ToList();

                MalzemelereGoreTarifGetir(kullaniciMalzemeleri);
            }

        }
        private void MalzemelereGoreTarifGetir(List<string> kullaniciMalzemeleri)
        {
            string malzemelerListesi = string.Join(",", kullaniciMalzemeleri.Select(m => "'" + m.Replace("'", "''") + "'"));

            string query = $@"
    SELECT T.TarifID, T.TarifAdi, 
           COUNT(TM.MalzemeID) AS EşleşenMalzemeSayisi, 
           (COUNT(TM.MalzemeID) * 100.0 / (SELECT COUNT(*) FROM TarifMalzeme WHERE TarifID = T.TarifID)) AS EslesmeYuzdesi
    FROM Tarifler T
    INNER JOIN TarifMalzeme TM ON T.TarifID = TM.TarifID
    INNER JOIN Malzemeler M ON TM.MalzemeID = M.MalzemeID
    WHERE M.MalzemeAdi IN ({malzemelerListesi})
    GROUP BY T.TarifID, T.TarifAdi
    HAVING COUNT(TM.MalzemeID) > 0  
    ORDER BY EslesmeYuzdesi DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tarifler getirilirken bir hata oluştu: " + ex.Message);
                }
            }
        }
        private void TarifleriGetir(string searchTerm = "")
        {
            string query = "SELECT * FROM Tarifler";
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query += " WHERE TarifAdi LIKE @searchTerm";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        dataAdapter.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                    }

                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            TarifleriGetir(textBox1.Text);

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Seçilen satırın TarifID'sini al
            if (e.RowIndex >= 0)
            {
                int tarifID = (int)dataGridView1.Rows[e.RowIndex].Cells["TarifID"].Value;
                this.Hide();
                // Yeni tarif detay formunu aç
                TarifDetayForm detayForm = new TarifDetayForm(tarifID);
                detayForm.ShowDialog(); // Modal olarak aç
                //this.Show();
                
            }
        }
        private void SiralamaKriterineGoreTarifleriGetir(string siralamaKriteri)
        {
            string query = @"
SELECT T.TarifAdi, 
       T.HazirlamaSuresi, 
       (SELECT SUM(TM.MalzemeMiktar * M.BirimFiyat ) 
        FROM TarifMalzeme TM
        JOIN Malzemeler M ON TM.MalzemeID = M.MalzemeID
        WHERE TM.TarifID = T.TarifID) AS TarifMaliyeti,
       (SELECT COUNT(*) 
        FROM TarifMalzeme TM
        WHERE TM.TarifID = T.TarifID) AS MalzemeSayisi
FROM Tarifler T ";

            // Sıralama kriterine göre sorguya ORDER BY ekliyoruz
            switch (siralamaKriteri)
            {
                case "Maliyete Göre Artan":
                    query += " ORDER BY TarifMaliyeti ASC"; // En düşükten en yükseğe
                    break;
                case "Maliyete Göre Azalan":
                    query += " ORDER BY TarifMaliyeti DESC"; // En düşükten en yükseğe
                    break;
                case "Malzeme Sayısına Göre Azalan":
                    query += " ORDER BY MalzemeSayisi DESC"; // En fazla malzemeden en aza
                    break;
                case "Malzeme Sayısına Göre Artan":
                    query += " ORDER BY MalzemeSayisi ASC"; // En fazla malzemeden en aza
                    break;
                case "Hazırlama Süresine Göre Azalan":
                    query += " ORDER BY HazirlamaSuresi DESC"; // En kısa süreden en uzuna
                    break;
                case "Hazırlama Süresine Göre Artan":
                    query += " ORDER BY HazirlamaSuresi ASC"; // En uzun süreden en kısaya
                    break;
                default:
                    query += "  ORDER BY TarifAdi ASC"; // Varsayılan: Tarif adına göre sıralama
                    break;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable); // Verileri DataTable içine doldur

                    dataGridView1.DataSource = dataTable; // DataGridView'e bağla
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
                }
            }
        }
        private void cmbSirala_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secilenKriter = cmbSirala.SelectedItem.ToString();
            SiralamaKriterineGoreTarifleriGetir(secilenKriter);
        }

        private void button4_Click(object sender, EventArgs e)
        {
                // Kategori, malzeme sayısı ve maliyet aralığını filtrelemek için değişkenler
                string selectedCategory = cmbKategoriFiltre.SelectedItem?.ToString();
                int minMalzemeSayisi = string.IsNullOrEmpty(txtMinMalzemeSayisi.Text) ? 0 : int.Parse(txtMinMalzemeSayisi.Text);
                int maxMalzemeSayisi = string.IsNullOrEmpty(txtMaxMalzemeSayisi.Text) ? int.MaxValue : int.Parse(txtMaxMalzemeSayisi.Text);
                decimal minMaliyet = string.IsNullOrEmpty(txtMinMaliyet.Text) ? 0 : decimal.Parse(txtMinMaliyet.Text);
                decimal maxMaliyet = string.IsNullOrEmpty(txtMaxMaliyet.Text) ? decimal.MaxValue : decimal.Parse(txtMaxMaliyet.Text);

                // SQL sorgusu oluşturma
                string query = @"SELECT T.TarifID, T.TarifAdi, T.Kategori, T.HazirlamaSuresi,
                    (SELECT COUNT(TM.MalzemeID) FROM TarifMalzeme TM WHERE TM.TarifID = T.TarifID) AS MalzemeSayisi,
                    (SELECT SUM(M.BirimFiyat * TM.MalzemeMiktar) 
                     FROM TarifMalzeme TM 
                     JOIN Malzemeler M ON TM.MalzemeID = M.MalzemeID 
                     WHERE TM.TarifID = T.TarifID) AS Maliyet
             FROM Tarifler T
             WHERE 1 = 1"; // Dinamik sorgu için başlangıç

                // Kategoriye göre filtre
                if (!string.IsNullOrEmpty(selectedCategory))
                {
                    query += " AND T.Kategori = @Kategori";
                }

                // Malzeme sayısına göre filtre (min-max aralığı)
                if (minMalzemeSayisi > 0 || maxMalzemeSayisi < int.MaxValue)
                {
                    query += @" AND (SELECT COUNT(TM.MalzemeID) 
                 FROM TarifMalzeme TM WHERE TM.TarifID = T.TarifID) 
                 BETWEEN @MinMalzemeSayisi AND @MaxMalzemeSayisi";
                }

                // Maliyet aralığına göre filtre
                if (minMaliyet > 0 || maxMaliyet < decimal.MaxValue)
                {
                    query += @" AND (SELECT SUM(M.BirimFiyat * TM.MalzemeMiktar) 
                 FROM TarifMalzeme TM 
                 JOIN Malzemeler M ON TM.MalzemeID = M.MalzemeID 
                 WHERE TM.TarifID = T.TarifID) BETWEEN @MinMaliyet AND @MaxMaliyet";
                }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                // Parametreleri ekle
                if (!string.IsNullOrEmpty(selectedCategory))
                {
                    command.Parameters.AddWithValue("@Kategori", selectedCategory);
                }

                if (minMalzemeSayisi > 0 || maxMalzemeSayisi < int.MaxValue)
                {
                    command.Parameters.AddWithValue("@MinMalzemeSayisi", minMalzemeSayisi);
                    command.Parameters.AddWithValue("@MaxMalzemeSayisi", maxMalzemeSayisi);
                }

                if (minMaliyet > 0 || maxMaliyet < decimal.MaxValue)
                {
                    command.Parameters.AddWithValue("@MinMaliyet", minMaliyet);
                    command.Parameters.AddWithValue("@MaxMaliyet", maxMaliyet);
                }

                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // DataGridView'e verileri bağlama
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Filtreleme sırasında bir hata oluştu: " + ex.Message);
                }

            }
        }
        
        private void textBoxMalzemeGiris_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Tüm TextBox'ları temizler
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
            }
            string query = "SELECT TarifID,TarifAdi FROM Tarifler";

            // SQL bağlantısı ve komutunu kullanarak veritabanından veri çekme işlemi
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);  // Veriyi DataTable içine doldur

                    // DataGridView'e verileri bağla
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            TarifOnerForm onerForm = new TarifOnerForm();
            onerForm.ShowDialog();
        }
    }
}
