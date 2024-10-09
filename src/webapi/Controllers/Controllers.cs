using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private static List<Items> items = new List<Items>();

        public ItemsController()
        {
        }

        [HttpPost]
        public IActionResult Post([FromBody] Items newItem){
            items.Add(newItem);

            return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var forecast = items.FirstOrDefault(f => f.Id == id);
            if (forecast == null)
            {
                return NotFound();
            }
            return Ok(forecast);
        }
    }

    public class Items
    {
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
