using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalSystem
{
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();

			timer1.Enabled = true;
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void Main_Load(object sender, EventArgs e)
		{

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label2.Left += 8;
			if (label2.Left > this.Width)
				label2.Left -= this.Width;
		}

		private void addDoctorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			adddoctor f = new adddoctor();
			f.Show();
		}

		private void manageDoctorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			managedoctor f = new managedoctor();	
			f.Show();
		}

        private void patientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // to make button called (Patient) in form called (main) to go to form called (patient) when we click on it
            patient frm = new patient();
            // to show the form called (patient)
            frm.Show();
        }

        private void addProccessToolStripMenuItem_Click(object sender, EventArgs e)
        {
			// we will program the button called(add Proccess) to make it go to the form called(addpro)
			addpro f = new addpro();
			f.Show();
        }

        private void manageProccessToolStripMenuItem_Click(object sender, EventArgs e)
        {
			viewpro f = new viewpro();
			f.Show();	
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
			this.Close();
        }
    }
}
