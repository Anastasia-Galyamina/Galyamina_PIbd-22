﻿using ComputerWorkShopBusinessLogic.BindingModels;
using ComputerWorkShopBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace ComputerWorkShopView
{
    public partial class FormWarehouse : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IWarehouseLogic logic;
        private int? id;
        public FormWarehouse(IWarehouseLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormWarehouse_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = logic.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.WarehouseName;
                    }
                    var warehouseList = logic.GetList();
                    var warehouseDetails = warehouseList[0].WarehouseComponents;
                    for (int i = 0; i < warehouseList.Count; ++i)
                    {
                        if (warehouseList[i].Id == id)
                        {
                            warehouseDetails = warehouseList[i].WarehouseComponents;
                        }
                    }
                    if (warehouseDetails != null)
                    {
                        dataGridView.DataSource = warehouseDetails;
                        dataGridView.Columns[0].Visible = false;
                        dataGridView.Columns[1].Visible = false;
                        dataGridView.Columns[2].Visible = false;
                        dataGridView.Columns[3].Visible = false;
                        dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    }
                    dataGridView.Columns[1].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
