using Code_FirstAssignment.DTO;
using Code_FirstAssignment.Mappings;
using Code_FirstAssignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Code_FirstAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalsController : ControllerBase
    {
        private readonly MyContext _context;

        public HospitalsController(MyContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<HospitalDTO>>> GetHospitals()
        {
            List<Hospital> hospitals = _context.Hospitals.ToList();
            if (hospitals != null)
            {
                List<HospitalDTO> hospitalDTOs = hospitals.ToDTOList();
                return hospitalDTOs;
            }
            else
            {
                return NotFound();
            }
        }


    }
}
