using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using NLayerApp.DAL.Repository;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace NLayerApp.DAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController:Controller
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Doctors>))]
        [ProducesResponseType(400)]
        public IActionResult GetDoctors()
        {
            var doctors = _doctorRepository.GetDoctors();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(doctors);
        }
        [HttpGet("getById/{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Doctors>))]
        [ProducesResponseType(400)]
        public IActionResult GetDoctorById(int id)
        {
            if (!_doctorRepository.DoctorExist(id)) return NotFound();
            var doctor = _doctorRepository.GetDoctorById(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(doctor);
        }
        [HttpGet("getBySurname/{name}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Doctors>))]
        [ProducesResponseType(400)]
        public IActionResult GetDoctorsBySurname(string name)
        {
            var doctors = _doctorRepository.GetDoctorsBySurname(name);
            if (doctors == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(doctors);
        }
        [HttpGet("getByDepartment/{DepartmentName}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Doctors>))]
        [ProducesResponseType(400)]
        public IActionResult GetDoctorsByDepartment(string DepartmentName)
        {
            var doctors = _doctorRepository.GetDoctorsByDepartment(DepartmentName);
            if (doctors == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(doctors);
        }

    }
}
