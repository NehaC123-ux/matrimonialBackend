using MatrimonialModel_Layer.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatrimonialModel_Layer.DTO
{
    public class GotraDto
    {
        public Guid GotraId { get; set; }
        [MaxLength(100)]
        public string GotraName { get; set; }
        [ForeignKey("SubCasteId")]
        public Guid SubCasteId { get; set; }
        [MaxLength(100)]
        public SubCasteMaster? SubCasteMaster { get; set; }

        public bool Status { get; set; }
        [MaxLength(50)]
        public string? CreatedBY { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [MaxLength(50)]
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
    }
}
