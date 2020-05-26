using ComputerWorkShopBusinessLogic.BindingModels;
using ComputerWorkShopBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace ComputerWorkShopBusinessLogic.Interfaces
{
    public interface IImplementerLogic
    {
        List<ImplementerViewModel> Read(ImplementerBindingModel model);
        void CreateOrUpdate(ImplementerBindingModel model);
        void Delete(ImplementerBindingModel model);
    }
}
