using AutoMapper;
using MySchool.Models.DTOs.REQUEST;
using MySchool.Models.DTOs.RESPONSE;
using MySchool.Models.Entities;

namespace MySchoolApp.Profiles
{
    // Contains profiles for mapping models to data transfer objects (DTOs) and vice versa
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegRequestDTO, User>();

            CreateMap<User, LoginResponseDTO>();
            /*.ForMember(dest => dest.Name, option => option.MapFrom(src =>
                        $"{src.FirstName} {src.LastName}"));*/

            CreateMap<User, GetUserDTO>();
                /*.ForMember(dest => dest.Name, option => option.MapFrom(src =>
                            $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Address,
                            option => option.MapFrom(src => $"{src.StreetAddress}, {src.City}, {src.State}."))
                .ForMember(dest => dest.DateOfBirth,
                            option => option.MapFrom(src => src.DateOfBirth.ToShortDateString()));*/
            CreateMap<Subject, SchoolCreateDto>().ReverseMap();
            CreateMap<Student, StudentCreateDto>().ReverseMap();
            CreateMap<Teacher, TeacherCreateDto>().ReverseMap();
            CreateMap<Subject, SchoolUpdateDto>().ReverseMap();
            CreateMap<Student, StudentUpdateDto>().ReverseMap();
            CreateMap<Teacher, TeacherUpdateDto>().ReverseMap();
            CreateMap<Class, UpdateClassDto>().ReverseMap();
            CreateMap<Class, CreateClassDto>().ReverseMap();
            CreateMap<Subject, CreateSubjectDto>().ReverseMap();
            CreateMap<Subject, UpdateSubjectDto>().ReverseMap();
            CreateMap<Topic, UpdateTopicDto>().ReverseMap();
            CreateMap<Topic, CreateTopicDto>().ReverseMap();

        }
    }
}
