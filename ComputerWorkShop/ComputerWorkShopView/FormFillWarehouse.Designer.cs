namespace ComputerWorkShopView
{
    partial class FormFillWarehouse
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
            this.comboBoxWarehouse = new System.Windows.Forms.ComboBox();
            this.comboBoxComponent = new System.Windows.Forms.ComboBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxWarehouse
            // 
            this.comboBoxWarehouse.FormattingEnabled = true;
            this.comboBoxWarehouse.Location = new System.Drawing.Point(124, 20);
            this.comboBoxWarehouse.Name = "comboBoxWarehouse";
            this.comboBoxWarehouse.Size = new System.Drawing.Size(176, 21);
            this.comboBoxWarehouse.TabIndex = 0;
            // 
            // comboBoxComponent
            // 
            this.comboBoxComponent.FormattingEnabled = true;
            this.comboBoxComponent.Location = new System.Drawing.Point(124, 52);
            this.comboBoxComponent.Name = "comboBoxComponent";
            this.comboBoxComponent.Size = new System.Drawing.Size(176, 21);
            this.comboBoxComponent.TabIndex = 1;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(124, 89);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(176, 22);
            this.textBoxCount.TabIndex = 2;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 127);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(128, 37);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Склад";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Компонент";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Количество";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 37);
            this.button1.TabIndex = 7;
            this.button1.Text = "Отмена";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormFillWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 200);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.comboBoxComponent);
            this.Controls.Add(this.comboBoxWarehouse);
            this.Name = "FormFillWarehouse";
            this.Text = "Пополнить склад";
            this.Load += new System.EventHandler(this.FormFillWarehouse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxWarehouse;
        private System.Windows.Forms.ComboBox comboBoxComponent;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}