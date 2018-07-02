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
    public partial class NameEdit : Form
    {
        public NameEdit()
        {
            InitializeComponent();
        }
        private void NameEdit_Load(object sender, EventArgs e)
        {
            textBox1.Text = Member_List.firstname;
            textBox2.Text = Member_List.mi;
            textBox4.Text = Member_List.lastname;
            textBox1.Focus();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (DialogResult.Yes == MessageBox.Show("Would you like to go back?\n\nAll information will be discarded.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    Close();
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (DialogResult.Yes == MessageBox.Show("Would you like to save changes?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    Member_List.Updated("FN", textBox1.Text, Member_List.idnumber);
                    Member_List.Updated("MI", textBox2.Text, Member_List.idnumber);
                    Member_List.Updated("LN", textBox4.Text, Member_List.idnumber);
                    MessageBox.Show("Data Updated!", "Update Successful!");
                    Member_List.fullname = textBox1.Text + " " + textBox2.Text + " " + textBox4.Text;
                    Close();

                }
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (DialogResult.Yes == MessageBox.Show("Would you like to go back?\n\nAll information will be discarded.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    Close();
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (DialogResult.Yes == MessageBox.Show("Would you like to save changes?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    Member_List.Updated("FN", textBox1.Text, Member_List.idnumber);
                    Member_List.Updated("MI", textBox2.Text, Member_List.idnumber);
                    Member_List.Updated("LN", textBox4.Text, Member_List.idnumber);
                    MessageBox.Show("Data Updated!", "Update Successful!");
                    Member_List.fullname = textBox1.Text + " " + textBox2.Text + " " + textBox4.Text;
                    Close();
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (DialogResult.Yes == MessageBox.Show("Would you like to go back?\n\nAll information will be discarded.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    Close();
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (DialogResult.Yes == MessageBox.Show("Would you like to save changes?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    Member_List.Updated("FN", textBox1.Text, Member_List.idnumber);
                    Member_List.Updated("MI", textBox2.Text, Member_List.idnumber);
                    Member_List.Updated("LN", textBox4.Text, Member_List.idnumber);
                    MessageBox.Show("Data Updated!", "Update Successful!");
                    Member_List.fullname = textBox1.Text + " " + textBox2.Text + " " + textBox4.Text;
                    Close();
                }
            }
        }
    }
}
