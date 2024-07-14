using eTickets.Data;

namespace eTickets.Services
{
    public interface IMovieCategoryService
    {
        public IEnumerable<MovieCategory> GetAllMovieCategory();
    }
}
