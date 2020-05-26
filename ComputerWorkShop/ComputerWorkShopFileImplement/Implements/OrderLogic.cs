using System;
using System.Collections.Generic;
using System.Linq;
using ComputerWorkShopBusinessLogic.BindingModels;
using ComputerWorkShopBusinessLogic.Interfaces;
using ComputerWorkShopFileImplement.Models;
using ComputerWorkShopBusinessLogic.ViewModels;
using ComputerWorkShopBusinessLogic.Enums;

namespace ComputerWorkShopFileImplement.Implements
{
    public class OrderLogic:IOrderLogic
    {
        private readonly FileDataListSingleton source;
        public OrderLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(OrderBindingModel model)
        {
            Order order;
            if (model.Id.HasValue)
            {
                order = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (order == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec => rec.Id) : 0;
                order = new Order
                {
                    Id = maxId + 1,
                    ComputerId = model.ComputerId,
                    Count = model.Count,
                    ImplementerId = model.ImplementerId,
                    DateCreate = model.DateCreate,
                    DateImplement = model.DateImplement,
                    Status = OrderStatus.Принят,
                    Sum = model.Sum
                };
                source.Orders.Add(order);
                return;
            }
            order.ImplementerId = model.ImplementerId;
            order.ComputerId = model.ComputerId;
            order.Count = model.Count;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            order.Status = model.Status;
            order.Sum = model.Sum;
        }

        public void Delete(OrderBindingModel model)
        {
            Order order = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (order != null)
            {
                source.Orders.Remove(order);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            return source.Orders
            .Where(rec => model == null ||
                (model.Id != null && rec.Id == model.Id) ||
                (model.DateFrom != null && model.DateTo != null && rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo) ||
                (rec.ClientId == model.ClientId) ||
                (model.FreeOrders.HasValue && model.FreeOrders.Value && !rec.ImplementerId.HasValue) ||
                (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId && rec.Status == OrderStatus.Выполняется))
            .Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                ComputerId = rec.ComputerId,
                ComputerName = source.Computers.FirstOrDefault(car => car.Id == rec.ComputerId).ComputerName,
                ClientFIO = source.Clients.FirstOrDefault((cl) => cl.Id == rec.ClientId).ClientFIO,
                ImplementerId = rec.ImplementerId,
                ImplementerFIO = rec.ImplementerId.HasValue ?
                                    source.Implementers.FirstOrDefault((i) => i.Id == rec.ImplementerId).ImplementerFIO
                                    : string.Empty,
                Count = rec.Count,
                DateCreate = rec.DateCreate,
                DateImplement = rec.DateImplement,
                Status = rec.Status,
                Sum = rec.Sum
            })
            .ToList();
        }
    }
}
