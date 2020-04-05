using System.Collections.Generic;
using ComputerWorkShopBusinessLogic.BindingModels;
using ComputerWorkShopBusinessLogic.ViewModels;


namespace ComputerWorkShopBusinessLogic.Interfaces
{
   public interface IWarehouseLogic
    {
        List<WarehouseViewModel> Read(WarehouseBindingModel model);
        void CreateOrUpdate(WarehouseBindingModel model);
        void Delete(WarehouseBindingModel model);
        void AddComponentToWarehouse(WarehouseComponentBindingModel model);
        bool RemoveComponentsFromWarehouse(OrderViewModel model);
    }
}
