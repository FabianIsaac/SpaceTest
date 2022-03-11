using Microsoft.AspNetCore.Mvc;
using SpaceShips.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpaceShips.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipController : ControllerBase
    {
        // GET: api/<ShipController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ShipData.GetAll());
        }

        // GET api/<ShipController>/5
        [HttpGet("{id}")]
        public Ship Get(int id)
        {
            return ShipData.Show(id);
        }

        // POST api/<ShipController>
        [HttpPost]
        public Ship Post([FromBody] Ship ship)
        {
            System.Diagnostics.Debug.WriteLine(ship);
            return ShipData.Create(ship);
        }

        // PUT api/<ShipController>/5
        [HttpPut("{id}")]
        public Ship Put(int id, [FromBody] Ship ship)
        {
            return ShipData.Update(id, ship);
        }

        // DELETE api/<ShipController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return ShipData.Delete(id);
        }
    }
}
