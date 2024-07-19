using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatrimonialModel_Layer.Model
{
    public class MultipleImageProfile
    {
       // public object NewRegistrationModel;

        [Key]
        public Guid Userid { get; set; }
        [ForeignKey("ProfileId")]
        public Guid ProfileId { get; set; }
        public NewRegistrationModel? newRegistrationModel { get; set; }
        public string ProfileName { get; set; }
        public string ProfileName1 { get; set; }
        public string ProfileName2 { get; set; }
    }
}
