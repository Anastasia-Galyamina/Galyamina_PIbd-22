﻿using ComputerWorkShopBusinessLogic.BindingModels;
using ComputerWorkShopBusinessLogic.Interfaces;
using ComputerWorkShopBusinessLogic.ViewModels;
using ComputerWorkShopDatabaseImplement;
using ComputerWorkShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerWorkShopImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        public void CreateOrUpdate(OrderBindingModel model)
        {
            using (var context = new ComputerWorkShopDatabase())
            {
                Order element;
                if (model.Id.HasValue)
                {
                    element = context.Orders.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Order();
                    context.Orders.Add(element);
                }
                element.ComputerId = model.ComputerId == 0 ? element.ComputerId : model.ComputerId;
                element.Count = model.Count;
                element.Sum = model.Sum;
                element.Status = model.Status;
                element.DateCreate = model.DateCreate;
                element.DateImplement = model.DateImplement;
                context.SaveChanges();
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using (var context = new ComputerWorkShopDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new ComputerWorkShopDatabase())
            {
                return context.Orders
            .Include(rec => rec.Computer)
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                ComputerName = rec.Computer.ComputerName,
                Count = rec.Count,
                Sum = rec.Sum,
                Status = rec.Status,
                DateCreate = rec.DateCreate,
                DateImplement = rec.DateImplement
            })
            .ToList();
            }
        }
    }
}
