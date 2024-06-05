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
namespace PersonelSistemi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SQL bgl = new SQL();
        private void Form3_Load(object sender, EventArgs e)
        {
            person_listele();
            textBox1.MaxLength = 11;
            label7.Text = Form1.ad + " " + Form1.soyad;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\kullanıcıResimler\\" + Form1.tcno + ".jpg");
            }
            catch (Exception)
            {
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\kullanıcıResimler\\resimyok.jpg");
            }
        }
        private void person_listele()
        {
            try
            {
                SqlDataAdapter komut = new SqlDataAdapter("Select * from Personel", bgl.baglantı());
                DataSet dt = new DataSet();
                komut.Fill(dt);
                dataGridView1.DataSource = dt.Tables[0];
                bgl.baglantı().Close();
            }
            catch (Exception HATA)
            {
                MessageBox.Show(HATA.ToString(), "YES Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bgl.baglantı().Close();
            }
        }
        private void kullanıcı_listele()
        {
            try
            {
                SqlDataAdapter komut = new SqlDataAdapter("Select * from kullanicilar", bgl.baglantı());
                DataSet dt = new DataSet();
                komut.Fill(dt);
                dataGridView1.DataSource = dt.Tables[0];
                bgl.baglantı().Close();
            }
            catch (Exception HATA)
            {
                MessageBox.Show(HATA.ToString(), "YES Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bgl.baglantı().Close();
            }
        }
       

        private void buttonara_Click(object sender, EventArgs e)
        {
            //Veritabanı sorgusu TCno ile
            bool kayıt_arama_durum = false;
            if (textBox1.Text.Length==11)
            {
                SqlCommand sorgu = new SqlCommand("Select * from Personel where tcno='" + textBox1.Text + "'", bgl.baglantı());
                SqlDataReader arama = sorgu.ExecuteReader();
                while (arama.Read())
                {
                    kayıt_arama_durum = true;
                    MessageBox.Show("Sorgu Başarılı! Kayıt bulundu");
                    try
                    {
                        pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\personelResimler\\" + arama.GetValue(0) + ".jpg");

                    }
                    catch (Exception)
                    {
                        pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\personelResimler\\resimyok.jpg");
                    }
                    label12.Text = arama.GetValue(1).ToString();
                    label14.Text = arama.GetValue(2).ToString();
                    if (arama.GetValue(3).ToString()=="BAY")
                    {
                        label15.Text = "BAY";
                    }
                    else
                    {
                        label15.Text = "BAYAN";
                    }
                    label16.Text = arama.GetValue(4).ToString();
                    label17.Text = arama.GetValue(5).ToString();
                    label18.Text = arama.GetValue(6).ToString();
                    label19.Text= arama.GetValue(7).ToString();
                    label20.Text=arama.GetValue(8).ToString();
                    break;
                }
                if (kayıt_arama_durum==false)
                {
                    MessageBox.Show("Aranan kayıt bulunamadı");
                }
                bgl.baglantı().Close();
            }
            else
            {
                MessageBox.Show("Lütfen 11 haneli tc no giriniz", "YES Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Datagridde hücre tıklandıgında araçlara veri taşıma
            SqlCommand kmt = new SqlCommand("select * from Personel where tcno='" + textBox1.Text + "'", bgl.baglantı());
            SqlDataReader dr = kmt.ExecuteReader();
            int seç = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[seç].Cells[0].Value.ToString();
            label12.Text = dataGridView1.Rows[seç].Cells[1].Value.ToString();
            label14.Text = dataGridView1.Rows[seç].Cells[2].Value.ToString();
            label15.Text = dataGridView1.Rows[seç].Cells[3].Value.ToString();
            label16.Text = dataGridView1.Rows[seç].Cells[4].Value.ToString();
            label17.Text = dataGridView1.Rows[seç].Cells[5].Value.ToString();
            label18.Text = dataGridView1.Rows[seç].Cells[6].Value.ToString();
            label19.Text = dataGridView1.Rows[seç].Cells[7].Value.ToString();
            label20.Text = dataGridView1.Rows[seç].Cells[8].Value.ToString();
            try
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\personelResimler\\" + dr.GetValue(0).ToString() + ".jpg");

            }
            catch (Exception)
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\personelResimler\\resimyok.jpg");
            }
        }
    }
}
