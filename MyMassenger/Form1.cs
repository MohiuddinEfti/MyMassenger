using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMassenger
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void Signup_Click(object sender, EventArgs e)
        {
            Signup su = new Signup();
            su.Show();
            this.Hide();
        }

        private void Signinbutton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SignUp"].ConnectionString);


            SqlCommand cmd = new SqlCommand("SELECT * FROM SignUp WHERE Name = '" + Namebox.Text + "' AND [Password] = '" + PasswordBox.Text + "' ", connection);



            connection.Open();


            SqlDataReader sdr = cmd.ExecuteReader();
            if ((sdr.Read() == true))

            {
                string emp;
                string eid;
                string po;
                string pi;
                

                Massage at = new Massage();
                at.Show();
                this.Hide();
            }
            else
            {

                MessageBox.Show("Invalid username or password!");

            }
        }

        private void LogIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
