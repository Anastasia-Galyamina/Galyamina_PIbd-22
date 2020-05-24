using ComputerWorkShopBusinessLogic.BindingModels;
using System;
using System.Windows.Forms;

namespace ComputerClientView
{
    public partial class FormUpdateData : Form
    {
        public FormUpdateData()
        {
            InitializeComponent();
            textBoxClientFIO.Text = Program.Client.ClientFIO;
            textBoxLogin.Text = Program.Client.Login;
            textBoxPassword.Text = Program.Client.Password;
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxLogin.Text) && !string.IsNullOrEmpty(textBoxPassword.Text) && !string.IsNullOrEmpty(textBoxClientFIO.Text))
            {
                try
                {
                    APIClient.PostRequest("api/client/updatedata", new ClientBindingModel
                    {
                        Id = Program.Client.Id,
                        ClientFIO = textBoxClientFIO.Text,
                        Login = textBoxLogin.Text,
                        Password = textBoxPassword.Text
                    });

                    MessageBox.Show("Обновление прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Program.Client.ClientFIO = textBoxClientFIO.Text;
                    Program.Client.Login = textBoxLogin.Text;
                    Program.Client.Password = textBoxPassword.Text;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите логин, пароль и ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
