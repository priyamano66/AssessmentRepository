using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ParentChildrenApp.Models
{
    public class ChildModel
    {
        public int Id { get; set; }
        public int ParentId { get; set; }

        [Required]
        public int NoOfChild { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Age { get; set; }
        public string Photo { get; set; }

		public IFormFile Image { get; set; }
    
}
}
