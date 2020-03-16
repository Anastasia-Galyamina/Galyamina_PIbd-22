using ComputerWorkShopBusinessLogic.BindingModels;
using ComputerWorkShopBusinessLogic.Interfaces;
using ComputerWorkShopBusinessLogic.ViewModels;
using ComputerWorkShopListImplement.Models;
using System;
using System.Collections.Generic;

namespace ComputerWorkShopListImplement.Implements
{
    public class ComputerLogic : IComputerLogic
    {
        private readonly DataListSingleton source;
        public ComputerLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(ComputerBindingModel model)
        {
            Computer tempComputer = model.Id.HasValue ? null : new Computer { Id = 1 };
            foreach (var computer in source.Computers)
            {
                if (computer.ComputerName == model.ComputerName && computer.Id != model.Id)
                {
                    throw new Exception("Уже есть компьютер с таким названием");
                }
                if (!model.Id.HasValue && computer.Id >= tempComputer.Id)
                {
                    tempComputer.Id = computer.Id + 1;
                }
                else if (model.Id.HasValue && computer.Id == model.Id)
                {
                    tempComputer = computer;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempComputer == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempComputer);
            }
            else
            {
                source.Computers.Add(CreateModel(model, tempComputer));
            }
        }
        public void Delete(ComputerBindingModel model)
        {
            // удаляем записи по компонентам при удалении компьютера
            for (int i = 0; i < source.ComputerComponents.Count; ++i)
            {
                if (source.ComputerComponents[i].ComputerId == model.Id)
                {
                    source.ComputerComponents.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Computers.Count; ++i)
            {
                if (source.Computers[i].Id == model.Id)
                {
                    source.Computers.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Computer CreateModel(ComputerBindingModel model, Computer computer)
        {
            computer.ComputerName = model.ComputerName;
            computer.Price = model.Price;
            //обновляем существуюущие компоненты и ищем максимальный идентификатор
            int maxPCId = 0;
            for (int i = 0; i < source.ComputerComponents.Count; ++i)
            {
                if (source.ComputerComponents[i].Id > maxPCId)
                {
                    maxPCId = source.ComputerComponents[i].Id;
                }
                if (source.ComputerComponents[i].ComputerId == computer.Id)
                {
                    // если в модели пришла запись компонента с таким id
                    if
                    (model.ComputerComponents.ContainsKey(source.ComputerComponents[i].ComponentId))
                    {
                        // обновляем количество
                        source.ComputerComponents[i].Count =
                        model.ComputerComponents[source.ComputerComponents[i].ComponentId].Item2;
                        // из модели убираем эту запись, чтобы остались только не  просмотренные
                        model.ComputerComponents.Remove(source.ComputerComponents[i].ComponentId);
                    }
                    else
                    {
                        source.ComputerComponents.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            foreach (var pc in model.ComputerComponents)
            {
                source.ComputerComponents.Add(new ComputerComponent
                {
                    Id = ++maxPCId,
                    ComputerId = computer.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
            return computer;
        }
        public List<ComputerViewModel> Read(ComputerBindingModel model)
        {
            List<ComputerViewModel> result = new List<ComputerViewModel>();
            foreach (var component in source.Computers)
            {
                if (model != null)
                {
                    if (component.Id == model.Id)
                    {
                        result.Add(CreateViewModel(component));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(component));
            }
            return result;
        }
        private ComputerViewModel CreateViewModel(Computer computer)
        {
            // требуется дополнительно получить список компонентов для компьютера с названиями и их количество
            Dictionary<int, (string, int)> computerComponents = new Dictionary<int,(string, int)>();
            foreach (var pc in source.ComputerComponents)
            {
                if (pc.ComputerId == computer.Id)
                {
                    string componentName = string.Empty;
                    foreach (var component in source.Components)
                    {
                        if (pc.ComponentId == component.Id)
                        {
                            componentName = component.ComponentName;
                            break;
                        }
                    }
                    computerComponents.Add(pc.ComponentId, (componentName, pc.Count));
                }
            }
            return new ComputerViewModel
            {
                Id = computer.Id,  
                ComputerName = computer.ComputerName,
                Price = computer.Price,
                ComputerComponents = computerComponents
            };
        }

    }
}