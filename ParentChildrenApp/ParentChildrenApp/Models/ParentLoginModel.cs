using System.ComponentModel.DataAnnotations;

namespace ParentChildrenApp.Models
{
    public class ParentLoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public int id { get; set; }
    }
}
