using System.ComponentModel.DataAnnotations;

namespace MatrimonialModel_Layer.Model
{
    public class SubCasteMaster
    {
        [Key]
        public Guid SubCasteId { get; set; }
        [MaxLength(100)]
        public string SubCasteName { get; set; }

        public bool Status { get; set; }
        [MaxLength(50)]
        public string? CreatedBY { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [MaxLength(50)]
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        public ICollection<GotraMaster> GotraMasters { get; set; } = new List<GotraMaster>();
    }
}
