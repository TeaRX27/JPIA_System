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
    public partial class MainMenu : Form
    {
        //"server=localhost;uid=root;pwd=;database=jpia;"                  // database conection strings
        //"server=localhost;uid=root;pwd=;database=jpia_events;"           //



        //Database connection variables
        public static MySqlConnection conn;
        public static string myConnectionString;
        public static bool isMaster = false;
        CrystalReport2 report = new CrystalReport2();


        public MainMenu()
        {
            InitializeComponent();
        }

        public static void Initialize(string connstr)
        {
            myConnectionString = connstr;
            conn = new MySqlConnection(myConnectionString);
        }
        int user_accounts;
        bool jpiadb;
        bool jpia_eventsdb;
        bool report_table;
        string jpia = "jpia";
        string jpia_events = "jpia_events";
        string reporttable ="report_table_1";

        public void checkdb(string ID, string check)
        {
            string query = "show databases like '" + ID + "';";
            MySqlCommand command;
            if (MainMenu.OpenConnection())
            {
                try
                {
                    if(ID=="report_table_1")
                    {
                        command = new MySqlCommand("show tables where tables_in_jpia = 'report_table_1';", MainMenu.conn);
                    }
                    else
                    {
                        command = new MySqlCommand(query, MainMenu.conn);
                    }
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (check == reader[0].ToString())
                        {
                            if (check == "jpia")
                            {
                                jpiadb = true;
                            }
                            if (check == "jpia_events")
                            {
                                jpia_eventsdb = true;
                            }
                            if(check=="report_table_1")
                            {
                                report_table = true;
                            }
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
        public void checkuser()
        {
            string query = "select count(user) from mysql.user where user = 'jpia'";
            if (MainMenu.OpenConnection())
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(query, MainMenu.conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user_accounts = Convert.ToInt32(reader[0].ToString());
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


        //create database
        public static void createdb(string q)
        {
            string query = q;
            if (MainMenu.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, MainMenu.conn);
                    cmd.ExecuteNonQuery();
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
                        iItem = new ListViewItem(EnCryptDecrypt.CryptorEngine.Decrypt(dataReader[0].ToString(), true));
                        iItem.SubItems.Add(EnCryptDecrypt.CryptorEngine.Decrypt(dataReader[1].ToString(), true));
                        iItem.SubItems.Add(EnCryptDecrypt.CryptorEngine.Decrypt(dataReader[2].ToString(), true));
                        iItem.SubItems.Add(EnCryptDecrypt.CryptorEngine.Decrypt(dataReader[3].ToString(), true));
                        iItem.SubItems.Add(EnCryptDecrypt.CryptorEngine.Decrypt(dataReader[4].ToString(), true));
                        iItem.SubItems.Add(EnCryptDecrypt.CryptorEngine.Decrypt(dataReader[5].ToString(), true));
                        iItem.SubItems.Add(EnCryptDecrypt.CryptorEngine.Decrypt(dataReader[6].ToString(), true));

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


        //Opening connection to database
        public static bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //closing connection to database
        public static bool CloseConnection()
        {
            try
            {
                conn.Dispose();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert into database
        public static void Insert(string q)
        {
            string query = q;
            if (OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("Operation succeeded.", "Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    if (Registration.isregistration == true)
                    {
                        MessageBox.Show("No Event Selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                finally
                {
                    CloseConnection();
                }
            }
        }

        private void imageLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form members = new Members();
            members.Show();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("You will be Logged Out. Continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                Form login = new Login();
                login.Show();
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form events = new Events();
            events.Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Work in Progress ;)", "O P S", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void localhostToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void imageLocationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {


        }

        private void localhostToolStripMenuItem1_Click(object sender, EventArgs e)
        {


        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            report.Load();
        }

        private void aboutToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This COESS Master Database System is created by COESS 2018-2019." + Environment.NewLine +
"\n\n©Christer Jude A. Mananquil, Vice President - Internal (2018-2019)\n©Charles Edward D. Bernardo, Lead Programmer (2018-2019)\n©Mark Generson D. Espiritu, " +
"Lead Designer (2018-2019)\n\nAll Rights Reserved.\nNo part of this system can be reproduced nor modified without consent from the developer.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void imageLocationToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Always put all Images in C:\\JPIA\\Images\\.\nThank You.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void printToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form report = new Report_Form();
            report.Show();
        }

        private void localhostToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            isMaster = true;
            Initialize("server=localhost;uid=root;pwd=;sslmode=none;");
            if (DialogResult.Yes == MessageBox.Show("Would you like to check if the database exists?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                checkdb("jpia", jpia);
                if (!jpiadb)
                {
                    createdb("create database jpia;");
                    Initialize("server=localhost;uid=root;pwd=;database=jpia;sslmode=none;");
                    createdb("create table event_list (Event_No int(3) auto_increment, Event_Name varchar(300) not null, Event_Date varchar(255) not null, Event_Location varchar(300) not null, Event_Pubmat varchar(300) null, primary key(Event_No));");
                    createdb("create table member_list (ID_No int(3) auto_increment, SN varchar(255) not null, FN varchar(255) not null, MI varchar(255) not null, LN varchar(255) not null, Email varchar(255) not null, Address varchar(300) not null, Contact_No varchar(255) not null, BDay varchar(255) not null, Age varchar(255) not null, Year_Level varchar(255) not null, Comm varchar(255) not null, Guard_Name varchar(255) not null, Guard_Contact varchar(255) not null, Membership varchar(255) not null, ID_Address varchar(255) null, primary key(ID_No));");
                    createdb("create table report_table (LN varchar(255) null, FN varchar(255) null, SN varchar(255) not null, Yr_Lvl varchar(255) null, primary key(SN));");
                    MessageBox.Show("JPIA Database has been created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("JPIA Database Exists!", "Success", MessageBoxButtons.OK);
                }
                checkdb("jpia_events", jpia_events);
                if (!jpia_eventsdb)
                {
                    Initialize("server=localhost;uid=root;pwd=;sslmode=none;");
                    createdb("create database jpia_events;");
                    MessageBox.Show("JPIA Events Database has been created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("JPIA Events Database Exists!", "Success", MessageBoxButtons.OK);
                }
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            isMaster = false;
        }

        private void createSlaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMenu.Initialize("server=localhost;user=root;sslmode=none;");
            checkuser();
            if (user_accounts != 2)
            {
                Insert("create user 'jpia'@'192.168.1.2';");
                Insert("GRANT USAGE ON *.* TO 'jpia'@'192.168.1.2';");
                Insert("GRANT SELECT, INSERT, UPDATE, DELETE, CREATE, ALTER ON `jpia\\_events`.*TO 'jpia'@'192.168.1.2';");
                Insert("GRANT SELECT, INSERT, UPDATE, DELETE, CREATE, ALTER ON `jpia`.*TO 'jpia'@'192.168.1.2';");
                Insert("GRANT ALL PRIVILEGES ON `jpia\\_ %`.*TO 'jpia'@'192.168.1.2';");

                Insert("create user 'jpia'@'192.168.1.3';");
                Insert("GRANT USAGE ON *.* TO 'jpia'@'192.168.1.3';");
                Insert("GRANT SELECT, INSERT, UPDATE, DELETE, CREATE, ALTER ON `jpia\\_events`.*TO 'jpia'@'192.168.1.3';");
                Insert("GRANT SELECT, INSERT, UPDATE, DELETE, CREATE, ALTER ON `jpia`.*TO 'jpia'@'192.168.1.3';");
                Insert("GRANT ALL PRIVILEGES ON `jpia\\_ %`.*TO 'jpia'@'192.168.1.3';");

                MessageBox.Show("User Accounts Created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void exportDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = report;
            if (isMaster == true)
            {
                MainMenu.Initialize("server=localhost;uid=root;pwd=;database=jpia;sslmode=none;");
            }
            else
            {
                MainMenu.Initialize("server=192.168.1.4;uid=access;pwd=;database=jpia;sslmode=none;");
            }
            checkdb("report_table_1", reporttable);
            if (!report_table)
            {
                if (isMaster == true)
                {
                    MainMenu.Initialize("server=localhost;uid=root;pwd=;database=jpia;sslmode=none;");
                }
                else
                {
                    MainMenu.Initialize("server=192.168.1.4;uid=access;pwd=;database=jpia;sslmode=none;");
                }
                Insert("DROP TABLE ` report_table_1 `");
                Insert("create table report_table_1 (First varchar(255) not null, Middle varchar(255) not null, Last varchar(255) not null,Gender varchar(255) not null, Year_Level varchar(255) not null, Contact_Number varchar(255) not null, Email varchar(255) not null);");
                Insert("Delete from report_table_1;");

                Populate_ListView("Select fn,mi,ln,gender,year_level,contact_no,email from member_list;");
                foreach (ListViewItem item in listView1.Items)
                {
                    string ln, mi, fn, yr, con, email, gen;
                    fn = item.SubItems[0].Text;
                    mi = item.SubItems[1].Text;
                    ln = item.SubItems[2].Text;
                    gen = item.SubItems[3].Text;
                    yr = item.SubItems[4].Text;
                    con = item.SubItems[5].Text;
                    email = item.SubItems[6].Text;
                    Insert("insert into report_table_1 values ('" + fn + "','" + mi + "','" + ln + "','" + gen + "','" + yr + "','" + con + "','" + email + "');");
                }

                crystalReportViewer1.RefreshReport();
                crystalReportViewer1.ExportReport();
                Insert("Delete from report_table_1;");
            }
            else
            {
                if (isMaster == true)
                {
                    MainMenu.Initialize("server=localhost;uid=root;pwd=;database=jpia;sslmode=none;");
                }
                else
                {
                    MainMenu.Initialize("server=192.168.1.4;uid=access;pwd=;database=jpia;sslmode=none;");
                }
                Insert("Delete from report_table_1;");

                Populate_ListView("Select fn,mi,ln,gender,year_level,contact_no,email from member_list;");
                foreach (ListViewItem item in listView1.Items)
                {
                    string ln, mi, fn, yr, con, email, gen;
                    fn = item.SubItems[0].Text;
                    mi = item.SubItems[1].Text;
                    ln = item.SubItems[2].Text;
                    gen = item.SubItems[3].Text;
                    yr = item.SubItems[4].Text;
                    con = item.SubItems[5].Text;
                    email = item.SubItems[6].Text;
                    Insert("insert into report_table_1 values ('" + fn + "','" + mi + "','" + ln + "','" + gen + "','" + yr + "','" + con + "','" + email + "');");
                }

                crystalReportViewer1.RefreshReport();
                crystalReportViewer1.ExportReport();
                Insert("Delete from report_table_1;");

            }
        }
    }
}
