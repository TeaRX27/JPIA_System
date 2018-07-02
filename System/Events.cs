using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System
{
    public partial class Events : Form
    {
        public Events()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Would you like to go back?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Form mainmenu = new MainMenu();
                mainmenu.Show();
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form newevent = new New_Event();
            newevent.Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form eventlist = new Event_List();
            eventlist.Show();
            Close();
        }
    }
}
