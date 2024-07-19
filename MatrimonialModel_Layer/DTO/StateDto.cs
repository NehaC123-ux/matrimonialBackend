using MatrimonialModel_Layer.Model;
using System.ComponentModel.DataAnnotations;

namespace MatrimonialModel_Layer.DTO
{
    public class StateDto
    {
        public Guid StateId { get; set; }
        [MaxLength(50)]
        public string StateName { get; set; }

        public Guid CountryId { get; set; }
        public CountryMaster? CountryMaster { get; set; }
        public bool Status { get; set; } = true;
        [MaxLength(50)]
        public string? CreatedBY { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [MaxLength(50)]
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        public ICollection<DistrictMaster> DistrictMasters { get; set; } = new List<DistrictMaster>();
    }
}
