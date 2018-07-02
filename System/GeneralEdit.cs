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
    public partial class GeneralEdit : Form
    {
        public GeneralEdit()
        {
            InitializeComponent();
            if (MainMenu.isMaster == true)
            {
                MainMenu.Initialize("server=localhost;uid=root;pwd=;database=jpia;sslmode=none;");
            }
            else
            {
                MainMenu.Initialize("server=192.168.1.4;uid=access;pwd=;database=jpia;sslmode=none;");
            }
        }

        public static string data;
        public static string col;

        private void GeneralEdit_Load(object sender, EventArgs e)
        {
            textBox1.Text = data;
            textBox1.Focus();
        }
        
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                if (DialogResult.Yes == MessageBox.Show("Would you like to go back?\n\nAll information will be discarded.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    Close();
                }
            }
            else if(e.KeyCode == Keys.Enter)
            {
                if (DialogResult.Yes == MessageBox.Show("Would you like to save changes?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    Member_List.Updated(col,textBox1.Text,Member_List.idnumber);
                    MessageBox.Show("Data Updated!", "Update Successful!");
                    Close();
                    data = textBox1.Text;
                }
            }
        }
    }
}
