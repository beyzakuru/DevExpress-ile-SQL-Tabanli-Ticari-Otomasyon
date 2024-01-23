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
    public partial class FrmFaturaUrunDetay : Form
    {
        public FrmFaturaUrunDetay()
        {
            InitializeComponent();
        }

        public string id; //faturabilgi tablosundaki id değerini (fatura detay tablosundaki son sütundaki değeri) forma taşımak amacımız.

        sqlbaglantisi bgl = new sqlbaglantisi();
        
        void listele()
        {
            // sql tabanında sorgulama yaparken (şuna eşit mi derken) eşitlik direkt sayısal bir ifade değilse tek tırnak içinde yazılıyor
            // c# ta da tek tırnak tek başına kullanılmadığından çift tırnak blokları arasına yazmış olduk. '"xxx"'
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_FATURADETAY where FaturaID='" + id + "'", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FrmFaturaUrunDetay_Load(object sender, EventArgs e)
        {
            // form yüklendiğinde taşınan ıd'ye (fatura) göre ürünleri listelesin 
            listele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunDuzenleme fr = new FrmFaturaUrunDuzenleme();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                fr.urunid = dr["FATURAURUNID"].ToString();
            }
            fr.Show();
        }
    }
}
