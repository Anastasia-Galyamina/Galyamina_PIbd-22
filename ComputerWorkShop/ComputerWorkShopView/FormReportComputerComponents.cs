using ComputerWorkShopBusinessLogic.BindingModels;
using ComputerWorkShopBusinessLogic.BusinessLogic;
using System;
using System.Windows.Forms;
using Unity;

namespace ComputerWorkShopView
{
    public partial class FormReportComputerComponents : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        public FormReportComputerComponents(ReportLogic logic)
        {
            InitializeComponent();            
            this.logic = logic;
        }
        private void FormReportComputerComponents_Load(object sender, EventArgs e)
        {
            try
            {
                var dict = logic.GetComputerComponent();
                if (dict != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        dataGridView.Rows.Add(new object[] { elem.ComponentName, "", ""});
                        foreach (var listElem in elem.Computers)
                        {
                            dataGridView.Rows.Add(new object[] { "", listElem.Item1,listElem.Item2 });
                        }
                        dataGridView.Rows.Add(new object[] { "Итого", "", elem.TotalCount});
                        dataGridView.Rows.Add(new object[] { });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void ButtonSaveToExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveProductComponentToExcelFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
