using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ComputerWorkShopBusinessLogic.ViewModels
{
    [DataContract]
    public class ComputerViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Название компьютера")]
        public string ComputerName { get; set; }

        [DataMember]
        [DisplayName("Цена")]
        public decimal Price { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> ComputerComponents { get; set; }
    }
}
