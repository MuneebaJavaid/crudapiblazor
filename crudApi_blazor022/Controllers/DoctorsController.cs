using crudApi_blazor022.Data;
using crudApi_blazor022.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace blazor_api_task.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DoctorsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] DoctorData data)
        {
            if (data == null)
            {
                return BadRequest("Invalid data");
            }

            _context.Doctors.Add(data);
            _context.SaveChanges();

            return Ok(data);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DoctorData data)
        {
            if (data == null)
            {
                return BadRequest("Invalid data");
            }

            var existingDoctor = _context.Doctors.Find(id);
            if (existingDoctor == null)
            {
                return NotFound("Doctor not found");
            }

            // Update properties of existingDoctor with data
            existingDoctor.DocName = data.DocName;
            existingDoctor.DocExperience = data.DocExperience;

            _context.SaveChanges();
            return Ok(existingDoctor);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var doctors = _context.Doctors.ToList();
            return Ok(doctors);
        }
    }
}
