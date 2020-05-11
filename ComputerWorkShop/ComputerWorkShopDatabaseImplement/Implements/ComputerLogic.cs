using ComputerWorkShopBusinessLogic.BindingModels;
using ComputerWorkShopBusinessLogic.Interfaces;
using ComputerWorkShopBusinessLogic.ViewModels;
using ComputerWorkShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerWorkShopDatabaseImplement.Implements
{
    public class ComputerLogic : IComputerLogic
    {
        public void CreateOrUpdate(ComputerBindingModel model)
        {
            using (var context = new ComputerWorkShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Computer element = context.Computers.FirstOrDefault(rec =>
                       rec.ComputerName == model.ComputerName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть компьютер с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Computers.FirstOrDefault(rec => rec.Id ==
                           model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Computer();
                            context.Computers.Add(element);
                        }
                        element.ComputerName = model.ComputerName;
                        element.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var ComputerComponents = context.ComputerComponents.Where(rec
                           => rec.ComputerId == model.Id.Value).ToList();
                            // удалили те, которых нет в модели
                            context.ComputerComponents.RemoveRange(ComputerComponents.Where(rec =>
                            !model.ComputerComponents.ContainsKey(rec.ComponentId)).ToList());
                            context.SaveChanges();
                            // обновили количество у существующих записей
                            foreach (var updateComponent in ComputerComponents)
                            {
                                updateComponent.Count =
                               model.ComputerComponents[updateComponent.ComponentId].Item2;

                                model.ComputerComponents.Remove(updateComponent.ComponentId);
                            }
                            context.SaveChanges();
                        }
                        // добавили новые
                        foreach (var pc in model.ComputerComponents)
                        {
                            context.ComputerComponents.Add(new ComputerComponent
                            {
                                ComputerId = element.Id,
                                ComponentId = pc.Key,
                                Count = pc.Value.Item2
                            });
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(ComputerBindingModel model)
        {
            using (var context = new ComputerWorkShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // удаяем записи по компонентам при удалении компьютера
                        context.ComputerComponents.RemoveRange(context.ComputerComponents.Where(rec =>
                        rec.ComputerId == model.Id));
                        Computer element = context.Computers.FirstOrDefault(rec => rec.Id
                        == model.Id);
                        if (element != null)
                        {
                            context.Computers.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public List<ComputerViewModel> Read(ComputerBindingModel model)
        {
            using (var context = new ComputerWorkShopDatabase())
            {
                return context.Computers
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
               .Select(rec => new ComputerViewModel
               {
                   Id = rec.Id,
                   ComputerName = rec.ComputerName,
                   Price = rec.Price,
                   ComputerComponents = context.ComputerComponents
                .Include(recPC => recPC.Component)
               .Where(recPC => recPC.ComputerId == rec.Id)
               .ToDictionary(recPC => recPC.ComponentId, recPC =>
                (recPC.Component?.ComponentName, recPC.Count))
               })
               .ToList();
            }
        }
    }
}