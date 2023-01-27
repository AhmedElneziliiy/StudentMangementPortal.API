using FluentValidation;
using StudentMangementPortal.API.Domain.Models;
using StudentMangementPortal.API.Repository;

namespace StudentMangementPortal.API.Validators
{
    public class UpdateStudentRequestValidator:AbstractValidator<UpdateStudentRequest>
    {
        public UpdateStudentRequestValidator(IStudentRepository studentRepository)
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.PhysicalAddress).NotEmpty();
            RuleFor(x => x.PostalAddress).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.Mobile).GreaterThan(99999).LessThan(100000000000);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.GenderId).NotEmpty().Must(id =>
            {
                var gender = studentRepository.GetGendersAsync().Result.ToList().FirstOrDefault(x => x.Id == id);

                if (gender is not null)
                {
                    return true;
                }
                return false;
            }).WithMessage("please insert valid gender");
        }
    }
}
