using System.ComponentModel.DataAnnotations;

namespace ParentChildrenApp.Models
{
    public class ParentRegistrationModel
    {
        [Required, MaxLength(50)]
        public string Username
        {
            get;
            set;
        }
        [Required, DataType(DataType.EmailAddress)]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage ="Email ID is invalid")]
        public string Email
        {
            get;
            set;
        }
        [Required, DataType(DataType.Password)]
        public string Password
        {
            get;
            set;
        }
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword
        {
            get;
            set;
        }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required,DataType(DataType.PhoneNumber)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "MobNo must be numeric")]
        public string MobNo { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "EmiratesID must be numeric")]
        public string EmiratesID { get; set; }
    }
}
