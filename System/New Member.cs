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
    public partial class New_Member : Form
    {
        public New_Member()
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
        string membership_type,gender;
        private void button2_Click(object sender, EventArgs e)
        {
                Form members = new Members();
                members.Show();
                Close();
        }
        public string requirements()
        {
            //SN,FN,MI,LN,Email,Address,Contact_No,BDay,Age,Year_Level,Comm,Guard_Name,Guard_Contact,ID_Address
            //shorten code in insertion
            string complete =null;
            complete += EnCryptDecrypt.CryptorEngine.Encrypt(SN.Text, true);
            complete = complete + "','" + EnCryptDecrypt.CryptorEngine.Encrypt(FN.Text, true);
            complete = complete + "','" + EnCryptDecrypt.CryptorEngine.Encrypt(MI.Text, true);
            complete = complete + "','" + EnCryptDecrypt.CryptorEngine.Encrypt(LN.Text, true);
            complete = complete + "','" + EnCryptDecrypt.CryptorEngine.Encrypt(EMail.Text, true);
            complete = complete + "','" + EnCryptDecrypt.CryptorEngine.Encrypt(Address.Text, true);
            complete = complete + "','" + EnCryptDecrypt.CryptorEngine.Encrypt(Contact.Text, true);
            complete = complete + "','" + EnCryptDecrypt.CryptorEngine.Encrypt(Convert.ToString(Bday.Value.ToShortDateString()), true);
            complete = complete + "','" + EnCryptDecrypt.CryptorEngine.Encrypt(Age.Text, true);
            complete = complete + "','" + EnCryptDecrypt.CryptorEngine.Encrypt(gender, true);
            complete = complete + "','" + EnCryptDecrypt.CryptorEngine.Encrypt(Year.SelectedItem.ToString(), true);
            complete = complete + "','" + EnCryptDecrypt.CryptorEngine.Encrypt(membership_type, true);
            complete = complete + "','" + EnCryptDecrypt.CryptorEngine.Encrypt(@"C:\\JPIA\\Images\\Member\\default.png", true);
            return complete;
        }

        string error;

        private void button1_Click(object sender, EventArgs e)
        {
            bool sn_flag = SN.MaskCompleted != false;
            bool fn_flag = FN.Text != "";
            bool mi_flag = MI.Text != "";
            bool ln_flag = LN.Text != "";
            bool email_flag = EMail.Text != "";
            bool address_flag = Address.Text != "";
            bool contact_flag = Contact.MaskCompleted != false;
            bool bday_flag = Bday.Value.ToShortDateString() != DateTime.Now.ToShortDateString();
            bool age_flag = Int32.Parse(Age.Text) > 0;
            bool year_flag = Year.Text != "";
            bool DPA_flag = checkBox1.Checked != false;
            bool membership = radioButton1.Checked != false||radioButton2.Checked!=false;
            bool gender = radioButton3.Checked != false || radioButton4.Checked != false;
            error = null;
            if (!sn_flag || !fn_flag || !mi_flag || !ln_flag || !email_flag || !address_flag || !contact_flag || !bday_flag || !year_flag || !DPA_flag || !age_flag||!membership||!gender)
            {

                if (!fn_flag)
                {
                    error += "First Name must not be Empty \n";
                }
                if (!mi_flag)
                {
                    error += "Middle Initial must not be Empty \n";
                }
                if (!ln_flag)
                {
                    error += "Last Name must not be Empty \n";
                }
                if (!sn_flag)
                {
                    error += "Student Number must not be Empty \n";
                }
                if (!email_flag)
                {
                    error += "Email must not be Empty \n";
                }
                if (!address_flag)
                {
                    error += "Address must not be Empty \n";
                }
                if (!contact_flag)
                {
                    error += "Contact Number must not be Empty\n";
                }
                if (!bday_flag)
                {
                    if (Bday.Value.ToShortDateString() == DateTime.Now.ToShortDateString())
                    {
                        error += "Date of Birth must not the same as Date Today\n";
                    }
                    else
                    {
                        error += "Date of Birth does not match your Age\n";
                    }
                }
                if (!age_flag)
                {
                    error += "Age must not be 0 or a Negative Value\n";
                }
                if (!year_flag)
                {
                    error += "Year Level must not be Empty\n";
                }
                if (!DPA_flag)
                {
                    error += "Data Privacy Act of 2012 not checked\n";
                }
                if (!membership)
                {
                    error += "Select Membership Type\n";
                }
                if (!gender)
                {
                    error += "Select Gender\n";
                }
                MessageBox.Show(error, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning); //Error Message Box for Invalid Data
            }
            else
            {
                MainMenu.Insert("insert into member_list(SN,FN,MI,LN,Email,Address,Contact_No,BDay,Age,Gender,Year_Level,Membership,ID_Address) values('" + requirements() + "');");
                FN.Text = null;
                MI.Text = null;
                LN.Text = null;
                SN.Text = null;
                EMail.Text = null;
                Address.Text = null;
                Contact.Text = null;
                Bday.Value = DateTime.Today;
                Age.Text = null;
                Year.Text = null;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                if (DialogResult.Yes == MessageBox.Show("New Member Registered!\n\nWould you like to go back?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    Form members = new Members();
                    members.Show();
                    Close();
                }
            }
        }

        private void New_Member_Load(object sender, EventArgs e)
        {
            Bday.Value = DateTime.Now;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(DialogResult.OK==MessageBox.Show(
                "I am fully aware that JPIA or its designated representative is duty bound and obligated under the Data Privacy Act of 2012 to protect all my personal and sensitive information that it collects, processes, and retains upon my enrolment and during my stay in the University.\n\nStudent personal information includes any information about my identity, academics, medical conditions, or any documents containing my identity.This includes but not limited to my name, address, names of my parents or guardians, date of birth, grades, attendance, disciplinary records, and other information necessary for basic administration and instruction.\n\nI understand that my personal information cannot be disclosed without my consent.\nI understand that the information that was collected and processed relates to my enrolment and to be used by JPIA to pursue its legitimate interests as an educational institution.\nLikewise, I am fully aware that JPIA may share such information to affiliated or partner organizations as part of its contractual obligations, or with government agencies pursuant to law or legal processes.\nIn this regard, I hereby allow JPIA to collect, process, use and share my personal data in the pursuit of its legitimate interests as an educational institution.\n\nIn addition, I am likewise giving my consent / permission in favor of my parents / guardian / representative or whoever is responsible in providing care for me to access, verify, examine and or inspect my academic and scholastic records, school fees / accounts in the University, the result of my physical medical examination(PME) and all matters that relate to my status as a student of the University.\n\nFinally, should I commit any misconduct or should there be a complaint filed against me, before the Student Affairs Office(SAO) or Student Disciplinary Board(SDB) by reason of violation of the provisions of the Student Manual or any laws or ordinances, I hereby authorize and give my full consent in favor of the University to inform my parents, guardian, representative or whoever person is in charge of providing care or custody for me.\n\nUpon clicking OK, I hereby give my consent for the processing, release, and retention of personal information."))
            {
                checkBox1.Checked = true;
            }
        }

        private void Bday_ValueChanged(object sender, EventArgs e)
        {
            int age;
            if((DateTime.Now.Month - Bday.Value.Month >= 0)&& (DateTime.Now.Day - Bday.Value.Day >= 0))
            {
                age = DateTime.Now.Year - Bday.Value.Year;
            }
            else
            {
                age = DateTime.Now.Year - (Bday.Value.Year+1);
            }
            Age.Text = age.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            membership_type = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            membership_type = radioButton2.Text;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            gender = radioButton4.Text;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            gender = radioButton3.Text;
        }
    }
}

