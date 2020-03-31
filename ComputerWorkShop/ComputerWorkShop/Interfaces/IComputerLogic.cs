using System.Collections.Generic;
using ComputerWorkShopBusinessLogic.BindingModels;
using ComputerWorkShopBusinessLogic.ViewModels;

namespace ComputerWorkShopBusinessLogic.Interfaces
{
    public interface IComputerLogic
    {
        List<ComputerViewModel> Read(ComputerBindingModel model);
        void CreateOrUpdate(ComputerBindingModel model);
        void Delete(ComputerBindingModel model);
    }
}
