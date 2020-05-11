using ComputerWorkShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerWorkShopBusinessLogic.HelperModels
{
    public class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<IGrouping<DateTime, OrderViewModel>> Orders { get; set; }
    }
}
