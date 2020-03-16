﻿using ComputerWorkShopBusinessLogic.Interfaces;
using ComputerWorkShopBusinessLogic.BindingModels;
using ComputerWorkShopBusinessLogic.Enums;
using System;

namespace ComputerWorkShopBusinessLogic.BusinessLogic
{
    public class MainLogic
    {
        private readonly IOrderLogic orderLogic;

        public MainLogic(IOrderLogic orderLogic)
        {
            this.orderLogic = orderLogic;
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
    }
}
