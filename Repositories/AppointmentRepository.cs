using Microsoft.EntityFrameworkCore;
using PaulaPachecoHairStyle.Context;
using PaulaPachecoHairStyle.Models;
using PaulaPachecoHairStyle.Repositories.Interfaces;

namespace PaulaPachecoHairStyle.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _context.Appointments.Include(a => a.Procedure).ToList();

        }

        public Appointment GetById(int id)
        {
            return _context.Appointments.Include(a => a.Procedure).FirstOrDefault(a => a.Id == id);
        }

        public void Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public bool IsTimeAvailable(DateTime dateTime)
        {
            return !_context.Appointments.Any(a => a.AppointmentDate == dateTime);
        }

        public IEnumerable<Procedure> GetAllProcedures()
        {
            return _context.Procedures.ToList();
        }
    }

}

