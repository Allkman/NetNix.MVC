using AutoMapper;
using NetNix.MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetNix.MVC.Services
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://virtserver.swaggerhub.com/BartvdPost/NetNix/0.2.0";
        private IEnumerable<MovieViewModel> _movies;
        private LikesViewModel _like = new LikesViewModel() { MovieId = Guid.Parse("d290f1ee-6c54-4b01-90e6-d701748f0851"), Like = 12 };
        private MovieViewModel _movie;
        private DirectorViewModel _director;
        public MovieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<MovieViewModel>> GetMoviesCollection()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/soon/");

            if (response.IsSuccessStatusCode)
            {
                var responseString = response.Content.ReadAsStringAsync().Result;
                _movies = JsonConvert.DeserializeObject<IEnumerable<MovieViewModel>>(responseString);
            }
            
            return _movies;
        }
        public async Task<MovieViewModel> GetMovie(Guid id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/movie/{id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = response.Content.ReadAsStringAsync().Result;
                _movie = JsonConvert.DeserializeObject<MovieViewModel>(responseString);
            }
            return _movie;
        }
        public async Task<DirectorViewModel> GetDirector(Guid id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/director/{id}");
            if (response.IsSuccessStatusCode)
            {
                var responseString = response.Content.ReadAsStringAsync().Result;
                _director = JsonConvert.DeserializeObject<DirectorViewModel>(responseString);
            }
            return _director;
        }
        public async Task<LikeBodyViewModel> PostLike(LikeBodyViewModel resourseToCreate)
        {
            resourseToCreate = new LikeBodyViewModel() { 
                UserName = "Bartas Neijas", 
                MovieId = Guid.Parse("d290f1ee-6c54-4b01-90e6-d701748f0851") 
            };
            string json = JsonConvert.SerializeObject(resourseToCreate);
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
            var postLike = await _httpClient.PostAsync($"{_baseUrl}/like", data);

            if (postLike.IsSuccessStatusCode)
            {
                string result = await postLike.Content.ReadAsStringAsync();
                resourseToCreate = JsonConvert.DeserializeObject<LikeBodyViewModel>(result);
            }
            Console.WriteLine($"{resourseToCreate.UserName}");
            return resourseToCreate;
        }
        public async Task<LikesViewModel> GetLike(Guid id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/likes/{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseString = response.Content.ReadAsStringAsync().Result;
                _like = JsonConvert.DeserializeObject<LikesViewModel>(responseString);                
            }
            Console.WriteLine(_like);
            return _like;
        }
    }
}
