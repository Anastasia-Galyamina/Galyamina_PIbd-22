using ComputerWorkShopBusinessLogic.BindingModels;
using ComputerWorkShopBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace ComputerWorkShopBusinessLogic.Interfaces
{
    public interface IMessageInfoLogic
    {
        List<MessageInfoViewModel> Read(MessageInfoBindingModel model);
        void Create(MessageInfoBindingModel model);
    }
}
