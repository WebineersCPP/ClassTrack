using System.ComponentModel.DataAnnotations;

namespace ClassTrack.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        // TODO: Specify validation attributes
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

	    [EmailAddress]
        public string Email { get; set; }
    }
}
