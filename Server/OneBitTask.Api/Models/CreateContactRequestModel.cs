namespace OneBitTask.Api.Models
{
    using System.ComponentModel.DataAnnotations;
    using OneBitTask.Models;

    public class CreateContactRequestModel
    {
        [Required(ErrorMessage = "Please enter First Name between 2 and 20 symbols!")]
        [MinLength(2)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name between 2 and 20 symbols!")]
        [MinLength(2)]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please choose a sex!")]
        public bool Sex { get; set; }

        [MaxLength(30)]
        public string Telephone { get; set; }

        [Url(ErrorMessage = "Please enter a valid url!")]
        public string PhotoUrl { get; set; }

        [Required(ErrorMessage = "Please chose a status!")]
        public Status Status { get; set; }
    }
}