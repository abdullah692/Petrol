using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FP__PPMS_
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user, pass;
            user = textBox1.Text;
            pass = textBox2.Text;
            if (user == "admin" && pass == "admin")
            {
                MessageBox.Show(" Login Successful");
                Main main = new Main();
                this.Hide();
                main.Show();
            }
            else
            {
                MessageBox.Show("Login Failed");
                this.Close();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
