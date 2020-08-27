namespace ComputerWorkShopView
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.referencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.componentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.computersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.implementersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.computersListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.computerComponentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startWorksToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonPayOrder = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.createBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.referencesToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.startWorksToolStripMenuItem1,
            this.createBackupToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1035, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.referencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.componentsToolStripMenuItem,
            this.computersToolStripMenuItem,
            this.clientsToolStripMenuItem,
            this.implementersToolStripMenuItem,
            this.messagesToolStripMenuItem});
            this.referencesToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.referencesToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.referencesToolStripMenuItem.Text = "Справочники";
            // 
            // компонентыToolStripMenuItem
            // 
            this.componentsToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.componentsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.componentsToolStripMenuItem.Text = "Компоненты";
            this.componentsToolStripMenuItem.Click += new System.EventHandler(this.componentsToolStripMenuItem_Click);
            // 
            // изделияToolStripMenuItem
            // 
            this.computersToolStripMenuItem.Name = "изделияToolStripMenuItem";
            this.computersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.computersToolStripMenuItem.Text = "Компьютеры";
            this.computersToolStripMenuItem.Click += new System.EventHandler(this.computersToolStripMenuItem_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.clientsToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.clientsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clientsToolStripMenuItem.Text = "Клиенты";
            this.clientsToolStripMenuItem.Click += new System.EventHandler(this.clientsToolStripMenuItem_Click);
            // 
            // исполнителиToolStripMenuItem
            // 
            this.implementersToolStripMenuItem.Name = "исполнителиToolStripMenuItem";
            this.implementersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.implementersToolStripMenuItem.Text = "Исполнители";
            this.implementersToolStripMenuItem.Click += new System.EventHandler(this.implementersToolStripMenuItem_Click);
            // 
            // сообщенияToolStripMenuItem
            // 
            this.messagesToolStripMenuItem.Name = "сообщенияToolStripMenuItem";
            this.messagesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.messagesToolStripMenuItem.Text = "Сообщения";
            this.messagesToolStripMenuItem.Click += new System.EventHandler(this.messagesToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.computersListToolStripMenuItem,
            this.computerComponentsToolStripMenuItem,
            this.ordersListToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.reportsToolStripMenuItem.Text = "Отчеты";
            // 
            // списокКомпонентовToolStripMenuItem
            // 
            this.computersListToolStripMenuItem.Name = "списокКомпонентовToolStripMenuItem";
            this.computersListToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.computersListToolStripMenuItem.Text = "Список компьютеров";
            this.computersListToolStripMenuItem.Click += new System.EventHandler(this.computersListToolStripMenuItem_Click);
            // 
            // компонентыПоКомпьютерамToolStripMenuItem
            // 
            this.computerComponentsToolStripMenuItem.Name = "компонентыПоКомпьютерамToolStripMenuItem";
            this.computerComponentsToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.computerComponentsToolStripMenuItem.Text = "Компоненты по компьютерам";
            this.computerComponentsToolStripMenuItem.Click += new System.EventHandler(this.computerComponentsToolStripMenuItem_Click);
            // 
            // списокЗаказовToolStripMenuItem
            // 
            this.ordersListToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            this.ordersListToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.ordersListToolStripMenuItem.Text = "Список заказов";
            this.ordersListToolStripMenuItem.Click += new System.EventHandler(this.ordersListToolStripMenuItem_Click);
            // 
            // запускРаботToolStripMenuItem1
            // 
            this.startWorksToolStripMenuItem1.Name = "запускРаботToolStripMenuItem1";
            this.startWorksToolStripMenuItem1.Size = new System.Drawing.Size(93, 20);
            this.startWorksToolStripMenuItem1.Text = "Запуск работ";
            this.startWorksToolStripMenuItem1.Click += new System.EventHandler(this.startWorksToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(9, 24);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(810, 349);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(831, 26);
            this.buttonCreateOrder.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(141, 29);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // buttonPayOrder
            // 
            this.buttonPayOrder.Location = new System.Drawing.Point(831, 68);
            this.buttonPayOrder.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPayOrder.Name = "buttonPayOrder";
            this.buttonPayOrder.Size = new System.Drawing.Size(141, 26);
            this.buttonPayOrder.TabIndex = 5;
            this.buttonPayOrder.Text = "Заказ оплачен";
            this.buttonPayOrder.UseVisualStyleBackColor = true;
            this.buttonPayOrder.Click += new System.EventHandler(this.buttonPayOrder_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(831, 116);
            this.buttonRef.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(141, 27);
            this.buttonRef.TabIndex = 6;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // создатьБэкапToolStripMenuItem
            // 
            this.createBackupToolStripMenuItem.Name = "создатьБэкапToolStripMenuItem";
            this.createBackupToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.createBackupToolStripMenuItem.Text = "Создать Бекап";
            this.createBackupToolStripMenuItem.Click += new System.EventHandler(this.createBackupToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 379);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonPayOrder);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.Text = "Ремонт компьютеров";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem referencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem componentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem computersToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonPayOrder;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem computersListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem computerComponentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordersListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem implementersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startWorksToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem messagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createBackupToolStripMenuItem;
    }
}