namespace StudentMangementPortal.API.Data.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }

        //nav prop
        public Guid StudentId { get; set; }
    }
}
