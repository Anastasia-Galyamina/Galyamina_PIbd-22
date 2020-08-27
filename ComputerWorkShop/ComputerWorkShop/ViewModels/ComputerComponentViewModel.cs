using ComputerWorkShopBusinessLogic.Attributes;
using ComputerWorkShopBusinessLogic.Enums;
using System.Collections.Generic;

namespace ComputerWorkShopBusinessLogic.ViewModels
{
    public class ComputerComponentViewModel : BaseViewModel
    {
        public int ComputerId { get; set; }

        public int ComponentId { get; set; }

        [Column(title: "Компонент", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ComponentName { get; set; }

        [Column(title: "Количество", width: 100)]
        public int Count { get; set; }

        public override List<string> Properties() => new List<string>
        {
            "Id",
            "ComponentName",
            "Count"
        };
    }
}
