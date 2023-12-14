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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HospitalSystem
{
    public partial class addpro : Form
    {
        SqlConnection con = new SqlConnection("server=.; DataBase=ho; Integrated Security = true");
        public addpro()
        {
            InitializeComponent();
        }

        private void addpro_Load(object sender, EventArgs e)
        {
            // to get the data of doctors from our DB
            SqlDataAdapter d = new SqlDataAdapter("select * from doctor", con);
            DataTable t1 = new DataTable();
            d.Fill(t1);

            comboBox2.DataSource = t1;
            comboBox2.DisplayMember = "name";
            comboBox2.ValueMember = "id";


            // to get the data of patients from our DB
            SqlDataAdapter d1 = new SqlDataAdapter("select * from patient", con);
            DataTable t2 = new DataTable();
            d1.Fill(t2);

            comboBox1.DataSource = t2;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // adding process to the database
            SqlCommand c = new SqlCommand("insert into proce(patname, docname, patid, docid, prodate, state) values('"+comboBox1.Text+ "', '"+comboBox2.Text+ "', '"+Convert.ToInt32(comboBox1.SelectedValue)+ "', '"+Convert.ToInt32(comboBox2.SelectedValue)+"', '"+dateTimePicker1.Value.ToString("yyyy-MM-dd")+"', '"+textBox5.Text+"')", con);
            con.Open();
            c.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("add successfully");
        }
    }
}
