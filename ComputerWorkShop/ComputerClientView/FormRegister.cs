using ComputerWorkShopBusinessLogic.BindingModels;
using System;
using System.Windows.Forms;

namespace ComputerClientView
{   
        public partial class FormRegister : Form
        {
            public FormRegister()
            {
                InitializeComponent();
            }
            private void ButtonRegister_Click(object sender, EventArgs e)
            {
                if (!string.IsNullOrEmpty(textBoxLogin.Text) &&
               !string.IsNullOrEmpty(textBoxPassword.Text) &&
               !string.IsNullOrEmpty(textBoxClientFIO.Text))
                {
                    try
                    {
                        APIClient.PostRequest("api/client/register", new ClientBindingModel
                        {
                            ClientFIO = textBoxClientFIO.Text,
                            Login = textBoxLogin.Text,
                            Password = textBoxPassword.Text
                        });
                        MessageBox.Show("Регистрация прошла успешно", "Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Введите логин, пароль и ФИО", "Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
}
