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
    public partial class TarifGuncelleForm : Form
    {
        string connectionString = @"Server=SENOL\SENOL;Database=TarifRehberi;Integrated Security=True;";

        public TarifGuncelleForm()
        {
            InitializeComponent();
            KategorileriYukle();
        }
        private void TemizleTextBoxlar()
        {
            txtTarifID.Clear();
            txtTarifAdi.Clear();
            cmbKategori.SelectedIndex = -1;
            txtHazirlamaSuresi.Clear();
            txtTalimatlar.Clear();
        }

        private void TarifGuncelleForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TarifID, TarifAdi, Kategori, HazirlamaSuresi, Talimatlar FROM Tarifler";
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
        private void KategorileriYukle()
        {
            cmbKategori.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT Kategori FROM Tarifler";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cmbKategori.Items.Add(reader["Kategori"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kategoriler yüklenirken bir hata oluştu: " + ex.Message);
                }
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtTarifID.Text = dataGridView1.SelectedRows[0].Cells["TarifID"].Value.ToString();
                txtTarifAdi.Text = dataGridView1.SelectedRows[0].Cells["TarifAdi"].Value.ToString();
                cmbKategori.SelectedItem = dataGridView1.SelectedRows[0].Cells["Kategori"].Value.ToString();
                txtHazirlamaSuresi.Text = dataGridView1.SelectedRows[0].Cells["HazirlamaSuresi"].Value.ToString();
                txtTalimatlar.Text = dataGridView1.SelectedRows[0].Cells["Talimatlar"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tarifID;
            if (int.TryParse(txtTarifID.Text, out tarifID))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Tarifler SET TarifAdi = @TarifAdi, Kategori = @Kategori, HazirlamaSuresi = @HazirlamaSuresi, Talimatlar = @Talimatlar WHERE TarifID = @TarifID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TarifAdi", txtTarifAdi.Text);
                    command.Parameters.AddWithValue("@Kategori", cmbKategori.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@HazirlamaSuresi", int.Parse(txtHazirlamaSuresi.Text));
                    command.Parameters.AddWithValue("@Talimatlar", txtTalimatlar.Text);
                    command.Parameters.AddWithValue("@TarifID", tarifID);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Tarif başarıyla güncellendi.");
                            TarifGuncelleForm_Load(null, null); // Listeyi yeniden yükle
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
                        MessageBox.Show("Tarif güncellenirken bir hata oluştu: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Geçerli bir Tarif ID girin.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 asForm = new Form1();
            asForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TemizleTextBoxlar();
        }
    }
}
