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
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
            dateTimePicker1.MaxDate = DateTime.Today;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public string pic;
        private void button3_Click(object sender, EventArgs e)
        {
            string img;
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All files(*.*)|*.*";
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    img = ofd.FileName;
                    if (img != "")
                    {
                        pic = img;
                    }
                    else
                    {
                        pic = string.Empty;
                    }

                    pictureBox1.ImageLocation = img;



                }

            }
            catch (Exception)
            {
                MessageBox.Show("An ERROR Occured");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Namebox.Text=="")
            {
                MessageBox.Show("ERROR Name Is Empty");
            }
            else if (PasswordBox.Text=="")
            {
                MessageBox.Show("ERROR Password Is Empty");
            }
            else if(PasswordBox.Text!=Confirmbox.Text)
            {
                MessageBox.Show("ERROR Password And Confirm Password Is Not Same");

            }
            else if(pictureBox1.ImageLocation=="")
            {
                MessageBox.Show("Please Upload A Picture Of You");

            }
            else if(radioButton1.Checked==false && radioButton2.Checked==false)
            {
                MessageBox.Show("You Did Not Select Your Gender");

            }
            else
            {
                string gen;
                if (radioButton1.Checked)
                {
                    gen = "Male";
                }
                else
                {
                    gen = "Female";
                }
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SignUp"].ConnectionString);
                connection.Open();
                string sq1 = "INSERT INTO SignUp(Name,Password,Email,DOB,Picture,Gender) VALUES('" + Namebox.Text + "','" + PasswordBox.Text + "','" + Emailbox.Text + "','" + dateTimePicker1.Text + "','" + pic + "','" + gen + "')";

                SqlCommand command = new SqlCommand(sq1, connection);
                int diary = command.ExecuteNonQuery();

                if (diary > 0)
                {
                    MessageBox.Show("Account Created");
                    LogIn mg = new LogIn();
                    mg.Show();
                    this.Hide();

                    
                }
                else
                {
                    MessageBox.Show("Error In Creating Account");
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LogIn mg = new LogIn();
            mg.Show();
            this.Hide();
        }

        private void Signup_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }
    }
}
