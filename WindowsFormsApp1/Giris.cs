using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=kelimeoyunu;Uid=root;Pwd='';");
        }

        MySqlConnection con;
        MySqlCommand cmd;
        string kadi;

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            Oyun form_oyun = new Oyun();
            kadi = textBox1.Text;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Kullanıcı adı girin");
            }
            else
            {
                cmd = new MySqlCommand("INSERT INTO kullanici(k_adi) VALUES('" + kadi + "')", con);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    form_oyun.kadi = kadi;
                    con.Close();
                    this.Hide();
                    form_oyun.Show();
                } 
                else
                    MessageBox.Show("Kullanıcı adı eklenemedi");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SoruCevapEkle form_sc = new SoruCevapEkle();
            this.Hide();
            form_sc.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SkorTablosu frmskor = new SkorTablosu();
            this.Hide();
            frmskor.Show();
        }
    }
}
