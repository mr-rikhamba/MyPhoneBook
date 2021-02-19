using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Models
{
    public class PhoneBookOutputModel: PhoneBookInputModel
    {
        public int PhoneBookId { get; set; }
    }
    public class PhoneBookInputModel
    {
        [Required(ErrorMessage = "Please enter a valid name.")]
        public string Name { get; set; }
        public int EntriesCount { get; set; }
    }
}
