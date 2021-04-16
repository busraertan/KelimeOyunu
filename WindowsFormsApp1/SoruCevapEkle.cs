using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class SoruCevapEkle : Form
    {
        public SoruCevapEkle()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=kelimeoyunu;Uid=root;Pwd='';");
        }

        MySqlConnection con;
        MySqlCommand cmd1, cmd2;
        MySqlDataReader dr;
        ArrayList cevaplar = new ArrayList();

        private void button1_Click(object sender, EventArgs e)
        {
            string kelime = textBox2.Text;
            kelime = kelime.ToUpper();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen eklemek istediğiniz soruyu giriniz!");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Lütfen eklemek istediğiniz cevabı giriniz!");
            }
            else if (cevaplar.Contains(kelime))
            {
                MessageBox.Show("Bu kelime veritabanında zaten var! Başka bir kelime giriniz");
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                // Ardından Veri ekleme komutumuzu kendimize göre düzenliyoruz.
                con.Open();
                cmd1 = new MySqlCommand("INSERT INTO sorular(soru) VALUES('" + textBox1.Text + "')", con);
                if (cmd1.ExecuteNonQuery() == 1)
                {
                    int harf_sayisi = Convert.ToInt32((textBox2.Text).Length);
                    cmd2 = new MySqlCommand("INSERT INTO cevaplar(cevap,harf_sayisi) VALUES('" + textBox2.Text + "','" + harf_sayisi + "')", con);
                    if (cmd2.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Soru ve cevap eklendi");
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Cevap eklenemedi");
                        MySqlCommand cmd = new MySqlCommand("DELETE FROM sorular WHERE soru = ('" + textBox1.Text + "')", con);
                    }
                }
                else
                    MessageBox.Show("Soru ve cevap eklenemedi");

                con.Close();
            }
        }

        private void SoruCevapEkle_Load(object sender, EventArgs e)
        {
            con.Open();
            cmd1 = new MySqlCommand("SELECT * FROM cevaplar", con);
            dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                cevaplar.Add((dr["cevap"].ToString()).ToUpper());
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Giris form_giris = new Giris();
            this.Hide();
            form_giris.Show();
        }
    }
}
