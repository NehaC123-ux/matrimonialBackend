using System.ComponentModel.DataAnnotations;

namespace MatrimonialModel_Layer.Model
{
    public class ProfessionMaster
    {
        [Key]
        public Guid ProfessionId { get; set; }
        [MaxLength(100)]
        public string ProfessionName { get; set; }

        public bool Status { get; set; }
        [MaxLength(50)]
        public string? CreatedBY { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [MaxLength(50)]
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
    }
}
