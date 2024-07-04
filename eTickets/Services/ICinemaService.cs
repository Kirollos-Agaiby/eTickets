using eTickets.Models;

namespace eTickets.Services
{
    public interface ICinemaService
    {
        List<Cinema> GetAll();
        Cinema GitById(int id);
        void Insert(Cinema newCinema);
        void Update(int id, Cinema newCinema);
        void Delete(int id);
    }
}
