using ComputerWorkShopBusinessLogic.BindingModels;
using ComputerWorkShopBusinessLogic.Interfaces;
using ComputerWorkShopBusinessLogic.ViewModels;
using ComputerWorkShopListImplement.Models;
using System;
using System.Collections.Generic;

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
                Dictionary<int, (string, int)> warehouseComponents = new Dictionary<int, (string, int)>();

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

                        warehouseComponents.Add(source.WarehouseComponents[j].Id, (componentName, source.WarehouseComponents[j].Count));                        
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
                Dictionary<int, (string, int)> warehouseComponents = new Dictionary<int, (string, int)>();

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
                        warehouseComponents.Add(source.WarehouseComponents[j].Id, (componentName, source.WarehouseComponents[j].Count));                      
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
                    throw new Exception("Уже есть склад с таким названием");
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
                    throw new Exception("Уже есть склад с таким названием");
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
                
        public void FillWarehouse(WarehouseComponentBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.WarehouseComponents.Count; i++)
            {
                if (source.WarehouseComponents[i].ComponentId == model.ComponentId &&
                    source.WarehouseComponents[i].WarehouseId == model.WarehouseId)
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
            {
                source.WarehouseComponents[index].Count += model.Count;
            }
            else
            {
                int maxId = 0;
                for (int i = 0; i < source.WarehouseComponents.Count; i++)
                {
                    if (source.WarehouseComponents[i].Id > maxId)
                    {
                        maxId = source.WarehouseComponents[i].Id;
                    }
                }
                source.WarehouseComponents.Add(new WarehouseComponent
                {
                    Id = maxId + 1,
                    WarehouseId = model.WarehouseId,
                    ComponentId = model.ComponentId,
                    Count = model.Count
                });
            }
        }
    }
}
