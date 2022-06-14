using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OrnekProje
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=ICMEN\\SQLEXPRESS;Initial Catalog=kitaplik;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Personel",baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kayitEkle = new SqlCommand("insert into Personel (PersonelNo,PersonelAd,PersonelSoyad,PersonelGorev,PersonelMaas,PersonelSehir,PersonelBilgi) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglanti);
            kayitEkle.Parameters.AddWithValue("@p1", textBox1.Text);
            kayitEkle.Parameters.AddWithValue("@p2", textBox2.Text);
            kayitEkle.Parameters.AddWithValue("@p3", textBox3.Text);
            kayitEkle.Parameters.AddWithValue("@p4", textBox4.Text);
            kayitEkle.Parameters.AddWithValue("@p5", textBox5.Text);
            kayitEkle.Parameters.AddWithValue("@p6", textBox6.Text);
            kayitEkle.Parameters.AddWithValue("@p7", textBox7.Text);
            kayitEkle.ExecuteNonQuery();
            baglanti.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutSil = new SqlCommand("Delete from Personel where PersonelAd = @adi", baglanti);
            komutSil.Parameters.AddWithValue("@adi", textBox2.Text);
            komutSil.ExecuteNonQuery();
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            string no = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            string ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            string soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            string gorev = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            string maas = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            string sehir = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            string bilgi = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

            textBox1.Text = no;
            textBox2.Text = ad;
            textBox3.Text = soyad;
            textBox4.Text = gorev;
            textBox5.Text = maas;
            textBox6.Text = sehir;
            textBox7.Text = bilgi;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutGuncelle = new SqlCommand("update Personel set PersonelNo = @p1, PersonelAd = @p2,PersonelSoyad = @p3,PersonelGorev = @p4,PersonelMaas = @p5,PersonelSehir = @p6,PersonelBilgi = @p7 where PersonelNo = @p1", baglanti);
            komutGuncelle.Parameters.AddWithValue("@p1", textBox1.Text);
            komutGuncelle.Parameters.AddWithValue("@p2", textBox2.Text);
            komutGuncelle.Parameters.AddWithValue("@p3", textBox3.Text);
            komutGuncelle.Parameters.AddWithValue("@p4", textBox4.Text);
            komutGuncelle.Parameters.AddWithValue("@p5", textBox5.Text);
            komutGuncelle.Parameters.AddWithValue("@p6", textBox6.Text);
            komutGuncelle.Parameters.AddWithValue("@p7", textBox7.Text);

            komutGuncelle.ExecuteNonQuery();
            baglanti.Close();
        }
    }
    
}
