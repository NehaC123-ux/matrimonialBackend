using System.ComponentModel.DataAnnotations;

namespace MatrimonialModel_Layer.DTO
{
    public class QualificationDto
    {
        public Guid QualificationId { get; set; }
        [MaxLength(100)]
        public string QualificationName { get; set; }

        public bool Status { get; set; }
        [MaxLength(50)]
        public string? CreatedBY { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [MaxLength(50)]
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
    }
}
