using ComputerWorkShopBusinessLogic.ViewModels;
using System.Collections.Generic;


namespace ComputerWorkShopBusinessLogic.HelperModels
{
    public class WordInfo
    { 
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ComputerViewModel> Computers { get; set; }
    }
}
