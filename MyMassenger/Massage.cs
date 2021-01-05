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
    public partial class Massage : Form
    {
        public Massage()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public int id1;
        public string a;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id1 = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SignUp"].ConnectionString);
            connection.Open();
            string sq1 = "SELECT * FROM SignUp WHERE AId = '"+id1+"'  ";

            SqlCommand command1 = new SqlCommand(sq1, connection);
            SqlDataReader reader2 = command1.ExecuteReader();
            
            while (reader2.Read())
            {
                
               

                a= reader2["Picture"].ToString();
              
                pictureBox1.ImageLocation=a;
            }
        

            connection.Close();
        }

        private void Massage_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SignUp"].ConnectionString);
            connection.Open();
            string sql = "SELECT * FROM SignUp";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader2 = command.ExecuteReader();
            List<Search> list2 = new List<Search>();
            while (reader2.Read())
            {
                Search CS = new Search();

                CS.ID = (int)reader2["AId"];
                CS.Name = reader2["Name"].ToString();
                list2.Add(CS);
            }
            dataGridView1.DataSource = list2;
        }

        private void Massage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SignUp"].ConnectionString);
            connection.Open();
            string sq1 = "SELECT * FROM SignUp WHERE Name LIKE '" + textBox1.Text + "%'  ";

            SqlCommand command1 = new SqlCommand(sq1, connection);
            SqlDataReader reader2 = command1.ExecuteReader();
            List<Search> list2 = new List<Search>();
            while (reader2.Read())
            {
                Search CS = new Search();


                CS.ID = (int)reader2["AId"];
                CS.Name = reader2["Name"].ToString();
                list2.Add(CS);
            }
            dataGridView1.DataSource = list2;

            connection.Close();
        }
    }
}
