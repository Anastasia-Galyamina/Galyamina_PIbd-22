namespace ComputerClientView
{
    partial class FormRegister
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
            this.labelLogin = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.labelClientFIO = new System.Windows.Forms.Label();
            this.textBoxClientFIO = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            //
            // labelLogin
            //
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(20, 21);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(75, 13);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "Логин(почта):";
            //             
            // textBoxLogin
            //
            this.textBoxLogin.Location = new System.Drawing.Point(101, 18);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(200, 20);
            this.textBoxLogin.TabIndex = 1;
            //
            // labelPassword
            //
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(20, 64);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(48, 13);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Пароль:";
            //
            // textBoxPassword
            //
            this.textBoxPassword.Location = new System.Drawing.Point(101, 61);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(200, 20);
            this.textBoxPassword.TabIndex = 3;
            //
            // labelClientFIO
            //
            this.labelClientFIO.AutoSize = true;
            this.labelClientFIO.Location = new System.Drawing.Point(20, 108);
            this.labelClientFIO.Name = "labelClientFIO";
            this.labelClientFIO.Size = new System.Drawing.Size(37, 13);
            this.labelClientFIO.TabIndex = 4;
            this.labelClientFIO.Text = "ФИО:";
            //
            // textBoxClientFIO
            //
            this.textBoxClientFIO.Location = new System.Drawing.Point(101, 105);
            this.textBoxClientFIO.Name = "textBoxClientFIO";
            this.textBoxClientFIO.Size = new System.Drawing.Size(200, 20);
            this.textBoxClientFIO.TabIndex = 5;
            //
            // buttonRegister
            //
            this.buttonRegister.Location = new System.Drawing.Point(149, 152);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(100, 23);
            this.buttonRegister.TabIndex = 6;
            this.buttonRegister.Text = "Регистрация";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.ButtonRegister_Click);
            //
            // FormRegister
            //
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 200);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.textBoxClientFIO);
            this.Controls.Add(this.labelClientFIO);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.labelLogin);
            this.Text = "Регистрация";
            this.ResumeLayout(false);           
            this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelClientFIO;
        private System.Windows.Forms.TextBox textBoxClientFIO;
        private System.Windows.Forms.Button buttonRegister;

    }
}