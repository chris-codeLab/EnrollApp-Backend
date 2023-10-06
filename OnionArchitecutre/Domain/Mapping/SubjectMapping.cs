using System;
using AutoMapper;
using Contracts;

using Domain.Entities;

    namespace Domain.Mapping
    {
        public class MapperConfig:Profile
        {
            public static IMapper InitializeAutoMapper()
            {
                //Provide all the Mapping Configuration
                var config = new MapperConfiguration(cfg =>
                {
                    //Configuring Subject and EmployeeDTO
                    cfg.CreateMap<Subject, SubjectDto>()
                    //Provide Mapping Configuration of FullName and Name Property
                       .ForMember(dest => dest.Title, act => act.MapFrom(src => src.Title))
                    
                    //Provide Mapping Dept of FullName and Department Property
                        .ForMember(dest => dest.Credits, act => act.MapFrom(src => src.Credits));
                     
                     cfg.CreateMap<Subject, SubjectForUpdateDto>();
                     cfg.CreateMap<Subject, SubjectForCreationDto>();

                    //Any Other Mapping Configuration ....
                });
                var mapper = new Mapper(config);
                return mapper;
            }
        }
    }