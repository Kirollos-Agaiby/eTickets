using eTickets.Data;

namespace eTickets.Services
{
    public class MovieCategoryService : IMovieCategoryService
    {
        public IEnumerable<MovieCategory> GetAllMovieCategory()
        {
            var list = Enum.GetValues(typeof(MovieCategory));
            return (IEnumerable<MovieCategory>)list;
        }
    }
}
