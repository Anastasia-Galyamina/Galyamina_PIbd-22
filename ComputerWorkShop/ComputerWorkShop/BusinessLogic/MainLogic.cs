using ComputerWorkShopBusinessLogic.Interfaces;
using ComputerWorkShopBusinessLogic.BindingModels;
using ComputerWorkShopBusinessLogic.Enums;
using System;
using ComputerWorkShopBusinessLogic.ViewModels;

namespace ComputerWorkShopBusinessLogic.BusinessLogic
{
    public class MainLogic
    {
        private readonly IOrderLogic orderLogic;
        private readonly IWarehouseLogic warehouseLogic;
        private readonly IComponentLogic componentLogic;

        public MainLogic(IOrderLogic orderLogic, IWarehouseLogic warehouseLogic, IComponentLogic componentLogic)
        {
            this.orderLogic = orderLogic;
            this.warehouseLogic = warehouseLogic;
            this.componentLogic = componentLogic;
        }

        public void CreateOrder(CreateOrderBindingModel model)
        {
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                ComputerId = model.ComputerId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят
            });
        }

        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];

            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }

            if (order.Status != OrderStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }

            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                ComputerId = order.ComputerId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                Status = OrderStatus.Выполняется
            });
        }

        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];

            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }

            if (order.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }

            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                ComputerId = order.ComputerId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = DateTime.Now,
                Status = OrderStatus.Готов
            });
        }

        public void PayOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];

            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }

            if (order.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }

            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                ComputerId = order.ComputerId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Оплачен
            });
        }
        public void AddComponentsToWarehouse(WarehouseComponentBindingModel model)
        {
            WarehouseViewModel warehouse = warehouseLogic.Read(new WarehouseBindingModel() { Id = model.Id })?[0];
            // если на складе есть компонент
            if (warehouse.WarehouseComponents.ContainsKey(model.ComponentId))
                //то увеличиваем его количество
                warehouse.WarehouseComponents[model.ComponentId] = (warehouse.WarehouseComponents[model.ComponentId].Item1,
                   warehouse.WarehouseComponents[model.ComponentId].Item2 + model.Count);
            // если нет такого компонента, то добавляем его
            else
                warehouse.WarehouseComponents.Add(model.ComponentId,
                    (componentLogic.Read(new ComponentBindingModel() { Id = model.ComponentId })[0].ComponentName, model.Count));
            warehouseLogic.CreateOrUpdate(new WarehouseBindingModel()
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                WarehouseComponents = warehouse.WarehouseComponents
            });
        }
    }
}
