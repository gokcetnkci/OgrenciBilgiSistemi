using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OgrenciBilgiSistemi.BL;
using OgrenciBilgiSistemi.DAL;
using OgrenciBilgiSistemi.UI;

namespace OgrenciBilgiSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            ///Kullanıcı girişi veritabanından text boxtaki verileri gönderecek bir metod
            ///KullaniciGiris(txtuser, txtpass);
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Eksik Bilgi Girdiniz. Lütfen Tekrar Deneyin.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                HelperUser h = new HelperUser();
                var b = h.StudentUser(txtUsername.Text, txtPassword.Text);
                if (b != null)
                {
                    if (b.Type.Value == Convert.ToInt32(Style.ogrenci))
                    {
                        Form2 f2 = new Form2(b.Ogrt_ogrID.Value, b.Type.Value);
                        f2.Show();
                        this.Hide();
                    }
                    else if (b.Type.Value == Convert.ToInt32(Style.admin))
                    {
                        Form3 f3 = new Form3(b.Ogrt_ogrID.Value);
                        f3.Show();
                        this.Hide();
                    }
                    else if (b.Type.Value == Convert.ToInt32(Style.ogretmen))
                    {
                        Form4 f4 = new Form4(b.Ogrt_ogrID.Value);
                        HelperOgretmen ho = new HelperOgretmen();
                        var ogrt = ho.GetOgretmen(b.Ogrt_ogrID.Value);
                        f4.Text = ogrt.OgretmenAdi;
                        f4.Show();                        
                        this.Hide();
                    }
                }                
                else
                {
                    MessageBox.Show("Hatalı Giriş Yaptınız. Lütfen Tekrar Deneyin.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Clear();
                    txtPassword.Clear();
                }
            }
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }

    public enum style
    {
        ogretmen = 1,
        ogrenci  =2,
    }

    public enum gender
    {
        kız,erkek,
    }

    public enum active
    {
        pasif,aktif,
    }
    
}
