namespace OneBitTask.Api.Models
{
    using System.ComponentModel.DataAnnotations;
    using OneBitTask.Models;

    public class UpdateContactRequestModel
    {
        [Required]
        public int Id { get; set; }

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

        public string PhotoUrl { get; set; }

        public Status Status { get; set; }
    }
}