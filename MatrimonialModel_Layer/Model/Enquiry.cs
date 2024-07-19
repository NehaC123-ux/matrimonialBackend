using System.ComponentModel.DataAnnotations;

namespace MatrimonialModel_Layer.Model
{
    public class Enquiry
    {
        [Key]
        public Guid EnquiryId { get; set; }
        [MaxLength(100)]
        public string EnquiryName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string EnquiryFor { get; set; }
        public bool Status { get; set; }
        [MaxLength(50)]
        public string? CreatedBY { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [MaxLength(50)]
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
    }
}
