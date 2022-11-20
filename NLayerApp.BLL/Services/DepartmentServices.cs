using AutoMapper;
using NLayerApp.BLL.DTO;
using NLayerApp.BLL.Exceptions;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.BLL.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentServices(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public DepartmentsDTO GetById(int id)
        {
            var entity = _departmentRepository.GetDepartmentById(id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Departments), id);
            }
            return _mapper.Map<DepartmentsDTO>(entity);
        }
        public DepartmentsDTO Create(DepartmentsDTO department)
        {
            var entity = _mapper.Map<Departments>(department);
            _departmentRepository.CreateDepartment(entity);
            _departmentRepository.Save();
            return _mapper.Map<DepartmentsDTO>(entity);
        }
    }
}
