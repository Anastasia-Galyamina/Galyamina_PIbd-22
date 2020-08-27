﻿using ComputerWorkShopBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ComputerWorkShopBusinessLogic.ViewModels
{
    [DataContract]
    public class MessageInfoViewModel : BaseViewModel
    {
        [DataMember]
        public string MessageId { get; set; }

        [Column(title: "Отправитель", width: 150)]
        [DataMember]
        public string SenderName { get; set; }

        [DisplayName("Дата письма")]
        [DataMember]
        public DateTime DateDelivery { get; set; }

        [Column(title: "Заголовок", width: 100)]
        [DataMember]
        public string Subject { get; set; }
        [Column(title: "Текст", width: 150)]
        [DataMember]
        public string Body { get; set; }

        public override List<string> Properties() => new List<string> { "MessageId", "SenderName", "DateDelivery", "Subject", "Body" };
    }
}
