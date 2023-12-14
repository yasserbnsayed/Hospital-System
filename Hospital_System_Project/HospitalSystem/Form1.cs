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
using System.Data;

namespace HospitalSystem
{
	public partial class Form1 : Form
	{
		// we use SqlConnection to connect VS with our DB
		SqlConnection con = new SqlConnection("server=.; DataBase=ho; Integrated Security = true");
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			// we use SqlDataAdapter to get data from our DB
			SqlDataAdapter ad = new SqlDataAdapter("select * from users where username='"+textBox1.Text+"' and password= '"+ textBox2.Text + "'", con);

			// we use DataTable to put data from our DB in it as it is an empty table
			DataTable dt = new DataTable();

			// ad put the data in dt
			ad.Fill(dt);

			// check if inputs is match the data in DB or not
			if (dt.Rows.Count > 0 )
			{
				Main f = new Main();
				f.Show();
				this.Hide();
			}
			else
			{
				MessageBox.Show("username or password is wrong..!!");
			}
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
