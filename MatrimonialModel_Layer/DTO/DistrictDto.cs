using MatrimonialModel_Layer.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatrimonialModel_Layer.DTO
{
    public class DistrictDto
    {
        public Guid DistrictId { get; set; }
        [MaxLength(50)]
        public string DistrictName { get; set; }
        [ForeignKey("StateId")]
        public Guid StateId { get; set; }
        public StateMaster? StateMaster { get; set; }
        public bool Status { get; set; } = true;
        [MaxLength(50)]
        public string? CreatedBY { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [MaxLength(50)]
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
    }
}
