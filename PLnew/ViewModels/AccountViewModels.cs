using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PLnew.ViewModels;

namespace PLnew.Models
{
    
    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Username can not be empty")]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password can not be empty")]
        public string Password { get; set; }

     
    }

    public class RegistrationViewModel
    {
       
        [Required(ErrorMessage = "The 'name' are required!")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The name must be from 1 to 20 characters")]
        [RegularExpression("[A-Z a-z]{2,20}$", ErrorMessage = "The name must consist of uppercase and lowercase letters of the English alphabet")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The 'surname' are required!")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The surname must be from 1 to 20 characters")]
        [RegularExpression("[A-Z a-z]{2,20}$", ErrorMessage = "The surname must consist of uppercase and lowercase letters of the English alphabet")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "The 'phone' required field!")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Telephone number must consist of 12 digits")]
        [RegularExpression("[0-9.+]{12,14}$", ErrorMessage = "Phone number must start with a + and consist of numbers")]
        public string MNumber { get; set; }

        [Required(ErrorMessage = "Email can not be empty")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Email may not be the size of")]
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,20}", ErrorMessage = "Mistyped address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Username can not be empty")]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password can not be empty")]
        public string Password { get; set; }

    }
    public class PersonViewModel
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "The 'name' are required!")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The name must be from 1 to 20 characters")]
        [RegularExpression("[A-Z a-z]{2,20}$", ErrorMessage = "The name must consist of uppercase and lowercase letters of the English alphabet")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The 'surname' are required!")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The surname must be from 1 to 20 characters")]
        [RegularExpression("[A-Z a-z]{2,20}$", ErrorMessage = "The surname must consist of uppercase and lowercase letters of the English alphabet")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "The 'phone' required field!")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Telephone number must consist of 12 digits")]
        [RegularExpression("[0-9.+]{12,14}$", ErrorMessage = "Phone number must start with a + and consist of numbers")]
        public string MNumber { get; set; }

        [Required(ErrorMessage = "Email can not be empty")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Email may not be the size of")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Username can not be empty")]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password can not be empty")]
        public string Password { get; set; }

        public int IdRole { get; set; }

        public int CountREcord { get; set; }
        public IEnumerable<int> ListFriendId { get; set; }
        
    }
}
