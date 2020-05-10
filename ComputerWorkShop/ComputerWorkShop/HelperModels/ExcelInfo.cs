using ComputerWorkShopBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace ComputerWorkShopBusinessLogic.HelperModels
{
    public class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportComputerComponentViewModel> ComputerComponents { get; set; }
    }
}
