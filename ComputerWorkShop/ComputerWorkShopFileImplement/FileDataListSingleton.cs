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
        private readonly string WarehouseFileName = "Warehouse.xml";
        private readonly string WarehouseComponentFileName = "WarehouseComponent.xml";

        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Computer> Computers { get; set; }
        public List<ComputerComponent> ComputerComponents { get; set; }
        public List<Warehouse> Warehouses { get; set; }
        public List<WarehouseComponent> WarehouseComponents { get; set; }

        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Computers = LoadComputers();
            ComputerComponents = LoadComputerComponents();
            Warehouses = LoadWarehouses();
            WarehouseComponents = LoadWarehouseComponents();
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
            SaveWarehouses();
            SaveWarehouseComponents();
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

        private List<Warehouse> LoadWarehouses()
        {
            var list = new List<Warehouse>();

            if (File.Exists(WarehouseFileName))
            {
                XDocument xDocument = XDocument.Load(WarehouseFileName);
                var xElements = xDocument.Root.Elements("Warehouse").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Warehouse
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        WarehouseName = elem.Element("WarehouseName").Value                       
                    });
                }
            }

            return list;
        }

        private List<WarehouseComponent> LoadWarehouseComponents()
        {
            var list = new List<WarehouseComponent>();

            if (File.Exists(WarehouseComponentFileName))
            {
                XDocument xDocument = XDocument.Load(WarehouseComponentFileName);
                var xElements = xDocument.Root.Elements("WarehouseComponent").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new WarehouseComponent
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        WarehouseId = Convert.ToInt32(elem.Element("WarehouseId").Value),
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
                    xElement.Add(new XElement("Computer",
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
        private void SaveWarehouses()
        {
            if (Warehouses != null)
            {
                var xElement = new XElement("Warehouses");

                foreach (var warehouse in Warehouses)
                {
                    xElement.Add(new XElement("Warehouse",
                    new XAttribute("Id", warehouse.Id),
                    new XElement("WarehouseName", warehouse.WarehouseName)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(WarehouseFileName);
            }
        }

        private void SaveWarehouseComponents()
        {
            if (WarehouseComponents != null)
            {
                var xElement = new XElement("WarehouseComponents");

                foreach (var warehouseComponent in WarehouseComponents)
                {
                    xElement.Add(new XElement("WarehouseComponent",
                    new XAttribute("Id", warehouseComponent.Id),
                    new XElement("WarehouseId", warehouseComponent.WarehouseId),
                    new XElement("ComponentId", warehouseComponent.ComponentId),
                    new XElement("Count", warehouseComponent.Count)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ComputerComponentFileName);
            }
        }
    }
}
