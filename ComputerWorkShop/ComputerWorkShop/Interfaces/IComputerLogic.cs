using System.Collections.Generic;
using ComputerWorkShopBusinessLogic.BindingModels;
using ComputerWorkShopBusinessLogic.ViewModels;

namespace ComputerWorkShopBusinessLogic.Interfaces
{
    public interface IComputerLogic
    {
        List<ComputerViewModel> GetList();

        ComputerViewModel GetElement(int id);

        void AddElement(ComputerBindingModel model);

        void UpdElement(ComputerBindingModel model);

        void DelElement(int id);
    }
}
