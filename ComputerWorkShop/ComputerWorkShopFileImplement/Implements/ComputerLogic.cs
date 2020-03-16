using ComputerWorkShopBusinessLogic.BindingModels;
using ComputerWorkShopBusinessLogic.Interfaces;
using ComputerWorkShopBusinessLogic.ViewModels;
using ComputerWorkShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerWorkShopFileImplement.Implements
{
    public class ComputerLogic : IComputerLogic
    {
        private readonly FileDataListSingleton source;

        public ComputerLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(ComputerBindingModel model)
        {
            Computer element = source.Computers
                            .FirstOrDefault(rec => rec.ComputerName == model.ComputerName && rec.Id != model.Id);

            if (element != null)
            {
                throw new Exception("Уже есть компьютер с таким названием");
            }

            if (model.Id.HasValue)
            {
                element = source.Computers.FirstOrDefault(rec => rec.Id == model.Id);

                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Computers.Count > 0 ? source.Components.Max(rec =>
                rec.Id) : 0;
                element = new Computer { Id = maxId + 1 };
                source.Computers.Add(element);
            }

            element.ComputerName = model.ComputerName;
            element.Price = model.Price;

            source.ComputerComponents.RemoveAll(rec => rec.ComputerId == model.Id && !model.ComputerComponents.ContainsKey(rec.ComponentId));

            var updateComponents = 
                source.ComputerComponents.Where(rec => rec.ComputerId == model.Id && model.ComputerComponents.ContainsKey(rec.ComponentId));

            foreach (var updateComponent in updateComponents)
            {
                updateComponent.Count = model.ComputerComponents[updateComponent.ComponentId].Item2;
                model.ComputerComponents.Remove(updateComponent.ComponentId);
            }

            int maxPCId = source.ComputerComponents.Count > 0 ? source.ComputerComponents.Max(rec => rec.Id) : 0;

            foreach (var pc in model.ComputerComponents)
            {
                source.ComputerComponents.Add(new ComputerComponent
                {
                    Id = ++maxPCId,
                    ComputerId = element.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
        }

        public void Delete(ComputerBindingModel model)
        {

            source.ComputerComponents.RemoveAll(rec => rec.ComputerId == model.Id);
            Computer element = source.Computers.FirstOrDefault(rec => rec.Id == model.Id);

            if (element != null)
            {
                source.Computers.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public List<ComputerViewModel> Read(ComputerBindingModel model)
        {
            return source.Computers
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new ComputerViewModel
            {
                Id = rec.Id,
                ComputerName = rec.ComputerName,
                Price = rec.Price,
                ComputerComponents = source.ComputerComponents
                                    .Where(recPC => recPC.ComputerId == rec.Id)
                                    .ToDictionary(
                                        recPC => recPC.ComponentId, 
                                        recPC =>(
                                            source.Components.FirstOrDefault(recC => recC.Id == recPC.ComponentId)?.ComponentName, recPC.Count
                                            )
                                        )
            })
            .ToList();
        }
    }
}