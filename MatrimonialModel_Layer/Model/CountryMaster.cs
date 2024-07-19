using System.ComponentModel.DataAnnotations;

namespace MatrimonialModel_Layer.Model
{
    public class CountryMaster
    {
        [Key]
        public Guid CountryId { get; set; }
        [MaxLength(50)]
        public string CountryName { get; set; }

        public bool Status { get; set; } = true;
        [MaxLength(50)]
        public string? CreatedBY { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [MaxLength(50)]
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        public ICollection<StateMaster> StateMasters { get; set; } = new List<StateMaster>();
    }
}
