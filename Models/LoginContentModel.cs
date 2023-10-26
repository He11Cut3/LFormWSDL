using System.ComponentModel.DataAnnotations;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;

namespace LForm.Models
{
    public class LoginContentModel
    {
        [Required]
        [StringLength(30)]
        public string UserName { get; set; }

        [Required]
        [StringLength(30)]
        public string Password { get; set; }
    }
}
