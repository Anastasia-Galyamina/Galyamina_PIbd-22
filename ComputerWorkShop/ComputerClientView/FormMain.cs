﻿using ComputerWorkShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ComputerClientView
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            LoadList();
        }

        private void LoadList()
        {
            try
            {
                dataGridView.DataSource = APIClient.GetRequest<List<OrderViewModel>>($"api/main/getorders?clientId={Program.Client.Id}");

                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[2].Visible = false;
                dataGridView.Columns[3].Visible = false;
                dataGridView.Columns[4].Visible = false;
                dataGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormUpdateData();

            form.ShowDialog();
        }

        private void CreateOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormCreateOrder();

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadList();
            }
        }

        private void RefreshOrderListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadList();
        }

        private void MessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormMails();
            form.ShowDialog();
        }
    }
}
