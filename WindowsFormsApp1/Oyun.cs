using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Collections;

namespace WindowsFormsApp1
{
    public partial class Oyun : Form
    {
        public Oyun()
        {
            InitializeComponent();
            con= new MySqlConnection("Server=localhost;Database=kelimeoyunu;Uid=root;Pwd='';");
        }

        MySqlConnection con;
        MySqlCommand cmd1,cmd2;
        MySqlDataReader dr1,dr2;

        ArrayList dortharf = new ArrayList();
        ArrayList besharf = new ArrayList();
        ArrayList altiharf = new ArrayList();
        ArrayList yediharf = new ArrayList();
        ArrayList sekizharf = new ArrayList();
        ArrayList dokuzharf = new ArrayList();
        ArrayList onharf = new ArrayList();

        int saniye = 60;
        int saniye2 = 20;
        int dakika = 4;
        int harf = 4;
        char[] charCevap;
        string cevap;
        int sayac = 0;
        int puan = 400;
        int toplampuan = 0;
        public string kadi { get; set; }
        Random rastgele = new Random();

        public void Harfiste()
        {
            int i = rastgele.Next(0, charCevap.Length);
            char x = charCevap[i];
            if (x != ' ')
            {
                if (i == 0)
                {
                    textBox1.Text = x.ToString();
                    charCevap[i] = ' ';
                    puan = puan - 100;
                    label2.Text = puan.ToString();
                }
                else if (i == 1)
                {
                    textBox2.Text = x.ToString();
                    charCevap[i] = ' ';
                    puan = puan - 100;
                    label2.Text = puan.ToString();
                }
                else if (i == 2)
                {
                    textBox3.Text = x.ToString();
                    charCevap[i] = ' ';
                    puan = puan - 100;
                    label2.Text = puan.ToString();
                }
                else if (i == 3)
                {
                    textBox4.Text = x.ToString();
                    charCevap[i] = ' ';
                    puan = puan - 100;
                    label2.Text = puan.ToString();
                }
                else if (i == 4)
                {
                    textBox5.Text = x.ToString();
                    charCevap[i] = ' ';
                    puan = puan - 100;
                    label2.Text = puan.ToString();
                }
                else if (i == 5)
                {
                    textBox6.Text = x.ToString();
                    charCevap[i] = ' ';
                    puan = puan - 100;
                    label2.Text = puan.ToString();
                }
                else if (i == 6)
                {
                    textBox7.Text = x.ToString();
                    charCevap[i] = ' ';
                    puan = puan - 100;
                    label2.Text = puan.ToString();
                }
                else if (i == 7)
                {
                    textBox8.Text = x.ToString();
                    charCevap[i] = ' ';
                    puan = puan - 100;
                    label2.Text = puan.ToString();
                }
                else if (i == 8)
                {
                    textBox9.Text = x.ToString();
                    charCevap[i] = ' ';
                    puan = puan - 100;
                    label2.Text = puan.ToString();
                }
                else if (i == 9)
                {
                    textBox10.Text = x.ToString();
                    charCevap[i] = ' ';
                    puan = puan - 100;
                    label2.Text = puan.ToString();
                }
            }
            else
                Harfiste();
        }

        public void textBoxTemizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox13.Clear();
        }
        private void Oyun_Load(object sender, EventArgs e)
        {
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            textBox11.Enabled = false;
            textBox13.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

            con.Open();
            for (int harf = 4; harf <= 10; harf++)
            {
                cmd1 = new MySqlCommand("SELECT * FROM cevaplar where harf_sayisi=" + harf, con);
                dr1 = cmd1.ExecuteReader();
                while (dr1.Read())
                {
                    if (harf == 4)
                        dortharf.Add(dr1["cevap_id"].ToString());
                    else if (harf == 5)
                        besharf.Add(dr1["cevap_id"].ToString());
                    else if (harf == 6)
                        altiharf.Add(dr1["cevap_id"].ToString());
                    else if (harf == 7)
                        yediharf.Add(dr1["cevap_id"].ToString());
                    else if (harf == 8)
                        sekizharf.Add(dr1["cevap_id"].ToString());
                    else if (harf == 9)
                        dokuzharf.Add(dr1["cevap_id"].ToString());
                    else
                        onharf.Add(dr1["cevap_id"].ToString());
                }
                dr1.Close();
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = true;
            label1.Text = toplampuan.ToString();
            label2.Text = puan.ToString();
            timer1.Start();
            Random random = new Random();
            int sayi = random.Next(dortharf.Count);
            con.Open();
            cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + dortharf[sayi].ToString(), con);
            dr2 = cmd2.ExecuteReader();
            if (dr2.Read())
                textBox12.Text = dr2["soru"].ToString();
            dr2.Close();

            cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + dortharf[sayi].ToString(), con);
            dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                cevap = dr1["cevap"].ToString();
                cevap = cevap.ToUpper();
                MessageBox.Show(cevap);
                charCevap = cevap.ToCharArray();
            }
            dortharf.RemoveAt(sayi);
            sayac++;
            con.Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            saniye = saniye - 1;
            label5.Text = saniye.ToString();
            label3.Text = (dakika - 1).ToString();
            if (saniye == 0)
            {
                dakika = dakika - 1;
                label3.Text = dakika.ToString();
                saniye = 60;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Harfiste();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tahmin = textBox13.Text;
            tahmin = tahmin.ToUpper();
            if (tahmin == cevap)
            {
                label7.Text = "DOĞRU CEVAP";
                textBox13.Enabled = false;
                button4.Enabled = false;
                button3.Enabled = true;
                timer2.Stop();
                timer1.Start();
                saniye2 = 20;
                label6.Text = "--";
                textBoxTemizle();
                toplampuan = toplampuan + puan;
                label1.Text = toplampuan.ToString();

                con.Open();

                if (sayac < 2)
                {
                    Random random = new Random();
                    if (harf == 4)
                    {
                        puan = 400;
                        label2.Text = puan.ToString();
                        int sayi = random.Next(dortharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + dortharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + dortharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        dortharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else if (harf == 5)
                    {
                        puan = 500;
                        label2.Text = puan.ToString();
                        textBox5.Visible = true;
                        int sayi = random.Next(besharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + besharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + besharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        besharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else if (harf == 6)
                    {
                        puan = 600;
                        label2.Text = puan.ToString();
                        textBox6.Visible = true;
                        int sayi = random.Next(altiharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + altiharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + altiharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        altiharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else if (harf == 7)
                    {
                        puan = 700;
                        label2.Text = puan.ToString();
                        textBox7.Visible = true;
                        int sayi = random.Next(yediharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + yediharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + yediharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        yediharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else if (harf == 8)
                    {
                        puan = 800;
                        label2.Text = puan.ToString();
                        textBox8.Visible = true;
                        int sayi = random.Next(sekizharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + sekizharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + sekizharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        sekizharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else if (harf == 9)
                    {
                        puan = 900;
                        label2.Text = puan.ToString();
                        textBox9.Visible = true;
                        int sayi = random.Next(dokuzharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + dokuzharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + dokuzharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        dokuzharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else if (harf == 10)
                    {
                        puan = 1000;
                        label2.Text = puan.ToString();
                        textBox10.Visible = true;
                        int sayi = random.Next(onharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + onharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + onharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        onharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else
                    {
                        DateTime tarih = DateTime.Now;
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO skor(k_adi, skor, sure, tarih) VALUES('" + kadi + "','" + toplampuan + "','" + ((dakika - 1) + ":" + saniye).ToString() + "','" + tarih.ToShortDateString() + "')", con);
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Kullanıcı adı: " + kadi + ", Toplam puanı: " + toplampuan + ", Kalan süre:" + ((dakika - 1) + ":" + saniye).ToString() + ", Tarih ve zaman:" + tarih.ToString());
                            con.Close();
                            Giris frmGiris = new Giris();
                            this.Hide();
                            frmGiris.Show();
                        }
                    }
                }
                else
                {
                    Random random = new Random();
                    harf++;
                    sayac = 0;
                    if (harf == 5)
                    {
                        puan = 500;
                        label2.Text = puan.ToString();
                        textBox5.Visible = true;
                        int sayi = random.Next(besharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + besharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + besharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        besharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else if (harf == 6)
                    {
                        puan = 600;
                        label2.Text = puan.ToString();
                        textBox6.Visible = true;
                        int sayi = random.Next(altiharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + altiharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + altiharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        altiharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else if (harf == 7)
                    {
                        puan = 700;
                        label2.Text = puan.ToString();
                        textBox7.Visible = true;
                        int sayi = random.Next(yediharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + yediharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + yediharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        yediharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else if (harf == 8)
                    {
                        puan = 800;
                        label2.Text = puan.ToString();
                        textBox8.Visible = true;
                        int sayi = random.Next(sekizharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + sekizharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + sekizharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        sekizharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else if (harf == 9)
                    {
                        puan = 900;
                        label2.Text = puan.ToString();
                        textBox9.Visible = true;
                        int sayi = random.Next(dokuzharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + dokuzharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + dokuzharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        dokuzharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else if (harf == 10)
                    {
                        puan = 1000;
                        label2.Text = puan.ToString();
                        textBox10.Visible = true;
                        int sayi = random.Next(onharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + onharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + onharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        onharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else
                    {
                        DateTime tarih = DateTime.Now;
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO skor(k_adi, skor, sure, tarih) VALUES('" + kadi + "','" + toplampuan + "','" + ((dakika - 1) + ":" + saniye).ToString() + "','" + tarih.ToShortDateString() + "')", con);
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Kullanıcı adı: " + kadi + ", Toplam puanı: " + toplampuan + ", Kalan süre:" + ((dakika - 1) + ":" + saniye).ToString() + ", Tarih ve zaman:" + tarih.ToString());
                            con.Close();
                            Giris frmGiris = new Giris();
                            this.Hide();
                            frmGiris.Show();
                        }                       
                    }
                }
            }

            else
            {
                label7.Text = "YANLIŞ CEVAP";
                textBox13.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox13.Enabled = true;
            button4.Enabled = true;
            button3.Enabled = false;
            timer1.Stop();
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            timer2.Interval = 1000;
            saniye2 = saniye2 - 1;
            label6.Text = saniye2.ToString();
            if (saniye2 == 0)
            {
                label7.Text = "SÜRE DOLDU!!!!";
                textBox13.Enabled = false;
                button4.Enabled = false;
                button3.Enabled = true;
                timer2.Stop();
                timer1.Start();
                saniye2 = 20;
                toplampuan = toplampuan - puan;
                label1.Text = toplampuan.ToString();
                textBoxTemizle();
                
                con.Open();

                if (sayac < 2)
                {
                    Random random = new Random();
                    if (harf == 4)
                    {
                        puan = 400;
                        label2.Text = puan.ToString();
                        int sayi = random.Next(dortharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + dortharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + dortharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        dortharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else if (harf == 5)
                    {
                        puan = 500;
                        label2.Text = puan.ToString();
                        textBox5.Visible = true;
                        int sayi = random.Next(besharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + besharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + besharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        besharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else if (harf == 6)
                    {
                        puan = 600;
                        label2.Text = puan.ToString();
                        textBox6.Visible = true;
                        int sayi = random.Next(altiharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + altiharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + altiharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        altiharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else if (harf == 7)
                    {
                        puan = 700;
                        label2.Text = puan.ToString();
                        textBox7.Visible = true;
                        int sayi = random.Next(yediharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + yediharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + yediharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        yediharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else if (harf == 8)
                    {
                        puan = 800;
                        label2.Text = puan.ToString();
                        textBox8.Visible = true;
                        int sayi = random.Next(sekizharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + sekizharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + sekizharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        sekizharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else if (harf == 9)
                    {
                        puan = 900;
                        label2.Text = puan.ToString();
                        textBox9.Visible = true;
                        int sayi = random.Next(dokuzharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + dokuzharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + dokuzharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        dokuzharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else if (harf == 10)
                    {
                        puan = 1000;
                        label2.Text = puan.ToString();
                        textBox10.Visible = true;
                        int sayi = random.Next(onharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + onharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + onharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        onharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else
                    {
                        DateTime tarih = DateTime.Now;
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO skor(k_adi, skor, sure, tarih) VALUES('" + kadi + "','" + toplampuan + "','" + ((dakika - 1) + ":" + saniye).ToString() + "','" + tarih.ToShortDateString() + "')", con);
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Kullanıcı adı: " + kadi + ", Toplam puanı: " + toplampuan + ", Kalan süre:" + ((dakika - 1) + ":" + saniye).ToString() + ", Tarih ve zaman:" + tarih.ToString());
                            con.Close();
                            Giris frmGiris = new Giris();
                            this.Hide();
                            frmGiris.Show();
                        }
                    }
                }
                else
                {
                    Random random = new Random();
                    harf++;
                    sayac = 0;
                    if (harf == 5)
                    {
                        puan = 500;
                        label2.Text = puan.ToString();
                        textBox5.Visible = true;
                        int sayi = random.Next(besharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + besharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + besharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        besharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else if (harf == 6)
                    {
                        puan = 600;
                        label2.Text = puan.ToString();
                        textBox6.Visible = true;
                        int sayi = random.Next(altiharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + altiharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + altiharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        altiharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else if (harf == 7)
                    {
                        puan = 700;
                        label2.Text = puan.ToString();
                        textBox7.Visible = true;
                        int sayi = random.Next(yediharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + yediharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + yediharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        yediharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else if (harf == 8)
                    {
                        puan = 800;
                        label2.Text = puan.ToString();
                        textBox8.Visible = true;
                        int sayi = random.Next(sekizharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + sekizharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + sekizharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        sekizharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else if (harf == 9)
                    {
                        puan = 900;
                        label2.Text = puan.ToString();
                        textBox9.Visible = true;
                        int sayi = random.Next(dokuzharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + dokuzharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + dokuzharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        dokuzharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else if (harf == 10)
                    {
                        puan = 1000;
                        label2.Text = puan.ToString();
                        textBox10.Visible = true;
                        int sayi = random.Next(onharf.Count);
                        cmd2 = new MySqlCommand("SELECT * FROM sorular where soru_id=" + onharf[sayi].ToString(), con);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                            textBox12.Text = dr2["soru"].ToString();
                        dr2.Close();

                        cmd1 = new MySqlCommand("SELECT * FROM cevaplar where cevap_id=" + onharf[sayi].ToString(), con);
                        dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            cevap = dr1["cevap"].ToString();
                            cevap = cevap.ToUpper();
                            MessageBox.Show(cevap);
                            charCevap = cevap.ToCharArray();
                        }
                        onharf.RemoveAt(sayi);
                        sayac++;
                        con.Close();
                    }
                    else
                    {
                        DateTime tarih = DateTime.Now;
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO skor(k_adi, skor, sure, tarih) VALUES('" + kadi + "','" + toplampuan + "','" + ((dakika - 1) + ":" + saniye).ToString() + "','" + tarih.ToShortDateString() + "')", con);
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Kullanıcı adı: " + kadi + ", Toplam puanı: " + toplampuan + ", Kalan süre:" + ((dakika - 1) + ":" + saniye).ToString() + ", Tarih ve zaman:" + tarih.ToString());
                            con.Close();
                            Giris frmGiris = new Giris();
                            this.Hide();
                            frmGiris.Show();
                        }
                    }
                }

            }
        }
    }
}
