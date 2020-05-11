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
        public ReportLogic(IComputerLogic computerLogic, IComponentLogic componentLogic,
       IOrderLogic orderLLogic)
        {            
            this.computerLogic = computerLogic;
            this.componentLogic = componentLogic;
            this.orderLogic = orderLLogic;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких компьютерах используются
        /// </summary>
        /// <returns></returns>
        public List<ReportComputerComponentViewModel> GetComputerComponent()
        {
            var components = componentLogic.Read(null);
            var computers = computerLogic.Read(null);
            var list = new List<ReportComputerComponentViewModel>();            
               
            foreach (var component in components)
            {
                foreach (var computer in computers)
                {
                    if (computer.ComputerComponents.ContainsKey(component.Id))
                    {
                        var record = new ReportComputerComponentViewModel
                        {
                            ComputerName = computer.ComputerName,
                            ComponentName = component.ComponentName,
                            Count = computer.ComputerComponents[component.Id].Item2
                        };
                        list.Add(record);
                    }
                }
            }            
            return list;
        }
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return orderLogic.Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                ComputerName = x.ComputerName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }
         /// <summary>
         /// Сохранение компьютеров в файл-Word
         /// </summary>
         /// <param name="model"></param>
         public void SaveComputersToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список компьютеров",
                Computers = computerLogic.Read(null)
            });
        }
        /// <summary>
        /// Сохранение заказовв в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                Orders = GetOrders(model)
            });
        }
        /// <summary>
        /// Сохранение компьютеров с компонентами в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
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
