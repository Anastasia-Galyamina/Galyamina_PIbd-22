using ComputerWorkShopBusinessLogic.BindingModels;
using ComputerWorkShopBusinessLogic.HelperModels;
using ComputerWorkShopBusinessLogic.Interfaces;
using ComputerWorkShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerWorkShopBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IComponentLogic componentLogic;
        private readonly IComputerLogic computerLogic;
        private readonly IOrderLogic orderLogic;

        public ReportLogic(IComputerLogic computerLogic, IComponentLogic componentLogic, IOrderLogic orderLogic)
        {
            this.computerLogic = computerLogic;
            this.componentLogic = componentLogic;
            this.orderLogic = orderLogic;
        }

        public List<ReportComputerComponentViewModel> GetComputerComponent()
        {
            var computers = computerLogic.Read(null);
            var list = new List<ReportComputerComponentViewModel>();

            foreach (var computer in computers)
            {
                foreach (var pc in computer.ComputerComponents)
                {
                    var record = new ReportComputerComponentViewModel
                    {
                        ComputerName = computer.ComputerName,
                        ComponentName = pc.Value.Item1,
                        Count = pc.Value.Item2
                    };

                    list.Add(record);
                }
            }
            return list;
        }

        public List<IGrouping<DateTime, OrderViewModel>> GetOrders(ReportBindingModel model)
        {
            var list = orderLogic
            .Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .GroupBy(rec => rec.DateCreate.Date)
            .OrderBy(recG => recG.Key)
            .ToList();

            return list;
        }

        public void SaveComputersToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список компьютеров",
                Computers = computerLogic.Read(null)
            });
        }

        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrders(model)
            });
        }

        public void SaveComputerComponentsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список компьютеров с компонентами",
                ComputerComponents = GetComputerComponent()
            });
        }
    }
}
