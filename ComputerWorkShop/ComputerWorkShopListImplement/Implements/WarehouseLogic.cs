using ComputerWorkShop.ViewModels;
using ComputerWorkShopBusinessLogic.BindingModels;
using ComputerWorkShopBusinessLogic.Interfaces;
using ComputerWorkShopBusinessLogic.ViewModels;
using ComputerWorkShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerWorkShopListImplement.Implements
{
    public class WarehouseLogic : IWarehouseLogic
    {
        private readonly DataListSingleton source;

        public WarehouseLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<WarehouseViewModel> GetList()
        {
            List<WarehouseViewModel> result = new List<WarehouseViewModel>();

            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                List<WarehouseComponentViewModel> warehouseComponents = new List<WarehouseComponentViewModel>();

                for (int j = 0; j < source.WarehouseComponents.Count; ++j)
                {
                    if (source.WarehouseComponents[j].WarehouseId == source.Warehouses[i].Id)
                    {
                        string componentName = string.Empty;

                        for (int k = 0; k < source.Components.Count; ++k)
                        {
                            if (source.WarehouseComponents[j].ComponentId == source.Components[k].Id)
                            {
                                componentName = source.Components[k].ComponentName;
                                break;
                            }
                        }
                        warehouseComponents.Add(new WarehouseComponentViewModel
                        {
                            Id = source.WarehouseComponents[j].Id,
                            WarehouseId = source.WarehouseComponents[j].WarehouseId,
                            ComponentId = source.WarehouseComponents[j].ComponentId,
                            ComponentName = componentName,
                            Count = source.WarehouseComponents[j].Count
                        });
                    }
                }

                result.Add(new WarehouseViewModel
                {
                    Id = source.Warehouses[i].Id,
                    WarehouseName = source.Warehouses[i].WarehouseName,
                    WarehouseComponents = warehouseComponents
                });
            }
            return result;
        }

        public WarehouseViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                List<WarehouseComponentViewModel> warehouseComponents = new List<WarehouseComponentViewModel>();

                for (int j = 0; j < source.WarehouseComponents.Count; ++j)
                {
                    if (source.WarehouseComponents[j].WarehouseId == source.Warehouses[i].Id)
                    {
                        string componentName = string.Empty;

                        for (int k = 0; k < source.Components.Count; ++k)
                        {
                            if (source.WarehouseComponents[j].ComponentId == source.Components[k].Id)
                            {
                                componentName = source.Components[k].ComponentName;
                                break;
                            }
                        }

                        warehouseComponents.Add(new WarehouseComponentViewModel
                        {
                            Id = source.WarehouseComponents[j].Id,
                            WarehouseId = source.WarehouseComponents[j].WarehouseId,
                            ComponentId = source.WarehouseComponents[j].ComponentId,
                            ComponentName = componentName,
                            Count = source.WarehouseComponents[j].Count
                        });
                    }
                }

                if (source.Warehouses[i].Id == id)
                {
                    return new WarehouseViewModel
                    {
                        Id = source.Warehouses[i].Id,
                        WarehouseName = source.Warehouses[i].WarehouseName,
                        WarehouseComponents = warehouseComponents
                    };
                }
            }

            throw new Exception("Элемент не найден");
        }

        public void AddElement(WarehouseBindingModel model)
        {
            int maxId = 0;

            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                if (source.Warehouses[i].Id > maxId)
                {
                    maxId = source.Warehouses[i].Id;
                }

                if (source.Warehouses[i].WarehouseName == model.WarehouseName)
                {
                    throw new Exception("Склад с таким названием уже существует");
                }
            }
            source.Warehouses.Add(new Warehouse
            {
                Id = maxId + 1,
                WarehouseName = model.WarehouseName
            });
        }

        public void UpdElement(WarehouseBindingModel model)
        {
            int index = -1;

            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                if (source.Warehouses[i].Id == model.Id)
                {
                    index = i;
                }

                if (source.Warehouses[i].WarehouseName == model.WarehouseName && source.Warehouses[i].Id != model.Id)
                {
                    throw new Exception("Склад с таким названием уже существует");
                }
            }

            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }

            source.Warehouses[index].WarehouseName = model.WarehouseName;
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.WarehouseComponents.Count; ++i)
            {
                if (source.WarehouseComponents[i].WarehouseId == id)
                {
                    source.WarehouseComponents.RemoveAt(i--);
                }
            }

            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                if (source.Warehouses[i].Id == id)
                {
                    source.Warehouses.RemoveAt(i);
                    return;
                }
            }

            throw new Exception("Элемент не найден");
        }

        public void AddComponent(WarehouseComponentBindingModel model)
        {
            for (int i = 0; i < source.WarehouseComponents.Count; ++i)
            {
                if (source.WarehouseComponents[i].WarehouseId == model.WarehouseId &&
                    source.WarehouseComponents[i].ComponentId == model.ComponentId)
                {
                    source.WarehouseComponents[i].Count += model.Count;
                    model.Id = source.WarehouseComponents[i].Id;
                    return;
                }
            }

            int maxWCId = 0;

            for (int i = 0; i < source.WarehouseComponents.Count; ++i)
            {
                if (source.WarehouseComponents[i].Id > maxWCId)
                {
                    maxWCId = source.WarehouseComponents[i].Id;
                }
            }

            if (model.Id == 0)
            {
                source.WarehouseComponents.Add(new WarehouseComponent
                {
                    Id = ++maxWCId,
                    WarehouseId = model.WarehouseId,
                    ComponentId = model.ComponentId,
                    Count = model.Count
                });
            }
        }
        public bool CheckAvailable(int ComputerId, int Count)
        {
            var ComputerComponents = source.ComputerComponents
              .Where(x => x.ComputerId == ComputerId);
            if (ComputerComponents.Count() == 0)
                return false;
            foreach (var elem in ComputerComponents)
            {
                int count = 0;
                var warehouseComponents = source.WarehouseComponents.FindAll(x => x.ComponentId == elem.ComponentId);
                count = warehouseComponents.Sum(x => x.Count);
                if (count < elem.Count * Count)
                    return false;
            }
            return true;
        }

        public void DeleteFromWarehouse(int ComputerId, int Count)
        {
            var ComputerComponents = source.ComputerComponents.Where(x => x.ComputerId == ComputerId);
            if (ComputerComponents.Count() == 0) return;
            foreach (var elem in ComputerComponents)
            {
                int left = elem.Count * Count;
                var warehouseComponents = source.ComputerComponents.FindAll(x => x.ComponentId == elem.ComponentId);
                foreach (var rec in warehouseComponents)
                {
                    int toRemove = left > rec.Count ? rec.Count : left;
                    rec.Count -= toRemove;
                    left -= toRemove;
                    if (left == 0) break;
                }
            }
            return;
        }
    }
}
