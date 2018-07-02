namespace System
{
    partial class New_Event
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(New_Event));
            this.event_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.event_location = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.event_date = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.event_pubmat = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.event_pubmat)).BeginInit();
            this.SuspendLayout();
            // 
            // event_name
            // 
            this.event_name.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.event_name.Location = new System.Drawing.Point(196, 188);
            this.event_name.Multiline = true;
            this.event_name.Name = "event_name";
            this.event_name.Size = new System.Drawing.Size(592, 26);
            this.event_name.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightGreen;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 37);
            this.label1.TabIndex = 4;
            this.label1.Text = "Event Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightGreen;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 37);
            this.label2.TabIndex = 6;
            this.label2.Text = "Event Location:";
            // 
            // event_location
            // 
            this.event_location.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.event_location.Location = new System.Drawing.Point(231, 242);
            this.event_location.Multiline = true;
            this.event_location.Name = "event_location";
            this.event_location.Size = new System.Drawing.Size(557, 26);
            this.event_location.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightGreen;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 37);
            this.label3.TabIndex = 8;
            this.label3.Text = "Event Date:";
            // 
            // event_date
            // 
            this.event_date.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.event_date.Location = new System.Drawing.Point(181, 315);
            this.event_date.Name = "event_date";
            this.event_date.Size = new System.Drawing.Size(200, 20);
            this.event_date.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::System.Properties.Resources.create_event_button;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(19, 354);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(310, 234);
            this.button1.TabIndex = 10;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // event_pubmat
            // 
            this.event_pubmat.BackgroundImage = global::System.Properties.Resources.JPIA_BACKGROUND;
            this.event_pubmat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.event_pubmat.Location = new System.Drawing.Point(335, 354);
            this.event_pubmat.Name = "event_pubmat";
            this.event_pubmat.Size = new System.Drawing.Size(453, 234);
            this.event_pubmat.TabIndex = 11;
            this.event_pubmat.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightGreen;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(404, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 37);
            this.label4.TabIndex = 12;
            this.label4.Text = "Event Pubmat:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::System.Properties.Resources.browse;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(613, 309);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(175, 32);
            this.button2.TabIndex = 13;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::System.Properties.Resources.go_back_new;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(640, 66);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(127, 32);
            this.button3.TabIndex = 31;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // New_Event
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::System.Properties.Resources.JPIA_EVENTS;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.event_pubmat);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.event_date);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.event_location);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.event_name);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "New_Event";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New_Event";
            this.Load += new System.EventHandler(this.New_Event_Load);
            ((System.ComponentModel.ISupportInitialize)(this.event_pubmat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.Forms.TextBox event_name;
        private Windows.Forms.Label label1;
        private Windows.Forms.Label label2;
        private Windows.Forms.TextBox event_location;
        private Windows.Forms.Label label3;
        private Windows.Forms.DateTimePicker event_date;
        private Windows.Forms.Button button1;
        private Windows.Forms.PictureBox event_pubmat;
        private Windows.Forms.Label label4;
        private Windows.Forms.OpenFileDialog openFileDialog1;
        private Windows.Forms.Button button2;
        private Windows.Forms.Button button3;
    }
}