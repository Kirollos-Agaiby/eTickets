using eTickets.Models;

namespace eTickets.Services
{
    public interface ICinemaService
    {
        public List<Cinema> GetAll();
        public Cinema GetById(int id);
        public void Insert(Cinema newCinema);
        public void Update(int id, Cinema newCinema);
        public void Delete(int id);
    }
}
