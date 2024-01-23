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

namespace TicariOtomasyon
{
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_ADMIN", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            listele();
            TxtKullaniciAdi.Text = "";
            TxtSifre.Text = "";
        }

        private void BtnIslem_Click(object sender, EventArgs e)
        {
            if (BtnIslem.Text == "Kaydet")
            {
                SqlCommand komut = new SqlCommand("insert into TBL_ADMIN VALUES (@P1, @P2)", bgl.baglanti());
                komut.Parameters.AddWithValue("@P1", TxtKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@P2", TxtSifre.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Yeni admin sisteme kaydedildi.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            if (BtnIslem.Text == "Güncelle")
            {
                SqlCommand komut1 = new SqlCommand("update TBL_ADMIN set Sifre=@p1 where KullaniciAd=@p2", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", TxtSifre.Text);
                komut1.Parameters.AddWithValue("@p2", TxtKullaniciAdi.Text);
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt güncellendi.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listele();
            }
          
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtKullaniciAdi.Text = dr["KullaniciAd"].ToString();
                TxtSifre.Text = dr["Sifre"].ToString();
            }
        }

        private void TxtKullaniciAdi_TextChanged(object sender, EventArgs e)
        {
            // textboxta herhangi bir değer geldiği zaman ne olsun???
            if (TxtKullaniciAdi.Text != "")
            {
                BtnIslem.Text = "Güncelle";
                BtnIslem.BackColor = Color.Pink;
            }
            else
            {
                BtnIslem.Text = "Kaydet";
                BtnIslem.BackColor = Color.MediumTurquoise;
            }
        }
    }
}
