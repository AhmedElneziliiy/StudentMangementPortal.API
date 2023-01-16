namespace StudentMangementPortal.API.Domain.Models
{
    public class AddressDto
    {
        public Guid Id { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }

        //nav prop
        public Guid StudentId { get; set; }
    }
}
