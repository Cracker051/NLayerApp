﻿using System.Linq;
using NLayerApp.DAL.Data;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace NLayerApp.DAL.Repository
{
    public class PatientRepository:IPatientRepository
    {
        private readonly DataContext _context;
        public PatientRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Patients> GetPatients()
        {
            return _context.Patients.OrderBy(p=>p.Id).Include(p=> p.Doctor).ToList();
        }
        public Patients GetPatientById(int id)
        {
            return _context.Patients.Include(p => p.Doctor).Where(p => p.Id == id).FirstOrDefault();
        }
        public bool PatientExist(int id)
        {
            return _context.Patients.Any(p => p.Id == id);
        }
        public ICollection<Patients> GetPatientsBySurname(string name)
        {
            return _context.Patients.Include(p => p.Doctor).Where(p => p.surname==name).ToList();
        }
        public ICollection<Patients> GetPatientsByDiagnosis(string diagnosis)
        {
            return _context.Patients.Include(p => p.Doctor).Where(p => p.Diagnosis == diagnosis).ToList();
        }
    }
}