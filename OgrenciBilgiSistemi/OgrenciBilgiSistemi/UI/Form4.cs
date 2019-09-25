using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OgrenciBilgiSistemi.DAL;

namespace OgrenciBilgiSistemi.UI
{
    public partial class Form4 : Form
    {
        Ogretmen_Ogrenci_Ders od = new Ogretmen_Ogrenci_Ders();
        HelperStudent hs         = new HelperStudent();
        HelperLesson hl          = new HelperLesson();
        int ogrtId;
        int dersID;
        int sayac;
        int ogrt_ogr_ders_Id;
        int ogrt_ogr_ID;
        bool Isclick;
        public Form4(int ogrtId)
        {
            this.ogrtId = ogrtId;
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            var a = hs.GetLessons(this.ogrtId, Convert.ToInt32(style.ogretmen));
            List<Ders> dl = new List<Ders>();
            foreach (var item in a)
            {
               dl.Add(hl.GetLessonBydersId(item.Ders.DersId));
               
            }
            cbxDers.ValueMember   = "DersId";
            cbxDers.DisplayMember = "DersAdi";
            cbxDers.DataSource    = dl;          
            
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void cbxDers_SelectedValueChanged(object sender, EventArgs e)
        {
            dersID = Convert.ToInt32(cbxDers.SelectedValue);
            NotegridShow();

        }

        public void NotegridShow()
        {
            dataGridView1.Rows.Clear();
            sayac = 0;
            var s = hl.GetLessonList(Convert.ToInt32(style.ogrenci), Convert.ToInt32(active.aktif), dersID);
            foreach (var item in s)
            {
                HelperStudent hs = new HelperStudent();
                var st = hs.GetStudent(Convert.ToInt32(item.Ogrt_Ogr_ID));
                dataGridView1.Rows.Add();
                dataGridView1.Rows[sayac].Cells[0].Value = item.Ogretmen_Ogrenci_DersID;
                dataGridView1.Rows[sayac].Cells[1].Value = item.Ogrt_Ogr_ID;
                dataGridView1.Rows[sayac].Cells[2].Value = sayac + 1;
                dataGridView1.Rows[sayac].Cells[3].Value = st.OgrNo;
                dataGridView1.Rows[sayac].Cells[4].Value = st.Ad;
                dataGridView1.Rows[sayac].Cells[5].Value = st.Soyad;
                dataGridView1.Rows[sayac].Cells[6].Value = item.Ders.DersAdi;
                dataGridView1.Rows[sayac].Cells[7].Value = item.Vize1;
                dataGridView1.Rows[sayac].Cells[8].Value = item.Vize2;
                dataGridView1.Rows[sayac].Cells[9].Value = item.Final;
                dataGridView1.Rows[sayac].Cells[10].Value = item.DersID;
                sayac++;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Isclick)
            {
                od.Ogretmen_Ogrenci_DersID = ogrt_ogr_ders_Id;
                od.Ogrt_Ogr_ID             = ogrt_ogr_ID;
                od.DersID                  = dersID;
                od.Type                    = Convert.ToInt32(style.ogrenci);
                od.Vize1                   = Convert.ToInt32(txtVize1.Text);                  
                od.Vize2                   = Convert.ToInt32(txtVize2.Text);                
                od.Final                   = Convert.ToInt32(txtFinal.Text);                
                hl.OgretmenDersCUD(od, System.Data.Entity.EntityState.Modified);
                NotegridShow();
                Isclick = false;
            }
            else
            {
                MessageBox.Show("Lütfen Öğrenci Seçin.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            Isclick = true;
            ogrt_ogr_ders_Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            ogrt_ogr_ID      = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
            dersID           = Convert.ToInt32(dataGridView1.CurrentRow.Cells[10].Value);
            txtVize1.Text    = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtVize2.Text    = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtFinal.Text    = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Isclick)
            {
                od.Ogretmen_Ogrenci_DersID = ogrt_ogr_ders_Id;
                od.Ogrt_Ogr_ID             = ogrt_ogr_ID;
                od.DersID                  = dersID;
                od.Type                    = Convert.ToInt32(style.ogrenci);
                od.Vize1                   = Convert.ToInt32(txtVize1.Text);
                od.Vize2                   = Convert.ToInt32(txtVize2.Text);
                od.Final                   = Convert.ToInt32(txtFinal.Text);
                hl.OgretmenDersCUD(od, System.Data.Entity.EntityState.Modified);
                NotegridShow();
                Isclick = false;
            }
            else
            {
                MessageBox.Show("Lütfen Öğrenci Seçin.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();

        }
    }
}
