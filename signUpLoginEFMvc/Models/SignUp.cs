using System.ComponentModel.DataAnnotations;

namespace signUpLoginEFMvc.Models
{
    public class SignUp
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

       [DataType(DataType.Password)]
       [Compare("Password",ErrorMessage ="Password is not matched")]
        public string ConfirmPassword { get; set; }

    }
}