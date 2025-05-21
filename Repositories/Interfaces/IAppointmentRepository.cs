using PaulaPachecoHairStyle.Models;

namespace PaulaPachecoHairStyle.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAll();
        Appointment GetById(int id);
        void Add(Appointment appointment);
        bool IsTimeAvailable(DateTime dateTime);
        IEnumerable<Procedure> GetAllProcedures();
    }
}
