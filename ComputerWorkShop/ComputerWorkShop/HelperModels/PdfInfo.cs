﻿using ComputerWorkShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace ComputerWorkShopBusinessLogic.HelperModels
{
    public class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<ReportComputerComponentViewModel> ComputerComponents { get; set; }
    }
}
