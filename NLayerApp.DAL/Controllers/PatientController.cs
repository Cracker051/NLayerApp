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
    public class PatientController:Controller
    {
        private readonly IPatientRepository _patientRepository;
        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Patients>))]
        [ProducesResponseType(400)]
        public IActionResult GetPatients()
        {
            var patients = _patientRepository.GetPatients();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(patients);
        }
        [HttpGet("getPatientById/{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Patients>))]
        [ProducesResponseType(400)]
        public IActionResult GetPatientById(int id)
        {
            if (!_patientRepository.PatientExist(id)) return NotFound();
            var patient=_patientRepository.GetPatientById(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(patient);
        }
        [HttpGet("getPatientBySurname/{surname}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Patients>))]
        [ProducesResponseType(400)]
        public IActionResult GetPatientsBySurname(string surname)
        {
            var patient = _patientRepository.GetPatientsBySurname(surname);
            if(patient==null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(patient);
        }
        [HttpGet("getPatientByDiagnosis/{diagnosis}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Patients>))]
        [ProducesResponseType(400)]
        public IActionResult GetPatientsByDiagnosis(string diagnosis)
        {
            var patient = _patientRepository.GetPatientsByDiagnosis(diagnosis);
            if (patient == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(patient);
        }
    }
}
