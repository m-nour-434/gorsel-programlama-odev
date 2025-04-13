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

namespace Ödev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string connectionString = @"Server=.\SQLEXPRESS;Database=KullaniciDB;Trusted_Connection=True;";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ad = textAd.Text;
            string soyad = textSoyad.Text;
            int gun = int.Parse(textGun.Text);
            int ay = int.Parse(textAy.Text);
            string ayAdi = Getaylar(ay);
            int yil= int.Parse(textYıl.Text);
            double boy = double.Parse(textBoy.Text);
            double kilo = double.Parse(textKilo.Text);
            string burc = GetBurc(gun, ay);
            string burcYorum = GetBurcYorum(burc);
            double vki = kilo / (boy * boy);
            string vkiYorum= GetVKIYorum(vki);
            string burcResmi = GetBurcResmi(burc);


            listAd.Items.Add(ad);
            listSoyad.Items.Add(soyad);
            listGun.Items.Add(gun);
            listAy.Items.Add(ayAdi);
            listYil.Items.Add(yil);
            listBurc.Items.Add(burc);
            listBurcYorum.Items.Add(burcYorum);
            listVKİ.Items.Add(vki);
            listVKİYorum.Items.Add(vkiYorum);
            piBurc.Image= Image.FromFile(burcResmi);
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO KullaniciBilgileri " +
                               "(Ad, Soyad, Gun, Ay, Yil, Burc, BurcYorum,burcResmi, VKI, VKIYorum) " +
                               "VALUES (@Ad, @Soyad, @Gun, @Ay, @Yil, @Burc, @BurcYorum,@burcResmi,  @VKI, @VKIYorum)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Ad", ad);
                cmd.Parameters.AddWithValue("@Soyad", soyad);
                cmd.Parameters.AddWithValue("@Gun", gun);
                cmd.Parameters.AddWithValue("@Ay", ayAdi);
                cmd.Parameters.AddWithValue("@Yil", yil);
                cmd.Parameters.AddWithValue("@Burc", burc);
                cmd.Parameters.AddWithValue("@BurcYorum", burcYorum);
                cmd.Parameters.AddWithValue("@burcResmi", burcResmi);
                cmd.Parameters.AddWithValue("@VKI", vki);
                cmd.Parameters.AddWithValue("@VKIYorum", vkiYorum);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Kayıt başarılı!");

        }
        private string GetBurc(int gun, int ay)
        {
            if ((ay == 1 && gun >= 20) || (ay == 2 && gun <= 18)) return "Kova";
            else if ((ay == 2 && gun >= 19) || (ay == 3 && gun <= 20)) return "Balık";
            else if ((ay == 3 && gun >= 21) || (ay == 4 && gun <= 19)) return "Koç";
            else if ((ay == 4 && gun >= 20) || (ay == 5 && gun <= 20)) return "Boğa";
            else if ((ay == 5 && gun >= 21) || (ay == 6 && gun <= 20)) return "İkizler";
            else if ((ay == 6 && gun >= 21) || (ay == 7 && gun <= 22)) return "Yengeç";
            else if ((ay == 7 && gun >= 23) || (ay == 8 && gun <= 22)) return "Aslan";
            else if ((ay == 8 && gun >= 23) || (ay == 9 && gun <= 22)) return "Başak";
            else if ((ay == 9 && gun >= 23) || (ay == 10 && gun <= 22)) return "Terazi";
            else if ((ay == 10 && gun >= 23) || (ay == 11 && gun <= 21)) return "Akrep";
            else if ((ay == 11 && gun >= 22) || (ay == 12 && gun <= 21)) return "Yay";
            else if ((ay == 12 && gun >= 22) || (ay == 1 && gun <= 19)) return "Oğlak";
            else return "Bilinmiyor";
        }
        private string GetBurcYorum(string burc)
        {
            if (burc == "Kova") return "Özgün ve bağımsız.";
            else if (burc == "Balık") return "Hayalperest ve sezgisel.";
            else if (burc == "Koç") return "Cesur ve enerjik.";
            else if (burc == "Boğa") return "Sabırlı ve güvenilir.";
            else if (burc == "İkizler") return "Zeki ve meraklı.";
            else if (burc == "Yengeç") return "Duygusal ve sezgisel.";
            else if (burc == "Aslan") return "Kendine güvenen ve cömert.";
            else if (burc == "Başak") return "Titiz ve çalışkan.";
            else if (burc == "Terazi") return "Adaletli ve zarif.";
            else if (burc == "Akrep") return "Tutkulu ve kararlı.";
            else if (burc == "Yay") return "Özgür ruhlu ve iyimser.";
            else if (burc == "Oğlak") return "Disiplinli ve sorumluluk sahibi.";
            else return "Bilinmiyor";
        }
        private string GetVKIYorum(double vki)
        {
            if (vki < 18.5) return "Zayıf";
            else if (vki < 24.9) return "Normal";
            else if (vki < 29.9) return "Fazla kilolu";
            else return "Obez";
        }
        private string Getaylar(int ay)
        {
            if (ay  == 12) return "Aralık";
            else if (ay == 1) return "Ocak";
            else if (ay == 2) return "Şubat";
            else if (ay == 3) return "Mart";
            else if (ay == 4) return "Nisan";
            else if (ay == 5) return "Mayıs";
            else if (ay == 6) return "Haziran";
            else if (ay == 7) return "Temmuz";
            else if (ay == 8) return "Ağustos";
            else if (ay == 9) return "Eylül";
            else if (ay == 10) return "Ekim";
            else if (ay == 11) return "Kasım";
            else return "Bilinmiyor";
        }
        private string GetBurcResmi(string burc)
        {
            string klasor = Application.StartupPath + "\\Burçlar\\";
            string dosyaAdi = burc.ToLower() + ".jpg";
            return Path.Combine(klasor, dosyaAdi);
        }


    }
}
