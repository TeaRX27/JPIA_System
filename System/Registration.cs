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
    public partial class Registration : Form
    {
        
        public Event_List eventlist { get; set; }

        public Registration(Event_List _form1)
        {
            eventlist = _form1;
            InitializeComponent();
        }

        int ID;
        int query_ID;

        public static bool isregistration = false;
        public static bool duplicate = false;

        public static void GetSN(int id)
        {
            int dup = 1;
            string query = "select count(*) from "+Event_List.event_name+" where ID_No = " + id + ";";
            if (MainMenu.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, MainMenu.conn);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        if (dup == Convert.ToInt32(dataReader[0].ToString()))
                        {
                            duplicate = true;
                        }
                        else
                        {
                            duplicate = false;
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

        public void Max_ID()
        {
            string query = "select max(ID_No) from member_list;";
            if (MainMenu.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, MainMenu.conn);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        query_ID = Convert.ToInt32(dataReader[0]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    MainMenu.CloseConnection();
                }
            }
        }


        private void Registration_Load(object sender, EventArgs e)
        {
            //isregistration = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (eventlist.checkBox1.Checked==true)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ID = Convert.ToInt32(textBox1.Text);
                    if (MainMenu.isMaster == true)
                    {
                        MainMenu.Initialize("server=localhost;uid=root;pwd=;database=jpia;sslmode=none;");
                    }
                    else
                    {
                        MainMenu.Initialize("server=192.168.1.4;uid=access;pwd=;database=jpia;sslmode=none;");
                    }
                    Max_ID();
                    if (ID <= query_ID)
                    {
                        if (MainMenu.isMaster == true)
                        {
                            MainMenu.Initialize("server=localhost;uid=root;pwd=;database=jpia_events;sslmode=none;");
                        }
                        else
                        {
                            MainMenu.Initialize("server=192.168.1.4;uid=access;pwd=;database=jpia_events;sslmode=none;");
                        }
                        GetSN(ID);
                        if(!duplicate)
                        {
                            MainMenu.Insert("insert into " + Event_List.event_name + " (ID_No, FN, LN, SN, Year_Level) select ID_No, FN, LN, SN,Year_Level from jpia.member_list where ID_No = " + ID + ";");
                            MainMenu.Insert("update " + Event_List.event_name + " set Time_In = '" + DateTime.Now.ToString("HH:mm") + "' where ID_No = " + ID + ";");
                            textBox1.Text = null;
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
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid ID Number! Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        textBox1.Text = null;
                    }
                }
            }
            else if (eventlist.checkBox1.Checked==false)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ID = Convert.ToInt32(textBox1.Text);
                    if (MainMenu.isMaster == true)
                    {
                        MainMenu.Initialize("server=localhost;uid=root;pwd=;database=jpia;sslmode=none;");
                    }
                    else
                    {
                        MainMenu.Initialize("server=192.168.1.4;uid=access;pwd=;database=jpia;sslmode=none;");
                    }
                    Max_ID();
                    if (ID <= query_ID)
                    {
                        if (MainMenu.isMaster == true)
                        {
                            MainMenu.Initialize("server=localhost;uid=root;pwd=;database=jpia_events;sslmode=none;");
                        }
                        else
                        {
                            MainMenu.Initialize("server=192.168.1.4;uid=access;pwd=;database=jpia_events;sslmode=none;");
                        }
                        MainMenu.Insert("update " + Event_List.event_name + " set Time_Out = '" + DateTime.Now.ToString("HH:mm") + "' where ID_No = " + ID + ";");
                        textBox1.Text = null;
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
                        MessageBox.Show("Invalid ID Number! Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        textBox1.Text = null;
                    }
                }
            }
        }
    }
}
