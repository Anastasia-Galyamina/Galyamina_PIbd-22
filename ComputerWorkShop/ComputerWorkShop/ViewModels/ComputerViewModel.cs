using ComputerWorkShopBusinessLogic.Attributes;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ComputerWorkShopBusinessLogic.ViewModels
{
    [DataContract]
    public class ComputerViewModel : BaseViewModel
    {     
        [DataMember]
        [Column(title: "Название компьютера", width: 150)]       
        public string ComputerName { get; set; }

        [DataMember]
        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> ComputerComponents { get; set; }

        public override List<string> Properties() => new List<string> { "Id", "ComputerName", "Price" };
    }
}
