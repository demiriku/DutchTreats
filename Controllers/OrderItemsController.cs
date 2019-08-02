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
    [Route("/api/orders/{orderid}/items")]
    public class OrderItemsController : Controller
    {
        private readonly IDutchRepository repository;
        private readonly ILogger logger;
        private readonly IMapper mapper;

        public OrderItemsController(IDutchRepository repository, ILogger<DutchRepository> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int orderId)
        {
            try
            {
                var order = repository.GetOrderById(orderId);
                if (order != null) return Ok(mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemViewModel>>(order.Items));
                return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get Order: {ex}");
                return BadRequest("Failed to get Order. ");
            }

        }

        [HttpGet("{id}")]
        public IActionResult Get(int orderId, int id)
        {


            try
            {
                var order = repository.GetOrderById(orderId);
                if (order != null)
                {
                    var item = order.Items.Where(i => i.Id == id).FirstOrDefault();
                    if (item != null)
                    {
                        return Ok(mapper.Map<OrderItem, OrderItemViewModel>(item));
                    }
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError($"Order was not found: {ex}");
                return BadRequest("Order was not found.");
            }

        }
        [HttpPost]
        public IActionResult Post(int orderId, [FromBody]OrderItemViewModel model)
        {
            try
            {
                // Ensure model state is valid.
                if (ModelState.IsValid)
                {
                    // Creater map the ViewModel back to an OrderItem.
                    var newOrderItem = mapper.Map<OrderItemViewModel, OrderItem>(model);

                    // Add the newOrderItem object into the database.
                    repository.AddEntity(newOrderItem);
                    // return a 201 response if it successfully saves to database.
                    if (repository.SaveAll())
                    {
                        // convert Order back to ViewModel to be returned. Also generate custom URI.
                        return Created($"/api/orders/{orderId}/items/{newOrderItem.Id}", mapper.Map<OrderItem, OrderItemViewModel>(newOrderItem));
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to save a new order: {ex}");
            }

            return BadRequest("Failed to save new order");
        }

    }
}

