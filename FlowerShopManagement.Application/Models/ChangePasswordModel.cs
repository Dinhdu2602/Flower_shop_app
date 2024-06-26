<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;

namespace FlowerShopManagement.Application.Models
{
    public class ChangePasswordModel
    {
        public string OldPassword { get; set; } = string.Empty;

        [Required]
        [MinLength(6, ErrorMessage = "Password have to be greater than 6 characters")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Password format invalid")]
        public string NewPassword { get; set; } = string.Empty;

        [Required]
        [Compare(nameof(NewPassword), ErrorMessage = "Passwords don't match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
	}
}
=======
﻿using System.ComponentModel.DataAnnotations;

namespace FlowerShopManagement.Application.Models
{
    public class ChangePasswordModel
    {
        public string OldPassword { get; set; } = string.Empty;

        [Required]
        [MinLength(6, ErrorMessage = "Password have to be greater than 6 characters")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Password format invalid")]
        public string NewPassword { get; set; } = string.Empty;

        [Required]
        [Compare(nameof(NewPassword), ErrorMessage = "Passwords don't match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
	}
}
>>>>>>> 24db0d200fe76027e4b8f2c691699d480217e22a
