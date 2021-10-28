using NetNix.MVC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetNix.MVC.Services
{
    public interface IMovieService
    {
        Task<DirectorViewModel> GetDirector(Guid id);
        Task<LikesViewModel> GetLike(Guid id);
        Task<MovieViewModel> GetMovie(Guid id);
        Task<IEnumerable<MovieViewModel>> GetMoviesCollection();
        Task<LikeBodyViewModel> PostLike(LikeBodyViewModel resourseToCreate);
    }
}
