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

        public void CreateOrUpdate(WarehouseBindingModel warehouse)
        {
            Warehouse tempWarehouse = warehouse.Id.HasValue ? null : new Warehouse
            {
                Id = 1
            };
            foreach (var s in source.Warehouses)
            {
                if (s.WarehouseName == warehouse.WarehouseName && s.Id != warehouse.Id)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
                if (!warehouse.Id.HasValue && s.Id >= tempWarehouse.Id)
                {
                    tempWarehouse.Id = s.Id + 1;
                }
                else if (warehouse.Id.HasValue && s.Id == warehouse.Id)
                {
                    tempWarehouse = s;
                }
            }
            if (warehouse.Id.HasValue)
            {
                if (tempWarehouse == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(warehouse, tempWarehouse);
            }
            else
            {
                source.Warehouses.Add(CreateModel(warehouse, tempWarehouse));
            }
        }

        public void Delete(WarehouseBindingModel model)
        {
            // удаляем записи по компонентам при удалении хранилища
            for (int i = 0; i < source.WarehouseComponents.Count; ++i)
            {
                if (source.WarehouseComponents[i].WarehouseId == model.Id)
                {
                    source.WarehouseComponents.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                if (source.Warehouses[i].Id == model.Id)
                {
                    source.Warehouses.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<WarehouseViewModel> Read(WarehouseBindingModel model)
        {
            List<WarehouseViewModel> result = new List<WarehouseViewModel>();
            foreach (var warehouse in source.Warehouses)
            {
                if (model != null)
                {
                    if (warehouse.Id == model.Id)
                    {
                        result.Add(CreateViewModel(warehouse));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(warehouse));
            }
            return result;
        }

        private Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse)
        {
            warehouse.WarehouseName = model.WarehouseName;
            //обновляем существуюущие компоненты и ищем максимальный идентификатор
            int maxSMId = 0;
            for (int i = 0; i < source.WarehouseComponents.Count; ++i)
            {
                if (source.WarehouseComponents[i].Id > maxSMId)
                {
                    maxSMId = source.WarehouseComponents[i].Id;
                }
                if (source.WarehouseComponents[i].WarehouseId == warehouse.Id)
                {
                    // если в модели пришла запись компонента с таким id
                    if (model.WarehouseComponents.ContainsKey(source.WarehouseComponents[i].ComponentId))
                    {
                        // обновляем количество
                        source.WarehouseComponents[i].Count = model.WarehouseComponents[source.WarehouseComponents[i].ComponentId].Item2;
                        // из модели убираем эту запись, чтобы остались только не
                        //просмотренные
                        model.WarehouseComponents.Remove(source.WarehouseComponents[i].ComponentId);
                    }
                    else
                    {
                        source.WarehouseComponents.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            foreach (var sm in model.WarehouseComponents)
            {
                source.WarehouseComponents.Add(new WarehouseComponent
                {
                    Id = ++maxSMId,
                    WarehouseId = warehouse.Id,
                    ComponentId = sm.Key,
                    Count = sm.Value.Item2
                });
            }
            return warehouse;
        }

        private WarehouseViewModel CreateViewModel(Warehouse warehouse)
        {
            // требуется дополнительно получить список компонентов для хранилища с
            // названиями и их количество
            Dictionary<int, (string, int)> warehouseComponents = new Dictionary<int, (string, int)>();
            foreach (var sm in source.WarehouseComponents)
            {
                if (sm.WarehouseId == warehouse.Id)
                {
                    string componentName = string.Empty;
                    foreach (var component in source.Components)
                    {
                        if (sm.ComponentId == component.Id)
                        {
                            componentName = component.ComponentName;
                            break;
                        }
                    }
                    warehouseComponents.Add(sm.ComponentId, (componentName, sm.Count));
                }
            }
            return new WarehouseViewModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                WarehouseComponents = warehouseComponents
            };
        }
        public void AddComponentToWarehouse(WarehouseComponentBindingModel model)
        {
            // если склад пустой, то добавляем первый компонент с id = 1
            if (source.WarehouseComponents.Count == 0)
            {
                source.WarehouseComponents.Add(new WarehouseComponent()
                {
                    Id = 1,
                    ComponentId = model.ComponentId,
                    WarehouseId = model.WarehouseId,
                    Count = model.Count
                });
            }
            // проверяем, есть ли на складе нужный компонент
            else
            {
                var component = source.WarehouseComponents.FirstOrDefault(wc => wc.WarehouseId == model.WarehouseId && wc.ComponentId == model.ComponentId);
                // если нет, то добавляем
                if (component == null)
                {
                    source.WarehouseComponents.Add(new WarehouseComponent()
                    {
                        Id = source.WarehouseComponents.Max(sm => sm.Id) + 1,
                        ComponentId = model.ComponentId,
                        WarehouseId = model.WarehouseId,
                        Count = model.Count
                    });
                }
                // если есть, то увеличиваем количество
                else
                    component.Count += model.Count;
            }
        }
    }
}
