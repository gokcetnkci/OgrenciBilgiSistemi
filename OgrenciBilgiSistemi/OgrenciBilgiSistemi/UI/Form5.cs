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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }       

        private void Form5_Load(object sender, EventArgs e)
        {
            gridShow();
        }
        DataTable table;
        public void gridShow()
        {          
            table = new DataTable();
            table.Columns.Add("Ad", typeof(string));
            table.Columns.Add("Soyad", typeof(string));
            table.Columns.Add("ÖğrenciNo", typeof(string));
            table.Columns.Add("Tc", typeof(string));
            table.Columns.Add("Bölüm", typeof(string));
            table.Columns.Add("AldığıDers", typeof(string));
            table.Columns.Add("Öğretmen", typeof(string));

            int sayac = 0;
            HelperLesson hl     = new HelperLesson();
            HelperStudent hs    = new HelperStudent();
            HelperDepartment hd = new HelperDepartment();
            var list = hs.StudentList(Convert.ToInt32(active.aktif));
            foreach (var item in list)
            {
                var list2 = hs.GetLessons(item.OgrId, Convert.ToInt32(style.ogrenci));
                foreach (var item2 in list2)
                {
                    var list3 = hl.GetLessonList(Convert.ToInt32(style.ogretmen), Convert.ToInt32(active.aktif), item2.Ders.DersId);
                    foreach (var item3 in list3)
                    {
                        var b = hd.GetDepartment(item3.Ogretmen.BolumId.Value);
                        table.Rows.Add(item.Ad, item.Soyad, item.OgrNo, item.Tc, b.BolumAdi, item2.Ders.DersAdi, item3.Ogretmen.OgretmenAdi);
                        dataGridView1.DataSource = table;                        
                    }
                    sayac++;
                }
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv  = table.DefaultView;
            dv.RowFilter = "Tc LIKE '" + textBox1.Text + "%'";
            dataGridView1.DataSource = dv;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            DataView dv  = table.DefaultView;
            dv.RowFilter = "ÖğrenciNo LIKE '" + textBox2.Text + "%'";
            dataGridView1.DataSource = dv;
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            DataView dv  = table.DefaultView;
            dv.RowFilter = "Ad LIKE '" + textBox3.Text + "%'";
            dataGridView1.DataSource = dv;
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            DataView dv  = table.DefaultView;
            dv.RowFilter = "Bölüm LIKE '" + textBox4.Text + "%'";
            dataGridView1.DataSource = dv;
        }
    }
}
