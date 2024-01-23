using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace TicariOtomasyon
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }

        public string mail;
        private void FrmMail_Load(object sender, EventArgs e)
        {
            TxtMailAdresi.Text = mail;
        }

        private void BtnGonder_Click(object sender, EventArgs e)
        {
            MailMessage mesajim = new MailMessage(); // MailMessage sınıfından nesne türettik.
            // Simple Mail Transfer Protokol mail göndermek için s - c arasındaki iletişimi belirleyen protokoldür.
            SmtpClient istemci = new SmtpClient();
            // Credentials kimlik. Aşağıdaki istemcinin kimliği
            istemci.Credentials = new System.Net.NetworkCredential("Mail", "Şifre"); // Kendi mail ve şifreni yaz.
            istemci.Port = 587;
            istemci.Host = "smtp.live.com"; // gmail olarak değiştirebilirsiniz.
            istemci.EnableSsl = true; // Yol boyunca şifrelesin.
            mesajim.To.Add(RchMesaj.Text);
            mesajim.From = new MailAddress("Mail");
            mesajim.Subject = TxtKonu.Text;
            mesajim.Body = RchMesaj.Text;
            istemci.Send(mesajim);
        }
    }
}
