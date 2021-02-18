using System;
namespace PhoneBook.Models
{
    public class PhoneBookOutputModel: PhoneBookInputModel
    {
        public int PhoneBookId { get; set; }
    }
    public class PhoneBookInputModel
    {
        public string Name { get; set; }
    }
}
