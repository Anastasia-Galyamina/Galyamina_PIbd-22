using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerWorkShopFileImplement
{
    class FileDataListSingleton
    {
        private static FileDataListSingleton instance;

        private readonly string ComponentFileName = "Component.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string ComputerFileName = "Computer.xml";
        private readonly string ComputerComponentFileName = "ComputerComponent.xml";

        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Computer> Computers { get; set; }
        public List<ComputerComponent> ComputerComponents { get; set; }

        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Computers = LoadComputers();
            ComputerComponents = LoadComputerComponents();
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
            SaveProducts();
            SaveProductComponents();
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
                        ProductId = Convert.ToInt32(elem.Element("ProductId").Value),
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

        private List<Computer> LoadProducts()
        {
            var list = new List<Computer>();

            if (File.Exists(ComputerFileName))
            {
                XDocument xDocument = XDocument.Load(ComputerFileName);
                var xElements = xDocument.Root.Elements("Product").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Computer
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ProductName = elem.Element("ComputerName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value)
                    });
                }
            }

            return list;
        }

        private List<ComputerComponent> LoadProductComponents()
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
                    new XElement("ProductId", order.ProductId),
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

        private void SaveProductComponents()
        {
            if (ComputerComponents != null)
            {
                var xElement = new XElement("ComputerComponents");

                foreach (var computerComponent in ComputerComponents)
                {
                    xElement.Add(new XElement("ComputerComponent",
                    new XAttribute("Id", computerComponent.Id),
                    new XElement("ComputerId", computerComponent.ProductId),
                    new XElement("ComponentId", computerComponent.ComponentId),
                    new XElement("Count", computerComponent.Count)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ComputerComponentFileName);
            }
        }

    }
}
