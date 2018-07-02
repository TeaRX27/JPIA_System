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
    public partial class Members : Form
    {
        public Members()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes==MessageBox.Show("Would you like to go back?","Information",MessageBoxButtons.YesNo,MessageBoxIcon.Question))
            {
                Form mainmenu = new MainMenu();
                mainmenu.Show();
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form newmember = new New_Member();
            newmember.Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form memberlist = new Member_List();
            memberlist.Show();
            Close();
        }
    }
}
