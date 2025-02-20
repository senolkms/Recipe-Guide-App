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
    public partial class TarifDetayForm : Form
    {
        private string connectionString = @"Server=SENOL\SENOL;Database=TarifRehberi;Integrated Security=True;";
        private int tarifID;
        
        public TarifDetayForm(int id)
        {
            InitializeComponent();
            tarifID = id;
            LoadTarifDetails();
        }
        private void LoadTarifDetails()
        {
            string query = "SELECT * FROM Tarifler WHERE TarifID = @TarifID";
            string malzemelerQuery = @"
        SELECT M.MalzemeAdi, TM.MalzemeMiktar, M.BirimFiyat, 
               (TM.MalzemeMiktar * M.BirimFiyat) AS ToplamMaliyet
        FROM TarifMalzeme TM
        JOIN Malzemeler M ON TM.MalzemeID = M.MalzemeID
        WHERE TM.TarifID = @TarifID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlCommand malzemelerCommand = new SqlCommand(malzemelerQuery, connection);
                command.Parameters.AddWithValue("@TarifID", tarifID);
                malzemelerCommand.Parameters.AddWithValue("@TarifID", tarifID);

                try
                {
                    connection.Open();

                    // Tarif detayları
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        txtTarifAdi.Text = reader["TarifAdi"].ToString();
                        txtKategori.Text = reader["Kategori"].ToString();
                        txtHazirlamaSuresi.Text = reader["HazirlamaSuresi"].ToString();
                        txtTalimatlar.Text = reader["Talimatlar"].ToString();
                        // Resim yolunu veritabanından al ve PictureBox'a yükle
                        string imagePath = reader["Resim"].ToString(); // Veritabanında saklanan dosya yolu
                        if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                        {
                            pictureBox1.Image = Image.FromFile(imagePath); // Resmi PictureBox'a yükle
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Görseli PictureBox boyutuna göre ayarla
                        }
                        else
                        {
                            pictureBox1.Image = null; // Eğer görsel yoksa boş bırak
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tarif bulunamadı.");
                        return;
                    }
                    reader.Close();

                    // Malzemeler ve maliyet hesaplama
                    SqlDataReader malzemelerReader = malzemelerCommand.ExecuteReader();
                    StringBuilder malzemelerBuilder = new StringBuilder();
                    decimal toplamMaliyet = 0;

                    while (malzemelerReader.Read())
                    {
                        string malzemeAdi = malzemelerReader["MalzemeAdi"].ToString();
                        string malzemeMiktar = malzemelerReader["MalzemeMiktar"].ToString();
                        decimal birimFiyat = Convert.ToDecimal(malzemelerReader["BirimFiyat"]);
                        decimal toplamMalzemeMaliyeti = Convert.ToDecimal(malzemelerReader["ToplamMaliyet"]);

                        malzemelerBuilder.AppendLine($"{malzemeAdi} - {malzemeMiktar} - {birimFiyat:C}");
                        toplamMaliyet += toplamMalzemeMaliyeti;
                    }

                    // TextBox'ları doldur
                    txtMalzemeler.Text = malzemelerBuilder.ToString();
                    txtMaliyet.Text = toplamMaliyet.ToString("C"); // Para birimi formatında göster
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tarif detayları yüklenirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void TarifDetayForm_Load(object sender, EventArgs e)
        {

        }

        private void txtMaliyet_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 asForm = new Form1();
            asForm.ShowDialog();
            
        }
    }
}
