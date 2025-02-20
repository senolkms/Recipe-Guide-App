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
    public partial class TarifSilForm : Form
    {
        string connectionString = @"Server=SENOL\SENOL;Database=TarifRehberi;Integrated Security=True;";

        public TarifSilForm()
        {
            InitializeComponent();
            AutoCompleteTarifAdlariYukle();
        }

        private void TarifSilForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TarifID, TarifAdi FROM Tarifler";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table; // dataGridView'ine tabloyu ekle
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tarifler yüklenirken bir hata oluştu: " + ex.Message);
                }
            }
        }
        private void TemizleTextBoxlar()
        {
            txtTarifID.Clear();
            txtTarifAdi.Clear();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Seçilen satırdaki verileri TextBox'lara doldur
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int tarifID = (int)dataGridView1.SelectedRows[0].Cells["TarifID"].Value;

                txtTarifID.Text = dataGridView1.SelectedRows[0].Cells["TarifID"].Value.ToString();
                txtTarifAdi.Text = dataGridView1.SelectedRows[0].Cells["TarifAdi"].Value.ToString();
                LoadTarifImage(tarifID);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Öncelikle ID ile kontrol edelim
            int tarifID;
            if (int.TryParse(txtTarifID.Text, out tarifID))
            {
                TarifIDIleSil(tarifID);
            }
            // Eğer ID boşsa ya da geçersizse, isme göre silmeye çalışalım
            else if (!string.IsNullOrWhiteSpace(txtTarifAdi.Text))
            {
                TarifAdiIleSil(txtTarifAdi.Text);
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir Tarif ID veya Tarif Adı giriniz.");
            }
        }
        // ID'ye göre tarif silme fonksiyonu
        private void TarifIDIleSil(int tarifID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Tarifler WHERE TarifID = @TarifID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TarifID", tarifID);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Tarif başarıyla silindi.");
                        TarifSilForm_Load(null, null); // Grid'i yeniden yükle
                        TemizleTextBoxlar();
                    }
                    else
                    {
                        MessageBox.Show("Bu ID'ye ait bir tarif bulunamadı.");
                        TemizleTextBoxlar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tarif silinirken bir hata oluştu: " + ex.Message);
                }
            }
        }
        // İsimle tarif silme fonksiyonu
        private void TarifAdiIleSil(string tarifAdi)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Tarifler WHERE TarifAdi = @TarifAdi";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TarifAdi", tarifAdi);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Tarif başarıyla silindi.");
                        TarifSilForm_Load(null, null); // Grid'i yeniden yükle
                        TemizleTextBoxlar();
                    }
                    else
                    {
                        MessageBox.Show("Bu ada sahip bir tarif bulunamadı.");
                        TemizleTextBoxlar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tarif silinirken bir hata oluştu: " + ex.Message);
                }
            }
        }
        private void AutoCompleteTarifAdlariYukle()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TarifAdi FROM Tarifler";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        autoCompleteCollection.Add(reader["TarifAdi"].ToString());
                    }

                    // TextBox'ımıza AutoComplete özelliğini ekleyelim
                    txtTarifAdi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtTarifAdi.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtTarifAdi.AutoCompleteCustomSource = autoCompleteCollection;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tarif adları yüklenirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Öncelikle ID ile kontrol edelim
            int tarifID;
            if (int.TryParse(txtTarifID.Text, out tarifID))
            {
                TarifIDIleSil(tarifID);
            }
            // Eğer ID boşsa ya da geçersizse, isme göre silmeye çalışalım
            else if (!string.IsNullOrWhiteSpace(txtTarifAdi.Text))
            {
                TarifAdiIleSil(txtTarifAdi.Text);
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir Tarif ID veya Tarif Adı giriniz.");
            }
        }
        private void LoadTarifImage(int tarifID)
        {
            string query = "SELECT Resim FROM Tarifler WHERE TarifID = @TarifID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TarifID", tarifID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string imagePath = reader["Resim"].ToString(); // Resim dosya yolu

                        // Eğer resim yolu boş değilse resmi yükle
                        if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                        {
                            pictureBox1.Image = Image.FromFile(imagePath); // Resmi yükle
                        }
                        else
                        {
                            pictureBox1.Image = null; // Resim yolu geçersizse resmi temizle
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Resim yüklenirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 asForm = new Form1();
            asForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Öncelikle ID ile kontrol edelim
            int tarifID;
            if (int.TryParse(txtTarifID.Text, out tarifID))
            {
                TarifIDIleSil(tarifID);
            }
            // Eğer ID boşsa ya da geçersizse, isme göre silmeye çalışalım
            else if (!string.IsNullOrWhiteSpace(txtTarifAdi.Text))
            {
                TarifAdiIleSil(txtTarifAdi.Text);
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir Tarif ID veya Tarif Adı giriniz.");
            }
        }
    }
}
