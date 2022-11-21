using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using NLayerApp.BLL.Exceptions;
using NLayerApp.BLL.Services;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

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
            try{
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

        //[HttpPost]
        //[ProducesResponseType(204)]
        //[ProducesResponseType(400)]
        //public IActionResult CreateDepartment([FromBody] Departments departmentCreate)
        //{
        //    if (departmentCreate == null) return BadRequest(ModelState);

        //    var department = _departmentRepository.GetDepartments().Where(p => p.Name.Trim().ToUpper() == departmentCreate.Name.Trim().ToUpper()).FirstOrDefault();

        //    if (department != null)
        //    {
        //        ModelState.AddModelError("", "Department already exists!");
        //        return StatusCode(422, ModelState);
        //    }

        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    if (!_departmentRepository.CreateDepartment(departmentCreate))
        //    {
        //        ModelState.AddModelError("", "Smth went wrong while saving");
        //        return StatusCode(500, ModelState);
        //    }
        //    return Ok("Successfully created!");
        //}
    }
}
