using LForm.ViewModels;
using System.ComponentModel.DataAnnotations;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;

namespace LForm.Models
{
    public class AccountContentModel
    {
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(120)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(120)]
        public string LastName { get; set; }

        [Required]
        [StringLength(25)]
        public string Mobile { get; set; }

        [Required]
        public int Country { get; set; }
    }
}
