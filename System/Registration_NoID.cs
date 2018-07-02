using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace System
{
    public partial class Registration_NoID : Form
    {
        public Event_List eventlist { get; set; }

        public Registration_NoID(Event_List _form1)
        {
            eventlist = _form1;
            InitializeComponent();
        }
        public static bool duplicate = false;

        public static void GetSN(string sn)
        {
            int dup = 1;
            string query = "select count(SN) from "+Event_List.event_name+" where SN = '"+sn+"';";
            if (MainMenu.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, MainMenu.conn);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while(dataReader.Read())
                    {
                        if(dup ==Convert.ToInt32(dataReader[0].ToString()))
                        {
                            duplicate = true;
                        }   
                    }
                }
                catch (MySqlException ex)
                {
                        MessageBox.Show(ex.Message);
                }
                finally
                {
                    MainMenu.CloseConnection();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox2.Text == null || !maskedTextBox1.MaskCompleted || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Fill up all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (eventlist.checkBox1.Checked)
                {
                    if (MainMenu.isMaster == true)
                    {
                        MainMenu.Initialize("server=localhost;uid=root;pwd=;database=jpia_events;sslmode=none;");
                    }
                    else
                    {
                        MainMenu.Initialize("server=192.168.1.4;uid=access;pwd=;database=jpia_events;sslmode=none;");
                    }
                    GetSN(EnCryptDecrypt.CryptorEngine.Encrypt(maskedTextBox1.Text,true));//Finish dis tonight verifying for duplicate SN to avoid error in primary key
                    if(!duplicate)
                    {
                        MainMenu.Insert("insert into " + Event_List.event_name + " (FN, LN, SN,Year_Level) values ('" + EnCryptDecrypt.CryptorEngine.Encrypt(textBox1.Text, true) + "','" + EnCryptDecrypt.CryptorEngine.Encrypt(textBox2.Text, true) + "','" + EnCryptDecrypt.CryptorEngine.Encrypt(maskedTextBox1.Text, true) + "','" + EnCryptDecrypt.CryptorEngine.Encrypt(comboBox1.Text, true) + "');");
                        MainMenu.Insert("update " + Event_List.event_name + " set Time_In = '" + DateTime.Now.ToString("HH:mm") + "' where SN = '" + EnCryptDecrypt.CryptorEngine.Encrypt(maskedTextBox1.Text, true) + "';");
                        textBox1.Text = null;
                        textBox2.Text = null;
                        maskedTextBox1.Text = null;
                        eventlist.LA(Event_List.event_name);
                        if (MainMenu.isMaster == true)
                        {
                            MainMenu.Initialize("server=localhost;uid=root;pwd=;database=jpia;sslmode=none;");
                        }
                        else
                        {
                            MainMenu.Initialize("server=192.168.1.4;uid=access;pwd=;database=jpia;sslmode=none;");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Duplicate Entry Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Text = null;
                        textBox2.Text = null;
                        maskedTextBox1.Text = null;
                        eventlist.LA(Event_List.event_name);
                        if (MainMenu.isMaster == true)
                        {
                            MainMenu.Initialize("server=localhost;uid=root;pwd=;database=jpia;sslmode=none;");
                        }
                        else
                        {
                            MainMenu.Initialize("server=192.168.1.4;uid=access;pwd=;database=jpia;sslmode=none;");
                        }
                    }

                }
                else
                {
                    if (MainMenu.isMaster == true)
                    {
                        MainMenu.Initialize("server=localhost;uid=root;pwd=;database=jpia_events;sslmode=none;");
                    }
                    else
                    {
                        MainMenu.Initialize("server=192.168.1.4;uid=access;pwd=;database=jpia_events;sslmode=none;");
                    }
                    MainMenu.Insert("update " + Event_List.event_name + " set Time_Out = '" + DateTime.Now.ToString("HH:mm") + "' where SN = '" +EnCryptDecrypt.CryptorEngine.Encrypt(maskedTextBox1.Text,true) + "';");
                    eventlist.LA(Event_List.event_name);
                    if (MainMenu.isMaster == true)
                    {
                        MainMenu.Initialize("server=localhost;uid=root;pwd=;database=jpia;sslmode=none;");
                    }
                    else
                    {
                        MainMenu.Initialize("server=192.168.1.4;uid=access;pwd=;database=jpia;sslmode=none;");
                    }
                }
            }
            duplicate = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
