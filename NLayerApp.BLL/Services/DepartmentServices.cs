﻿using AutoMapper;
using NLayerApp.BLL.DTO;
using NLayerApp.BLL.Exceptions;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;

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
        public ICollection<DepartmentsDTO> GetDepartments()
        {
            var entities = _departmentRepository.GetDepartments();
            return _mapper.Map<ICollection<DepartmentsDTO>>(entities);
        }
        public DepartmentsDTO GetById(int id)
        {
            
            if (!_departmentRepository.DepartmentExist(id))
            {
                throw new NotFoundException(nameof(Departments), id);
            }
            var entity = _departmentRepository.GetDepartmentById(id);
            return _mapper.Map<DepartmentsDTO>(entity);
        }
        public DepartmentsDTO GetByName(string name)
        {
            if (!_departmentRepository.DepartmentExist(name))
            {
                throw new NotFoundException(nameof(Departments), name);
            }
            var entity = _departmentRepository.GetDepartmentByName(name);
            return _mapper.Map<DepartmentsDTO>(entity);
        }
        public DepartmentsDTO Create(DepartmentsDTO department)
        {
            if (_departmentRepository.DepartmentExist(department.Name))
            {
                throw new ArleadyExistsException(nameof(Departments), department.Name);
            }
            var entity = _mapper.Map<Departments>(department);
            _departmentRepository.CreateDepartment(entity);
            _departmentRepository.Save();
            return _mapper.Map<DepartmentsDTO>(entity);  
        }
    }
}
