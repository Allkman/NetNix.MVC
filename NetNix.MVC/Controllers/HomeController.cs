using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetNix.MVC.Models;
using NetNix.MVC.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NetNix.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;

        public HomeController(ILogger<HomeController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieViewModel>>> Index()
        {
            var upcompingMovies = await DisplayMovies();
            return View(upcompingMovies);
        }
        [HttpGet]
        public async Task<ActionResult<MovieViewModel>> Movie(Guid id)
        {
            var movie = await GetMovie(id);
            return View(movie);
        }
        [HttpGet]
        public async Task<ActionResult<DirectorViewModel>> Director(Guid id)
        {
            var director = await GetDirector(id);
            return View(director);
        }
        [HttpPost]
        public async Task<ActionResult<LikeBodyViewModel>> Like([FromBody] LikeBodyViewModel like)
        {
            if (like == null)
            {
                return BadRequest();
            }
            await _movieService.PostLike(like);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<LikesViewModel>> Likes(Guid id)
        {
            var like = await GetLike(id);
            return View(like);
        }
        private async Task<LikesViewModel> GetLike(Guid id)
        {
            try
            {
                var like = await _movieService.GetLike(id);
                return like;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //i used null here if value can be missing and/or present and both are valide for application logic
                return null;
            }
        }
        private async Task<DirectorViewModel> GetDirector(Guid id)
        {
            try
            {
                var director = await _movieService.GetDirector(id);
                return director;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //i used null here if value can be missing and/or present and both are valide for application logic
                return null;
            }
        }
        private async Task<MovieViewModel> GetMovie(Guid id)
        {
            try
            {
                var movie = await _movieService.GetMovie(id);
                return movie;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //i used null here if value can be missing and/or present and both are valide for application logic
                return null;
            }
        }
        private async Task<IEnumerable<MovieViewModel>> DisplayMovies()
        {
            try
            {
                var upcomingMovies = await _movieService.GetMoviesCollection();
                return upcomingMovies;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Enumerable.Empty<MovieViewModel>();
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
