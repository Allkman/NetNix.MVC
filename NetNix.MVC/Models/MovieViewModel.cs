using System;

namespace NetNix.MVC.Models
{
    public class MovieViewModel
    {
        private string _image= "https://m.media-amazon.com/images/M/MV5BYzE5MjY1ZDgtMTkyNC00MTMyLThhMjAtZGI5OTE1NzFlZGJjXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_FMjpg_UY720_.jpg";

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Image { get => _image; set => _image = value; }
        public DirectorViewModel Director { get; set; }
    }

}
