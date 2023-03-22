using AutoMapper;
using backend.src.DTOs;
using backend.src.Models;

namespace backend.src.Helpers
{
    public class AutoMappingConfig
    {
        public static IMapper RegisterMapping()
        {
            var config = new MapperConfiguration(conf =>
            {
                conf.CreateMap<UserCreateDTO, User>()
                    .ForMember(
                        dest => dest.Password, opt =>
                            opt.MapFrom(src => new StringToByteArrayConverter()
                                .Convert(src.Password, null!, null!)));

                conf.CreateMap<User, UserReadDTO>();
            });

            return config.CreateMapper();
        }
          
    }
}
