﻿using NLayerApp.DAL.Entities;

namespace NLayerApp.DAL.Interfaces
{
    public interface IDepartmentRepository
    {
        ICollection<Departments> GetDepartments();
        Departments GetDepartmentById(int id);
        Departments GetDepartmentByName(string name);
        bool DepartmentExist(int departmentId);
        bool DepartmentExist(string departmentName);
        void CreateDepartment(Departments department);
        bool Save();
    }
}
