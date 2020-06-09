using ComputerWorkShopBusinessLogic.Attributes;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ComputerWorkShopBusinessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel : BaseViewModel
    {        
        [DataMember]
        [Column(title: "ФИО", width: 100)]
        public string ClientFIO { get; set; }

        [DataMember]
        [Column(title: "Логин", width: 100)]
        public string Login { get; set; }

        [DataMember]
        [Column(title: "Пароль", width: 100)]
        public string Password { get; set; }

        public override List<string> Properties() => new List<string> { "Id", "ClientFIO", "Login", "Password" };

    }
}
