using AutoMapper;
using StudentMangementPortal.API.Data.Models;
using StudentMangementPortal.API.Domain.Models;


namespace StudentAdminPortal.API.Profiles.AfterMaps
{
    public class UpdateStudentRequestAfterMap : IMappingAction<UpdateStudentRequest, Student>
    {
        public void Process(UpdateStudentRequest source, Student destination, ResolutionContext context)
        {
            destination.Address = new Address()
            {
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
        }
    }
}