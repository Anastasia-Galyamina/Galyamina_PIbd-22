using ComputerRestApi.Models;
using ComputerWorkShopBusinessLogic.BindingModels;
using ComputerWorkShopBusinessLogic.BusinessLogic;
using ComputerWorkShopBusinessLogic.Interfaces;
using ComputerWorkShopBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ComputerRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly IComputerLogic _computer;
        private readonly MainLogic _main;
        public MainController(IOrderLogic order, IComputerLogic computer, MainLogic main)
        {
            _order = order;
            _computer = computer;
            _main = main;
        }
        [HttpGet]
        public List<ComputerModel> GetComputerList() => _computer.Read(null)?.Select(rec =>
       Convert(rec)).ToList();
        [HttpGet]
        public ComputerModel GetComputer(int computerId) => Convert(_computer.Read(new
       ComputerBindingModel
        { Id = computerId })?[0]);
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new
       OrderBindingModel
        { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
       _main.CreateOrder(model);
        private ComputerModel Convert(ComputerViewModel model)
        {
            if (model == null) return null;
            return new ComputerModel
            {
                Id = model.Id,
                ComputerName = model.ComputerName,
                Price = model.Price
            };
        }
    }
}
