using System.Collections.Generic;
using ComputerWorkShopBusinessLogic.BindingModels;
using ComputerWorkShopBusinessLogic.ViewModels;

namespace ComputerWorkShopBusinessLogic.Interfaces
{
    public interface IComponentLogic
    {
        List<ComponentViewModel> GetList();

        ComponentViewModel GetElement(int id);

        void AddElement(ComponentBindingModel model);

        void UpdElement(ComponentBindingModel model);

        void DelElement(int id);
    }
}
