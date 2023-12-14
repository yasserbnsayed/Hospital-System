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
	public partial class managedoctor : Form
	{
		SqlConnection con = new SqlConnection("server=.; DataBase=ho; Integrated Security = true");

		public managedoctor()
		{
			InitializeComponent();

            // to show the data of doctors in dataGridView1
            SqlDataAdapter ad = new SqlDataAdapter("select * from doctor",con);	
			DataTable d = new DataTable();
			ad.Fill(d);
			dataGridView1.DataSource = d;
		}

		private void button2_Click(object sender, EventArgs e)
		{
            // to make button called (Edit) in form called (managedoctor) to go to form called (editdoctor) when we click on it
            editdoctor f = new editdoctor();

            // to show the data of the doctor that we want to Edit in the textboxs of form called (editdoctor)
            f.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            f.textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            f.comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            f.textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            f.textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

			// to show the form called (editdoctor)
            f.Show();

			
		}

		private void managedoctor_Load(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        private void button1_Click(object sender, EventArgs e)
        {
            // we use SqlCommand to execute the delete statement
            SqlCommand cmd = new SqlCommand("delete from doctor where id = '" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)+"' ",con);
			con.Open();
			cmd.ExecuteNonQuery();
			con.Close();

			MessageBox.Show("delete successfully..!");

            SqlDataAdapter ad = new SqlDataAdapter("select * from doctor", con);
            DataTable d = new DataTable();
            ad.Fill(d);
            dataGridView1.DataSource = d;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
