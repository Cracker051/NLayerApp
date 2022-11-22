﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using NLayerApp.BLL.Exceptions;
using NLayerApp.BLL.Services;
using NLayerApp.BLL.DTO;
using NLayerApp.DAL.Entities;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace NLayerApp.DAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : Controller
    {
        private readonly IDoctorServices _doctorServices;

        public DoctorController(IDoctorServices doctorServices)
        {
            _doctorServices = doctorServices;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Doctors>))]
        [ProducesResponseType(400)]
        public IActionResult GetDoctors()
        {
            return Ok(_doctorServices.GetDoctors());
        }
        [HttpGet("getById/{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Doctors>))]
        [ProducesResponseType(400)]
        public IActionResult GetDoctorById(int id)
        {
            try
            {
                return Ok(_doctorServices.GetDoctorById(id));
            }
            catch(NotFoundException ex)
            {
                return NotFound();
            }
        }
        [HttpGet("getBySurname/{surname}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Doctors>))]
        [ProducesResponseType(400)]
        public IActionResult GetDoctorsBySurname(string surname)
        {
            try
            {
                var entities = _doctorServices.GetDoctorsBySurname(surname);
                return Ok(entities);
            }
            catch(NotFoundException ex)
            {
                return NotFound();
            }
        }
        [HttpGet("getByDepartment/{departmentName}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Doctors>))]
        [ProducesResponseType(400)]
        public IActionResult GetDoctorsByDepartment(string departmentName)
        {
            try
            {
                var entities = _doctorServices.GetDoctorsByDepartment(departmentName);
                return Ok(entities);
            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDoctor([FromBody] DoctorsDTO doctor)
        {
            try
            {
                return Ok(_doctorServices.CreateDoctor(doctor));
            }
            catch (NotFoundException ex)
            {
                ModelState.AddModelError("", "Department doesnt exist!");
                return NotFound(ModelState);
            }
        }

    }
}
