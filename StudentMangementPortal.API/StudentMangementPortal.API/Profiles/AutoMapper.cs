using AutoMapper;
using StudentAdminPortal.API.Profiles.AfterMaps;
using StudentMangementPortal.API.Data.Models;
using StudentMangementPortal.API.Domain.Models;

namespace StudentMangementPortal.API.Profiles
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Gender, GenderDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<UpdateStudentRequest, Student>()
                .AfterMap<UpdateStudentRequestAfterMap>();
                ;
        }
    }
}
