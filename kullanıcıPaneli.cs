using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace PersonelSistemi
{
    public partial class kullanıcıPaneli : Form
    {
        public kullanıcıPaneli()
        {
            InitializeComponent();
        }
        //SQL Baglantı sınıfı
        SQL bgl = new SQL();

        void temizle()
        {
            textBoxTC.Text = "";
            txtboxAD.Text = "";
            txtbxSOYAD.Text = "";
            radiobtKullanıcı.Checked = false; radiobtYÖNETİCİ.Checked = false;
            textBoxKullanıcıad.Text = "";
            textBoxparola.Text = "";
        }
        private void person_listele()
        {
            try
            {
                SqlDataAdapter komut = new SqlDataAdapter("Select * from Personel", bgl.baglantı());
                DataSet dt = new DataSet();
                komut.Fill(dt);
                dataGridView2.DataSource = dt.Tables[0];
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
        private void kullanıcıPaneli_Load(object sender, EventArgs e)
        {
            //Pictureboxa fotograf çekme
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\kullanıcıresimler" + Form1.tcno + ".jpg");
            }
            catch (Exception)
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\kullanıcıresimler\\resimyok.jpg");
            }
            //Kullanıcı sekme ayarları
            textBox3.Text = "0";
            textBoxTC.MaxLength = 11;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            labelAktfkullanıcı.Text = Form1.ad + " " + Form1.soyad;
            radioButtonbay.Checked = true;
            radiobtYÖNETİCİ.Checked = true;
            //Comboboxa mezuniyet alanlarını ekleme
            cmbmezun.Items.Add("İLK ÖGRETİM"); cmbmezun.Items.Add("ORTA ÖGRETİM");
            cmbmezun.Items.Add("LİSE"); cmbmezun.Items.Add("ÜNİVERSİTE MEZUNU");

            //Görev comboboxına iş alanları ekleme
            comboBox1.Items.Add("YÖNETİCİ"); comboBox1.Items.Add("MEMUR");
            comboBox1.Items.Add("ŞÖFÖR"); comboBox1.Items.Add("İŞÇİ");

            //İş alanlarının yerini ekleme
            comboBox2.Items.Add("ARGE"); comboBox2.Items.Add("BİLGİ İŞLEM");
            comboBox2.Items.Add("MUHASEBE"); comboBox2.Items.Add("ÜRETİM");
            comboBox2.Items.Add("PAKETLEME"); comboBox2.Items.Add("NAKLİYE");

            //datetimepickera şuana göre tarih zaman ekleme
            DateTime dt = DateTime.Now;
            int yil = int.Parse(dt.ToString("yyyy"));
            int ay = int.Parse(dt.ToString("MM"));
            int gun = int.Parse(dt.ToString("dd"));
            dateTimePicker1.MinDate = new DateTime(1960, 1, 1);

            dateTimePicker1.Format = DateTimePickerFormat.Short;

            person_listele();
            kullanıcı_listele();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Datagrid herhangi hücreye tıklandıgında o satıra ait bilgileri araçlara taşıma
            int seçen = dataGridView1.SelectedCells[0].RowIndex;
            textBoxTC.Text = dataGridView1.Rows[seçen].Cells[0].Value.ToString();
            txtboxAD.Text = dataGridView1.Rows[seçen].Cells[1].Value.ToString();
            txtbxSOYAD.Text = dataGridView1.Rows[seçen].Cells[2].Value.ToString();
            textBoxKullanıcıad.Text = dataGridView1.Rows[seçen].Cells[4].Value.ToString();
            textBoxparola.Text = dataGridView1.Rows[seçen].Cells[5].Value.ToString();
            textBoxPAROLA2.Text = dataGridView1.Rows[seçen].Cells[5].Value.ToString();
        }
        private void textBoxTC_TextChanged(object sender, EventArgs e)
        {
            //Textbox TC nesnesine 11karakterden az girildiginde uyarı vermesi
            if (textBoxTC.Text.Length < 11)
            {
                errorProvider1.SetError(textBoxTC, "TC NO 11 KARAKTER OLMALI");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void textBoxTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Sayı hariç alfabetik rakam harfleri engelleme
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57 || (int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void txtboxAD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void txtbxSOYAD_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void textBoxKullanıcıad_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKullanıcıad.Text.Length != 8)
            {
                errorProvider2.SetError(textBoxKullanıcıad, "KULLANICI AD 8 KARAKTER OLMALI");
            }
            else
            {
                errorProvider2.Clear();
            }
        }
        private void textBoxKullanıcıad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsDigit(e.KeyChar) == true)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        int parola_skoru = 0;
        private void textBoxparola_TextChanged(object sender, EventArgs e)
        {
            string parola_seviyesi = "";
            int küçük_harf_skoru = 0, büyük_harf_skoru = 0, rakam_skoru = 0, sembol_skoru = 0;
            string sifre = textBoxparola.Text;
            //REGEX KÜTÜPHANESİ İNGİLİZCE KARAKTER BAZ ALDIGINDAN DOLAYI,TÜRKÇE KARAKTERLERDE SORUN YAŞAMAMAK İÇİN
            //ŞİFRE STRİNG İFADESİNDEKİ TÜRKÇE KARAKTERLERİ İNGİLİZCE KARAKTERLERE DÖNÜŞTÜRMEMİZ GEREKİYOR
            string düzeltilmiş_sifre = "";
            düzeltilmiş_sifre = sifre;
            düzeltilmiş_sifre = düzeltilmiş_sifre.Replace('İ', 'I');
            düzeltilmiş_sifre = düzeltilmiş_sifre.Replace('ı', 'I');
            düzeltilmiş_sifre = düzeltilmiş_sifre.Replace('Ç', 'C');
            düzeltilmiş_sifre = düzeltilmiş_sifre.Replace('ç', 'c');
            düzeltilmiş_sifre = düzeltilmiş_sifre.Replace('Ü', 'U');
            düzeltilmiş_sifre = düzeltilmiş_sifre.Replace('ü', 'u');
            düzeltilmiş_sifre = düzeltilmiş_sifre.Replace('Ö', 'O');
            düzeltilmiş_sifre = düzeltilmiş_sifre.Replace('Ğ', 'G');
            düzeltilmiş_sifre = düzeltilmiş_sifre.Replace('Ö', 'O');
            düzeltilmiş_sifre = düzeltilmiş_sifre.Replace('Ş', 'S');
            düzeltilmiş_sifre = düzeltilmiş_sifre.Replace('ş', 's');
            if (sifre != düzeltilmiş_sifre)
            {
                sifre = düzeltilmiş_sifre;
                textBoxparola.Text = sifre;
                MessageBox.Show("Paroladaki Türkçe karakterler İngilizce karakterlere Döndürüldü");
            }
            //1 KÜÇÜK HARF 10puan 2ve üzeri 20puan (ŞİFRE GÜCÜ)
            int az_karakter_sayısı = sifre.Length - Regex.Replace(sifre, "[a-z]", "").Length;
            küçük_harf_skoru = Math.Min(2, az_karakter_sayısı) * 10;

            //1 büyük harf 10 puan 2 ve üzeri 20 puan
            int Az_karakter_sayısı = sifre.Length - Regex.Replace(sifre, "[A-Z]", "").Length;
            büyük_harf_skoru = Math.Min(2, Az_karakter_sayısı) * 10;

            //1 rakam 10 puan 2 ve üzeri 20puan
            int rakam_sayısı = sifre.Length - Regex.Replace(sifre, "[0-9]", "").Length;
            rakam_skoru = Math.Min(2, rakam_sayısı) * 10;

            //1 sembol 10 puan 2 ve üzeri 20 puan
            int sembol_sayısı = sifre.Length - az_karakter_sayısı - Az_karakter_sayısı - rakam_sayısı;
            sembol_skoru = Math.Min(2, sembol_sayısı) * 10;
            parola_skoru = küçük_harf_skoru + büyük_harf_skoru + sembol_skoru + rakam_skoru;

            if (sifre.Length == 9)
            {
                parola_skoru += 10;
            }
            else if (sifre.Length == 10)
            {
                parola_skoru += 20;
            }

            if (küçük_harf_skoru == 0 || büyük_harf_skoru == 0 || rakam_skoru == 0 || sembol_skoru == 0)
            {
                label9.Text = "Büyük harf,Küçük harf,Sembol,sayı kullanmalısınız!";
            }
            if (küçük_harf_skoru != 0 && büyük_harf_skoru != 0 && rakam_skoru != 0 && sembol_skoru != 0)
            {
                label9.Text = "";
            }
            if (parola_skoru < 70)
            {
                parola_seviyesi = "KABUL EDİLEMEZ";
            }
            else if (parola_skoru == 70 || parola_skoru == 80)
            {
                parola_seviyesi = "GÜÇLÜ";
            }
            else if (parola_skoru == 90 || parola_skoru == 100)
            {
                parola_seviyesi = "ÇOK GÜÇLÜ";
            }
            labelPskor.Text = "%" + Convert.ToString(parola_skoru);
            LblParolaSeviye.Text = parola_seviyesi;
            progressBar1.Value = parola_skoru;
        }
        private void textBoxPAROLA2_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPAROLA2.Text != textBoxparola.Text)
            {
                errorProvider1.SetError(textBoxPAROLA2, "PAROLA UYUŞMUYOR TEKRAR DENEYİN");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void tabpage1_temizle()
        {
            txtboxAD.Text = "";
            textBoxTC.Text = "";
            txtbxSOYAD.Text = "";
            textBoxKullanıcıad.Text = "";
            textBoxparola.Text = "";
            textBoxPAROLA2.Text = "";
        }
        private void tabpage2_temizle()
        {
            pictureBox2.Image = null;
            MASKTC.Text = "";
            textBoxad.Text = "";
            textBoxsoyad.Text = "";
            cmbmezun.SelectedIndex = -1;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            textBox3.Text = "";
            cmbmezun.SelectedIndex = -1;
        }
        private void buttonKAYDET_Click(object sender, EventArgs e)
        {
            string yetkı = "";
            //TC KİMLİK KONTROLÜ
            if (textBoxTC.Text.Length < 11 || textBoxTC.Text == "")
            {
                label1.ForeColor = Color.Red;
            }
            else
            {
                label1.ForeColor = Color.Black;
            }
            //AD KONTROLÜ
            if (txtboxAD.Text.Length < 2 || txtboxAD.Text == "")
            {
                label2.ForeColor = Color.Red;
            }
            else
            {
                label2.ForeColor = Color.Black;
            }
            //SOYADI KONTROLÜ
            if (txtbxSOYAD.Text.Length < 2 || txtbxSOYAD.Text == "")
            {
                label3.ForeColor = Color.Red;
            }
            else
            {
                label3.ForeColor = Color.Black;
            }
            //Kullanıcı ad kontrolü
            if (textBoxKullanıcıad.Text.Length != 8 || textBoxKullanıcıad.Text == "")
            {
                label6.ForeColor = Color.Red;
            }
            else
            {
                label6.ForeColor = Color.Black;
            }
            //parola kontrol
            if (textBoxparola.Text == "" || parola_skoru < 70)
            {
                label5.ForeColor = Color.Red;
            }
            else
            {
                label5.ForeColor = Color.Black;
            }
            //PAROLA 2 KONTROL
            if (textBoxPAROLA2.Text == "" || textBoxparola.Text != textBoxPAROLA2.Text)
            {
                label7.ForeColor = Color.Red;
            }
            else
            {
                label7.ForeColor = Color.Black;
            }
            //Nesnelerimiz şartı saglıyormu
            if (textBoxTC.Text.Length == 11 && textBoxTC.Text != "" && txtboxAD.Text != "" & txtboxAD.Text.Length > 1 && txtbxSOYAD.Text != "" &&
                txtbxSOYAD.Text.Length > 1 && textBoxKullanıcıad.Text != "" && textBoxparola.Text != "" && textBoxPAROLA2.Text != "" && textBoxparola.Text == textBoxPAROLA2.Text && parola_skoru >= 70)
            {
                if (radiobtYÖNETİCİ.Checked == true)
                {
                    yetkı = "YÖNETİCİ";
                }
                else if (radiobtKullanıcı.Checked == true)
                {
                    yetkı = "KULLANICI";
                }
                try
                {
                    //Nesnelerimizin şartları uyuyor ise ve yetki alanımız seçili ise eleman ekleme kodu
                    SqlCommand komut1 = new SqlCommand("insert into kullanicilar (tcno,ad,soyad,yetki,kullaniciad,parola) values (@k1,@k2,@k3,@k4,@k5,@k6)", bgl.baglantı());
                    komut1.Parameters.AddWithValue("@k1", textBoxTC.Text);
                    komut1.Parameters.AddWithValue("@k2", txtboxAD.Text);
                    komut1.Parameters.AddWithValue("@k3", txtbxSOYAD.Text);
                    komut1.Parameters.AddWithValue("@k4", yetkı);
                    komut1.Parameters.AddWithValue("@k5", textBoxKullanıcıad.Text);
                    komut1.Parameters.AddWithValue("@k6", textBoxparola.Text);
                    komut1.ExecuteNonQuery();
                    MessageBox.Show("Yeni kullanıcı kaydı oluşturuldu", "YES Personel takip programı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    bgl.baglantı().Close();
                    tabpage1_temizle();
                    kullanıcı_listele();
                }
                catch (Exception HTA)
                {
                    MessageBox.Show(HTA.ToString());
                    bgl.baglantı().Close();
                }
            }
            else
            {
                MessageBox.Show("YAZISI KIRMIZI OLAN ALANLARI GÖZDEN GEÇİRİN", "YES Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonARA_Click(object sender, EventArgs e)
        {
            //Girilen tc no'ya eşit db'de olan bilgileri araçlara çekme
            bool Kayıt_arama_durumu = false;
            if (textBoxTC.Text.Length == 11)
            {
                SqlCommand komut = new SqlCommand("Select * from kullanicilar where tcno='" + textBoxTC.Text + "'", bgl.baglantı());
                SqlDataReader sorgu = komut.ExecuteReader();
                while (sorgu.Read())
                {
                    Kayıt_arama_durumu = true;
                    MessageBox.Show("Sorgu Başarılı! Kayıt Bulundu", "YES PERSONEL SİSTEMİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtboxAD.Text = sorgu.GetValue(1).ToString();
                    txtbxSOYAD.Text = sorgu.GetValue(2).ToString();
                    if (sorgu.GetValue(3).ToString() == "YÖNETİCİ")
                    {
                        radiobtYÖNETİCİ.Checked = true;
                    }
                    else
                    {
                        radiobtKullanıcı.Checked = true;
                    }
                    textBoxKullanıcıad.Text = sorgu.GetValue(4).ToString();
                    textBoxparola.Text = sorgu.GetValue(5).ToString();
                    break;
                }
                if (Kayıt_arama_durumu == false)
                {
                    MessageBox.Show("Aranan kayıt bulunamadı", "YES Personel takip Programı UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    temizle();
                    bgl.baglantı().Close();
                }
                bgl.baglantı().Close();
            }
            else
            {
                MessageBox.Show("Lütfen 11 haneli Tc No Giriniz!!!", "YES Personel Takip Sistemi UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void buttonGÜNCELLE_Click(object sender, EventArgs e)
        {
            string yetkı = "";

            //TC KİMLİK KONTROLÜ
            if (textBoxTC.Text.Length < 11 || textBoxTC.Text == "")
            {
                label1.ForeColor = Color.Red;
            }
            else
            {
                label1.ForeColor = Color.Black;
            }
            //AD KONTROLÜ
            if (txtboxAD.Text.Length < 2 || txtboxAD.Text == "")
            {
                label2.ForeColor = Color.Red;
            }
            else
            {
                label2.ForeColor = Color.Black;
            }
            //SOYADI KONTROLÜ
            if (txtbxSOYAD.Text.Length < 2 || txtbxSOYAD.Text == "")
            {
                label3.ForeColor = Color.Red;
            }
            else
            {
                label3.ForeColor = Color.Black;
            }
            //Kullanıcı ad kontrolü
            if (textBoxKullanıcıad.Text.Length != 8 || textBoxKullanıcıad.Text == "")
            {
                label6.ForeColor = Color.Red;
            }
            else
            {
                label6.ForeColor = Color.Black;
            }
            //parola kontrol
            if (textBoxparola.Text == "" || parola_skoru < 70)
            {
                label5.ForeColor = Color.Red;
            }
            else
            {
                label5.ForeColor = Color.Black;
            }
            //PAROLA 2 KONTROL
            if (textBoxPAROLA2.Text == "" || textBoxparola.Text != textBoxPAROLA2.Text)
            {
                label7.ForeColor = Color.Red;
            }
            else
            {
                label7.ForeColor = Color.Black;
            }
            //Nesnelerimiz şartı saglıyormu
            if (textBoxTC.Text.Length == 11 && textBoxTC.Text != "" && txtboxAD.Text != "" & txtboxAD.Text.Length > 1 && txtbxSOYAD.Text != "" &&
                txtbxSOYAD.Text.Length > 1 && textBoxKullanıcıad.Text != "" && textBoxparola.Text != "" && textBoxPAROLA2.Text != "" && textBoxparola.Text == textBoxPAROLA2.Text && parola_skoru >= 70)
            {
                if (radiobtYÖNETİCİ.Checked == true)
                {
                    yetkı = "YÖNETİCİ";
                }
                else if (radiobtKullanıcı.Checked == true)
                {
                    yetkı = "KULLANICI";
                }
                try
                {
                    //Nesnelerimizin şartları uyuyor ise ve yetki alanımız seçili ise eleman ekleme kodu
                    SqlCommand komut1 = new SqlCommand("Update kullanicilar set ad=@p2,soyad=@p3,yetki=@p4,kullaniciad=@p5,parola=@p6 where tcno=@p1", bgl.baglantı());
                    komut1.Parameters.AddWithValue("@p1", textBoxTC.Text);
                    komut1.Parameters.AddWithValue("@p2", txtboxAD.Text);
                    komut1.Parameters.AddWithValue("@p3", txtbxSOYAD.Text);
                    komut1.Parameters.AddWithValue("@p4", yetkı);
                    komut1.Parameters.AddWithValue("@p5", textBoxKullanıcıad.Text);
                    komut1.Parameters.AddWithValue("@p6", textBoxparola.Text);
                    komut1.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı kaydı Güncellendi!", "YES Personel takip programı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bgl.baglantı().Close();
                    tabpage1_temizle();
                    kullanıcı_listele();
                }
                catch (Exception HTA)
                {
                    MessageBox.Show(HTA.ToString());
                    bgl.baglantı().Close();
                }
            }
            else
            {
                MessageBox.Show("YAZISI KIRMIZI OLAN ALANLARI GÖZDEN GEÇİRİN", "YES Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonSİL_Click(object sender, EventArgs e)
        {
            bool kayıt_aramads = false;

            if (textBoxTC.Text.Length == 11)
            {
                SqlCommand komut = new SqlCommand("Select * from kullanicilar where tcno='" + textBoxTC.Text + "'", bgl.baglantı());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    kayıt_aramads = true;
                    SqlCommand komutsl = new SqlCommand("Delete from kullanicilar where tcno='" + textBoxTC.Text + "'", bgl.baglantı());
                    komutsl.ExecuteNonQuery();
                    MessageBox.Show("Sistemdeki Kayıt Silindi", "YES Personel Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    bgl.baglantı().Close();
                    kullanıcı_listele();
                    tabpage1_temizle();
                    break;
                }
                if (kayıt_aramads == false)
                {
                    MessageBox.Show("Sistemde Girilen tc ye ait kayıt bulunamadı", "YES Personel Takip sistemi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tabpage1_temizle();
                    bgl.baglantı().Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen 11 Karakterden Oluşan Tcno giriniz!", "YES Personel Sistemi UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void buttonGÖZAT_Click(object sender, EventArgs e)
        {
            //Pictureboxa resim aktarma
            //Dosya yoluyla .jpg uzantılı dosyaları filtreyelerek pb aktarma
            OpenFileDialog resmseç = new OpenFileDialog();
            resmseç.Title = "PERSONEL RESMİNİ SEÇİN";
            resmseç.Filter = "JPG dosyalar (*.jpg) | *.jpg";
            if (resmseç.ShowDialog() == DialogResult.OK)
            {
                //Pictureboxdaki Fotografı Stretch ile tam yerleştirme
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pictureBox2.Image = new Bitmap(resmseç.OpenFile());

            }
        }
        private void buttonKAYdt2_Click(object sender, EventArgs e)
        {
            string cinsiyet = "";
            bool kayıtkontrol = false;

            SqlCommand kmt = new SqlCommand("select * from Personel where tcno='" + MASKTC.Text + "'", bgl.baglantı());
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                kayıtkontrol = true;
                break;
            }
            bgl.baglantı().Close();

            if (kayıtkontrol == false)
            {
                if (pictureBox2.Image == null)
                {
                    buttonGÖZAT.ForeColor = Color.Red;
                }
                else
                {
                    buttonGÖZAT.ForeColor = Color.Black;
                }
                if (MASKTC.MaskCompleted == false)
                {
                    label11.ForeColor = Color.Red;
                }
                else
                {
                    label11.ForeColor = Color.Black;
                }
                if (textBoxad.Text == "")
                {
                    label12.ForeColor = Color.Red;
                }
                else
                {
                    label12.ForeColor = Color.Black;
                }
                if (textBoxsoyad.Text == "")
                {
                    label13.ForeColor = Color.Red;
                }
                else
                {
                    label13.ForeColor = Color.Black;
                }
                if (cmbmezun.Text == "")
                {
                    label15.ForeColor = Color.Red;
                }
                else
                {
                    label15.ForeColor = Color.Black;
                }
                if (comboBox1.Text == "")
                {
                    label17.ForeColor = Color.Red;
                }
                else
                {
                    label17.ForeColor = Color.Black;
                }
                if (comboBox2.Text == "")
                {
                    label18.ForeColor = Color.Red;
                }
                else
                {
                    label18.ForeColor = Color.Black;
                }
                if (textBox3.Text == "")
                {
                    label19.ForeColor = Color.Red;
                }
                else
                {
                    label19.ForeColor = Color.Black;
                }
                if (int.Parse(textBox3.Text) < 1000)
                {
                    label19.ForeColor = Color.Red;
                }
                else
                {
                    label19.ForeColor = Color.Black;
                }
                if (pictureBox2.Image != null && MASKTC.MaskCompleted != false && textBoxad.Text != "" && textBoxsoyad.Text != "" && cmbmezun.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && textBox3.Text != "")
                {
                    if (radioButtonbay.Checked == true)
                    {
                        cinsiyet = "BAY";
                    }
                    else if (radioButtonbayan.Checked == true)
                    {
                        cinsiyet = "BAYAN";
                    }
                    try
                    {
                        SqlCommand ekleme = new SqlCommand("insert into Personel (tcno,ad,soyad,cinsiyet,mezuniyet,dogumtarihi,gorev,gorevyeri,maas) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglantı());
                        ekleme.Parameters.AddWithValue("@p1", MASKTC.Text);
                        ekleme.Parameters.AddWithValue("@p2", textBoxad.Text);
                        ekleme.Parameters.AddWithValue("@p3", textBoxsoyad.Text);
                        ekleme.Parameters.AddWithValue("@p4", cinsiyet);
                        ekleme.Parameters.AddWithValue("@p5", cmbmezun.Text);
                        ekleme.Parameters.AddWithValue("@p6", dateTimePicker1.Text);
                        ekleme.Parameters.AddWithValue("@p7", comboBox1.Text);
                        ekleme.Parameters.AddWithValue("@p8", comboBox2.Text);
                        ekleme.Parameters.AddWithValue("@p9", textBox3.Text);
                        ekleme.ExecuteNonQuery();
                        bgl.baglantı().Close();
                        if (!Directory.Exists(Application.StartupPath + "\\kullanıcıResimler\\"))
                        {
                            Directory.CreateDirectory(Application.StartupPath + "\\kullanıcıResimler\\");
                        }
                        else
                        {
                            pictureBox2.Image.Save(Application.StartupPath + "\\kullanıcıResimler\\" + MASKTC.Text + ".jpg");
                        }
                        MessageBox.Show("Yeni kullanıcı kaydı oluşturuldu", "YES Personel Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        person_listele();
                    }
                    catch (Exception hta)
                    {
                        MessageBox.Show(hta.Message, "YES Personel takip sistemi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        bgl.baglantı().Close();
                    }
                }
                else
                {
                    MessageBox.Show("Kırmızı olan alanları gözden geçiriniz!!!", "YES Personel takip sistemi", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }
            }
            else
            {
                MessageBox.Show("GİRİLEN TC DAHA ÖNCEDEN KAYITLIDIR", "YES Personel takip sistemi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Radiobutona ve araçlara datatan veri çekme
            string cinsiyet = "";
            //DATABASEDEN cinsiyeti çektikten sonra iki radiobutonada aktarma
            SqlCommand komt = new SqlCommand("Select cinsiyet from Personel", bgl.baglantı());
            SqlDataReader dr = komt.ExecuteReader();
            while (dr.Read())
            {
                if (dr["cinsiyet"].ToString() == "BAY")
                {
                    radioButtonbay.Checked = true;
                }
                if (dr["cinsiyet"].ToString() == "BAYAN")
                {
                    radioButtonbayan.Checked = true;
                }
                int seçen = dataGridView2.SelectedCells[0].RowIndex;
                MASKTC.Text = dataGridView2.Rows[seçen].Cells[0].Value.ToString();
                textBoxad.Text = dataGridView2.Rows[seçen].Cells[1].Value.ToString();
                textBoxsoyad.Text = dataGridView2.Rows[seçen].Cells[2].Value.ToString();
                dateTimePicker1.Text = dataGridView2.Rows[seçen].Cells[5].Value.ToString();
                cmbmezun.Text = dataGridView2.Rows[seçen].Cells[4].Value.ToString();
                comboBox1.Text = dataGridView2.Rows[seçen].Cells[6].Value.ToString();
                comboBox2.Text = dataGridView2.Rows[seçen].Cells[7].Value.ToString();
                textBox3.Text = dataGridView2.Rows[seçen].Cells[8].Value.ToString();
            }
            bgl.baglantı().Close();

        }

        private void BUTONARA_Click(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            //BOOL DEGİŞKEN FALSE İSE KAYIT YOK TRUE İSE KAYIT VAR ANLAMINA GELİR
            //TC BOX 11 HANELİ İSE DATABASEYE SORGU ATILIR VE O SORGU VAR İSE ARAÇLARA TAŞINIR
            bool kayt_arama_durum = false;
            if (MASKTC.Text.Length == 11)
            {
                SqlCommand sorgu = new SqlCommand("Select * from Personel where tcno='" + MASKTC.Text + "'", bgl.baglantı());
                SqlDataReader data = sorgu.ExecuteReader();
                while (data.Read())
                {
                    kayt_arama_durum = true;
                    try
                    {
                        pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\kullanıcıResimler\\" + data.GetValue(0).ToString() + ".jpg");

                    }
                    catch (Exception)
                    {
                        pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\kullanıcıResimler\\resimyok.jpg");
                    }
                    MessageBox.Show("Sorgu başarılı! Kayıt bulundu");
                    MASKTC.Text = data.GetValue(0).ToString();
                    textBoxad.Text = data.GetValue(1).ToString();
                    textBoxsoyad.Text = data.GetValue(2).ToString();
                    if (data["cinsiyet"].ToString() == "BAY")
                    {
                        radioButtonbay.Checked = true;
                    }
                    else
                    {
                        radioButtonbayan.Checked = true;
                    }
                    cmbmezun.Text = data.GetValue(4).ToString();
                    dateTimePicker1.Text = data.GetValue(5).ToString();
                    comboBox1.Text = data.GetValue(6).ToString();
                    comboBox2.Text = data.GetValue(7).ToString();
                    textBox3.Text = data.GetValue(8).ToString();
                    bgl.baglantı().Close();
                    break;
                }
                if (kayt_arama_durum == false)
                {
                    MessageBox.Show("Girdiginiz tcye ait kayıt bulunamadı", "YES Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                bgl.baglantı().Close();
            }
            else
            {
                MessageBox.Show("11 Haneli TCNO Giriniz!!!", "YES Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonsİL2_Click(object sender, EventArgs e)
        {
            bool kayıt_arama_durumu = false;
            if (MASKTC.MaskCompleted==true)
            {
                SqlCommand arama = new SqlCommand("Select * from Personel where tcno='" + MASKTC.Text + "'", bgl.baglantı());
                SqlDataReader okuma = arama.ExecuteReader();
                while (okuma.Read())
                {
                    kayıt_arama_durumu = true;
                    SqlCommand silkomut = new SqlCommand("Delete from Personel where tcno='" + MASKTC.Text + "'", bgl.baglantı());
                    silkomut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Silindi", "YES Personel Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                }
                if (kayıt_arama_durumu==false)
                {
                    MessageBox.Show("Silinecek kayıt bulunamadı", "YES Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                bgl.baglantı().Close();
                person_listele();
                tabpage2_temizle();
                textBox3.Text = "0";
            }
            else
            {
                MessageBox.Show("11 Haneli tcno Giriniz!!!", "YES Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabpage2_temizle();
                textBox3.Text = "0";
            }
        }

        private void buttonUPDATE2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
            {
                buttonGÖZAT.ForeColor = Color.Red;
            }
            else
            {
                buttonGÖZAT.ForeColor = Color.Black;
            }
            if (MASKTC.MaskCompleted == false)
            {
                label11.ForeColor = Color.Red;
            }
            else
            {
                label11.ForeColor = Color.Black;
            }
            if (textBoxad.Text == "")
            {
                label12.ForeColor = Color.Red;
            }
            else
            {
                label12.ForeColor = Color.Black;
            }
            if (textBoxsoyad.Text == "")
            {
                label13.ForeColor = Color.Red;
            }
            else
            {
                label13.ForeColor = Color.Black;
            }
            if (cmbmezun.Text == "")
            {
                label15.ForeColor = Color.Red;
            }
            else
            {
                label15.ForeColor = Color.Black;
            }
            if (comboBox1.Text == "")
            {
                label17.ForeColor = Color.Red;
            }
            else
            {
                label17.ForeColor = Color.Black;
            }
            if (comboBox2.Text == "")
            {
                label18.ForeColor = Color.Red;
            }
            else
            {
                label18.ForeColor = Color.Black;
            }
            if (textBox3.Text == "")
            {
                label19.ForeColor = Color.Red;
            }
            else
            {
                label19.ForeColor = Color.Black;
            }
            if (int.Parse(textBox3.Text) < 1000)
            {
                label19.ForeColor = Color.Red;
            }
            else
            {
                label19.ForeColor = Color.Black;
            }
            if (pictureBox2.Image != null && MASKTC.MaskCompleted != false && textBoxad.Text != "" && textBoxsoyad.Text != "" && cmbmezun.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && textBox3.Text != "")
            {
                try
                {
                    string cinsiyet = "";
                    if (radioButtonbay.Checked == true)
                    {
                        cinsiyet = "BAY";
                    }
                    else
                    {
                        cinsiyet = "BAYAN";
                    }
                    //Veritabanında bilgi güncelleme
                    SqlCommand kmtgüncel = new SqlCommand("update Personel set ad=@p2,soyad=@p3,cinsiyet=@p4,mezuniyet=@p5,dogumtarihi=@p6,gorev=@p7,gorevyeri=@p8,maas=@p9 where tcno=@p1", bgl.baglantı());
                    kmtgüncel.Parameters.AddWithValue("@p1", MASKTC.Text);
                    kmtgüncel.Parameters.AddWithValue("@p2", textBoxad.Text);
                    kmtgüncel.Parameters.AddWithValue("@p3", textBoxsoyad.Text);
                    kmtgüncel.Parameters.AddWithValue("@p4", cinsiyet);
                    kmtgüncel.Parameters.AddWithValue("@p5", cmbmezun.Text);
                    kmtgüncel.Parameters.AddWithValue("@p6", dateTimePicker1.Text);
                    kmtgüncel.Parameters.AddWithValue("@p7", comboBox1.Text);
                    kmtgüncel.Parameters.AddWithValue("@p8", comboBox2.Text);
                    kmtgüncel.Parameters.AddWithValue("@p9", textBox3.Text);
                    kmtgüncel.ExecuteNonQuery();
                    bgl.baglantı().Close();
                    MessageBox.Show("Kayıt bilgileri güncellendi", "YES Personel Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    person_listele();
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message, "YES Personel Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Kırmızı alanları gözden geçiriniz!", "YES Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void butonTemizle2_Click(object sender, EventArgs e)
        {
            tabpage2_temizle();
        }

        private void buttonTEMİZLE_Click(object sender, EventArgs e)
        {
            tabpage1_temizle();
        }

        private void txtbxSOYAD_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
