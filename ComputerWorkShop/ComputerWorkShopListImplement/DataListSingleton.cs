using ComputerWorkShopListImplement.Models;
using System.Collections.Generic;

namespace ComputerWorkShopListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Component> Components { get; set; }

        public List<Order> Orders { get; set; }

        public List<Computer> Computers { get; set; }

        public List<ComputerComponent> ComputerComponents { get; set; }

        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Computers = new List<Computer>();
            ComputerComponents = new List<ComputerComponent>();
        }

        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }

            return instance;
        }
    }
}