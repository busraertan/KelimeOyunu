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
    public partial class SkorTablosu : Form
    {
        public SkorTablosu()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=kelimeoyunu;Uid=root;Pwd='';");
            /*try
            {
                con.Open(); 
                if (con.State != ConnectionState.Closed) 
                {
                    MessageBox.Show("Bağlantı Başarılı Bir Şekilde Gerçekleşti");
                }
                else
                {
                    MessageBox.Show("Maalesef Bağlantı Yapılamadı...!"); 
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Hata! " + err.Message, "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        MySqlConnection con;

        private void kayitGetir()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM skor ORDER BY skor DESC ", con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void SkorTablosu_Load(object sender, EventArgs e)
        {
            kayitGetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Giris formgiris = new Giris();
            this.Hide();
            formgiris.Show();
        }
    }
}
