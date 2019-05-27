using Microsoft.AspNetCore.Mvc;
using Micro.Api.Models;
using Micro.Api.Repositories;
using RawRabbit;
using System;
using System.Threading.Tasks;

namespace Micro.Api.Controllers
{
    [Route("")]
    public class ItemsController : Controller
    {
        private readonly IBusClient _busClient;
        private readonly IItemRepository _repository;

        public ItemsController(IBusClient busClient, IItemRepository repository)
        {
            _busClient = busClient;
            _repository = repository;
        }

        [HttpPost("save")]
        public async Task<IActionResult> Post([FromBody] RequestItem model)
        {
            var command = new Micro.Common.Commands.xItem();
            command.Id = Guid.NewGuid();
            command.Item = model.Item;
            await _busClient.PublishAsync(command);
            return Accepted($"save/{command.Id}");
        }

        [HttpGet("status/{item}")]
        public async Task<IActionResult> Get(string item)
        {
            var xItem = await _repository.GetAsync(item);
            if (xItem == null)
            {
                return NotFound();
            }
            if(xItem.Status == "locked")
            {
                return BadRequest();
            }
            return Json(new { xItem.Item, xItem.Status, xItem.Count });
        }
    }
}