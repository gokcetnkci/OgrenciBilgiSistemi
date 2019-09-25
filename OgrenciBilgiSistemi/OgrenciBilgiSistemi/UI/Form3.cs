using OgrenciBilgiSistemi.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciBilgiSistemi.UI
{
    public partial class Form3 : Form
    {
        Ogretmen_Ogrenci_Ders od = new Ogretmen_Ogrenci_Ders();
        HelperDepartment hd      = new HelperDepartment();
        HelperOgretmen ho        = new HelperOgretmen();
        HelperStudent h          = new HelperStudent();
        HelperLesson hl          = new HelperLesson();
        HelperUser hu            = new HelperUser();
        Ogrenci ogr              = new Ogrenci();
        User u                   = new User();
        Ders d                   = new Ders();
        
        int kayityapanID;
        int ogrenciID;
        int dersID;
        int sayac;
        int NotDersId;
        int ogrt_ogr_ders_Id;
        int ogrt_ogr_ID;
        int ogrt_dersID;
        bool IsClick1;
        bool IsClick2;
        bool IscLick3;

        public Form3(int Id)
        {
            kayityapanID = Id;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IsClick1)
            {
                ogr.OgrId             = ogrenciID;
                ogr.OgrNo             = Convert.ToInt32(txtOgrNo.Text);
                ogr.Ad                = txtAd.Text;
                ogr.Soyad             = txtSoyad.Text;
                ogr.Tc                = txtTC.Text;
                ogr.DogumTarih        = dtDogum.Value;
                ogr.Cinsiyet          = Convert.ToByte(cbxCinsiyet.SelectedValue);
                ogr.Email             = txtEmail.Text;
                ogr.BolumId           = Convert.ToInt32(cbxBolum.SelectedValue);
                ogr.KayityapanID      = kayityapanID;
                ogr.KayitYapilantarih = DateTime.Now.Date;
                ogr.AktifPasif        = Convert.ToByte(active.aktif);
                h.CUD(ogr, System.Data.Entity.EntityState.Modified);

                var user = hu.GetUser(ogr.OgrId, Convert.ToInt32(style.ogrenci));
                u.UserId     = user.UserId;
                u.Username   = txtOgrNo.Text;
                u.Password   = txtPass.Text;
                u.Ogrt_ogrID = ogr.OgrId;
                u.Type       = Convert.ToInt32(style.ogrenci);
                hu.UserCUD(u, System.Data.Entity.EntityState.Modified);
                Clear();
                StudentgridShow();
                IsClick1 = false;
                MessageBox.Show("Kayıt Güncellendi.", "BAŞARI", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Güncelleme Yapmak İstediğiniz Öğrenciyi Seçin !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {           
            cbxCinsiyet.DataSource    = Enum.GetValues(typeof(gender));
            cbxBolumAd.ValueMember    = "BolumId";
            cbxBolumAd.DisplayMember  = "BolumAdi";
            cbxBolumAd.DataSource     = hd.DepartmentList();
            cbxBolumSec.ValueMember   = "BolumId";
            cbxBolumSec.DisplayMember = "BolumAdi";
            cbxBolumSec.DataSource    = hd.DepartmentList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (txtOgrNo.Text == "" || txtAd.Text == "" || txtSoyad.Text == "" || txtTC.Text == "" || txtEmail.Text == "" || 
                cbxFakulte.Text == "" || cbxBolum.Text == "" || cbxCinsiyet.Text == "")
            {
                MessageBox.Show("Eksik Bilgi Girdiniz...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {               
                ogr.OgrNo             = Convert.ToInt32(txtOgrNo.Text);
                ogr.Ad                = txtAd.Text;
                ogr.Soyad             = txtSoyad.Text;
                ogr.Tc                = txtTC.Text;
                ogr.DogumTarih        = dtDogum.Value;
                ogr.Cinsiyet          = Convert.ToByte(cbxCinsiyet.SelectedValue);
                ogr.Email             = txtEmail.Text;
                ogr.BolumId           = Convert.ToInt32(cbxBolum.SelectedValue);
                ogr.KayityapanID      = kayityapanID;
                ogr.KayitYapilantarih = DateTime.Now.Date;
                ogr.AktifPasif        = Convert.ToByte(active.aktif);
                h.CUD(ogr, System.Data.Entity.EntityState.Added);

                u.Username   = txtOgrNo.Text;
                u.Password   = txtPass.Text;
                u.Ogrt_ogrID = ogr.OgrId;
                u.Type       = Convert.ToInt32(style.ogrenci);
                hu.UserCUD(u, System.Data.Entity.EntityState.Added);
                StudentgridShow();
                Clear();
                MessageBox.Show("Öğrenci Kayıt Edildi.", "BAŞARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DgOgrenci_Click(object sender, EventArgs e)
        {
            int index        = DgOgrenci.CurrentCell.RowIndex;
            ogrenciID        = Convert.ToInt32(DgOgrenci.Rows[index].Cells[0].Value);
            if (ogrenciID != 0)
            {
                IsClick1         = true;
                txtOgrNo.Text    = DgOgrenci.Rows[index].Cells[1].Value.ToString();
                txtAd.Text       = DgOgrenci.Rows[index].Cells[2].Value.ToString();
                txtSoyad.Text    = DgOgrenci.Rows[index].Cells[3].Value.ToString();
                txtTC.Text       = DgOgrenci.Rows[index].Cells[4].Value.ToString();
                dtDogum.Text     = DgOgrenci.Rows[index].Cells[5].Value.ToString();
                cbxCinsiyet.Text = DgOgrenci.Rows[index].Cells[6].Value.ToString();
                txtEmail.Text    = DgOgrenci.Rows[index].Cells[7].Value.ToString();
                cbxFakulte.Text  = DgOgrenci.Rows[index].Cells[8].Value.ToString();
                cbxBolum.Text    = DgOgrenci.Rows[index].Cells[9].Value.ToString();
                txtPass.Text     = DgOgrenci.Rows[index].Cells[10].Value.ToString();
            }
            else
            {
                MessageBox.Show("Henüz Öğrenciler Listelenmemeiş Veya Öğrenci Kaydı Yapılmamış !!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (IsClick1)
            {
                ogr.OgrId             = ogrenciID;
                ogr.OgrNo             = Convert.ToInt32(txtOgrNo.Text);
                ogr.Ad                = txtAd.Text;
                ogr.Soyad             = txtSoyad.Text;
                ogr.Tc                = txtTC.Text;
                ogr.DogumTarih        = dtDogum.Value;
                ogr.Cinsiyet          = Convert.ToByte(cbxCinsiyet.SelectedValue);
                ogr.Email             = txtEmail.Text;
                ogr.BolumId           = Convert.ToInt32(cbxBolum.SelectedValue);
                ogr.KayityapanID      = kayityapanID;
                ogr.KayitYapilantarih = DateTime.Now.Date;
                ogr.AktifPasif        = Convert.ToByte(active.pasif);
                h.CUD(ogr, System.Data.Entity.EntityState.Modified);
                StudentgridShow();
                Clear();
                IsClick1 = false;
                MessageBox.Show("Öğrenci Silindi.", "BAŞARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen Öğrenci Seçin !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }                   
            
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (txtDersAdi.Text == "" || txtDersKodu.Text == "" || txtKredi.Text == "" || cbxBolumAd.Text == ""
                || cbxOgretmen.Text == "")
            {
                MessageBox.Show("Eksik Bilgi Girdiniz...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                d.DersAdi    = txtDersAdi.Text;
                d.DersKodu   = txtDersKodu.Text;
                d.Kredi      = Convert.ToInt32(txtKredi.Text);
                d.BolumId    = Convert.ToInt32(cbxBolumAd.SelectedValue);
                d.AktifPasif = Convert.ToByte(active.aktif);
                hl.DersCUD(d, System.Data.Entity.EntityState.Added);

                od.Ogrt_Ogr_ID = Convert.ToInt32(cbxOgretmen.SelectedValue);
                od.DersID      = d.DersId;
                od.Type        = Convert.ToInt32(style.ogretmen);
                od.Vize1 = 0;
                od.Vize2 = 0;
                od.Final = 0;
                hl.OgretmenDersCUD(od, System.Data.Entity.EntityState.Added);
                LessongridShow();
                MessageBox.Show("Kayıt Eklendi.", "BAŞARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtDersAdi.Text  = "";
            txtDersKodu.Text = "";
            txtKredi.Text    = "";
        }

        private void CbxBolumAd_SelectedValueChanged(object sender, EventArgs e)
        {
            cbxOgretmen.Text = "";
            int Id           = Convert.ToInt32(cbxBolumAd.SelectedValue);

            cbxOgretmen.ValueMember   = "OgretmenId";
            cbxOgretmen.DisplayMember = "OgretmenAdi";
            cbxOgretmen.DataSource    = ho.OgretmenList(Id);
            LessongridShow();
        }

        public void LessongridShow()
        {
            DgLesson.Rows.Clear();
            sayac = 0;
            foreach (var item in hl.OgrGetLessonList(Convert.ToInt32(style.ogretmen), Convert.ToInt32(active.aktif), Convert.ToInt32(cbxBolumAd.SelectedValue)))
            {
                var bolum = hd.GetDepartment(item.Ogretmen.BolumId.Value);
                DgLesson.Rows.Add();
                DgLesson.Rows[sayac].Cells[0].Value = item.Ogretmen_Ogrenci_DersID;
                DgLesson.Rows[sayac].Cells[1].Value = item.Ders.DersAdi;
                DgLesson.Rows[sayac].Cells[2].Value = item.Ders.DersKodu;
                DgLesson.Rows[sayac].Cells[3].Value = item.Ders.Kredi;
                DgLesson.Rows[sayac].Cells[4].Value = item.Ogretmen.OgretmenAdi;
                DgLesson.Rows[sayac].Cells[5].Value = bolum.BolumAdi;
                sayac++;
            }
        }

        public void NotegridShow()
        {
            dataGridView1.Rows.Clear();
            sayac = 0;
            var s = hl.GetLessonList(Convert.ToInt32(style.ogrenci), Convert.ToInt32(active.aktif), NotDersId);
            foreach (var item in s)
            {
                HelperStudent hs = new HelperStudent();
                var st = hs.GetStudent(Convert.ToInt32(item.Ogrt_Ogr_ID));
                dataGridView1.Rows.Add();
                dataGridView1.Rows[sayac].Cells[0].Value  = item.Ogretmen_Ogrenci_DersID;
                dataGridView1.Rows[sayac].Cells[1].Value  = item.Ogrt_Ogr_ID;
                dataGridView1.Rows[sayac].Cells[2].Value  = sayac + 1;
                dataGridView1.Rows[sayac].Cells[3].Value  = st.OgrNo;
                dataGridView1.Rows[sayac].Cells[4].Value  = st.Ad;
                dataGridView1.Rows[sayac].Cells[5].Value  = st.Soyad;
                dataGridView1.Rows[sayac].Cells[6].Value  = item.Ders.DersAdi;
                dataGridView1.Rows[sayac].Cells[7].Value  = item.Vize1;
                dataGridView1.Rows[sayac].Cells[8].Value  = item.Vize2;
                dataGridView1.Rows[sayac].Cells[9].Value  = item.Final;
                dataGridView1.Rows[sayac].Cells[10].Value = item.DersID;
                sayac++;
            }
        }

        public void StudentgridShow()
        {
            DgOgrenci.Rows.Clear();
            string cinsiyet;
            sayac = 0;            
            var st = h.StudentList(Convert.ToInt32(active.aktif));
            if (st != null)
            {
                foreach (var item in st)
                {
                    var u = hu.GetUser(item.OgrId, Convert.ToInt32(style.ogrenci));
                    if (item.Cinsiyet == Convert.ToByte(gender.kız))
                        cinsiyet = gender.kız.ToString();
                    else
                        cinsiyet = gender.erkek.ToString();
                    DgOgrenci.Rows.Add();
                    DgOgrenci.Rows[sayac].Cells[0].Value = item.OgrId;
                    DgOgrenci.Rows[sayac].Cells[1].Value = item.OgrNo;
                    DgOgrenci.Rows[sayac].Cells[2].Value = item.Ad;
                    DgOgrenci.Rows[sayac].Cells[3].Value = item.Soyad;
                    DgOgrenci.Rows[sayac].Cells[4].Value = item.Tc;
                    DgOgrenci.Rows[sayac].Cells[5].Value = item.DogumTarih.Value.ToShortDateString();
                    DgOgrenci.Rows[sayac].Cells[6].Value = cinsiyet;
                    DgOgrenci.Rows[sayac].Cells[7].Value = item.Email;
                    DgOgrenci.Rows[sayac].Cells[8].Value = item.Bolum.FakulteAdi;
                    DgOgrenci.Rows[sayac].Cells[9].Value = item.Bolum.BolumAdi;
                    DgOgrenci.Rows[sayac].Cells[10].Value = u.Password;
                    sayac++;
                }
            }
            else
            {
                MessageBox.Show("Listelenecek Öğrenci Mevcut Değil.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }
        public void Clear()
        {
            txtOgrNo.Clear();
            txtAd.Clear();
            txtSoyad.Clear();
            txtTC.Clear();
            txtEmail.Clear();
            txtPass.Clear();
            dtDogum.Value          = DateTime.Now.Date;
            cbxBolum.SelectedValue = "";
            cbxCinsiyet.Text       = "";
        }

        private void DgLesson_Click(object sender, EventArgs e)
        {
            int index        = DgLesson.CurrentCell.RowIndex;
            IsClick2         = true;
            dersID           = Convert.ToInt32(DgLesson.Rows[index].Cells[0].Value);
            txtDersAdi.Text  = DgLesson.Rows[index].Cells[1].Value.ToString();
            txtDersKodu.Text = DgLesson.Rows[index].Cells[2].Value.ToString();
            txtKredi.Text    = DgLesson.Rows[index].Cells[3].Value.ToString();
            cbxOgretmen.Text = DgLesson.Rows[index].Cells[4].Value.ToString();
            cbxBolumAd.Text  = DgLesson.Rows[index].Cells[5].Value.ToString();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (IsClick2)
            {
                var l      = hl.GetLesson(dersID);
                d.DersId   = Convert.ToInt32(l.DersID);
                d.DersAdi  = txtDersAdi.Text;
                d.DersKodu = txtDersKodu.Text;
                d.Kredi    = Convert.ToInt32(txtKredi.Text);
                d.BolumId  = Convert.ToInt32(cbxBolumAd.SelectedValue);
                hl.DersCUD(d, System.Data.Entity.EntityState.Modified);

                od.Ogretmen_Ogrenci_DersID = dersID;
                od.Ogrt_Ogr_ID             = Convert.ToInt32(cbxOgretmen.SelectedValue);
                od.DersID                  = d.DersId;
                od.Type                    = Convert.ToInt32(style.ogretmen);
                hl.OgretmenDersCUD(od, System.Data.Entity.EntityState.Modified);
                LessongridShow();
                IsClick2 = false;
                MessageBox.Show("Kayıt Güncellendi.", "BAŞARI", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Lütfen Güncellemek İstediğiniz dersi Seçin !","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            txtDersAdi.Text  = "";
            txtDersKodu.Text = "";
            txtKredi.Text    = "";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (IsClick2)
            {
                var l = hl.GetLesson(dersID);
                d.DersId     = Convert.ToInt32(l.DersID);
                d.DersAdi    = txtDersAdi.Text;
                d.DersKodu   = txtDersKodu.Text;
                d.Kredi      = Convert.ToInt32(txtKredi.Text);
                d.BolumId    = Convert.ToInt32(cbxBolumAd.SelectedValue);
                d.AktifPasif = Convert.ToByte(active.pasif);
                hl.DersCUD(d, System.Data.Entity.EntityState.Modified);
                LessongridShow();
            }
            else
            {
                MessageBox.Show("Lütfen Silmek İstediğiniz Dersi Seçin !!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (IscLick3)
            {
                od.Ogretmen_Ogrenci_DersID = ogrt_ogr_ders_Id;
                od.Ogrt_Ogr_ID             = ogrt_ogr_ID;
                od.DersID                  = ogrt_dersID;
                od.Type                    = Convert.ToInt32(style.ogrenci);
                od.Vize1                   = Convert.ToInt32(txtVize1.Text);
                od.Vize2                   = Convert.ToInt32(txtVize2.Text);
                od.Final                   = Convert.ToInt32(txtFinal.Text);
                hl.OgretmenDersCUD(od, System.Data.Entity.EntityState.Modified);
                NotegridShow();
                IscLick3 = false;               
            }
            else
            {
                MessageBox.Show("Notunu Gireceğiniz Öğrenciyi Seçin !!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void CbxDersSec_SelectedValueChanged(object sender, EventArgs e)
        {
            NotDersId = Convert.ToInt32(cbxDersSec.SelectedValue);
            NotegridShow();
        }

        private void CbxBolumSec_SelectedValueChanged(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(cbxBolumSec.SelectedValue);

            cbxDersSec.ValueMember   = "DersID";
            cbxDersSec.DisplayMember = "DersAdi";
            cbxDersSec.DataSource    = hl.GetLessonById(Id);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (IscLick3)
            {
                od.Ogretmen_Ogrenci_DersID = ogrt_ogr_ders_Id;
                od.Ogrt_Ogr_ID             = ogrt_ogr_ID;
                od.DersID                  = ogrt_dersID;
                od.Type                    = Convert.ToInt32(style.ogrenci);
                od.Vize1                   = Convert.ToInt32(txtVize1.Text);
                od.Vize2                   = Convert.ToInt32(txtVize2.Text);
                od.Final                   = Convert.ToInt32(txtFinal.Text);
                hl.OgretmenDersCUD(od, System.Data.Entity.EntityState.Modified);
                NotegridShow();
            }
            else
            {
                MessageBox.Show("Notunu Güncelleyeceğiniz Öğrenciyi Seçin !!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void DataGridView1_Click(object sender, EventArgs e)
        {

            IscLick3 = true;
            ogrt_ogr_ders_Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            ogrt_ogr_ID      = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
            ogrt_dersID      = Convert.ToInt32(dataGridView1.CurrentRow.Cells[10].Value);
            txtVize1.Text    = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtVize2.Text    = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtFinal.Text    = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            StudentgridShow();
        }

        private void cbxFakulte_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxBolum.ValueMember   = "BolumId";
            cbxBolum.DisplayMember = "BolumAdi";
            cbxBolum.DataSource    = hd.DepartmentList(cbxFakulte.SelectedItem.ToString());
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {            
            Form5 f5 = new Form5();
            f5.Show();
        }
    }
}
