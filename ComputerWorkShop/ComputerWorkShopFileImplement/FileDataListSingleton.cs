using System;
using System.Collections.Generic;
using System.Linq;
using ComputerWorkShopBusinessLogic.Enums;
using ComputerWorkShopFileImplement.Models;
using System.IO;
using System.Xml.Linq;

namespace ComputerWorkShopFileImplement
{
    class FileDataListSingleton
    {
        private static FileDataListSingleton instance;

        private readonly string ComponentFileName = "Component.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string ComputerFileName = "Computer.xml";
        private readonly string ComputerComponentFileName = "ComputerComponent.xml";
        private readonly string ClientFileName = "Client.xml";
        private readonly string ImplementerFileName = "Implementer.xml";
        private readonly string MessageInfoFileName = "MessageInfo.xml";

        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Computer> Computers { get; set; }
        public List<ComputerComponent> ComputerComponents { get; set; }
        public List<Client> Clients { get; set; }
        public List<Implementer> Implementers { get; set; } 
        public List<MessageInfo> MessageInfoes { get; set; }

        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Computers = LoadComputers();
            ComputerComponents = LoadComputerComponents();
            Clients = LoadClients();
            Implementers = LoadImplementers();
            MessageInfoes = LoadMessageInfoes();
        }

        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }

            return instance;
        }

        ~FileDataListSingleton()
        {
            SaveComponents();
            SaveOrders();
            SaveComputers();
            SaveComputerComponents();
            SaveClients();
            SaveImplementers();
            SaveMessageInfoes();
        }

        private List<Component> LoadComponents()
        {
            var list = new List<Component>();

            if (File.Exists(ComponentFileName))
            {
                XDocument xDocument = XDocument.Load(ComponentFileName);
                var xElements = xDocument.Root.Elements("Component").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Component
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }

            return list;
        }

        private List<Order> LoadOrders()
        {
            var list = new List<Order>();

            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComputerId = Convert.ToInt32(elem.Element("ComputerId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus),
                        elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
                        Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }

            return list;
        }

        private List<Computer> LoadComputers()
        {
            var list = new List<Computer>();

            if (File.Exists(ComputerFileName))
            {
                XDocument xDocument = XDocument.Load(ComputerFileName);
                var xElements = xDocument.Root.Elements("Computer").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Computer
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComputerName = elem.Element("ComputerName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value)
                    });
                }
            }

            return list;
        }

        private List<ComputerComponent> LoadComputerComponents()
        {
            var list = new List<ComputerComponent>();

            if (File.Exists(ComputerComponentFileName))
            {
                XDocument xDocument = XDocument.Load(ComputerComponentFileName);
                var xElements = xDocument.Root.Elements("ComputerComponent").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new ComputerComponent
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComputerId = Convert.ToInt32(elem.Element("ComputerId").Value),
                        ComponentId = Convert.ToInt32(elem.Element("ComponentId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }

            return list;
        }

        private List<Client> LoadClients()
        {
            var list = new List<Client>();

            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Client
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ClientFIO = elem.Element("ClientFIO").Value,
                        Login = elem.Element("Login").Value,
                        Password = elem.Element("Password").Value
                    });
                }
            }

            return list;
        }

        private List<Implementer> LoadImplementers()
        {
            var list = new List<Implementer>();
            if (File.Exists(ImplementerFileName))
            {
                XDocument xDocument = XDocument.Load(ImplementerFileName);
                var xElements = xDocument.Root.Elements("Implementer").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Implementer
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ImplementerFIO = elem.Element("ImplementerFIO").Value,
                        PauseTime = Convert.ToInt32(elem.Element("PauseTime").Value),
                        WorkingTime = Convert.ToInt32(elem.Element("WorkingTime").Value),
                    });
                }
            }
            return list;
        }

        private List<MessageInfo> LoadMessageInfoes()
        {
            var list = new List<MessageInfo>();
            if (File.Exists(MessageInfoFileName))
            {
                XDocument xDocument = XDocument.Load(MessageInfoFileName);
                var xElements = xDocument.Root.Elements("MessageInfo").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new MessageInfo
                    {
                        MessageId = elem.Attribute("MessageId").Value,
                        Body = elem.Element("Body").Value,
                        ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
                        DateDelivery = Convert.ToDateTime(elem.Element("DateDelivery").Value),
                        SenderName = elem.Element("SenderName").Value,
                        Subject = elem.Element("Subject").Value
                    });
                }
            }
            return list;
        }

        private void SaveComponents()
        {
            if (Components != null)
            {
                var xElement = new XElement("Components");

                foreach (var component in Components)
                {
                    xElement.Add(new XElement("Component",
                    new XAttribute("Id", component.Id),
                    new XElement("ComponentName", component.ComponentName)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ComponentFileName);
            }
        }

        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");

                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("ComputerId", order.ComputerId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveComputers()
        {
            if (Computers != null)
            {
                var xElement = new XElement("Computers");

                foreach (var computer in Computers)
                {
                    xElement.Add(new XElement("Product",
                    new XAttribute("Id", computer.Id),
                    new XElement("ComputerName", computer.ComputerName),
                    new XElement("Price", computer.Price)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ComputerFileName);
            }
        }

        private void SaveComputerComponents()
        {
            if (ComputerComponents != null)
            {
                var xElement = new XElement("ComputerComponents");

                foreach (var computerComponent in ComputerComponents)
                {
                    xElement.Add(new XElement("ComputerComponent",
                    new XAttribute("Id", computerComponent.Id),
                    new XElement("ComputerId", computerComponent.ComputerId),
                    new XElement("ComponentId", computerComponent.ComponentId),
                    new XElement("Count", computerComponent.Count)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ComputerComponentFileName);
            }
        }

        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");

                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("ClientFIO", client.ClientFIO),
                    new XElement("Login", client.Login),
                    new XElement("Password", client.Password)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ClientFileName);
            }
        }

        private void SaveImplementers()
        {
            if (Implementers != null)
            {
                var xElement = new XElement("Implementers");

                foreach (var implementer in Implementers)
                {
                    xElement.Add(
                        new XElement("Implementer",
                        new XAttribute("Id", implementer.Id),
                        new XElement("ImplementerFIO", implementer.ImplementerFIO),
                        new XElement("PauseTime", implementer.PauseTime),
                        new XElement("WorkingTime", implementer.WorkingTime)
                        ));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ImplementerFileName);
            }
        }

        private void SaveMessageInfoes()
        {
            if (MessageInfoes != null)
            {
                var xElement = new XElement("MessageInfoes");

                foreach (var messageInfo in MessageInfoes)
                {
                    xElement.Add(
                        new XElement("MessageInfoe",
                              new XAttribute("MessageId", messageInfo.MessageId),
                              new XElement("Body", messageInfo.Body),
                              new XElement("ClientId", messageInfo.ClientId),
                              new XElement("DateDelivery", messageInfo.DateDelivery),
                              new XElement("SenderName", messageInfo.SenderName),
                              new XElement("Subject", messageInfo.Subject)
                        ));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(MessageInfoFileName);
            }
        }
    }
}
