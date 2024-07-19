using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrimonialModel_Layer.Model
{
    public class NewRegistrationModel
    {
        [Key]
        public Guid ProfileId { get; set; }
        [MaxLength(80)]
        public string Location { get; set; }
        public string Religion { get; set; }
        public int Age { get; set; }
        [MaxLength(100)]
        public string MaritalStatus { get; set; }
        public string Height { get; set; }
        public string Caste { get; set; }
        public string Complexion { get; set; }
        public Guid SubCasteId { get; set; }
        public string HomeLocation { get; set; }
        public Guid GotraId { get; set; }
        public Guid DistrictId { get; set; }
        public Guid QualificationId { get; set; }
        public Guid StateId { get; set; }
        public Guid ProfessionId { get; set; }
        public Guid CountryId { get; set; }

        public bool Status { get; set; } = true;
        [MaxLength(50)]
        public string? CreatedBY { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [MaxLength(50)]
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        public ICollection<MultipleImageProfile> multipleImageProfiles { get; set; } = new List<MultipleImageProfile>();
    }
}
