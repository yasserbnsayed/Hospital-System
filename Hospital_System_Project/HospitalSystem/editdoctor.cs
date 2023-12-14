using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace HospitalSystem
{
    public partial class editdoctor : Form
    {
        SqlConnection con = new SqlConnection("server=.; DataBase=ho; Integrated Security = true");
        public editdoctor()
        {
            InitializeComponent();
        }

        private void editdoctor_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {

            // we use SqlCommand to add a new item to the table in DB
            SqlCommand cmd = new SqlCommand("update doctor set name='" + textBox1.Text + "', phone= '" + textBox2.Text + "',  section= '" + comboBox1.Text + "' ,address= '" + textBox4.Text + "' where id = '" + Convert.ToInt32(textBox3.Text) + "' ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("edit info successfully", "update data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";

        }
    }
}
