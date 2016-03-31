namespace OneBitTask.Api.Models
{
    using System.ComponentModel.DataAnnotations;
    using OneBitTask.Models;

    public class CreateContactRequestModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        public bool Sex { get; set; }

        [MaxLength(30)]
        public string Telephone { get; set; }

        [Url(ErrorMessage = "Please enter a valid url")]
        public string PhotoUrl { get; set; }

        [Required]
        public Status Status { get; set; }
    }
}