using ComputerWorkShop.BindingModels;
using ComputerWorkShop.ViewModels;
using System.Collections.Generic;

namespace ComputerWorkShop.Interfaces
{
    public interface IMessageInfoLogic
    {
        List<MessageInfoViewModel> Read(MessageInfoBindingModel model);
        void Create(MessageInfoBindingModel model);
    }
}
