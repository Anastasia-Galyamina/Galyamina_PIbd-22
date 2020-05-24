using ComputerWorkShopBusinessLogic.BindingModels;
using ComputerWorkShopBusinessLogic.BusinessLogic;
using ComputerWorkShopBusinessLogic.Interfaces;
using ComputerWorkShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace ComputerWorkShopView
{
    public partial class FormCreateOrder : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IComputerLogic logicP;
        private readonly IClientLogic logicC;
        private readonly MainLogic logicM;

        public FormCreateOrder(IComputerLogic logicP, MainLogic logicM, IClientLogic logicC)
        {
            InitializeComponent();
            this.logicP = logicP;
            this.logicM = logicM;
            this.logicC = logicC;
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {                
                List<ComputerViewModel> listP = logicP.Read(null);
                if (listP != null)
                {
                    comboBoxComputer.DisplayMember = "ComputerName";
                    comboBoxComputer.ValueMember = "Id";
                    comboBoxComputer.DataSource = listP;
                    comboBoxComputer.SelectedItem = null;
                }

                List<ClientViewModel> listC = logicC.Read(null);
                if (listC != null)
                {
                    comboBoxClient.DisplayMember = "ComputerName";
                    comboBoxClient.ValueMember = "Id";
                    comboBoxClient.DataSource = listC;
                    comboBoxClient.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void CalcSum()
        {
            if (comboBoxComputer.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxComputer.SelectedValue);
                    ComputerViewModel computer = logicP.Read(new ComputerBindingModel{Id = id})?[0]; 
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * computer?.Price ?? 0).ToString(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void comboBoxComputer_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxComputer.SelectedValue == null)
            {
                MessageBox.Show("Выберите компьютер", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (comboBoxClient.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logicM.CreateOrder(new CreateOrderBindingModel
                {
                    ComputerId = Convert.ToInt32(comboBoxComputer.SelectedValue),
                    ClientId = Convert.ToInt32(comboBoxClient.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text)
                });

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
