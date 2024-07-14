using eTickets.Data;

namespace eTickets.Services
{
    public interface IMovieCategoryRepository
    {
        public IEnumerable<MovieCategory> GetAllMovieCategory();
    }
}
