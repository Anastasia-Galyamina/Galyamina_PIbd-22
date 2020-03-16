using ComputerWorkShopBusinessLogic.BindingModels;
using ComputerWorkShopBusinessLogic.Interfaces;
using ComputerWorkShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace ComputerWorkShopView
{
    public partial class FormComputer : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IComputerLogic logic;
        private int? id;
        private List<ComputerComponentViewModel> productComponents;

        public FormComputer(IComputerLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ComputerViewModel view = logic.GetElement(id.Value);

                    if (view != null)
                    {
                        textBoxName.Text = view.ComputerName;
                        textBoxPrice.Text = view.Price.ToString();
                        productComponents = view.ComputerComponents;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                productComponents = new List<ComputerComponentViewModel>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (productComponents != null)
                {
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = productComponents;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormComputerComponent>();

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.ModelView != null)
                {
                    if (id.HasValue)
                    {
                        form.ModelView.ComputerId = id.Value;
                    }

                    productComponents.Add(form.ModelView);
                }

                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormComputerComponent>();
                form.ModelView = productComponents[dataGridView.SelectedRows[0].Cells[0].RowIndex];

                if (form.ShowDialog() == DialogResult.OK)
                {
                    productComponents[dataGridView.SelectedRows[0].Cells[0].RowIndex] = form.ModelView;
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        productComponents.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (productComponents == null || productComponents.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                List<ComputerComponentBindingModel> productComponentBM = new List<ComputerComponentBindingModel>();

                for (int i = 0; i < productComponents.Count; ++i)
                {
                    productComponentBM.Add(new ComputerComponentBindingModel
                    {
                        Id = productComponents[i].Id,
                        ComputerId = productComponents[i].ComputerId,
                        ComponentId = productComponents[i].ComponentId,
                        Count = productComponents[i].Count
                    });
                }

                if (id.HasValue)
                {
                    logic.UpdElement(new ComputerBindingModel
                    {
                        Id = id.Value,
                        ComputerName = textBoxName.Text,
                        Price = Convert.ToDecimal(textBoxPrice.Text),
                        ComputerComponents = productComponentBM
                    });
                }
                else
                {
                    logic.AddElement(new ComputerBindingModel
                    {
                        ComputerName = textBoxName.Text,
                        Price = Convert.ToDecimal(textBoxPrice.Text),
                        ComputerComponents = productComponentBM
                    });
                }

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; Close();
        }
    }
}