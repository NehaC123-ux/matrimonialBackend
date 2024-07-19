using System.ComponentModel.DataAnnotations.Schema;

namespace MatrimonialModel_Layer.DTO
{
    public class MultipleImageProfileDto
    {
        public Guid Userid { get; set; }

        public string ProfileName { get; set; }
        [ForeignKey("ProfileId")]
        public Guid ProfileId { get; set; }
        public string ProfileName1 { get; set; }
        public string ProfileName2 { get; set; }
    }
}
