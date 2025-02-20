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
    public partial class TarifOnerForm : Form
    {
        string connectionString = @"Server=SENOL\SENOL;Database=TarifRehberi;Integrated Security=True;";
        public TarifOnerForm()
        {
            InitializeComponent();
            VerileriGetir();
            MalzemeleriYukle();
        }
        public class Malzeme
        {
            public string MalzemeAdi { get; set; }
        }

        List<Malzeme> secilenMalzemeler = new List<Malzeme>();
        private void TarifOnerForm_Load(object sender, EventArgs e)
        {

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
        private void VerileriGetir()
        {
            // SQL sorgusu: Tarifler tablosundaki tüm verileri çek
            string query = "SELECT TarifID, TarifAdi, Kategori, HazirlamaSuresi, Talimatlar FROM Tarifler";

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

        private void UygunTarifleriGetirVeRenklendir()
        {
            string malzemelerListesi = string.Join(",", secilenMalzemeler.Select(m => "'" + m.MalzemeAdi + "'"));

            if (string.IsNullOrEmpty(malzemelerListesi))
            {
                MessageBox.Show("Lütfen en az bir malzeme seçin.");
                return;
            }

            string query = $@"
    SELECT T.TarifID, T.TarifAdi, 
           COUNT(TM.MalzemeID) AS GerekliMalzemeSayisi,
           SUM(CASE 
                WHEN M.MalzemeAdi IN ({malzemelerListesi}) THEN 1 
                ELSE 0 
           END) AS EslesenMalzemeSayisi,
           STRING_AGG(CASE 
                      WHEN M.MalzemeAdi NOT IN ({malzemelerListesi}) THEN M.MalzemeAdi
                      WHEN M.MalzemeAdi IN ({malzemelerListesi}) AND M.ToplamMiktar < TM.MalzemeMiktar THEN 
                           M.MalzemeAdi + ' (Eksik: ' + CAST(TM.MalzemeMiktar - M.ToplamMiktar AS VARCHAR) + ' ' + M.MalzemeBirim + ')'
                      ELSE NULL 
                      END, ', ') AS EksikMalzemeler,
           SUM(TM.MalzemeMiktar * M.BirimFiyat) AS TarifMaliyeti,
           SUM(CASE 
                WHEN M.MalzemeAdi NOT IN ({malzemelerListesi}) THEN TM.MalzemeMiktar * M.BirimFiyat
                WHEN M.MalzemeAdi IN ({malzemelerListesi}) AND M.ToplamMiktar < TM.MalzemeMiktar THEN 
                     (TM.MalzemeMiktar - M.ToplamMiktar) * M.BirimFiyat
                ELSE 0 
           END) AS EksikMalzemeMaliyeti
    FROM Tarifler T
    JOIN TarifMalzeme TM ON T.TarifID = TM.TarifID
    JOIN Malzemeler M ON TM.MalzemeID = M.MalzemeID
    GROUP BY T.TarifID, T.TarifAdi
    HAVING SUM(CASE WHEN M.MalzemeAdi IN ({malzemelerListesi}) THEN 1 ELSE 0 END) >= 3
    ";

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

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        int eslesenMalzemeSayisi = row.Cells["EslesenMalzemeSayisi"].Value != null
                                                   ? Convert.ToInt32(row.Cells["EslesenMalzemeSayisi"].Value)
                                                   : 0;

                        int gerekliMalzemeSayisi = row.Cells["GerekliMalzemeSayisi"].Value != null
                                                   ? Convert.ToInt32(row.Cells["GerekliMalzemeSayisi"].Value)
                                                   : 0;

                        string eksikMalzemeler = row.Cells["EksikMalzemeler"].Value?.ToString() ?? "";

                        row.Cells["EksikMalzemeler"].Value = eksikMalzemeler;

                        decimal tarifMaliyeti = row.Cells["TarifMaliyeti"].Value != null
                                                ? Convert.ToDecimal(row.Cells["TarifMaliyeti"].Value)
                                                : 0;

                        decimal eksikMalzemeMaliyeti = row.Cells["EksikMalzemeMaliyeti"].Value != null
                                                       ? Convert.ToDecimal(row.Cells["EksikMalzemeMaliyeti"].Value)
                                                       : 0;

                        row.Cells["TarifMaliyeti"].Value = tarifMaliyeti;
                        row.Cells["EksikMalzemeMaliyeti"].Value = eksikMalzemeMaliyeti;

                        if (eslesenMalzemeSayisi >= 3)
                        {
                            if (string.IsNullOrEmpty(eksikMalzemeler))
                            {
                                row.DefaultCellStyle.BackColor = Color.Green;
                            }
                            else
                            {
                                row.DefaultCellStyle.BackColor = Color.Red;
                            }
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.Red;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tarifler getirilirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void btnMalzemeEkle_Click_1(object sender, EventArgs e)
        {
            // Kullanıcının girdiği malzeme bilgilerini al
            string malzemeAdi = cmbMalzemeler.SelectedItem.ToString();
         
            // Malzemeyi listeye ekle
            secilenMalzemeler.Add(new Malzeme { MalzemeAdi = malzemeAdi });
            listBoxMalzemeler.Items.Add(malzemeAdi); 

            // Kullanıcıya bilgi ver
            MessageBox.Show($"{malzemeAdi} malzemesi eklendi.");

            // Formu temizle
            cmbMalzemeler.SelectedIndex = -1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            UygunTarifleriGetirVeRenklendir();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Seçilen satırın TarifID'sini al
            if (e.RowIndex >= 0)
            {
                int tarifID = (int)dataGridView1.Rows[e.RowIndex].Cells["TarifID"].Value;
                // Yeni tarif detay formunu aç
                TarifDetayForm detayForm = new TarifDetayForm(tarifID);
                detayForm.ShowDialog(); // Modal olarak aç
                                        //this.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 asForm = new Form1();
            asForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBoxMalzemeler.Items.Clear();
            secilenMalzemeler.Clear();
            VerileriGetir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ListBox'ta seçili bir öğe var mı kontrol edilir
            if (listBoxMalzemeler.SelectedItem != null)
            {
                // Seçili öğeyi al
                string seciliMalzeme = listBoxMalzemeler.SelectedItem.ToString();

                // ListBox'tan seçili malzemeyi kaldır
                listBoxMalzemeler.Items.Remove(seciliMalzeme);

                // secilenMalzemeler listesinden de kaldır
                secilenMalzemeler.RemoveAll(m => m.MalzemeAdi == seciliMalzeme);
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz bir malzemeyi seçin.");
            }
        }
    }
}
