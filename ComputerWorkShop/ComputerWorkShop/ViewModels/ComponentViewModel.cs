using ComputerWorkShopBusinessLogic.Attributes;
using System.Collections.Generic;

namespace ComputerWorkShopBusinessLogic.ViewModels
{
    public class ComponentViewModel : BaseViewModel
    {    

        [Column(title: "Название компонента", width: 150)]
        public string ComponentName { get; set; }

        public override List<string> Properties() => new List<string> { "Id", "ComponentName" };
    }
}
