using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarChart.Data;

namespace StarChart.Controllers
{
    [Route("")]
    [ApiController]
    public class CelestialObjectController:ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CelestialObjectController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id:int}", Name ="GetById")]
        public IActionResult GetById(int Id)
        {
            var celestralObject = _context.CelestialObjects.Find(id);
            if (celestralObject == null)
                return NotFound();
            celestralObject.Satellites = _context.CelestialObjects.Where(e => e.OrbitedObjectId == id).ToList();
            return Ok(celestralObject);
        }
         [HttpGet("{name}"})]
          public IActionResult GetByName(string name)
           {
        var celestialObjects = _context.CelestialObjects.Where(e => e.Name == name).ToList();
           }
    }
}
