using AutoMapper;
using DutchTreat.Data;
using DutchTreat.Data.Entities;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    [Route("api/[Controller]")]
    public class OrdersController : Controller
    {
        private readonly IDutchRepository repository;
        private readonly ILogger logger;
        private readonly IMapper mapper;

        public OrdersController(IDutchRepository repository, ILogger<DutchRepository> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(bool includeItems = true)
        {
            try
            {
                var results = repository.GetAllOrders(includeItems);    //bool added to allow includeItems to be modified in querystring.

                return Ok(mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>> (results));
            }
            catch(Exception ex)
            {
                logger.LogError($"Failed to get orders: {ex}");
                return BadRequest("Failed to get orders");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            {
                try
                {
                    var order = repository.GetOrderById(id);

                    if (order != null) return Ok(mapper.Map<Order, OrderViewModel>(order));
                    else return NotFound();
                }
                catch (Exception ex)
                {
                    logger.LogError($"Failed to get orders: {ex}");
                    return BadRequest("Failed to get orders");
                }
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]OrderViewModel model)
        {
            try
            {
                // Ensure model state is valid.
                if (ModelState.IsValid)
                {
                    // Creater map the ViewModel back to an Order.
                    var newOrder = mapper.Map<OrderViewModel, Order>(model);
                    
                    // Validate that the orderdate isn't the standard regular date.
                    if (newOrder.OrderDate == DateTime.MinValue)
                    {
                        newOrder.OrderDate = DateTime.Now;
                    }

                    // Add the newOrder object into the database.
                    repository.AddEntity(newOrder);
                    // return a 201 response if it successfully saves to database.
                    if (repository.SaveAll())
                    {
                        // convert Order back to ViewModel to be returned. Also generate custom URI.
                        return Created($"/api/orders/{newOrder.Id}", mapper.Map<Order, OrderViewModel>(newOrder));
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch(Exception ex)
            {
                logger.LogError($"Failed to save a new order: {ex}");
            }

            return BadRequest("Failed to save new order");
        }
                
    }
}
