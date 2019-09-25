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
using OgrenciBilgiSistemi.Model;
using OgrenciBilgiSistemi.UI;

namespace OgrenciBilgiSistemi.UI
{
    public partial class Form2 : Form
    {
        public int Id { get; set; }
        public int type { get; set; }
        List<Ogrenci_Ders_Model> st = new List<Ogrenci_Ders_Model>();
        List<Ogrenci_Ders_Model> dl = new List<Ogrenci_Ders_Model>();

        HelperLesson hl = new HelperLesson();
        HelperStudent hs = new HelperStudent();
        Ogrenci_Ders_Model ogr = new Ogrenci_Ders_Model();

        int sayac;
        bool Isclick1;


        public Form2(int Id, int type)
        {
            this.Id = Id;
            this.type = type;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            NoteShow();
            LessonShow();
        }

        public void NoteShow()
        {
            dataGridView1.Rows.Clear();

            HelperStudent h     = new HelperStudent();
            HelperDepartment hd = new HelperDepartment();
            var a               = hs.GetStudent(this.Id);
            var b               = hd.GetDepartment(a.BolumId.Value);
            DateTime date       = a.DogumTarih.Value;

            label7.Text  = a.Ad;
            label8.Text  = a.Soyad;
            label9.Text  = a.Tc;
            label10.Text = date.ToShortDateString();
            label11.Text = b.BolumAdi;
            label12.Text = a.Email;

            st = h.GetLessons(this.Id, this.type);
            sayac = 0;
            double ort;
            foreach (var item in st)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[sayac].Cells[0].Value = item.Ders.DersAdi;
                dataGridView1.Rows[sayac].Cells[1].Value = item.Ders.DersKodu;
                dataGridView1.Rows[sayac].Cells[2].Value = item.Vize1;
                dataGridView1.Rows[sayac].Cells[3].Value = item.Vize2;
                dataGridView1.Rows[sayac].Cells[4].Value = item.Final;
                if (item.Vize1 != 0 && item.Vize2 != 0 && item.Final != 0)
                {
                    ort = Convert.ToDouble((item.Vize1 * 0.3) + (item.Vize2 * 0.3) + (item.Final * 0.4));
                    dataGridView1.Rows[sayac].Cells[5].Value = ort;
                    dataGridView1.Rows[sayac].Cells[6].Value = StudentInfo.HarfNotu(ort);
                }
                else
                {
                    dataGridView1.Rows[sayac].Cells[5].Value = 0;
                }
                sayac++;
            }
        }        

        public void LessonShow()
        {
            var a = hs.GetStudent(this.Id);
            sayac = 0;
            foreach (var item in hl.OgrGetLessonList(Convert.ToInt32(style.ogretmen), Convert.ToInt32(active.aktif), a.BolumId.Value))
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[sayac].Cells[0].Value = item.Ogretmen_Ogrenci_DersID;
                dataGridView2.Rows[sayac].Cells[1].Value = item.DersID;
                dataGridView2.Rows[sayac].Cells[2].Value = sayac + 1;
                dataGridView2.Rows[sayac].Cells[3].Value = item.Ders.DersAdi;
                dataGridView2.Rows[sayac].Cells[4].Value = item.Ders.DersKodu;
                dataGridView2.Rows[sayac].Cells[5].Value = item.Ders.Kredi;
                dataGridView2.Rows[sayac].Cells[6].Value = item.Ogretmen.OgretmenAdi;
                dataGridView2.Rows[sayac].Cells[7].Value = item.Ogretmen.OgretmenId;
                sayac++;
            }
        }

        private void DataGridView2_Click(object sender, EventArgs e)
        {
            Isclick1 = true;
            ogr.Ogretmen_Ogrenci_DersID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            ogr.Ogrt_Ogr_ID             = this.Id;
            ogr.DersID                  = Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value);
            ogr.Ders.DersAdi            = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            ogr.Ders.DersKodu           = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            ogr.Ders.Kredi              = Convert.ToInt32(dataGridView2.CurrentRow.Cells[5].Value.ToString());
            ogr.Ogretmen.OgretmenAdi    = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            ogr.Ogretmen.OgretmenId     = Convert.ToInt32(dataGridView2.CurrentRow.Cells[7].Value);
            ogr.Type                    = Convert.ToInt32(style.ogrenci);
            ogr.Vize1                   = 0;
            ogr.Vize2                   = 0;
            ogr.Final                   = 0;
            dl.Add(ogr);
        }

        private void BtnDersEkle_Click(object sender, EventArgs e)
        {
            if (Isclick1)
            {
                Ogretmen_Ogrenci_Ders od = new Ogretmen_Ogrenci_Ders();
                od.Ogrt_Ogr_ID = ogr.Ogrt_Ogr_ID;
                od.DersID      = ogr.DersID;
                od.Type        = ogr.Type;
                od.Vize1       = ogr.Vize1;
                od.Vize2       = ogr.Vize2;
                od.Final       = ogr.Final;
                hl.OgretmenDersCUD(od, System.Data.Entity.EntityState.Added);
                NoteShow();
                MessageBox.Show("Ders Başarılı Bir Şekilde Eklendi.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen Ders Seçimi Yapın", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }       

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();            
        }

    }
}
