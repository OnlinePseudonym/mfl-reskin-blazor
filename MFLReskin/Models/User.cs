using System;
using System.ComponentModel.DataAnnotations;

namespace MFLReskin.Models
{
    public class User
    {
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string LeagueId { get; set; }
        public string UserId { get; set; }
        public string Year { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime LastDatabasePull { get; set; }
    }
}
