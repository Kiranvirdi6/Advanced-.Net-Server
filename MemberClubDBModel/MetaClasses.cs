using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberClubDBModel
{
    public class MemberMeta
    {
        [Display(Name = "Member First Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 10, ErrorMessage = "{0} must be between {2} to {1} characters long.", MinimumLength = 1)]
        public string FirstName { get; set; }

        [Display(Name = "Member Last Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: 10, ErrorMessage = "{0} must be between {2} to {1} characters long.", MinimumLength = 1)]
        public string LastName { get; set; }

    }
    public class GameMeta
    {
        [Display(Name = "Game Name")]
        [Required(ErrorMessage = "{0} is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Range(minimum: 1, maximum: 10, ErrorMessage = "{0} must be between {2} to {1}")]
        public string Rating { get; set; }
    }

}
