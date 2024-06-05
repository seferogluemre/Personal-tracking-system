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
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace PersonelSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //SQL Baglantısı
        SQL bgl = new SQL();
        //Form arası veri aktarımda kullanılcak degişkenler
        public static string tcno, ad, soyad, yetki;
        //giriş hak sayısı
        int hak = 3;
        bool durum = false;
        void temizle()
        {
            TXTkULLANICIAD.Text = "";
            msktxtPAROLA.Text = "";
        }

        private void TXTkULLANICIAD_MouseEnter(object sender, EventArgs e)
        {
            for (int i = 0; i <=300; i++)
            {
                TXTkULLANICIAD.BackColor = Color.Silver;
            }
        }
        private void buttonçıkış_Click(object sender, EventArgs e)
        {
            DialogResult tepki = new DialogResult();
            tepki = MessageBox.Show("Çıkış Yapmak istediginze emin misiniz?", "SKY Personel Takip Sistemi Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tepki==DialogResult.OK)
            {
                Application.Exit();
            }
            else
            {
                Form1 fr1 = new Form1();
                fr1.Refresh();
            }
        }

        private void msktxtPAROLA_MouseEnter(object sender, EventArgs e)
        {
            for (int i = 0; i <= 300; i++)
            {
                msktxtPAROLA.BackColor = Color.Silver;
            }
        }

        private void msktxtPAROLA_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i <= 300; i++)
            {
                msktxtPAROLA.BackColor = Color.White;
            }
        }

        private void radioByÖNETİCİ_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonGİRİŞ_Click(object sender, EventArgs e)
        {
            //Veri tabanlı giriş sistemi
            if (hak!=0)
            {
                SqlCommand komut = new SqlCommand("Select * from kullanicilar", bgl.baglantı()) ;
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    //Yetkisi yönetici olan giriş sistemi
                    if (radioByÖNETİCİ.Checked==true)
                    {
                        if (dr["kullaniciad"].ToString()==TXTkULLANICIAD.Text && dr["parola"].ToString()==msktxtPAROLA.Text && dr["yetki"].ToString()=="YÖNETİCİ")
                        {
                            durum = true;
                            tcno = dr.GetValue(0).ToString();
                            ad = dr.GetValue(1).ToString();
                            soyad = dr.GetValue(2).ToString();
                            yetki = dr.GetValue(3).ToString();
                            kullanıcıPaneli kp = new kullanıcıPaneli();
                            kp.Show();
                            this.Hide();
                            break;
                        }
                    }
                    //Yetkisi kullanıcı olan giriş sistemi
                    if (radioButtonKULLANICI.Checked==true)
                    {
                        if (dr["kullaniciad"].ToString() == TXTkULLANICIAD.Text && dr["parola"].ToString() == msktxtPAROLA.Text && dr["yetki"].ToString() == "KULLANİCİ")
                        {
                            durum = true;
                            tcno = dr.GetValue(0).ToString();
                            ad = dr.GetValue(1).ToString();
                            soyad = dr.GetValue(2).ToString();
                            yetki = dr.GetValue(3).ToString();
                            Form3 FR3 = new Form3();
                            FR3.Show();
                            this.Hide();
                            break;
                        }
                    }
                    //Giriş bilgileri dogru olmadıgında hak düşer
                    if (durum==false)
                    { 
                        hak = hak - 1;
                        lBLhKSAYI.Text = hak.ToString();
                        bgl.baglantı().Close();
                    }
                    lBLhKSAYI.Text = hak.ToString();
                    if (hak==0)
                    {
                        buttonGİRİŞ.Enabled = false;
                        MessageBox.Show("Giriş hakkınız kalmadı sonra tekrar deneyin!!!", "YES Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                }
                bgl.baglantı().Close();
            }
        }
        private void TXTkULLANICIAD_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i <= 300; i++)
            {
                TXTkULLANICIAD.BackColor = Color.White;
            }
        }  
        private void Form1_Load(object sender, EventArgs e)
        {
            this.AcceptButton = buttonGİRİŞ;
            this.CancelButton = buttonçıkış;
            radioByÖNETİCİ.Checked = true;
            lBLhKSAYI.Text = Convert.ToString(hak);
            TXTkULLANICIAD.Focus();      
        }
    }
}
