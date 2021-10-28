using AutoMapper;
using NetNix.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetNix.MVC.AutoMapper
{
    public class MovieMapperProfile : Profile
    {
        public MovieMapperProfile()
        {
            //CreateMap<MovieViewModel, UpcomingMoviesViewModel>().ReverseMap();
        }
    }
}
