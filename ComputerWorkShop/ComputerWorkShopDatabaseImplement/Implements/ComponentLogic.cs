using ComputerWorkShopBusinessLogic.BindingModels;
using ComputerWorkShopBusinessLogic.Interfaces;
using ComputerWorkShopBusinessLogic.ViewModels;
using ComputerWorkShopDatabaseImplement;
using ComputerWorkShopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerWorkShopImplement.Implements
{
    public class ComponentLogic : IComponentLogic
    {
        public void CreateOrUpdate(ComponentBindingModel model)
        {
            using (var context = new RepairDatabase())
            {
                Component element = context.Materials.FirstOrDefault(rec =>
               rec.MaterialName == model.MaterialName && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть продукт с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Materials.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Component();
                    context.Materials.Add(element);
                }
                element.MaterialName = model.MaterialName;
                context.SaveChanges();
            }
        }
        public void Delete(MaterialBindingModel model)
        {
            using (var context = new RepairDatabase())
            {
                Component element = context.Materials.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Materials.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<MaterialViewModel> Read(MaterialBindingModel model)
        {
            using (var context = new RepairDatabase())
            {
                return context.Materials
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new MaterialViewModel
                {
                    Id = rec.Id,
                    MaterialName = rec.MaterialName
                })
                .ToList();
            }
        }
    }}