using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace HospitalSystem
{
	public partial class adddoctor : Form
	{
		SqlConnection con = new SqlConnection("server=.; DataBase=ho; Integrated Security = true");

		public adddoctor()
		{
			InitializeComponent();
		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void textBox4_TextChanged(object sender, EventArgs e)
		{

		}

		private void adddoctor_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			// we use SqlCommand to add a new item to the table in DB
			SqlCommand cmd = new SqlCommand("insert into doctor values('"+textBox1.Text+"' , '"+textBox2.Text+"' , '"+comboBox1.Text+"' , '"+textBox4.Text+"') ",con);
			con.Open();
			cmd.ExecuteNonQuery();
			con.Close();
			MessageBox.Show("add doctor successfully..!");
			textBox1.Text = "";
			textBox2.Text = "";
			textBox4.Text = "";

		}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
