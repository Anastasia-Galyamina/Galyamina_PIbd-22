using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerWorkShopBusinessLogic.BindingModels;
using ComputerWorkShopBusinessLogic.ViewModels;

namespace ComputerWorkShopBusinessLogic.Interfaces
{
    public interface IProductLogic
    {
        List<ProductViewModel> GetList();

        ProductViewModel GetElement(int id);

        void AddElement(ProductBindingModel model);

        void UpdElement(ProductBindingModel model);

        void DelElement(int id);
    }
}
