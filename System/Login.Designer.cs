namespace System
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UserBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.Loginbutton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightGreen;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightGreen;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // UserBox
            // 
            this.UserBox.Location = new System.Drawing.Point(184, 96);
            this.UserBox.Name = "UserBox";
            this.UserBox.Size = new System.Drawing.Size(254, 20);
            this.UserBox.TabIndex = 2;
            this.UserBox.TextChanged += new System.EventHandler(this.UserBox_TextChanged);
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(182, 145);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(254, 20);
            this.PasswordBox.TabIndex = 3;
            this.PasswordBox.UseSystemPasswordChar = true;
            this.PasswordBox.TextChanged += new System.EventHandler(this.PasswordBox_TextChanged);
            // 
            // Loginbutton
            // 
            this.Loginbutton.BackgroundImage = global::System.Properties.Resources.login;
            this.Loginbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Loginbutton.Location = new System.Drawing.Point(182, 201);
            this.Loginbutton.Name = "Loginbutton";
            this.Loginbutton.Size = new System.Drawing.Size(136, 38);
            this.Loginbutton.TabIndex = 4;
            this.Loginbutton.UseVisualStyleBackColor = true;
            this.Loginbutton.Click += new System.EventHandler(this.Loginbutton_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::System.Properties.Resources.quit;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(422, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 40);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::System.Properties.Resources.JPIA_BACKGROUND;
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Loginbutton);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.UserBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.Forms.Label label1;
        private Windows.Forms.Label label2;
        private Windows.Forms.TextBox UserBox;
        private Windows.Forms.TextBox PasswordBox;
        private Windows.Forms.Button Loginbutton;
        private Windows.Forms.Button button1;
    }
}