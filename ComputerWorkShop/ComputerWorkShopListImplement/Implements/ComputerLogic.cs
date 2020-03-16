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

        public List<ComputerViewModel> GetList()
        {
            List<ComputerViewModel> result = new List<ComputerViewModel>();

            for (int i = 0; i < source.Computers.Count; ++i)
            {
                List<ComputerComponentViewModel> ComputerComponents = new List<ComputerComponentViewModel>();

                for (int j = 0; j < source.ComputerComponents.Count; ++j)
                {
                    if (source.ComputerComponents[j].ComputerId == source.Computers[i].Id)
                    {
                        string componentName = string.Empty;

                        for (int k = 0; k < source.Components.Count; ++k)
                        {
                            if (source.ComputerComponents[j].ComponentId == source.Components[k].Id)
                            {
                                componentName = source.Components[k].ComponentName;
                                break;
                            }
                        }

                        ComputerComponents.Add(new ComputerComponentViewModel
                        {
                            Id = source.ComputerComponents[j].Id,
                            ComputerId = source.ComputerComponents[j].ComputerId,
                            ComponentId = source.ComputerComponents[j].ComponentId,
                            ComponentName = componentName,
                            Count = source.ComputerComponents[j].Count
                        });
                    }
                }

                result.Add(new ComputerViewModel
                {
                    Id = source.Computers[i].Id,
                    ComputerName = source.Computers[i].ComputerName,
                    Price = source.Computers[i].Price,
                    ComputerComponents = ComputerComponents
                });
            }

            return result;
        }

        public ComputerViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Computers.Count; ++i)
            {
                List<ComputerComponentViewModel> ComputerComponents = new List<ComputerComponentViewModel>();

                for (int j = 0; j < source.ComputerComponents.Count; ++j)
                {
                    if (source.ComputerComponents[j].ComputerId == source.Computers[i].Id)
                    {
                        string componentName = string.Empty;

                        for (int k = 0; k < source.Components.Count; ++k)
                        {
                            if (source.ComputerComponents[j].ComponentId == source.Components[k].Id)
                            {
                                componentName = source.Components[k].ComponentName;
                                break;
                            }
                        }

                        ComputerComponents.Add(new ComputerComponentViewModel
                        {
                            Id = source.ComputerComponents[j].Id,
                            ComputerId = source.ComputerComponents[j].ComputerId,
                            ComponentId = source.ComputerComponents[j].ComponentId,
                            ComponentName = componentName,
                            Count = source.ComputerComponents[j].Count
                        });
                    }
                }

                if (source.Computers[i].Id == id)
                {
                    return new ComputerViewModel
                    {
                        Id = source.Computers[i].Id,
                        ComputerName = source.Computers[i].ComputerName,
                        Price = source.Computers[i].Price,
                        ComputerComponents = ComputerComponents
                    };
                }
            }

            throw new Exception("Элемент не найден");
        }

        public void AddElement(ComputerBindingModel model)
        {
            int maxId = 0;

            for (int i = 0; i < source.Computers.Count; ++i)
            {
                if (source.Computers[i].Id > maxId)
                {
                    maxId = source.Computers[i].Id;
                }

                if (source.Computers[i].ComputerName == model.ComputerName)
                {
                    throw new Exception("Уже есть компьютер с таким названием");
                }
            }

            source.Computers.Add(new Computer
            {
                Id = maxId + 1,
                ComputerName = model.ComputerName,
                Price = model.Price
            });

            int maxPCId = 0;

            for (int i = 0; i < source.ComputerComponents.Count; ++i)
            {
                if (source.ComputerComponents[i].Id > maxPCId)
                {
                    maxPCId = source.ComputerComponents[i].Id;
                }
            }

            for (int i = 0; i < model.ComputerComponents.Count; ++i)
            {
                for (int j = 1; j < model.ComputerComponents.Count; ++j)
                {
                    if (model.ComputerComponents[i].ComponentId == model.ComputerComponents[j].ComponentId)
                    {
                        model.ComputerComponents[i].Count += model.ComputerComponents[j].Count;
                        model.ComputerComponents.RemoveAt(j--);
                    }
                }
            }

            for (int i = 0; i < model.ComputerComponents.Count; ++i)
            {
                source.ComputerComponents.Add(new ComputerComponent
                {
                    Id = ++maxPCId,
                    ComputerId = maxId + 1,
                    ComponentId = model.ComputerComponents[i].ComponentId,
                    Count = model.ComputerComponents[i].Count
                });
            }
        }

        public void UpdElement(ComputerBindingModel model)
        {
            int index = -1;

            for (int i = 0; i < source.Computers.Count; ++i)
            {
                if (source.Computers[i].Id == model.Id)
                {
                    index = i;
                }

                if (source.Computers[i].ComputerName == model.ComputerName && source.Computers[i].Id != model.Id)
                {
                    throw new Exception("Уже есть компьютер с таким названием");
                }
            }

            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }

            source.Computers[index].ComputerName = model.ComputerName;
            source.Computers[index].Price = model.Price;

            int maxPCId = 0;

            for (int i = 0; i < source.ComputerComponents.Count; ++i)
            {
                if (source.ComputerComponents[i].Id > maxPCId)
                {
                    maxPCId = source.ComputerComponents[i].Id;
                }
            }

            for (int i = 0; i < source.ComputerComponents.Count; ++i)
            {
                if (source.ComputerComponents[i].ComputerId == model.Id)
                {
                    bool flag = true;

                    for (int j = 0; j < model.ComputerComponents.Count; ++j)
                    {

                        if (source.ComputerComponents[i].Id == model.ComputerComponents[j].Id)
                        {
                            source.ComputerComponents[i].Count =
                            model.ComputerComponents[j].Count;
                            flag = false;
                            break;
                        }
                    }

                    if (flag)
                    {
                        source.ComputerComponents.RemoveAt(i--);
                    }
                }
            }

            for (int i = 0; i < model.ComputerComponents.Count; ++i)
            {
                if (model.ComputerComponents[i].Id == 0)
                {
                    for (int j = 0; j < source.ComputerComponents.Count; ++j)
                    {
                        if (source.ComputerComponents[j].ComputerId == model.Id &&
                            source.ComputerComponents[j].ComponentId == model.ComputerComponents[i].ComponentId)
                        {
                            source.ComputerComponents[j].Count += model.ComputerComponents[i].Count;
                            model.ComputerComponents[i].Id = source.ComputerComponents[j].Id;
                            break;
                        }
                    }

                    if (model.ComputerComponents[i].Id == 0)
                    {
                        source.ComputerComponents.Add(new ComputerComponent
                        {
                            Id = ++maxPCId,
                            ComputerId = model.Id,
                            ComponentId = model.ComputerComponents[i].ComponentId,
                            Count = model.ComputerComponents[i].Count
                        });
                    }
                }
            }
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.ComputerComponents.Count; ++i)
            {
                if (source.ComputerComponents[i].ComputerId == id)
                {
                    source.ComputerComponents.RemoveAt(i--);
                }
            }

            for (int i = 0; i < source.Computers.Count; ++i)
            {
                if (source.Computers[i].Id == id)
                {
                    source.Computers.RemoveAt(i);
                    return;
                }
            }

            throw new Exception("Элемент не найден");
        }
    }
}