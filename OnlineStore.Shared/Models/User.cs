using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public class User
    {
        public required string UserId { get; set; }
        [Required(ErrorMessage ="User name is compulsory")]
        public required string UserName { get; set; }
        [Required(ErrorMessage ="Unique address is required")]
        [EmailAddress(ErrorMessage ="Invalid address")]
        public required string UserEmail { get; set; }

        [PasswordPropertyText][Required(ErrorMessage ="PassWord is required at any cost HeHeHe..😈")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        public required string UserPassword { get; set; }
        public DateTime DateTime { get; set; } //Id creation time
        public bool DidUserLogIn { get; set; } = false;
    }
}