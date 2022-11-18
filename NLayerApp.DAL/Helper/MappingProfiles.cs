using System;
using AutoMapper;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.DTO;
namespace NLayerApp.DAL.Helper
{
	public class MappingProfiles:Profile
	{
		public MappingProfiles()
		{
			CreateMap<Departments, DepartmentsDTO>();
            CreateMap<Doctors, DoctorsDTO>();
            CreateMap<Patients, PatientsDTO>();
		}
	}
}

