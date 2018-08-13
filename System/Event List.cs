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
    public partial class Event_List : Form
    {
        private ListViewColumnSorter lvwColumnSorter;
        public Event_List()
        {
            InitializeComponent();
            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView2.ListViewItemSorter = lvwColumnSorter;
            if (MainMenu.isMaster == true)
            {
                MainMenu.Initialize("server=localhost;uid=root;pwd=;database=jpia;sslmode=none;");
            }
            else
            {
                MainMenu.Initialize("server=192.168.1.4;uid=access;pwd=;database=jpia;sslmode=none;");
            }
        }


        public static string event_name;
        string SN;
        public static bool istimein=false;



        public void LEI(string ID) // LEI = Load Event Info
        {
            string query = "Select Event_Name, Event_Location, Event_Pubmat from event_list where Event_Name = '" +EnCryptDecrypt.CryptorEngine.Encrypt(ID,true) + "'";
            if (MainMenu.OpenConnection())
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(query, MainMenu.conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        textBox1.Text = EnCryptDecrypt.CryptorEngine.Decrypt(reader[0].ToString(),true);
                        textBox2.Text = EnCryptDecrypt.CryptorEngine.Decrypt(reader[1].ToString(), true);
                        Image dump = pictureBox1.BackgroundImage;
                        if (dump != null)
                            dump.Dispose();
                        pictureBox1.BackgroundImage = Image.FromFile(EnCryptDecrypt.CryptorEngine.Decrypt(reader[2].ToString(), true));
                        pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
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

        public void LA(string event_name) // LA=Load Attendees
        {
            if (event_name == null)
            {
                MessageBox.Show("No Event Selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string query = "Select FN, LN, SN, ID_No, Time_In, Time_Out from " + event_name + ";";
                listView2.Items.Clear();
                ListViewItem iItem;
                if (MainMenu.OpenConnection())
                {
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(query, MainMenu.conn);
                        MySqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            iItem = new ListViewItem(EnCryptDecrypt.CryptorEngine.Decrypt(dataReader[0].ToString(), true));
                            iItem.SubItems.Add(EnCryptDecrypt.CryptorEngine.Decrypt(dataReader[1].ToString(), true));
                            iItem.SubItems.Add(EnCryptDecrypt.CryptorEngine.Decrypt(dataReader[2].ToString(), true));
                            iItem.SubItems.Add(dataReader[3].ToString());
                            iItem.SubItems.Add(dataReader[4].ToString());
                            iItem.SubItems.Add(dataReader[5].ToString());
                            listView2.Items.Add(iItem);
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
                    listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    label5.Text = listView2.Items.Count.ToString();
                }
            }
        }

        public void Populate_ListView(string myquery)
        {
            listView1.Items.Clear();
            ListViewItem iItem;
            string query = myquery;
            if (MainMenu.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, MainMenu.conn);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        iItem = new ListViewItem(EnCryptDecrypt.CryptorEngine.Decrypt(dataReader[0].ToString(),true));
                        iItem.SubItems.Add(EnCryptDecrypt.CryptorEngine.Decrypt(dataReader[1].ToString(),true));
                        listView1.Items.Add(iItem);

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
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form reg_noid = new Registration_NoID(this);
            Form registration = new Registration(this);
            registration.Show();
            reg_noid.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
                Form events = new Events();
                events.Show();
                Close();       
        }

        private void Event_List_Load(object sender, EventArgs e)
        {
            Populate_ListView("select Event_Name,Event_Date from event_list;");

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                event_name = item.SubItems[0].Text;
                event_name = event_name.Replace(' ', '_');
                LEI(item.SubItems[0].Text);
                if (MainMenu.isMaster == true)
                {
                    MainMenu.Initialize("server=localhost;uid=root;pwd=;database=jpia_events;sslmode=none;");
                }
                else
                {
                    MainMenu.Initialize("server=192.168.1.4;uid=access;pwd=;database=jpia_events;sslmode=none;");
                }
                LA(event_name);
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                istimein = true;
            }
            else
            {
                istimein = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)//remove button
        {
            foreach (ListViewItem item in listView2.SelectedItems)
            {
                SN =item.SubItems[2].Text;
                if (MainMenu.isMaster == true)
                {
                    MainMenu.Initialize("server=localhost;uid=root;pwd=;database=jpia_events;sslmode=none;");
                }
                else
                {
                    MainMenu.Initialize("server=192.168.1.4;uid=access;pwd=;database=jpia_events;sslmode=none;");
                }


                MainMenu.Insert("delete from " +event_name + " where SN = '" + EnCryptDecrypt.CryptorEngine.Encrypt(SN,true) + "';");

                listView2.Items.Remove(item);

                if (MainMenu.isMaster == true)
                {
                    MainMenu.Initialize("server=localhost;uid=root;pwd=;database=jpia;sslmode=none;");
                }
                else
                {
                    MainMenu.Initialize("server=192.168.1.4;uid=access;pwd=;database=jpia;sslmode=none;");
                }

                if (label5.Text=="0")
                {
                    MessageBox.Show("There are no more participants!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    label5.Text = Convert.ToString(Convert.ToInt32(label5.Text) - 1);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Populate_ListView("select Event_Name,Event_Date from event_list;");
            Image dump = pictureBox1.BackgroundImage;
            if (dump != null)
                dump.Dispose();
            pictureBox1.BackgroundImage = Properties.Resources.JPIA_BACKGROUND;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            textBox1.Text = null;
            textBox2.Text = null;
            event_name = null;
            listView2.Items.Clear();
            checkBox1.Checked = true;
            label5.Text = "0";
        }

        private void listView2_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView2.Sort();
        }
    }
}
