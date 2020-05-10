using System;
using System.Collections.Generic;

namespace ComputerWorkShopBusinessLogic.ViewModels
{
    public class ReportComputerComponentViewModel
    {       
        public string ComponentName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Computers { get; set; }
    }
}
