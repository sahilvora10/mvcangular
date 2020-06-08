using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace MVCAngular.AutoMappers
{
    public class WeatherProfile: AutoMapper.Profile
    {
        public WeatherProfile()
        {
            CreateMap<DBContexts.WeatherForecast, Models.WeatherForecast>()
                .ReverseMap();
        }
    }
}
