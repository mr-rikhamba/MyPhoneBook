using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Models
{
    public class EntryOutputModel: EntryInputModel
    {
        public int EntryId { get; set; }
        public PhoneBookOutputModel PhoneBook { get; set; }
    }

    public class EntryInputModel
    {
        [Required(ErrorMessage = "Please enter a valid name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a valid phone number.")]
        public string PhoneNumber { get; set; }

        [Required]
        public int PhoneBookId { get; set; }
    }
}
