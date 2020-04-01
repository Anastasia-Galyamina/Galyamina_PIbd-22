using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerWorkShopBusinessLogic.BindingModels;
using ComputerWorkShopBusinessLogic.ViewModels;


namespace ComputerWorkShopBusinessLogic.Interfaces
{
   public interface IWarehouseLogic
    {
        List<WarehouseViewModel> Read(WarehouseBindingModel model);
        void CreateOrUpdate(WarehouseBindingModel model);
        void Delete(WarehouseBindingModel model);
    }
}
