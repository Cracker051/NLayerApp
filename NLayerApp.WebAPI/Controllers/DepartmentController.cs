using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using NLayerApp.BLL.Exceptions;
using NLayerApp.BLL.Services;
using NLayerApp.BLL.DTO;
using NLayerApp.DAL.Entities;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using System.Net;

namespace NLayerApp.DAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _departmentService;

        public DepartmentController(IDepartmentServices departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Departments>))]
        public IActionResult GetDepartments()
        {
            return Ok(_departmentService.GetDepartments());
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Departments>))]
        [ProducesResponseType(400)]
        public IActionResult GetDepartmentById(int id)
        {
            try {
                return Ok(_departmentService.GetById(id));
            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }
        }

        [HttpGet("getByName/{name}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Departments>))]
        [ProducesResponseType(400)]
        public IActionResult GetDepartmentByName(string name)
        {
            try
            {
                return Ok(_departmentService.GetByName(name));
            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDepartment([FromBody] DepartmentsDTO departmentCreate)
        {
            try
            {
                return Ok(_departmentService.Create(departmentCreate));
            }
            catch (ArleadyExistsException ex)
            {
                ModelState.AddModelError("", "Department already exists!");
                return StatusCode(422, ModelState);
            }
        }

        [HttpPut("{departmentId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateDepartment(int departmentId,[FromBody] DepartmentsDTO department)
        {
            try
            {
                return Ok(_departmentService.Update(departmentId, department));
            }
            catch(ArgumentException ex)
            {
                    ModelState.AddModelError("", ex.Message);
                    return BadRequest(ModelState);
            }
            catch(NotFoundException ex)
            {
                ModelState.AddModelError("", "Department with this id doesnt exists!");
                return BadRequest(ModelState);
            }
            catch(ModelErrorException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

    }
}
