using eTickets.Models;

namespace eTickets.Services
{
    public interface ICinemaRepository
    {
        List<Cinema> GetAll();
        Cinema GetById(int id);
        void Insert(Cinema newCinema);
        void Update(int id, Cinema newCinema);
        void Delete(int id);
    }
}
