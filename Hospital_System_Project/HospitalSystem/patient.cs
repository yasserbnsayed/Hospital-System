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
    public partial class patient : Form
    {
        SqlConnection con = new SqlConnection("server=.; DataBase=ho; Integrated Security = true");

        public patient()
        {
            InitializeComponent();

            button2.Enabled = false;

            // to show from our DB the data of table called(patient) in dataGridView1 of form called((patient) automatically after we open the form called(patient)
            SqlDataAdapter ad = new SqlDataAdapter("select * from patient", con);
            DataTable d = new DataTable();
            ad.Fill(d);
            dataGridView1.DataSource = d;
        }

        private void patient_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // we use SqlCommand to add a new item to the table called(patient) in our DB after we add the item in the fields of form called(patient)
            SqlCommand cmd = new SqlCommand("insert into patient values('" + textBox1.Text + "' , '" + textBox2.Text + "'  , '" + textBox3.Text + "' , '" +Convert.ToInt32(textBox4.Text) + "' , '" + textBox5.Text+ "' , '" + comboBox1.Text + "') ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            // to show message after we add the item in the fields of form called(patient)
            MessageBox.Show("add patient successfully..!");

            // to empty the data from the fields of form called(patient) after we add a new patient
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            // to show the new item after we add it in the fields of form called(patient) with the data of our DB of table called(patient) in dataGridView1 of form called((patient) automatically 
            SqlDataAdapter ad = new SqlDataAdapter("select * from patient", con);
            DataTable d = new DataTable();
            ad.Fill(d);
            dataGridView1.DataSource = d;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to delete the selected row??") == DialogResult.OK)
            {
                // we use SqlCommand to execute the delete statement
                SqlCommand cmd = new SqlCommand("delete from patient where id = '" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value) + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("delete successfully..!");

                SqlDataAdapter ad = new SqlDataAdapter("select * from patient", con);
                DataTable d = new DataTable();
                ad.Fill(d);
                dataGridView1.DataSource = d;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Visible = true;
            label8.Visible = true;
            textBox6.Enabled = false; // I am add it
            button4.Enabled = false;
            button2.Enabled = true;

            textBox6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update patient set name='"+textBox1.Text+"', phone= '"+textBox2.Text+"', address= '"+textBox3.Text+"', age= '"+Convert.ToInt32(textBox4.Text)+"', state= '"+textBox5.Text+"', section= '"+comboBox1.Text+"' where id = '"+Convert.ToInt32(textBox6.Text)+"' ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("edit info successfully", "update data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            // to show from our DB the data of table called(patient) in dataGridView1 of form called((patient) automatically after we edit the form called(patient)
            SqlDataAdapter ad = new SqlDataAdapter("select * from patient", con);
            DataTable d = new DataTable();
            ad.Fill(d);
            dataGridView1.DataSource = d;

            // to empty the fields after the editing them
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            button4.Enabled = true;
            button2.Enabled = false;
            textBox6.Visible = false;
            label8.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
