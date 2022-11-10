using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using NLayerApp.DAL.DTO;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace NLayerApp.DAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        [ProducesResponseType(200,Type=typeof(IEnumerable<Departments>))]
        public IActionResult GetDepartments()
        {
            
            var departments= _departmentRepository.GetDepartments();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(departments);
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Departments>))]
        [ProducesResponseType(400)]
        public IActionResult GetDepartmentById(int id)
        {
            if (!_departmentRepository.DepartmentExist(id)) return NotFound();
            var department = _departmentRepository.GetDepartmentById(id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(department);
        }
        
        [HttpGet("getByName/{name}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Departments>))]
        [ProducesResponseType(400)]
        public IActionResult GetDepartmentByName(string name)
        {
            var department = _departmentRepository.GetDepartmentByName(name);
            if (department==null) return NotFound();
            Console.WriteLine(department);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(department);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDepartment([FromBody] Departments departmentCreate)
        {
            if(departmentCreate==null) return BadRequest(ModelState);

            var department = _departmentRepository.GetDepartments().Where(p => p.Name.Trim().ToUpper() == departmentCreate.Name.Trim().ToUpper()).FirstOrDefault();

            if (department != null)
            {
                ModelState.AddModelError("", "Department already exists!");
                return StatusCode(422, ModelState);
            }

            if(!ModelState.IsValid) return BadRequest(ModelState);
            if(!_departmentRepository.CreateDepartment(departmentCreate))
            {
                ModelState.AddModelError("", "Smth went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created!");
        }
    }
}
